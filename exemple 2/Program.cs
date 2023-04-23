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
            // изначальный файл 
            string outputFile = @"C:\Users\Viktoria\Source\Repos\UniqueWords\UniqueWords\outputText.txt";
            // файл результата
            string text = File.ReadAllText(inputFile, Encoding.UTF8);
            // метод открывает файл считывает текст в заданной кодировке
            char[] UnwantedSigns = new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '\t', };
            // разделители
            string greattext = Regex.Replace(text, "[<...>|</...>]");
            // попытка убрать текст веб разметки
            string[] words = greattext.Split(UnwantedSigns, StringSplitOptions.RemoveEmptyEntries);
            // разделение слов
            Dictionary<string, int> countword = new Dictionary<string, int>();
            // создание словаря
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
            }// подсчет слов
            var sort = countword.OrderByDescending(w => w.Value);
            // сортировка по убыванию 
            using (StreamWriter wordincount = new StreamWriter(outputFile))
            {
                foreach (var unit in sort)
                {
                    wordincount.WriteLine($"{unit.Key} - {unit.Value}");
                }
            }
            //запись строк значений и кол-во слов
        }
    }
}
