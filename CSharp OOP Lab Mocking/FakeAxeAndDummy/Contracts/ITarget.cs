using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Contracts
{
    public interface ITarget
    {
        public int GiveExperience();
        public void TakeAttack(int attackPoints);
        int Health { get; }
        public bool IsDead();
    }
}
