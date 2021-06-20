using P02._Worker_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Worker_Before
{
    public class HighPerformingWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("This is a high performer");
        }
    }
}
