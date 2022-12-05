using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //When the samurai go below the set health threshold he deals double the damage.
    class Samurai : PhysicalAttackUnit
    {
        public Samurai()
        {
            this.Type = "Samurai";
            this.race = Race.Cyborg;
            this.Damage = new Dice(1, 10, 4);
            this.HP = 50;
            this.critChance = 1f;
            this.HitChance = new Dice(1, 12, 0);
            this.DefenseChance = new Dice(1, 5, 0);
            this.Capacity = 14;
        }

        public override void Attack(Unit defender)
        {
            if (this.HP <= 15)
            {
                this.Damage = new Dice(2, 10, 0);
            }

            defender.Defend(this);
        }
    }
}
