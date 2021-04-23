using System;

namespace Static_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Mathematics maths = new Mathematics();
            maths.PI = 3;
            maths.Multiply(5, 6);

            Mathematics.Add(5, 6);
            Console.Beep(200,40000);

            //Program.Print("something"); //a static method you can call directly

            Program program = new Program(); //withous the static keyword, Print() can be called only for an instance of class Program!
            program.Print("something");
        }

        void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
