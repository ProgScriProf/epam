using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {

        static Dictionary<string, double> Frequency(string text)
        {
            var res = new Dictionary<string, double>();

            Regex re = new Regex("[a-zA-Z]+");
            var matches = re.Matches(text);
            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();
                if (!res.ContainsKey(word))
                {
                    res.Add(word, 1d / matches.Count);
                }
                else
                {
                    res[word] = res[word] + 1d / matches.Count;
                }
            }

            return res;
        }

        static void PrintFrequencyWords(Dictionary<string, double> dict)
        {
            Console.WriteLine("\nЧастота появления слов в тексте: ");
            foreach (var freqWord in dict)
            {
                Console.WriteLine($"{freqWord.Key}:\t{freqWord.Value:F2} \t({freqWord.Value * 100:F1}%)");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите текст на английском: ");
            string text = Console.ReadLine();

            var wordsAndFrequency = Frequency(text);
            PrintFrequencyWords(wordsAndFrequency);
            Console.ReadKey();
        }
    }
}
