using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private IBag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            private set
            {
                if (value < 0 && value > this.baseHealth)
                {
                    throw new ArgumentException("Invalid health");
                }

                this.health = value;
            }
        }

        public bool IsAlive { get; set; } = true;

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid armor");
                }

                this.armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.armor - hitPoints >= 0)
                {
                    this.armor -= hitPoints;
                }
                else if (this.armor - hitPoints < 0)
                {
                    double pointsLeft = hitPoints - this.armor;
                    this.armor = 0;
                    this.health -= pointsLeft;

                    if (this.health <= 0)
                    {
                        this.IsAlive = false;
                    }
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }


    }
}