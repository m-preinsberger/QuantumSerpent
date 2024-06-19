using System.Drawing;

namespace QuantumSerpent
{
    // Represents a 2D position with X and Y coordinates.
    public class Position
    {
        // X coordinate.
        public int X { get; set; }
        // Y coordinate.
        public int Y { get; set; }

        // Constructor: Initializes position with X and Y coordinates.
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Converts Position to System.Drawing.Point.
        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        // Creates a Position from a System.Drawing.Point.
        public static Position FromPoint(Point point)
        {
            return new Position(point.X, point.Y);
        }
    }
}
