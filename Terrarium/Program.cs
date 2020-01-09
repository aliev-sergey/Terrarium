namespace Terrarium
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitCounts counts = new UnitCounts(7, 5, 2, 10, 7);
            Game game = new Game(counts);
            game.InitGame(1);
        }
    }
}
