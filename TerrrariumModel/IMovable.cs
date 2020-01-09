using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrrariumModel
{
    public interface IMovable
    {
            Point Location { get; set; }
            void Move(Point p);
            bool IsAlive { get; }
    }
}
