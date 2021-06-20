using DependencyInjection.Loggers;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            Engine engine = new Engine(logger);

            engine.Start();
            engine.End();
        }
    }
}
