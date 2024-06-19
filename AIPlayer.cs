// File: AIPlayer.cs
using System;
using System.Drawing;
using System.Collections.Generic;

namespace QuantumSerpent
{
    // AIPlayer extends Player to implement AI-controlled movement.
    public class AIPlayer : Player
    {
        private Random random; // Used for generating random decisions, if needed.
        private List<Point> currentPath; // Stores the current path to the target.
        private int pathIndex; // Index to track the current position in the path.

        // Constructor: Initializes AIPlayer with base player attributes and AI-specific fields.
        public AIPlayer(string name, Color headColor, Color bodyColor, Point startPosition, Direction startDirection, int initialLength)
            : base(name, headColor, bodyColor, startPosition, startDirection, initialLength)
        {
            random = new Random();
            currentPath = new List<Point>();
            pathIndex = 0;
        }

        // Determines and executes the next move based on the path to the closest food.
        public void MoveAI(Size gameBoardSize, List<Point> foodPositions, List<Point> obstacles)
        {
            // If there's no current path or the path is complete, find a new path to the closest food.
            if (currentPath == null || pathIndex >= currentPath.Count)
            {
                var target = SelectClosestFood(foodPositions);
                if (target != null)
                {
                    currentPath = AStarPathfinder.FindPath(BodyParts[0], target.Value, gameBoardSize, obstacles);
                    pathIndex = 0;
                }
            }

            // If there's a valid path, move towards the next point in the path.
            if (currentPath != null && pathIndex < currentPath.Count)
            {
                MoveTowards(currentPath[pathIndex]);
                pathIndex++;
            }
        }

        // Selects the closest food item based on the heuristic distance.
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

        // Sets the direction towards the target position and moves the AI player.
        private void MoveTowards(Point targetPosition)
        {
            var currentPos = BodyParts[0];

            // Determine the direction based on the target position relative to the current position.
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
            // Execute the move in the determined direction.
            Move(Direction);
        }
    }
}
