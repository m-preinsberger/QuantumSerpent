namespace QuantumSerpent
{
    public static class CollisionHelper
    {
        public enum CollisionType
        {
            None,
            Self,
            OtherPlayer,
            Wall
        }

        public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            return rect1.IntersectsWith(rect2);
        }


        public static (CollisionType Type, string Message) CheckCollisions(Player player, List<Player> allPlayers, Size boardSize, List<Point> foodPositions, List<Point> obstacles)
        {
            Point headPosition = player.BodyParts[0];

            // Check wall collision
            if (headPosition.X < 0 || headPosition.X >= boardSize.Width || headPosition.Y < 0 || headPosition.Y >= boardSize.Height)
            {
                return (CollisionType.Wall, $"{player.Name} hit the wall!");
            }

            // Check self collision, skip the head when comparing
            for (int i = 1; i < player.BodyParts.Count; i++)
            {
                if (player.BodyParts[i] == headPosition)
                {
                    return (CollisionType.Self, $"{player.Name} collided with itself!");
                }
            }

            // Check collision with other players
            foreach (var otherPlayer in allPlayers)
            {
                if (otherPlayer != player)
                {
                    foreach (var part in otherPlayer.BodyParts)
                    {
                        if (part == headPosition)
                        {
                            return (CollisionType.OtherPlayer, $"{player.Name} collided with {otherPlayer.Name}!");
                        }
                    }
                }
            }

            return (CollisionType.None, string.Empty);
        }

        public static bool CheckFoodCollision(Point playerHead, Point foodPosition)
        {
            return playerHead == foodPosition;
        }
    }
}
