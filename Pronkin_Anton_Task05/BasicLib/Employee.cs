using System;

namespace BasicLib
{
    public class EmployeeException : UserException
    {
        public EmployeeException(string message):base(message)
        {

        }
    }

    public class Employee : User
    {
        private int _experience;
        //   private string _position;
        private int _salary;

        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value >= 0)
                {
                    _experience = value;
                }
                else
                {
                    throw new EmployeeException("Неверноее значение для стажа");
                }
            }
        }
        public string Position { get; set; }
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 0)
                {
                    _salary = value;
                }
                else
                {
                    throw new EmployeeException("Неверноее значение для зарплаты");
                }
            }
        }


        public Employee(string name, string lastname, DateTime date, int experience, string position) : 
            base(name, lastname, date)
        {
            Experience = experience;
            Position = position;
            Salary = 0;
        }
        public Employee(string name, string lastname, string patronymic, DateTime date, int experience, string position) : 
            base(name, lastname, patronymic, date)
        {
            Experience = experience;
            Position = position;
            Salary = 0;
        }
        public Employee(User user, int experience, string position)
            : this(user.Name, user.Lastname, user.Patronymic, user.Date, experience, position)
        {
            Salary = 0;
        }
    }
}
