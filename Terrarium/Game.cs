using System.Threading;
using System.Threading.Tasks;

namespace Terrarium
{
    public class Game
    {
        private WorkField _field;
        private static System.Timers.Timer aTimer;
        public Game(UnitCounts counts, int dimension = 5)
        {
            _field = new WorkField(counts, dimension);
        }
        /// <summary>
        /// Последовательно выполняет все действия в отдельном потоке, пока не закончится рабочий день
        /// </summary>
        /// <param name="minutes">Рабочий день в минутах</param>
        public void InitGame(int minutes)
        {
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task runGame = Task.Run(() =>
            {
                do
                {
                    _field.ExecuteAllActions();
                    _field.MoveAllObjects();
                    _field.RemoveGeneratedWorkOrSalAdd();
                }
                while (!token.IsCancellationRequested);
            }, cts.Token);

            aTimer = new System.Timers.Timer(minutes * 60000);
            aTimer.Elapsed += ((o, e) => 
            {
                cts.Cancel();
                aTimer.Close();
            });

            aTimer.Enabled = true;
            Thread.Sleep(minutes * 60000);
        }
    }
}
