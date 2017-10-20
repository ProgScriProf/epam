using System;
using System.Text.RegularExpressions;

namespace BasicLib
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }

    public class User
    {
        private string _name;
        private string _lastName;
        private string _patronymic;
        private DateTime _date;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && (new Regex("[a-zA-Zа-яА-Я0-9-]+")).Match(value).Value == value)
                {
                    _name = value;
                }
                else
                {
                    throw new UserException("Неверное имя");
                }
            }
        }
        public string Lastname
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && (new Regex("[a-zA-Zа-яА-Я0-9- ]+")).IsMatch(value))
                {
                    _lastName = value;
                }
                else
                {
                    throw new UserException("Неверная фамилия");
                }
            }
        }
        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
            set
            {
                if ((new Regex("[a-zA-Zа-яА-Я- ]+")).Match(value).Value == value || value == "")
                {
                    _patronymic = value;
                }
                else
                {
                    throw new UserException("Неверное отчество");
                }
            }
        }
        public byte Age
        {
            get
            {
                return (byte)(new DateTime((DateTime.Now - _date).Ticks).Year - 1);
                /*
                const int DAY_OF_4YEARS = 1461;
                int days = (DateTime.Now - _date).Days % DAY_OF_4YEARS;
                int years = (DateTime.Now - _date).Days / DAY_OF_4YEARS;
                while (days > 365)
                {
                    days -= 365;
                    years++;
                }
                return (byte)years;
                */
            }
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    _date = value;
                }
                else
                {
                    throw new UserException("Неверная дата рождения!");
                }
            }
        }

        public User(string name, string lastName, string patronymic, DateTime date) : this(name, lastName, date)
        {
            Patronymic = patronymic;
        }
        public User(string name, string lastName, DateTime date)
        {
            Name = name;
            Lastname = lastName;
            Date = date;
            Patronymic = "";
        }
    }
}
