using System;
using System.Collections.Generic;

namespace Anagram_Test
{

    class Program
    {
        static int check_anagram(String a)
        {
            // give each character in the alphabet a weight
            var alphabet = new Dictionary<char, int>
            {
                ['a'] = 1,
                ['b'] = 2,
                ['c'] = 3,
                ['d'] = 4,
                ['e'] = 5,
                ['f'] = 6,
                ['g'] = 7,
                ['h'] = 8,
                ['i'] = 9,
                ['j'] = 10,
                ['k'] = 11,
                ['l'] = 12,
                ['m'] = 13,
                ['n'] = 14,
                ['o'] = 15,
                ['p'] = 16,
                ['q'] = 17,
                ['r'] = 18,
                ['s'] = 19,
                ['t'] = 20,
                ['u'] = 21,
                ['v'] = 22,
                ['w'] = 23,
                ['x'] = 24,
                ['y'] = 25,
                ['z'] = 26
            };

            // return the total weight of a word
            var counts = 0;
            foreach (var c in a) {
                counts += alphabet[c];
            }

            return counts;
        }

        static void Main()
        {
            // read in the words.txt file as an array
            string[] words = System.IO.File.ReadAllLines(@"/Users/jessieengstrom/myApp/words.txt");

            // using a dictionary to hold the word weights and which words have that weight
            Dictionary<int, List<string>> WordsValues = new Dictionary<int, List<string>>();

            // loop through each word and calculate weight then add it to WordValues
            foreach (var word in words) {
                var count = check_anagram(word);

                // if that weight already exists add that word to the list
                if (WordsValues.ContainsKey(count)) 
                {
                    WordsValues[count].Add(word);
                }
                else
                {
                    WordsValues[count] = new List<string>() { word };
                }
            }

            // loop through all the weights and print the words that have the same weight
            // if a word has the same weight it is an anagram
            foreach (int item in WordsValues.Keys){
                if (WordsValues[item].Count > 1)
                {
                    WordsValues[item].ForEach(i => Console.Write("{0}" + ' ', i));
                    Console.Write(Environment.NewLine);
                }
            }
        }
    }
}
