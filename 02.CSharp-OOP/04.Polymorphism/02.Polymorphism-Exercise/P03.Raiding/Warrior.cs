﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name)
            : base(name, WarriorPower)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
