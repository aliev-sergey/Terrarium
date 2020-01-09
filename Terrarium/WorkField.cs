using System;
using System.Collections.Generic;
using TerrrariumModel;

namespace Terrarium
{
    public class WorkField
    {
        /// <summary>
        /// Генерируется квадратное поле размеренностью _fieldDimension x _fieldDimension
        /// </summary>
        private int _fieldDimension;
        /// <summary>
        /// Список всех подвижных объектов на поле
        /// </summary>
        private List<IMovable> _movableObjects = new List<IMovable>();
        private Random _random = new Random(Environment.TickCount);
        private delegate void _meetingHandler(string message);
        /// <summary>
        /// Массив имен, которые случайным образом присваиваются сотрудникам
        /// </summary>
        private string[] _namesOfEmployees = {"Александр", "Алексей", "Анатолий", "Андрей", "Антон",
            "Аркадий", "Артём", "Артур", "Борис", "Вадим", "Валентин", "Валерий", "Василий", "Виктор",
            "Виталий", "Владимир", "Владислав", "Вячеслав", "Георгий", "Григорий", "Денис", "Дмитрий",
            "Евгений", "Егор", "Иван", "Игорь", "Илья", "Кирилл", "Константин", "Лев", "Леонид",
            "Максим", "Марк", "Михаил", "Никита", "Николай", "Олег", "Павел", "Пётр", "Роман", "Руслан",
            "Сергей", "Тимур", "Фёдор", "Юрий", "Ярослав" };

        public WorkField(UnitCounts counts, EventHandler<MeetingEventArgs>meetingEventHandler, int FieldDimension = 5)
        {
            if (FieldDimension > 10)
            {
                FieldDimension = 10;
            }
            _fieldDimension = FieldDimension;

            AddEmployeesToField(counts.WorkerCount, counts.BossCount, counts.BigBossCount, meetingEventHandler);
            AddCustomerToField(counts.CustomerCount);
            AddWorkToField(counts.WorkCount);
            RandomizeMovableLocation();
            AddSalaryAddition();
        }
        /// <summary>
        /// Удаляет все сгенерированные БигБоссом и Клиентом и использованные объекты (работу и надбавка к зарплате) из списка
        /// </summary>
        public void RemoveGeneratedWorkOrSalAdd()
        {
            for (int i = _movableObjects.Count - 1; i >= 0; i--)
            {
                if (isUsedGenSalAddition(_movableObjects[i]) || IsUsedGenCustWork(_movableObjects[i]))
                {
                    _movableObjects.Remove(_movableObjects[i]);
                }
            }
        }

        /// <summary>
        /// Проверяет, использована ли надбавка к зарплате, сгенерированная БигБоссом
        /// </summary>
        /// <param name="imvbl">Потенциальный работник, который получит надбавку</param>
        private bool isUsedGenSalAddition(IMovable imvbl)
        {
            return imvbl is SalaryAddition && (imvbl as SalaryAddition).IsBigBossGenerated;
        }
        /// <summary>
        /// Проверяет, выполнена ли работа, сгенерированная клиентом
        /// </summary>
        /// <param name="imvbl">Потенациальная работа, сгенерированная клиентом</param>
        /// <returns></returns>
        private bool IsUsedGenCustWork(IMovable imvbl)
        {
            return imvbl is Work && (imvbl as Work).IsCustomerGenerated && (imvbl as Work).IsExecuted;
        }
        /// <summary>
        /// Добавляет работников (Рабочих, Боссов и Бигбоссов на поле)
        /// </summary>
        /// <param name="workerCount">Количество рабочих</param>
        /// <param name="bossCount">Количество боссов</param>
        /// <param name="bigBossCount">Количество бигбоссов</param>
        private void AddEmployeesToField(int workerCount, int bossCount, int bigBossCount, EventHandler<MeetingEventArgs> meetingEventHandler)
        {
            int iterCount = Math.Max(Math.Max(workerCount, bossCount), bigBossCount);

            for (int i = 0; i < iterCount; i++)
            {
                if (workerCount > 0)
                {
                    AddMovableToField(new Worker(_namesOfEmployees[_random.Next(0,_namesOfEmployees.Length-1)]));
                    workerCount--;
                }
                if (bossCount > 0)
                {
                    AddMovableToField(new Boss(_namesOfEmployees[_random.Next(0, _namesOfEmployees.Length - 1)]));
                    bossCount--;
                }
                if (bigBossCount > 0)
                {
                    AddMovableToField(new BigBoss(_namesOfEmployees[_random.Next(0, _namesOfEmployees.Length - 1)]));
                }
                
                (_movableObjects[i] as Employee).GreetingHappend += meetingEventHandler;
            }
        }

        /// <summary>
        /// Добавляет клиентов на поле
        /// </summary>
        /// <param name="customerCount">Количество клиентов</param>
        private void AddCustomerToField(int customerCount)
        {
            for (int i = 0; i < customerCount; i++)
            {
                AddMovableToField(new Customer());
            }
        }
        /// <summary>
        /// Добавляет работу на поле
        /// </summary>
        /// <param name="workcount">Количество работы</param>
        private void AddWorkToField(int workcount)
        {
            for (int i = 0; i < workcount; i++)
            {
                AddMovableToField(new Work(new Point(0,0)));
            }
        }
        /// <summary>
        /// Добавляет любой подвижный объект на поле
        /// </summary>
        /// <param name="imvbl">подвижный объект</param>
        private void AddMovableToField(IMovable imvbl)
        {
            _movableObjects.Add(imvbl);
        }
        /// <summary>
        /// Раскидывает подвижные объекты по полю случайным образом
        /// </summary>
        private void RandomizeMovableLocation()
        {
            _movableObjects.ForEach(imbvbl => imbvbl.Location = new Point(_random.Next(0, _fieldDimension), _random.Next(0, _fieldDimension)));
        }
        /// <summary>
        /// Добавляет надбавку к зарплате, не сгенерированную БигБоссом
        /// </summary>
        public void AddSalaryAddition()
        {
            int salaryAdditionCount = _fieldDimension - 1;
            for (int i = 0; i < salaryAdditionCount; i++)
            {
                AddMovableToField(new SalaryAddition(new Point(_fieldDimension + 1, _fieldDimension + 1)));
            }
        }

