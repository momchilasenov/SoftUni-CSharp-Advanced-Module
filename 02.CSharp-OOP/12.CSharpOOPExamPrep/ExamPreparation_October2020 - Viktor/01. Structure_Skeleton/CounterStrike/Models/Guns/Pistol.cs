﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int fireRate = 1;

        public Pistol(string name, int bulletsCount)
            :base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (this.BulletsCount - fireRate >= 0)
            {
                this.BulletsCount -= fireRate;
                return fireRate;
            }
            else
            {
                return 0;
            }
        }
    }
}
