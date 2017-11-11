using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Anton", "Pronkin", new DateTime(1997, 1, 19));

            Employee emp1 = new Employee(user, 2, "director");
            Employee emp2 = new Employee(user, 2, "manager");
            Employee emp3 = new Employee(user, 2, "director");

            Console.WriteLine($"emp1 == emp2: {emp1.Equals(emp2)}");
            Console.WriteLine($"emp1 == emp3: {emp1.Equals(emp3)}");
            Console.WriteLine($"emp2 == emp3: {emp2.Equals(emp3)}");

            Console.ReadKey();
        }
    }
}
