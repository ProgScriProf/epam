using System;

namespace BasicLib
{
    public class ConvertInt
    {
        public static int GetIntValue()
        {
            string inputStr = Console.ReadLine();
            int res;
            while (!int.TryParse(inputStr, out res))
            {
                Console.Write("Ошибка данных. Повторите ввод: ");
                inputStr = Console.ReadLine();
            }
            return res;
        }

        public static int GetPositiveIntValue(int max = int.MaxValue)
        {
            string inputStr = Console.ReadLine();
            int res;
            while (!int.TryParse(inputStr, out res) || res <= 0 || res > max)
            {
                Console.Write("Ошибка данных. Повторите ввод: ");
                inputStr = Console.ReadLine();
            }
            return res;
        }
    }

    public class ConvertFloat
    {
        public static float GetFloatValue()
        {
            string inputStr = Console.ReadLine();
            float res;
            while (!float.TryParse(inputStr, out res))
            {
                Console.Write("Ошибка данных. Повторите ввод: ");
                inputStr = Console.ReadLine();
            }
            return res;
        }
    }
}
