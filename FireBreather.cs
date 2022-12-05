using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //After each time the FireBreather attacks he heats up adding more damage to the next attack.
    class FireBreather : MagicalAttackUnit
    {
        public FireBreather()
        {
           this.Type = "FireBreather";
           this.race = Race.Human;
           this.Damage = new Dice(1,10,4);
           this.HP = 30;
           this.Mana = 50;
           this.HitChance = new Dice(1, 8, 0);
           this.DefenseChance = new Dice(1, 6, 0);
           this.Capacity = 12;
        }

        public override void Attack(Unit defender)
        {
            int modifier = 0;

            if (ManaCheck())
            {
                Damage.RandomNumber();
                Mana -= 5;
                modifier += 2;
                this.Damage = new Dice(1,10,modifier);
            }
            else
                Damage = new Dice(1, 5, 0);

            defender.Defend(this);
        }
    }
}
