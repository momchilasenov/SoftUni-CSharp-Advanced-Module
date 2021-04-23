using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int health = int.Parse(data[3]);

                bool doesExist = false;

                Pokemon pokemon = CreatePokemon(pokemonName, pokemonElement, health);

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.AddPokemon(pokemon);
                        doesExist = true;
                        break;
                    }
                }

                if (!doesExist)
                {
                    Trainer currentTrainer = new Trainer(trainerName);
                    trainers.Add(currentTrainer);
                    currentTrainer.AddPokemon(pokemon);
                }

                input = Console.ReadLine();
            }

            string element = Console.ReadLine();

            while (element != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            if (trainer.Pokemons[i].Name != element)
                            {
                                trainer.Pokemons[i].Health -= 10;

                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                    i--;
                                }
                            }
                        }
                    }
                }

                element = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }

        }

        static Pokemon CreatePokemon(string name, string element, int health)
        {
            return new Pokemon(name, element, health);
        }
    }
}
