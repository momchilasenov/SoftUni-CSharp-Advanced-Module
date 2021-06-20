using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        [Author("Momchil")]
        public void PrintMethodsByAuthor()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes(); //get all types in assembly

            foreach (Type type in types)
            { //get all the methods for each type in the assembly
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.NonPublic);

                foreach(var method in methods)
                {
                    var attributes = method.GetCustomAttributes<AuthorAttribute>();

                    foreach(var attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }




        }
    }
}
