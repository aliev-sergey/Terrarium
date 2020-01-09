namespace TerrrariumModel
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y;
        }

        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X != secondPoint.X || firstPoint.Y == secondPoint.Y;
        }
    }
}
