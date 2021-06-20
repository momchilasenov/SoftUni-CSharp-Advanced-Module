using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy kira = new Puppy();
            kira.Bark();
            kira.Eat();
            kira.Weep();
        }
    }
}
