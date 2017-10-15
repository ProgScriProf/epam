using System;
using System.Collections.Generic;
using BasicLib;

namespace Task1
{
    class Program
    {
        static string GetText(string text, bool isNull = false)
        {
            Console.Write($"Введите {text}: ");
            string str = Console.ReadLine();
            while (!(isNull || (!isNull && str.Length != 0)))
            {
                Console.Write("Ошибка! Повтрите ввод: ");
                str = Console.ReadLine();
            }
            return str;
        }
        static DateTime GetDate()
        {
            DateTime newDate;
            Console.WriteLine("Введите дату рождения: ");
            string str = Console.ReadLine();
            while (!DateTime.TryParse(str, out newDate))
            {
                Console.WriteLine("Неверная дата. Повторите ввод");
                str = Console.ReadLine();
            }
            return newDate;
        }
        static void PrintInfo(List<Employee> users)
        {
            foreach (Employee user in users)
            {
                Console.WriteLine($"Имя: {user.Name}");
                Console.WriteLine($"Фамилия: {user.Lastname}");
                Console.WriteLine($"Отчество: {user.Patronymic}");
                Console.WriteLine($"Дата рождения: {user.Date.Day}.{user.Date.Month}.{user.Date.Year}");
                Console.WriteLine($"Возраст: {user.Age}");
                Console.WriteLine($"Должность: {user.Position}");
                Console.WriteLine($"Стаж: {user.Patronymic}\n\n");
            }
            Console.ReadKey();
        }
        static char PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Вывсти информацию обо всех");
            Console.WriteLine("3. Выход");
            Console.WriteLine("Введите действие: ");
            do
            {
                string s = Console.ReadLine();
                if (s.Length > 0)
                    return s[0];
            } while (true);
        }
        static void AddUser(List<Employee> Users)
        {
            string name = GetText("имя");
            string lastname = GetText("фамилию");
            string patronymic = GetText("отчество (необязательно)", true);
            string pos = GetText("должность");
            Console.Write("Введите стаж: ");
            int exp = ConvertInt.GetPositiveIntValue();

            DateTime date = GetDate();
            Employee newUser;
            try
            {
                newUser = new Employee(name, lastname, patronymic, date, exp, pos);
            }
            catch (UserException ex)
            {
                Console.Write("Ошибка содания работника: ");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            Users.Add(newUser);
            Console.WriteLine("Раотник добавлен");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var Users = new List<Employee>();

            bool isExit = false;
            do
            {
                switch (PrintMenu())
                {
                    case '1':
                        AddUser(Users);
                        break;
                    case '2':
                        PrintInfo(Users);
                        break;
                    case '3':
                        isExit = true;
                        break;
                }
            } while (!isExit);

            Console.ReadKey();
        }
    }
}
