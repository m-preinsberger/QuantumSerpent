// File: AStarPathfinder.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuantumSerpent
{
    public class AStarPathfinder
    {
        // Node for A* pathfinding.
        private class Node
        {
            public Point Position { get; }
            public Node Parent { get; }
            public float G { get; } // Cost from start to node.
            public float H { get; } // Heuristic cost to goal.
            public float F => G + H; // Total cost.

            public Node(Point position, Node parent, float g, float h)
            {
                Position = position;
                Parent = parent;
                G = g;
                H = h;
            }
        }

        // Possible movement directions.
        private static readonly Point[] Directions =
        {
                new Point(0, -1), // Up
                new Point(0, 1),  // Down
                new Point(-1, 0), // Left
                new Point(1, 0)   // Right
            };

        // Heuristic calculation.
        public static float Heuristic(Point start, Point end)
        {
            return Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y);
        }

        // Checks if a position is walkable.
        private static bool IsWalkable(Point position, Size gameBoardSize, List<Point> obstacles)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < gameBoardSize.Width && position.Y < gameBoardSize.Height && !obstacles.Contains(position);
        }

        // Finds path from start to goal.
        public static List<Point> FindPath(Point start, Point goal, Size gameBoardSize, List<Point> obstacles)
        {
            var openList = new List<Node>();
            var closedList = new HashSet<Point>();
            openList.Add(new Node(start, null, 0, Heuristic(start, goal)));

            while (openList.Count > 0)
            {
                openList.Sort((a, b) => a.F.CompareTo(b.F));
                var currentNode = openList[0];
                openList.RemoveAt(0);

                if (currentNode.Position == goal)
                {
                    var path = new List<Point>();
                    while (currentNode != null)
                    {
                        path.Add(currentNode.Position);
                        currentNode = currentNode.Parent;
                    }
                    path.Reverse();
                    return path;
                }

                closedList.Add(currentNode.Position);

                foreach (var direction in Directions)
                {
                    var newPosition = new Point(currentNode.Position.X + direction.X, currentNode.Position.Y + direction.Y);
                    if (!closedList.Contains(newPosition) && IsWalkable(newPosition, gameBoardSize, obstacles))
                    {
                        var g = currentNode.G + 1;
                        var h = Heuristic(newPosition, goal);
                        if (!openList.Exists(node => node.Position == newPosition && node.G <= g))
                        {
                            openList.Add(new Node(newPosition, currentNode, g, h));
                        }
                    }
                }
            }

            return null; // No path found.
        }
    }
}
