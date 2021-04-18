using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>() { decimal.Round(grade, 2, MidpointRounding.AwayFromZero) });
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            string grades = string.Empty;

            foreach (var student in students)
            {
                decimal averageGrade = student.Value.Sum() / student.Value.Count;

                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.Write($"(avg: {averageGrade:f2})");
                Console.WriteLine();
            }
        }
    }
}
