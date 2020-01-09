namespace TerrrariumModel
{
    public interface IMovable
    {
            Point Location { get; set; }
            void Move(Point p);
            bool IsAlive { get; }
    }
}
