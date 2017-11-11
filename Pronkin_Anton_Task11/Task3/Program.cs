using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hashes = new List<int>();

            for(int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    hashes.Add(new TwoDPointWithHash(i, j).GetHashCode());
                }
            }

            var uHashes = hashes.Distinct().ToArray();

            Console.WriteLine(uHashes.Length == 0 ? "Нет одинаковых хэшей" : "Есть одинаковые хэши");


            Console.ReadKey();
         }
    }
}
