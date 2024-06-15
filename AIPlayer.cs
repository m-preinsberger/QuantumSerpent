// File: AIPlayer.cs
using System;
using System.Drawing;
using System.Collections.Generic;

namespace QuantumSerpent
{
    public class AIPlayer : Player
    {
        private Random random;
        private List<Point> currentPath;
        private int pathIndex;

        public AIPlayer(string name, Color headColor, Color bodyColor, Point startPosition, Direction startDirection, int initialLength)
            : base(name, headColor, bodyColor, startPosition, startDirection, initialLength)
        {
            random = new Random();
            currentPath = new List<Point>();
            pathIndex = 0;
        }

        public void MoveAI(Size gameBoardSize, List<Point> foodPositions, List<Point> obstacles)
        {
            if (currentPath == null || pathIndex >= currentPath.Count)
            {
                var target = SelectClosestFood(foodPositions);
                if (target != null)
                {
                    currentPath = AStarPathfinder.FindPath(BodyParts[0], target.Value, gameBoardSize, obstacles);
                    pathIndex = 0;
                }
            }

            if (currentPath != null && pathIndex < currentPath.Count)
            {
                MoveTowards(currentPath[pathIndex]);
                pathIndex++;
            }
        }

        private Point? SelectClosestFood(List<Point> foodPositions)
        {
            Point? closestFood = null;
            float minDistance = float.MaxValue;

            foreach (var food in foodPositions)
            {
                float distance = AStarPathfinder.Heuristic(BodyParts[0], food);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestFood = food;
                }
            }

            return closestFood;
        }

        private void MoveTowards(Point targetPosition)
        {
            var currentPos = BodyParts[0];

            if (targetPosition.X < currentPos.X)
            {
                Direction = Direction.Left;
            }
            else if (targetPosition.X > currentPos.X)
            {
                Direction = Direction.Right;
            }
            else if (targetPosition.Y < currentPos.Y)
            {
                Direction = Direction.Up;
            }
            else if (targetPosition.Y > currentPos.Y)
            {
                Direction = Direction.Down;
            }

            // Move player in the current direction
            Move();
        }
    }
}
