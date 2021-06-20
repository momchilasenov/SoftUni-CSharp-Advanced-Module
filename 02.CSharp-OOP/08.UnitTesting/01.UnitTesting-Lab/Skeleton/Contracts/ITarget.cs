using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface ITarget
    {
        public bool IsDead();

        int GiveExperience();

        void TakeAttack(int attackPoints);
    }
}
