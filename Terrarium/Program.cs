using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrrariumModel;

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
