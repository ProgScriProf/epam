using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class PersonComeEvent : EventArgs
    {
        private DateTime _time;
        public PersonComeEvent(DateTime time)
        {
            _time = time;
        }
        public DateTime Time
        {
            get
            {
                return _time;
            }
        }
    }

    class Person
    {
        private string _name;
        private bool _isAlive;

        public delegate void EventCome(Person sender, PersonComeEvent args);
        public delegate void EventLeave(Person sender, EventArgs args);

        public event EventCome OnCame;
        public event EventLeave OnLeave;

        public void GreetWithPerson(Person per, DateTime time)
        {
            if (time.Day < 12)
            {
                Console.WriteLine($"\"Доброе утро, {per.Name}!\" - сказал {_name}");
            }
            else if (time.Day < 17)
            {
                Console.WriteLine($"\"Доброе день, {per.Name}!\" - произнес {_name}");
            }
            else
            {
                Console.WriteLine($"\"Доброе вечер, {per.Name}!\" - промолвил {_name}");
            }
        }
        public void GoodbyeWithPerson(Person per)
        {
            Console.WriteLine($"\"Прощай, {per.Name}\" - сказал {_name}");
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public Person(string name)
        {
            _name = name;
            _isAlive = true;
        }

        public bool ComeToWork()
        {
            if (!_isAlive)
            {
                return false;
            }

            // Идет на работу...
            OnCame(this, new PersonComeEvent(DateTime.Now));
            return true;
        }
        public void GoHome()
        {
            // Собирается идти домой...
            OnLeave(this, EventArgs.Empty);
        }
    }
}
