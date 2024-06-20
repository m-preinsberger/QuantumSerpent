using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuantumSerpent
{
    // Defines the Player class representing each player in the game.
    public class Player
    {
        // Properties for player's name, body parts, colors, and movement direction.
        public string Name { get; set; }
        public List<Point> BodyParts { get; private set; } // Stores the positions of the player's body parts.
        public Color HeadColor { get; set; } // Color of the player's head.
        public Color BodyColor { get; set; } // Color of the player's body.
        public Direction Direction { get; set; } // Current movement direction of the player.

        // Constructor to initialize a new player with specified attributes.
        public Player(string name, Color headColor, Color bodyColor, Point startPosition, Direction startDirection, int initialLength)
        {
            Name = name; // Player's name.
            HeadColor = headColor; // Color of the player's head.
            BodyColor = bodyColor; // Color of the player's body.
            Direction = startDirection; // Initial movement direction.
            BodyParts = new List<Point>(); // Initialize the list of body parts.

            // Initialize the player's body parts based on the starting position and initial length.
            for (int i = 0; i < initialLength; i++)
            {
                // Add body parts behind the starting position based on the initial length.
                BodyParts.Add(new Point(startPosition.X - (i * 20), startPosition.Y));
            }
        }

        // Method to move the player in the specified direction.
        public virtual void Move(Direction direction)
        {
            // Update the position of each body part to follow the one in front of it.
            for (int i = BodyParts.Count - 1; i > 0; i--)
            {
                BodyParts[i] = BodyParts[i - 1];
            }

            // Update the head's position based on the current direction.
            switch (direction)
            {
                case Direction.Up:
                    BodyParts[0] = new Point(BodyParts[0].X, BodyParts[0].Y - 20); // Move up.
                    break;
                case Direction.Down:
                    BodyParts[0] = new Point(BodyParts[0].X, BodyParts[0].Y + 20); // Move down.
                    break;
                case Direction.Left:
                    BodyParts[0] = new Point(BodyParts[0].X - 20, BodyParts[0].Y); // Move left.
                    break;
                case Direction.Right:
                    BodyParts[0] = new Point(BodyParts[0].X + 20, BodyParts[0].Y); // Move right.
                    break;
            }
        }

        // Method to add a new body part to the player.
        public void AddBodyPart()
        {
            // Duplicate the last body part's position to extend the player's body.
            BodyParts.Add(BodyParts[BodyParts.Count - 1]);
        }

        // Method to update the position of the last body part to follow the second-to-last part.
        public void UpdateLastBodyPartPosition()
        {
            // Ensure the last body part follows the second-to-last body part's position.
            BodyParts[BodyParts.Count - 1] = BodyParts[BodyParts.Count - 2];
        }
    }
}
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

