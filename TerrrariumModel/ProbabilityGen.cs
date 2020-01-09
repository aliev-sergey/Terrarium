using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrrariumModel
{
    /// <summary>
    /// Генератор вероятности
    /// </summary>
    public static class ProbabilityGen
    {
        private static Random _rand = new Random(Environment.TickCount);
        /// <summary>
        /// Генератор 50 процентной вероятности наступления события 
        /// </summary>
        /// <returns>Вернет значение отличное от нуля с 50 процентой вероятеностью</returns>
        public static int Rand50()
        {
            return _rand.Next() & 1;
        }
        /// <summary>
        /// Генератор 75 процентной вероятности наступления события 
        /// </summary>
        /// <returns>Вернет значение отличное от нуля с 75 процентой вероятеностью</returns>
        public static bool Rand75()
        {
            return Convert.ToBoolean(Rand50()) | Convert.ToBoolean(Rand50());
        }
    }
}
