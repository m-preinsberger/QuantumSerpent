// File: Apple.cs
using System;
using System.Drawing;

namespace QuantumSerpent
{
    public class Apple : Food
    {
        // Constructor to initialize the position of the apple
        public Apple(Point position)
        {
            this.Position = position;
            this.Respawn = true;
        }

        // Implement the Draw method to draw the apple on the screen
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(Position.X, Position.Y, 20, 20));
        }   

        // Implement the EatEffect method to define the effect of eating the apple
        public override void EatEffect(Player player)
        {
            // Example effect: Add a new part to the player's body
            if (player.BodyParts.Count > 0)
            {
                // Add a new body part at the tail's position (just a placeholder logic)
                var tail = player.BodyParts[player.BodyParts.Count - 1];
                player.BodyParts.Add(new Point(tail.X - 20, tail.Y));
            }
        }
    }
}
