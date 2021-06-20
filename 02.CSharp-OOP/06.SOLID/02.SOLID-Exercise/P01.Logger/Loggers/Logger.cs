using SOLID.Appenders;
using SOLID.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders; //where to append the information

        public Logger(params IAppender[] appender)
        {
            this.appenders = appender;
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Info, message);
        }
        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Fatal, message);
        }
        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Critical, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Warning, message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(var appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private void AppendToAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach(var appender in appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
    }
}
