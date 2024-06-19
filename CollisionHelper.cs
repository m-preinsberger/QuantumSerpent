using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuantumSerpent
{
    // Defines a helper class for collision detection in the game.
    public static class CollisionHelper
    {
        // Enum to represent the type of collision that occurred.
        public enum CollisionType
        {
            None, // No collision.
            Self, // Collision with oneself (not used, should be Player for self-collision).
            Player, // Collision with another player or oneself.
            Wall // Collision with the game board boundaries.
        }

        // Checks for collisions between a player and walls, themselves, or other players.
        public static CollisionResult CheckCollisions(Player player, List<Player> players, Size boardSize)
        {
            // Check collision with the board boundaries
            var head = player.BodyParts[0]; // The head of the player.
            if (head.X < 0 || head.Y < 0 || head.X >= boardSize.Width || head.Y >= boardSize.Height)
            {
                // If the player's head is outside the board boundaries, return a wall collision result.
                return new CollisionResult { Type = CollisionType.Wall, Message = $"{player.Name} hit the wall!" };
            }

            // Check for collision with self
            for (int i = 1; i < player.BodyParts.Count; i++)
            {
                if (player.BodyParts[i] == head)
                {
                    // If any of the player's body parts collide with their head, return a self-collision result.
                    return new CollisionResult { Type = CollisionType.Player, Message = $"{player.Name} collided with itself!" };
                }
            }

            // Check collision with other players
            foreach (var otherPlayer in players)
            {
                if (otherPlayer != player)
                {
                    foreach (var part in otherPlayer.BodyParts)
                    {
                        if (part == head)
                        {
                            // If the player's head collides with any part of another player, return a player collision result.
                            return new CollisionResult { Type = CollisionType.Player, Message = $"{player.Name} collided with {otherPlayer.Name}!" };
                        }
                    }
                }
            }

            // If no collisions are detected, return a result indicating no collision.
            return new CollisionResult { Type = CollisionType.None, Message = string.Empty };
        }

        // Checks if the player's head has collided with a food item.
        public static bool CheckFoodCollision(Point playerHead, Point foodPosition)
        {
            // Returns true if the player's head is at the same position as the food item.
            return playerHead == foodPosition;
        }
    }

    // Represents the result of a collision check, including the type of collision and a message.
    public class CollisionResult
    {
        public CollisionHelper.CollisionType Type { get; set; } // The type of collision that occurred.
        public string Message { get; set; } // A message describing the collision.
    }
}
