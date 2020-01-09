using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrrariumModel
{
    public class SalaryAddition : IMovable
    {
        public Point Location { get; set; }
        public int AdditionCount { get; private set; } = 5;
        public bool IsAlive => false;

        public bool IsBigBossGenerated { get; set; } = false; // Если генеририруется БигБоссом, удаляется с поля при получении сотрудником

        public SalaryAddition(Point point)
        {
            Move(point); 
        }

        public void AddSalary(Employee ee)
        {
            ee.SaLaryAdditionCount = AdditionCount;
            ee.Mood = true;
        }

        public void Move(Point p)
        {
            Location = p;
        }
    }
}
