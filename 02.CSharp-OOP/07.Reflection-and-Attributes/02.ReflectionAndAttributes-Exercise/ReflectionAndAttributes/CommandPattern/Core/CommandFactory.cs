using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(commandType));

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is an invalid type.");
            }

            ICommand newInstance = (ICommand)Activator.CreateInstance(type);

            return newInstance;
        }
    }
}
