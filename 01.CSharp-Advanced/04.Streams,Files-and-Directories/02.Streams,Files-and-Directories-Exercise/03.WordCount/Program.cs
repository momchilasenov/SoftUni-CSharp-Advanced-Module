using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToFind = File.ReadAllLines("../../../words.txt");
            string[] lines = File.ReadAllLines("../../../text.txt");

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < wordsToFind.Length; i++)
            {
                string wordToFind = wordsToFind[i].ToLower().Trim();

                if (!wordCount.ContainsKey(wordToFind))
                {
                    wordCount.Add(wordToFind, 0);
                }
                
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].ToLower();

                string[] wordsArray = SplitWords(line);

                wordCount = GetWordsCount(wordCount, wordsToFind, wordsArray);
            }

            GetActualResult(wordCount, wordsToFind);

            GetExpectedResult(wordCount, wordsToFind);

        }

        static Dictionary<string, int> GetWordsCount(Dictionary<string, int> wordCount, string[] wordsToFind, string[] wordsArray)
        {
            for (int i = 0; i < wordsArray.Length; i++)
            {
                string currentWord = wordsArray[i].Trim();

                for (int j = 0; j < wordsToFind.Length; j++)
                {
                    string wordToFind = wordsToFind[j].ToLower().Trim();

                    if (currentWord == wordToFind)
                    {
                        if (wordCount.ContainsKey(wordToFind)) 
                        {
                            wordCount[wordToFind]++;
                        }
                    }
                }
            }

            return wordCount;
        }

        static string[] SplitWords(string line)
        {
            string[] wordsArray = line
                .Split(new char[] { ',', ':', ' ', '!', '?', '.', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return wordsArray;
        }

        static void GetActualResult(Dictionary<string, int> wordCount, string[] wordsToFind)
        {
            int indexCount = 0;
            string[] actualResult = new string[wordsToFind.Length];

            foreach (var word in wordCount) //itterate through dictionary to extract key and value
            {
                actualResult[indexCount] = $"{word.Key} - {word.Value}";
                indexCount++;
            }

            File.WriteAllLines("../../../actualResults.txt", actualResult);
        }

        static void GetExpectedResult(Dictionary<string, int> wordCount, string[] wordsToFind)
        {
            int indexCount = 0;
            string[] expectedResult = new string[wordsToFind.Length];

            wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

            foreach (var word in wordCount)
            {
                expectedResult[indexCount] = $"{word.Key} - {word.Value}";
                indexCount++;
            }

            File.WriteAllLines("../../../expectedResults.txt", expectedResult);
        }
    }
}
