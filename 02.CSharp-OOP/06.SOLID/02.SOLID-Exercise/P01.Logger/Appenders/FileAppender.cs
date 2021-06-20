using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            this.MessagesCount++;

            if (!this.CanAppend(reportLevel))
            {
                return;
            }
            string content = string.Format(this.layout.Template, date, reportLevel, message) + Environment.NewLine;

            //File.AppendAllText("../../../log.txt", content);

            this.logFile.Write(content);

        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }

    }
}
