using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public class Player
    {
        public string Name { get; set; }
        public List<Point> BodyParts { get; private set; }
        public Color HeadColor { get; set; }
        public Color BodyColor { get; set; }
        public Direction Direction { get; set; }

        public Player(string name, Color headColor, Color bodyColor, Point startPosition, Direction startDirection, int initialLength)
        {
            Name = name;
            HeadColor = headColor;
            BodyColor = bodyColor;
            Direction = startDirection;
            BodyParts = new List<Point>();

            for (int i = 0; i < initialLength; i++)
            {
                BodyParts.Add(new Point(startPosition.X - (i * 20), startPosition.Y));
            }
        }

        public virtual void Move(Direction direction)
        {
            for (int i = BodyParts.Count - 1; i > 0; i--)
            {
                BodyParts[i] = BodyParts[i - 1];
            }

            switch (direction)
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

        public void AddBodyPart()
        {
            BodyParts.Add(BodyParts[BodyParts.Count - 1]);
        }

        public void UpdateLastBodyPartPosition()
        {
            BodyParts[BodyParts.Count - 1] = BodyParts[BodyParts.Count - 2];
        }
    }
}
