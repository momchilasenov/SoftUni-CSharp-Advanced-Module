using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.Push("Momchil");

            string[] names = { "A", "B", "C" };

            myStack.AddRange(names);

            Console.WriteLine(string.Join(" ", myStack));
        }
    }
}
