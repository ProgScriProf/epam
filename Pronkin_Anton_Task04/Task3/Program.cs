using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        static void InfoCulture(CultureInfo ci)
        {
            Console.WriteLine($"Культура: {ci.DisplayName}");
            Console.WriteLine($"Разделитель дроби: {ci.NumberFormat.CurrencyDecimalSeparator}");
            Console.WriteLine($"Разделитель тысяч: {ci.NumberFormat.CurrencyGroupSeparator}");
            Console.WriteLine($"Валюта: { ci.NumberFormat.CurrencySymbol}\n");
        }

        static void Main(string[] args)
        {
            InfoCulture(new CultureInfo("ru-RU"));
            InfoCulture(new CultureInfo("en-US"));
            InfoCulture(new CultureInfo(""));
            Console.ReadKey();
        }
    }
}
