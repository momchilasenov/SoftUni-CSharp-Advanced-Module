using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;

namespace SOLID
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader reader = new FileReader();

            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();

        }

        
    }
}
