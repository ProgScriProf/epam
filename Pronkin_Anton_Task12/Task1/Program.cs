using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static string CurrentPath(string name)
        {
            return Path.Combine(Environment.CurrentDirectory, name);
        }

        public static List<int> ReadInt(string name)
        {
            string path = CurrentPath(name);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            List<int> res = new List<int>();

            using (StreamReader sr = File.OpenText(path))
            {
                int numberStr = 0;
                while(!sr.EndOfStream)
                {
                    numberStr++;
                    if (!int.TryParse(sr.ReadLine(), out int curInt))
                    {
                        throw new FormatException($"Неверное число в строке №{numberStr}");
                    }
                    res.Add(curInt);
                   // res.Add(curInt * curInt);
                }
            }
            return res;
        }

        public static void SqrInts(ref List<int> ints)
        {
            ints = ints.Select(i => i * i).ToList();
        }

        static public void WriteInt(string name, List<int> ints)
        {
            string path = CurrentPath(name);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var i in ints)
                {
                    sr.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            const string name = "disposable_task_file.txt";
            List<int> ints = ReadInt(name);
            SqrInts(ref ints);
            WriteInt(name, ints);

            Console.WriteLine("Файл отредактирован");
            Console.ReadKey();
        }
    }
}
