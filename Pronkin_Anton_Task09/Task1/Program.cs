using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static T RemoveEachSecondItem<T>(ICollection<T> items)
        {
            if (items.Count == 0)
            {
                throw new Exception("Нет людей в колекции");
            }

            bool second = false; // true - второй по счету, false - первый по счету
            /*
           
            while(items.Count > 1)
            {
                T[] tmp = items.ToArray();

                foreach (T item in tmp)
                {
                    if (second)
                    {
                        items.Remove(item);
                    }
                    second = !second;
                }
            }
            
            */
            

            while (items.Count > 1)
            {
                items = items.Where(i => second = !second).ToList();
            }
            

            return items.First();
        }

        static void GenerateNumber(ICollection<int> items, int n)
        {
            items.Clear();
            for(int i = 0; i < n;i++)
            {
                items.Add(i + 1);
            }
        }

        static void Main(string[] args)
        {
            var list = new List<int>();
            var link = new LinkedList<int>();

            while(true)
            {
                string input;
                while (true)
                {
                    Console.WriteLine("Введите число человек: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int n))
                    {
                        GenerateNumber(list, n);
                        GenerateNumber(link, n);
                        break;
                    }
                    else
                    {
                        return;
                    }
                }

                Console.WriteLine($"Результат для List: {RemoveEachSecondItem(list)}");
                Console.WriteLine($"Результат для LinkedList: {RemoveEachSecondItem(link)}");


            }
        }
    }
}
