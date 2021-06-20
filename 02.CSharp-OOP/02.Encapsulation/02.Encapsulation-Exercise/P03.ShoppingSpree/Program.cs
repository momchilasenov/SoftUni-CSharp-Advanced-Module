using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] purchaseData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = purchaseData[0];
                string productName = purchaseData[1];

                Person person = people[personName];
                Product product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach(var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var peopleDictionary = new Dictionary<string, Person>();
            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                var personData = person.Split('=');
                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                //directly assign the key and set the value
                peopleDictionary[name] = new Person(name, money);
            }

            return peopleDictionary;
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var productDictionary = new Dictionary<string, Product>();

            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach(var product in products)
            {
                var productData = product.Split('=');
                string name = productData[0];
                decimal cost = decimal.Parse(productData[1]);

                productDictionary[name] = new Product(name, cost);
            }

            return productDictionary;
        }
    }
}
