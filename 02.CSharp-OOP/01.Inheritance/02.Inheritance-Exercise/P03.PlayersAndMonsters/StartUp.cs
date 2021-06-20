using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Elf elf = new Elf("Elf", 22);
            Knight knight = new Knight("Knight", 20);
            Wizard wizard = new Wizard("Wizard", 21);
            MuseElf museElf = new MuseElf("MuseElf", 23);   
            DarkWizard darkWizard = new DarkWizard("darkWizard", 24);   
            DarkKnight darkKnight = new DarkKnight("darkKnight", 25);
            SoulMaster soulMaster = new SoulMaster("soulMaster", 26);
            BladeKnight bladeKnight = new BladeKnight("bladeKnight", 27);


            Console.WriteLine(elf);
            Console.WriteLine(knight);
            Console.WriteLine(wizard);
            Console.WriteLine(museElf);
            Console.WriteLine(darkWizard);
            Console.WriteLine(darkKnight);
            Console.WriteLine(soulMaster);
            Console.WriteLine(bladeKnight);
        }
    }
}
