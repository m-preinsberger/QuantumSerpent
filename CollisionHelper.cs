using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuantumSerpent
{
    public static class CollisionHelper
    {
        public enum CollisionType
        {
            None,
            Self,
            Player,
            Wall
        }

        public static CollisionResult CheckCollisions(Player player, List<Player> players, Size boardSize)
        {
            // Check collision with the board boundaries
            var head = player.BodyParts[0];
            if (head.X < 0 || head.Y < 0 || head.X >= boardSize.Width || head.Y >= boardSize.Height)
            {
                return new CollisionResult { Type = CollisionType.Wall, Message = $"{player.Name} hit the wall!" };
            }

            // Check for collision with self
            for (int i = 1; i < player.BodyParts.Count; i++)
            {
                if (player.BodyParts[i] == head)
                {
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
                            return new CollisionResult { Type = CollisionType.Player, Message = $"{player.Name} collided with {otherPlayer.Name}!" };
                        }
                    }
                }
            }

            return new CollisionResult { Type = CollisionType.None, Message = string.Empty };
        }


        public static bool CheckFoodCollision(Point playerHead, Point foodPosition)
        {
            return playerHead == foodPosition;
        }
    }

    public class CollisionResult
    {
        public CollisionHelper.CollisionType Type { get; set; }
        public string Message { get; set; }
    }
}
