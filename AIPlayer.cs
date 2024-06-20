using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuantumSerpent
{
    // Define the WorldInfoFunction delegate in a public scope for accessibility.
    public delegate (IEnumerable<Point> avoid, IEnumerable<Food> food, int maxWidth, int maxHeight) WorldInfoFunction();

    public class AIPlayer : Player
    {
        public WorldInfoFunction GetWorldInfo { get; set; }

        private Random random;
        private List<Point> currentPath;
        private int pathIndex;

        public AIPlayer(string name, Color headColor, Color bodyColor, Point startPosition, Direction startDirection, int initialLength, WorldInfoFunction getWorldInfo)
            : base(name, headColor, bodyColor, startPosition, startDirection, initialLength)
        {
            GetWorldInfo = getWorldInfo;
            random = new Random();
            currentPath = new List<Point>();
            pathIndex = 0;
        }

        private Point? GetClosestFood(IEnumerable<Food> food, IEnumerable<Point> avoid)
        {
            var closest = food.OrderBy(f => Distance(f.Position, BodyParts[0])).FirstOrDefault(f => !avoid.Contains(f.Position));
            return closest?.Position;
        }

        public void MoveAI()
        {
            // Properly invoke the delegate
            var world = GetWorldInfo();
            Point? closestFood = GetClosestFood(world.food, world.avoid);

            if (closestFood == null)
            {
                // No food found, move to a random empty field
                var randomPosition = GetBestPath(world.avoid, world.maxWidth, world.maxHeight);
                if (randomPosition != null)
                {
                    var direction = GetDirection(BodyParts[0], randomPosition.Value);
                    Move(direction);
                }
            }
            else
            {
                // Move towards food using pathfinding
                var path = AStarAlgorithm(BodyParts[0], closestFood.Value, world.avoid, world.maxWidth, world.maxHeight);
                if (path.Count > 1)
                {
                    var nextPosition = path[1];
                    var direction = GetDirection(BodyParts[0], nextPosition);
                    Move(direction);
                }
            }
        }

        private Direction GetDirection(Point current, Point next)
        {
            if (next.X < current.X) return Direction.Left;
            if (next.X > current.X) return Direction.Right;
            if (next.Y < current.Y) return Direction.Up;
            return Direction.Down;
        }

        private List<Point> AStarAlgorithm(Point start, Point goal, IEnumerable<Point> avoid, int maxWidth, int maxHeight)
        {
            var openSet = new List<Point> { start };
            var cameFrom = new Dictionary<Point, Point>();
            var gScore = new Dictionary<Point, int> { [start] = 0 };
            var fScore = new Dictionary<Point, int> { [start] = Distance(start, goal) };

            while (openSet.Any())
            {
                var current = openSet.OrderBy(p => fScore.ContainsKey(p) ? fScore[p] : int.MaxValue).First();
                if (current == goal) return ReconstructPath(cameFrom, current);

                openSet.Remove(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (avoid.Contains(neighbor) || neighbor.X < 0 || neighbor.X >= maxWidth || neighbor.Y < 0 || neighbor.Y >= maxHeight)
                        continue;

                    var tentativeGScore = gScore[current] + 1;

                    if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + Distance(neighbor, goal);
                        if (!openSet.Contains(neighbor)) openSet.Add(neighbor);
                    }
                }
            }

            return new List<Point>();
        }

        private List<Point> ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
        {
            var path = new List<Point> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Insert(0, current);
            }
            return path;
        }

        private IEnumerable<Point> GetNeighbors(Point position)
        {
            return new List<Point>
            {
                new Point(position.X, position.Y - 1),
                new Point(position.X, position.Y + 1),
                new Point(position.X - 1, position.Y),
                new Point(position.X + 1, position.Y)
            };
        }

        private static int Distance(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        private Point? GetBestPath(IEnumerable<Point> avoid, int maxWidth, int maxHeight)
        {
            var emptyFields = GetEmptyFields(avoid, maxWidth, maxHeight);
            if (emptyFields.Count == 0) return null;

            return emptyFields[random.Next(emptyFields.Count)];
        }

        private List<Point> GetEmptyFields(IEnumerable<Point> avoid, int maxWidth, int maxHeight)
        {
            var emptyFields = new List<Point>();

            var potentialMoves = new List<Point>
            {
                new Point(BodyParts[0].X, BodyParts[0].Y - 1),
                new Point(BodyParts[0].X, BodyParts[0].Y + 1),
                new Point(BodyParts[0].X - 1, BodyParts[0].Y),
                new Point(BodyParts[0].X + 1, BodyParts[0].Y)
            };

            foreach (var move in potentialMoves)
            {
                if (!avoid.Contains(move) && move.X >= 0 && move.X < maxWidth && move.Y >= 0 && move.Y < maxHeight)
                {
                    emptyFields.Add(move);
                }
            }

            return emptyFields;
        }
    }
}
