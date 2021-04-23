using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsFile = File.ReadAllText("../../../words.txt");
            string[] wordsToFind = wordsFile.Split().ToArray();

            string[] lines = File.ReadAllLines("../../../input.txt");

            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] wordsInSentence = lines[i].Split(new char[] { ',', '.', '!', '?', ':', ' ','-' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < wordsInSentence.Length; j++)
                {
                    string currentWord = wordsInSentence[j].ToLower().Trim();

                    for (int k = 0; k < wordsToFind.Length; k++)
                    {
                        string wordToFind = wordsToFind[k].ToLower().Trim();

                        if (currentWord == wordToFind)
                        {
                            if (!wordDictionary.ContainsKey(wordToFind))
                            {
                                wordDictionary.Add(wordToFind, 0);
                            }

                            wordDictionary[wordToFind]++;

                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var word in wordDictionary.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine(word.Key + " - " + word.Value);
                }
            }
            



        }
    }
}

