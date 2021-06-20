using System;
using System.Linq;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Pesho", -10); 

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);

            
        }
    }
}
