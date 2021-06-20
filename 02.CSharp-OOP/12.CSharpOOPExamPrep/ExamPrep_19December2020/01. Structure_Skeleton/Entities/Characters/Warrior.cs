using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double Health = 100;
        private const double Armor = 50;
        private const double AbilityPoints = 40;
        private Bag bag = new Satchel();

        public Warrior(string name) 
            : base(name, Health, Armor, AbilityPoints, bag)
        {
        }

        public string Name { get; private set; }

        public void Attack(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
