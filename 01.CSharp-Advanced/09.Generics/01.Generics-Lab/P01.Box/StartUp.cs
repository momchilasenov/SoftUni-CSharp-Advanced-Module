﻿using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BoxOfT<int> box = new BoxOfT<int>();
            box.Add(4);
            box.Add(5);
            box.Add(6);
            Console.WriteLine(box.Remove());
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);

        }
    }
}
