using P04.WildFarm.Animals.Birds;
using P04.WildFarm.Animals.Mammal;
using P04.WildFarm.Animals.Mammal.Feline;
using System;
using System.Collections.Generic;

namespace P04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] animalData = line.Split();

                Animal animal = CreateAnimal(animalData);
                animals.Add(animal);

                string[] foodData = Console.ReadLine().Split();

                Food food = CreateFood(foodData);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

        }

        private static Food CreateFood(string[] foodData)
        {
            Food food = null;
            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] animalData)
        {
            Animal animal = null;
            string type = animalData[0];

            //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
            //Birds - "{Type} {Name} {Weight} {WingSize}";
            //Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";

            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalData[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalData[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
