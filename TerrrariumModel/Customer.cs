namespace TerrrariumModel
{
    public class Customer : IManage, IMovable
    {
        public bool IsAlive => true;
        public Point Location { get; set; } = new Point(0, 0);

        public void Manage(IManagable imngbl)
        {
            imngbl.DoWork();
        }

        /// <summary>
        /// Генерирует работу в той же точке, что и находится
        /// </summary>
        /// <returns></returns>
        public Work generateWork()
        {
            Work custWork = new Work(Location);
            custWork.IsCustomerGenerated = true;
            return custWork;
        }

        public void Move(Point p)
        {
            Location = p;
        }
    }
}
