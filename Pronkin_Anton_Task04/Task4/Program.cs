using System;
using System.Text;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Сравнение скоростей конкатенации String и StringBuilder");
            Console.WriteLine("Нажмите любую клавишу, чтобы начать");
            Console.ReadKey();

            string str = "";
            StringBuilder sb = new StringBuilder();


            for (int N = 10; N < 1000000; N *= 10)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i < N; i++)
                {
                    str += "*";
                }

                sw.Stop();
                TimeSpan time1 = sw.Elapsed;

                sw.Restart();
                for (int i = 0; i < N; i++)
                {
                    sb.Append("*");
                }

                sw.Stop();
                TimeSpan time2 = sw.Elapsed;

                Console.WriteLine($"N = {N}");
                Console.WriteLine($"Время работы String       : {time1.Seconds:00}:{time1.Milliseconds:00}:{time1.Milliseconds:0000}");
                Console.WriteLine($"Время работы StringBuilder: {time2.Seconds:00}:{time2.Milliseconds:00}:{time2.Milliseconds:0000}\n");
            }
            Console.ReadKey();
        }
    }
}
