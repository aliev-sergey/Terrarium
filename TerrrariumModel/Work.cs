namespace TerrrariumModel
{
    public class Work : IMovable
    {
        public Point Location { get; set; }

        public bool IsExecuted { get; set; } = false;
        
        /// <summary>
        /// Если работа сгенерирована клиентом, убирается с поля после выполнения
        /// </summary>
        public bool IsCustomerGenerated { get; set; } = false;

        public Work(Point p)
        {
            Location = p;
        }

        public bool IsAlive => false;

        public void Move(Point p)
        {
            Location = p;
        }
    }
}
