using SOLID.Appenders;
using SOLID.Core.IO;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core.Factories
{
    public class Engine : IEngine
    {
        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;
        private ILogger logger;
        private readonly IReader reader;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
        }

        public void Run()
        {

            int n = int.Parse(this.reader.ReadLine());

            IAppender[] appenders = this.ReadAppenders(n);

            this.logger = new Logger(appenders);

            while (true)
            {
                string command = this.reader.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] data = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(data[0], true);
                string date = data[1];
                string message = data[2];

                this.ProcessCommand(reportLevel, date, message);
                
            }

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    this.logger.Info(date, message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(date, message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(date, message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(date, message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(date, message);
                    break;
            }
        }

        private IAppender[] ReadAppenders(int n)
        {
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] data = this.reader.ReadLine().Split();

                string appenderType = data[0];
                string layoutType = data[1];

                ReportLevel reportLevel = data.Length == 3
                    ? Enum.Parse<ReportLevel>(data[2], true)
                    : ReportLevel.Info;

                ILayout layout = layoutFactory.CreateLayout(layoutType);

                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}
