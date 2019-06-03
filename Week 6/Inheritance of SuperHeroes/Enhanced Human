using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes
{
    class Enhanced_Human : SuperHero
    {
        private int sumOfPowers;
        private bool enhanced = false;
        private List<SuperPower> powerSet;

        public Enhanced_Human(string name, string secretId, List<SuperPower> powers) : base(name, secretId)
        {
            powerSet = powers;
        }

        public override void SwitchIdentity()
        {
            base.SwitchIdentity();
            enhanced = !enhanced;
        }

        public override bool HasPower(SuperPower whatPower)
        {
            if (enhanced && this.powerSet.Contains(whatPower))
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
            if (enhanced)
            {
                foreach (int power in powerSet)
                {
                    this.sumOfPowers += power;
                }
                return this.sumOfPowers;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
