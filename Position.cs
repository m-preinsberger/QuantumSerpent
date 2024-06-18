using System.Drawing;

namespace QuantumSerpent
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public static Position FromPoint(Point point)
        {
            return new Position(point.X, point.Y);
        }
    }
}
