using System;

namespace TerrrariumModel
{

    public class BigBoss : Boss, IManage
    {
        public new void DoWork()
        {
            throw new NotSupportedException();
        }

        public BigBoss(string name, decimal salary = 1000) : base(name, salary)
        {
            base.Mood = false;
        }

        public override void Talk(Employee ee)
        {
            if (ee is Boss)
            {
                Console.WriteLine($"From: {Say("How are you, Buddy!")} To: {ee.ToString()}");
                return;
            }
            if (ee is BigBoss)
            {
                Console.WriteLine($"From: {Say("Assalam Aleykum!")} To: {ee.ToString()}");
                return;
            }

            Console.WriteLine($"From: {Say("Hi!")} To: {ee.ToString()}");
        }
        /// <summary>
        /// Генерирует надбавку к зарплате в клетке, в которой находится
        /// </summary>
        /// <returns></returns>
        public SalaryAddition GenerateSalaryAddition()
        {
            SalaryAddition addition = new SalaryAddition(Location);
            addition.IsBigBossGenerated = true;
            return addition;
        }

        public override string ToString()
        {
            return $"Name: {base.Name}, Job position: Big Boss";
        }
    }
}
