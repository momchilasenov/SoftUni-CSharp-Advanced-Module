﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name)
            : base(name, DruidPower)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
        }
    }
}
