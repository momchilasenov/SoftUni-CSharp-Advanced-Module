using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            HashSet<string> cameToParty = new HashSet<string>();
            List<string> notAtTheParty = new List<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "PARTY")
                {
                    input = Console.ReadLine();
                    while (input != "END")
                    {
                        cameToParty.Add(input);
                        input = Console.ReadLine();
                    }
                    break;
                }

                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (string guest in vip)
            {
                if (!cameToParty.Contains(guest))
                {
                    notAtTheParty.Add(guest);
                }
            }
            foreach (string guest in regular)
            {
                if (!cameToParty.Contains(guest))
                {
                    notAtTheParty.Add(guest);
                }
            }

            Console.WriteLine(notAtTheParty.Count);
            for (int i=0; i<notAtTheParty.Count; i++)
            {
                Console.WriteLine(notAtTheParty[i]);
            }

        }
    }
}
