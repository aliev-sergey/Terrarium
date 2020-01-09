using System;
using System.Threading;

namespace TerrrariumModel
{
    public class Worker : Employee, IManagable
    {
        public Worker(string name, decimal salary = 100)
        {
            base.Name = name;
            base.Salary = salary;
        }

        public void DoWork()
        {
            Thread.Sleep(1000);
            base.MoneyCount += base.Salary + base.SaLaryAdditionCount;
        }

        public override void Talk(Employee ee)
        {
            // Очень не нравится, что вызываются методы консоли в коде
            // Хотелось бы услышать рекомендации по исправлению этого
            if (ee is Boss)
            {
                Console.WriteLine( $"From: {Say("Hello, Boss!")} To: {ee.ToString()}" );
                return;
            }
            if (ee is BigBoss)
            {
                Console.WriteLine( $"From: {Say("Good bless you, Sir!")} To: {ee.ToString()}" );
                return;
            }

            Console.WriteLine( $"From: {Say("Hi, comrade!")} To: {ee.ToString()}" );
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Job position: Worker";
        }
    }
}
