using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The monk has the ability to heal.
    class Monk : MagicalAttackUnit
    {
        public Monk()
        {
            this.Type = "Monk";
            this.race = Race.Cyborg;
            this.Damage = new Dice(1, 5, 2);
            this.HP = 70;
            this.Mana = 45;
            this.HitChance = new Dice(1, 6, 0);
            this.DefenseChance = new Dice(1, 6, 0);
            this.Capacity = 10;
        }

        public void Heal() 
        {
            if (ManaCheck())
            {
                HP += 10;
                Mana -= 15;
            }
        }
    }
}
