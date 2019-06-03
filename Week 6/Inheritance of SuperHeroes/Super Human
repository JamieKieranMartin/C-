using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes
{
    class Super_Human : SuperHero
    {
        private int sumOfPowers;
        private List<SuperPower> powerSet;
        private List<SuperPower> oldPowerSet;

        public Super_Human(string name, string secretId, List<SuperPower> powers) : base(name, secretId)
        {
            powerSet = powers;
        }

        public override bool HasPower(SuperPower whatPower)
        {
            if (this.powerSet.Contains(whatPower))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int TotalPower()
        {
            this.sumOfPowers = 0;
            foreach (int power in this.powerSet)
            {
                this.sumOfPowers += power;
            }
            return this.sumOfPowers;
        }

        public void AddSuperPower(SuperPower newPower)
        {
            if (!this.powerSet.Contains(newPower))
            {
                this.powerSet.Add(newPower);
                this.sumOfPowers = TotalPower();
            }
            
        }

        public void LoseSinglePower(SuperPower power)
        {
            if (this.powerSet.Contains(power))
            {
                this.powerSet.Remove(power);
                this.sumOfPowers = TotalPower();
            }
        }

        public void LoseAllSuperPowers()
        {
            this.oldPowerSet = powerSet;
            this.powerSet.Clear();
            this.sumOfPowers = TotalPower();
        }
    }
}
