using System;
using System.Linq;
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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            string @namespace = nameof(Stealer);
            string fullName = $"{@namespace}.{className}";

            Type type = Type.GetType(fullName);
            object classInstance = Activator.CreateInstance(type, new object[0]);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in methods)
            {
                if (method.Name.Contains("get"))
                {
                    if (!method.IsPublic)
                    {
                        sb.AppendLine($"{method.Name} have to be public!");
                    }
                }
                else if (method.Name.Contains("set"))
                {
                    if (!method.IsPrivate)
                    {
                        sb.AppendLine($"{method.Name} have to be private!");
                    }
                    
                }
            }

            return sb.ToString().TrimEnd();
        }


        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");

            Type type = Type.GetType(className);
            var baseClass = type.BaseType.Name;
            sb.AppendLine($"Base Class: {baseClass}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m=> m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }


            return sb.ToString().TrimEnd();

            
        }
    }
}