        /// <summary>
        /// Передвинуть все подвижные объекты на поле
        /// </summary>
        public void MoveAllObjects()
        {
            int xCoord, yCoord;
            IMovable imvbl;
            for (int i = 0; i < _movableObjects.Count; i++)
            {
                imvbl = _movableObjects[i];

                if (imvbl.IsAlive) // Любой живой объект сдвигается на случайную соседнюю клетку
                {
                    xCoord = _random.Next(imvbl.Location.X - 1, imvbl.Location.X + 1);
                    yCoord = _random.Next(imvbl.Location.Y - 1, imvbl.Location.Y + 1);
                    imvbl.Move(new Point(xCoord, yCoord));
                }
                if (imvbl is Work && (imvbl as Work).IsExecuted) // Выполненная работа передвигается в случайную область поля
                {
                    xCoord = _random.Next(0, _fieldDimension - 1);
                    yCoord = _random.Next(0, _fieldDimension - 1);
                    if (!(imvbl as Work).IsCustomerGenerated)
                    {
                        imvbl.Move(new Point(xCoord, yCoord));
                    }
                    else
                    {
                        imvbl.Move(new Point(_fieldDimension + 1, _fieldDimension + 1)); // Если работа сгенерирована клиентом, убирается с поля
                    }

                }
                if ((imvbl is SalaryAddition) && !ProbabilityGen.Rand75() && !(imvbl as SalaryAddition).IsBigBossGenerated)
                    //  Если это не сгенерированная Бигбоссом надбавка, то убирается с поля, чтобы затем полявится с 25 процентной вероятностью
                {
                    xCoord = _random.Next(0, _fieldDimension - 1);
                    yCoord = _random.Next(0, _fieldDimension - 1);
                    imvbl.Move(new Point(xCoord, yCoord));
                }
                if (imvbl is Customer && ProbabilityGen.Rand75())
                //  Добавляем работу клиентом с 75 процентой вероятностью
                {
                    AddMovableToField((imvbl as Customer).generateWork());
                }
                if (imvbl is BigBoss && !ProbabilityGen.Rand75())
                    /// добавляем надбавку к зарплате с помощью БигБосса с 25 процентой вероятностью
                {
                    AddMovableToField((imvbl as BigBoss).GenerateSalaryAddition());
                }
            }
        }
        /// <summary>
        /// Выполняет всю работу на поле,
        /// использует все надбавки к зарплате
        /// и здоровается, если это возможно
        /// </summary>
        public void ExecuteAllActions()
        {
            foreach (IMovable movableObj in _movableObjects)
            {
                if (movableObj is Worker || movableObj is Boss)
                {
                    FindWork(movableObj);
                }
                if (movableObj is SalaryAddition)
                {
                    FindEmpSalaryAdd(movableObj);
                }
                if (movableObj is Employee)
                {
                    SayHello(movableObj);
                }
            }
        }
        /// <summary>
        /// Проверяет необходимость выолпнения работы
        /// </summary>
        /// <param name="workableUnit"></param>
        private void FindWork(IMovable workableUnit)
        {
            foreach (IMovable potentialWork in _movableObjects)
            {
                if (workableUnit.Location == potentialWork.Location && workableUnit != potentialWork) // Если работоспособная единица в одной клетке с потенциальной работой
                {
                    if ((potentialWork is IManage && workableUnit is Worker) || (potentialWork is IManage && workableUnit is Boss && !(potentialWork is Boss)))
                        // Если работа представляется в виде поручения начальника
                    {
                        (potentialWork as IManage).Manage(workableUnit as IManagable);
                    }
                    if (potentialWork is Work)
                        // Если работа, это отдельный объект на поле
                    {
                        (workableUnit as IManagable).DoWork();
                        (potentialWork as Work).IsExecuted = true;
                    }
                }
            }
        }
        /// <summary>
        /// Проверяет, есть ли юниты, которые могут использовать надбавку к зарплате
        /// </summary>
        /// <param name="salaryAddObj"></param>
        private void FindEmpSalaryAdd(IMovable salaryAddObj)
        {
            foreach (IMovable employeePerson in _movableObjects)
            {
                if (employeePerson.Location == salaryAddObj.Location && employeePerson is Employee && employeePerson != salaryAddObj)
                {
                    SalaryAddition salAddition = salaryAddObj as SalaryAddition;
                    (employeePerson as Employee).SalaryAdditionCount += salAddition.AdditionCount;
                    salAddition.Location = new Point(_fieldDimension + 1, _fieldDimension + 1);
                }
            }
        }
        /// <summary>
        /// Проверяет, есть ли возможность поздороваться
        /// </summary>
        /// <param name="employee">
        /// Отдельно взятый работник, если в клетке есть еще сотрудники,
        /// то в зависимости от субординации здоровается
        /// </param>
        private void SayHello(IMovable employee)
        {
            foreach (IMovable metEmployee in _movableObjects)
            {
                if (metEmployee.Location == employee.Location && metEmployee is Employee && employee != metEmployee)
                {
                    (employee as Employee).Talk(metEmployee as Employee);
                }
            }
        }

    }
}
