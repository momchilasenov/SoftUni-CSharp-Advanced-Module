using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directory = new DirectoryInfo("../../../");

            FileInfo[] files = directory.GetFiles();

            foreach (var item in files)
            {
                string extension = item.Extension;
                string name = item.Name;
                double size = item.Length / 1024.0;

                if (!dictionary.ContainsKey(extension))
                {
                    dictionary.Add(extension, new Dictionary<string, double>());
                    dictionary[extension].Add(name, size);
                }
                else
                {
                    dictionary[extension].Add(name, size);
                }
            }

            dictionary = dictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter writer = new StreamWriter($"{path}/report.txt"))
            {
                foreach (var extension in dictionary)
                {
                    writer.WriteLine(extension.Key);

                    foreach (var file in extension.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:f3}kb");
                    }
                }
            }
        }
    }
}
