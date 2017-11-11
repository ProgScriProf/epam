using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public delegate void GreetPerson(Person pers, DateTime time);
        public delegate void GoodbyePerson(Person pers);

        public static GreetPerson Greed;
        public static GoodbyePerson Goodbye;
    
        static void Main(string[] args)
        {
            Person per1 = new Person("Anton");
            Person per2 = new Person("Roman");
            Person per3 = new Person("Alex");
            Person per4 = new Person("Kate");

            per1.OnCame += PersoneCame;
            per2.OnCame += PersoneCame;
            per3.OnCame += PersoneCame;
            per4.OnCame += PersoneCame;

            per1.OnLeave += PersonLeave;
            per2.OnLeave += PersonLeave;
            per3.OnLeave += PersonLeave;
            per4.OnLeave += PersonLeave;

            per1.ComeToWork();
            Thread.Sleep(300);

            per2.ComeToWork();
            Thread.Sleep(300);

            per3.ComeToWork();
            Thread.Sleep(300);

            per4.ComeToWork();
            Thread.Sleep(300);

            per2.GoHome();
            Thread.Sleep(300);

            per1.GoHome();
            Thread.Sleep(300);

            per3.GoHome();
            Thread.Sleep(300);

            per4.GoHome();
            Thread.Sleep(300);

            Console.ReadKey();
        }

        static void PersoneCame(Person sender, PersonComeEvent e)
        {          
            Console.WriteLine($"[Работник {sender.Name} пришел на работу]");
            Greed?.Invoke(sender, e.Time);
            Greed += sender.GreetWithPerson;
            Goodbye += sender.GoodbyeWithPerson;
            Console.WriteLine();
        }

        static void PersonLeave(Person sender, EventArgs e)
        {
            Console.WriteLine($"[Работник {sender.Name} ушел с работы]");
            Goodbye -= sender.GoodbyeWithPerson;
            Greed -= sender.GreetWithPerson;
            Goodbye?.Invoke(sender);
            Console.WriteLine();
        }
    }
}
