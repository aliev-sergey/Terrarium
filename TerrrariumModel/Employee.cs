using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrrariumModel
{
        public abstract class Employee : IMovable
        {
            public decimal Salary { get; set; } // Зарплата, получаемая за каждую выполненную единицу работы
            public decimal MoneyCount { get; set; } = 0; // Накопленные средства
            public decimal SaLaryAdditionCount { get; set; } = 0; // Величина надбавки з/п
            public string Name { get; protected set; } // Имя работника
            public bool Mood { get; set; } = true; // Настроение работника
            public Point Location { get; set; } = new Point(0, 0); // Начальная позиция

            public bool IsAlive => true; // Живая ли сущность?

            public void Move(Point p) // Двигается в точку p
            {
                Location = p;
            }

            public string Say(string WhatToSay) // Используется для разговора с другими сотрудниками
            {
                return $"{this.ToString()}, Message: {WhatToSay}";
            }

            public abstract void Talk(Employee ee); // абстрактный член, реализующий субординацию общения между встречающимися сотрудниками

            public override string ToString()
            {
                return $"Name: {Name}";
            }
        }
}
