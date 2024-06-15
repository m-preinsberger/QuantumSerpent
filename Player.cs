// File: Player.cs
using System.Collections.Generic;
using System.Drawing;

namespace QuantumSerpent
{
    public class Player
    {
        public string Name { get; set; }
        public Color HeadColor { get; set; }
        public Color BodyColor { get; set; }
        public List<Point> BodyParts { get; set; }
        public Direction Direction { get; set; }

        public Player(string name, Color headColor, Color bodyColor, Point initialPosition, Direction initialDirection, int initialLength)
        {
            Name = name;
            HeadColor = headColor;
            BodyColor = bodyColor;
            Direction = initialDirection;
            BodyParts = new List<Point>();

            // Initialize body parts, spaced out to avoid immediate self-collision
            for (int i = 0; i < initialLength; i++)
            {
                BodyParts.Add(new Point(initialPosition.X - i * 20, initialPosition.Y));
            }
        }

        public void AddBodyPart()
        {
            Point newPart = BodyParts[BodyParts.Count - 1];
            BodyParts.Add(newPart);
        }

        public void UpdateLastBodyPartPosition()
        {
            // Update the position of the last body part
            Point lastPart = BodyParts[BodyParts.Count - 1];
            BodyParts[BodyParts.Count - 1] = lastPart;
        }

        // Move the player in the current direction
        public void Move()
        {
            for (int i = BodyParts.Count - 1; i > 0; i--)
            {
                BodyParts[i] = BodyParts[i - 1];
            }

            switch (Direction)
            {
                case Direction.Up:
                    BodyParts[0] = new Point(BodyParts[0].X, BodyParts[0].Y - 20);
                    break;
                case Direction.Down:
                    BodyParts[0] = new Point(BodyParts[0].X, BodyParts[0].Y + 20);
                    break;
                case Direction.Left:
                    BodyParts[0] = new Point(BodyParts[0].X - 20, BodyParts[0].Y);
                    break;
                case Direction.Right:
                    BodyParts[0] = new Point(BodyParts[0].X + 20, BodyParts[0].Y);
                    break;
            }
        }
    }
}
