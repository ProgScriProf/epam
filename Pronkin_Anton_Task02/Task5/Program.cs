using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Простите, что пишу в main'е

            // Первый способ самый "банальный"

            /*
            int sum = 0;
            for (int i = 3; i < 1000; i++)
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;
            Console.WriteLine(sum);
            */


            // Но можно немного извратиться.
            // Если выписать первые несколько нужных чисел:
            // 0 3 5 6 9 10 12 15 18 20 21 24 25 27 30 ..
            // То можно заметить, что каждое из них отличается от предыдущего на
            // 3 2 1 3 1 2 3 | 3 2 1 3 1 2 3 | ...
            // В принципе, это можно доказать математически...

            /*
            byte[] change = { 3, 2, 1, 3, 1, 2, 3 };

            int sum2 = 0;
            for (int i = 0, j = 0; i < 1000; i += change[j++], j %= 7)
                sum2 += i;
            Console.WriteLine(sum2);
            */

            // Ну а третий способ, это просто воспользоваться формулой
            // суммы арифметической прогрессии: S = (a1 + an)*n/2
            // Считаем сумму прогрессии 3, 6, 9, ...
            // Прибавляем сумму прогрессии 5, 10, 15, ...
            // Вычитаем числа, которые встречались в обоих прогрессиях:
            // 15, 30, 45, ...


            const int MAX = 999;

            int sum3 = (3 + MAX / 3 * 3) * (MAX / 3) / 2;
            sum3 += (5 + MAX / 5 * 5) * (MAX / 5) / 2;
            sum3 -= (15 + MAX / 15 * 15) * (MAX / 15) / 2;
                
            Console.WriteLine("Сумма чисел, кратных 3 или 5, меньших " + MAX + " равна: " + sum3);        
            Console.ReadKey();
        }
    }
}
