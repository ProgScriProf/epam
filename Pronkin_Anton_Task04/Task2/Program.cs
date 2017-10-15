using System;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();

            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();


            StringBuilder newStr = new StringBuilder(str1.Length * 2);


            // Вариант 1, используя множества

            UnionChar uc = new UnionChar();
            for (int i = 0; i < str2.Length; i++)
                uc.AddValue(str2[i]);

            for (int i = 0; i < str1.Length; i++)
            {
                newStr.Append(str1[i]);
                if (uc.Exists(str1[i]))
                {
                    newStr.Append(str1[i]);
                }
            }
     
            
            /*
          
            // Вариант 2, использу поиск символа
            for (int i = 0; i < str1.Length; i++)
            {
                newStr.Append(str1[i]);
                if (str2.IndexOf(str1[i]) >= 0)
                {
                    newStr.Append(str1[i]);
                }
            }
            */

            Console.WriteLine($"Новая строка: {newStr}");
            Console.ReadKey();
        }
    }

    class UnionChar
    {
        private byte[] _value;    
        public UnionChar()
        {
            _value = new byte[32];
        }
        public void AddValue(char value)
        {
            int index = value / 8; // Определяем номер байта для хранения
            int mask = 1 << (value % 8); // определяем номер разряда для хранения
            _value[index] |= (byte)mask;
        }
        public bool Exists(char value)
        {
            int index = value / 8; // Определяем номер байта для хранения
            int mask = 1 << (value % 8); // определяем номер разряда для хранения
            return (_value[index] & mask) > 0 ? true : false;
        }
        public void Delete(char value)
        {
            int index = value / 8; // Определяем номер байта для хранения
            int mask = ~(1 << (value % 8)); // определяем номер разряда для хранения
            _value[index] &= (byte)mask;
        }
    }
}
