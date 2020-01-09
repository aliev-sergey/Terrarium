using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TerrrariumModel
{
    public class Boss : Employee, IManage, IManagable
    {
        public Boss(string name, decimal salary = 300)
        {
            base.Name = name;
            base.Salary = salary;
            base.Mood = false;
        }
        public void DoWork()
        {
            Thread.Sleep(1000);
            base.MoneyCount += base.Salary + base.SalaryAdditionCount;
        }

        public void Manage(IManagable imngbl)
        {
            base.Mood = true;
            imngbl.DoWork();
        }

        public override void Talk(Employee ee)
        {
            if (ee is Boss)
            {
                Console.WriteLine($"From: {Say("What's up!")} To: {ee.ToString()}");
                return;
            }
            if (ee is BigBoss)
            {
                Console.WriteLine($"From: {Say("Hello, Boss!")} To: {ee.ToString()}");
                return;
            }

            Console.WriteLine($"From: {Say("Hi!")} To: {ee.ToString()}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, job position: Boss";
        }
    }

}
