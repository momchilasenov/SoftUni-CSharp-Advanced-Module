using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);

            sb.AppendLine($"Class under investigation: {type.Name}");

            Object classInstance = Activator.CreateInstance(type, new object[0]);

            foreach (var fieldName in fieldNames)
            {
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var value = field.GetValue(classInstance);

                sb.AppendLine($"{field.Name} = {value}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
