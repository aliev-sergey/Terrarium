using System;


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
            base.MoneyCount += base.Salary + base.SalaryAdditionCount;
        }

        public void UpdateMeeting(string greeting)
        {
            OnMeetingHappened(new MeetingEventArgs(greeting));
        }
        protected override void OnMeetingHappened(MeetingEventArgs e)
        {
            base.OnMeetingHappened(e);
        }

        public override void Talk(Employee ee)
        {
            // Очень не нравится, что вызываются методы консоли в коде
            // Хотелось бы услышать рекомендации по исправлению этого
            if (ee is Boss)
            {
                UpdateMeeting( $"From: {Say("Hello, Boss!")} To: {ee.ToString()}" );
                return;
            }
            if (ee is BigBoss)
            {
                UpdateMeeting( $"From: {Say("Good bless you, Sir!")} To: {ee.ToString()}" );
                return;
            }

            UpdateMeeting( $"From: {Say("Hi, comrade!")} To: {ee.ToString()}" );
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Job position: Worker";
        }
    }
}
