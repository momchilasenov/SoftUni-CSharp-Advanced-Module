using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList random = new RandomList();
            random.Add("Pesho");
            random.Add("Misho");
            random.Add("Momchil");
            random.Add("Petya");

            foreach(var element in random)
            {
                Console.WriteLine(random.RandomString());
            }

        }
    }
}
