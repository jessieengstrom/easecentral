using System;
using System.Collections.Generic;

namespace Anagram_Test
{

    class Program
    {
        static string sort_string(String a)
        {

            char[] characters = a.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        static void Main(string[] args)
        {
            string[] words = System.IO.File.ReadAllLines(args[0]);

            Dictionary<string, List<string>> SortedWords = new Dictionary<string, List<string>>();

            foreach (var word in words) {
                var sort = sort_string(word);

                if (SortedWords.ContainsKey(sort)) 
                {
                    SortedWords[sort].Add(word);
                }
                else
                {
                    SortedWords[sort] = new List<string>() { word };
                }
            }

            foreach (List<string> item in SortedWords.Values){
                if (item.Count > 1)
                {
                    item.ForEach(i => Console.Write("{0}" + ' ', i));
                    Console.Write(Environment.NewLine);
                }
            }
        }
    }
}
