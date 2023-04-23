using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace UniqueWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile =@"C:\Users\Viktoria\Downloads\tolstoj_lew_nikolaewich-text_0040.fb2\tolstoj_lew_nikolaewich-text_0040.fb2";
            string outputFile = @"C:\Users\Viktoria\Source\Repos\UniqueWords\UniqueWords\outputText.txt";
            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            char[] UnwantedSigns = new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '\t', };
            string greattext = Regex.Replace(text, "[<*>]", "");
            string[] words = greattext.Split(UnwantedSigns, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> countword = new Dictionary<string, int>();
            foreach(var key in words)
            {
                if (!countword.ContainsKey(key)) 
                { 
                    countword.Add(key, 1); 
                }
                else
                {
                    countword[key]++;
                }
            }
            var sort = countword.OrderByDescending(w => w.Value);
            using (StreamWriter wordincount = new StreamWriter(outputFile))
            {
                foreach (var unit in sort)
                {
                    wordincount.WriteLine($"{unit.Key} - {unit.Value}");
                }
            }
            
        }
    }
}
