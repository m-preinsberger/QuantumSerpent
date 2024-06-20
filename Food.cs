// File: Food.cs
using System;
using System.Drawing;

namespace QuantumSerpent
{
    public abstract class Food
    {
        // Property to get or set the position of the food
        public Point Position { get; set; }

        //respawn propertie
        public bool Respawn { get; set; }

        // Abstract method to be implemented by derived classes
        public abstract void Draw(Graphics g);

        // Abstract method to handle the effect of eating the food
        public abstract void EatEffect(Player player);
    }
}
