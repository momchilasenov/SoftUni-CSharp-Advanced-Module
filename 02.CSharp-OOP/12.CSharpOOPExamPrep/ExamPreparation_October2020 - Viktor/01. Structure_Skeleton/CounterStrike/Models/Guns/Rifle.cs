using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int fireRate = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
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
                int bulletsLeft = BulletsCount;
                BulletsCount = 0;
                return bulletsLeft;
            }
        }
    }
}
