using System;

namespace PrototypePattern
{
    public class Startup
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["A"] = new Sandwich("A", "A", "A", "A"); 
            sandwichMenu["B"] = new Sandwich("B", "B", "B", "B"); 
            sandwichMenu["C"] = new Sandwich("C", "C", "C", "C"); 
            sandwichMenu["D"] = new Sandwich("D", "D", "D", "D");

            Sandwich copyA = sandwichMenu["A"].Clone() as Sandwich;
            Sandwich copyB = sandwichMenu["B"].Clone() as Sandwich;
            Sandwich copyC = sandwichMenu["C"].Clone() as Sandwich;
        }
    }
}
