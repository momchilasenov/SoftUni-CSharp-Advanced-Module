using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] stringArray = ArrayCreator.Create<string>(5, "Momchil");
            int[] array = ArrayCreator.Create<int>(8, 444);

        }
    }
}
