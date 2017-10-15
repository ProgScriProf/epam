using System;
using BasicLib;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static string GetText(string text, bool isNull = false)
        {
            Console.Write($"Введите {text}: ");
            string str = Console.ReadLine();
            while(!(isNull || (!isNull && str.Length != 0)))
            {
                Console.Write("Ошибка! Повтрите ввод: ");
                str = Console.ReadLine();
            }
            return str;
        }
        static DateTime GetDate()
        {
            /*
            Console.WriteLine("Введите день рождения: ");
            int day = ConvertInt.GetPositiveIntValue(31);
            Console.WriteLine("Введите месяц рождения: ");
            int month = ConvertInt.GetPositiveIntValue(12);
            Console.WriteLine("Введите год рождения: ");
            int year = ConvertInt.GetPositiveIntValue(DateTime.Now.Year);
            return new DateTime(year, month, day);
            */
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
        static void PrintInfo(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"Имя: {user.Name}");
                Console.WriteLine($"Фамилия: {user.Lastname}");
                Console.WriteLine($"Отчество: {user.Patronymic}");
                Console.WriteLine($"Дата рождения: {user.Date.Day}.{user.Date.Month}.{user.Date.Year}");
                Console.WriteLine($"Возраст: {user.Age}\n\n");
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
        static void AddUser(List<User> Users)
        {
            string name = GetText("имя");
            string lastname = GetText("фамилию");
            string patronymic = GetText("отчество (необязательно)", true);
            DateTime date = GetDate();
            User newUser;
            try
            {
                newUser = new User(name, lastname, patronymic,  date);
            }
            catch(UserException ex)
            {
                Console.Write("Ошибка содания пользоателя: ");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            Users.Add(newUser);
            Console.WriteLine("Пользователь добавлен");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var Users = new List<User>();

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
