using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    /// <summary>
    /// Объект, передаваемый в конструктор поля, для инициализации работников и клиентов
    /// </summary>
    public class UnitCounts
    {
        public int WorkerCount { get; private set; }
        public int BossCount { get; private set; }
        public int BigBossCount { get; private set; }
        public int WorkCount { get; private set; }
        public int CustomerCount { get; private set; }

        public UnitCounts(int workerCount, int bossCount, int bigBossCount, int workCount, int customerCount)
        {
            WorkerCount = workerCount;
            BossCount = bossCount;
            BigBossCount = bigBossCount;
            WorkCount = workCount;
            CustomerCount = customerCount;
        }
    }
}
