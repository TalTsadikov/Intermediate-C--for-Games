using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The Engineer knows machine so well he knows where their weak points are and attacks them dealing extra damage.
    class Engineer : PhysicalAttackUnit
    {
        public Engineer()
        {
            this.Type = "Engineer";
            this.race = Race.Cyborg;
            this.Damage = new Dice(1, 8, 3);
            this.HP = 75;
            this.critChance = 0.1f;
            this.HitChance = new Dice(1, 10, 0);
            this.DefenseChance = new Dice(1, 6, 0);
            this.Capacity = 17;
        }

        public override void Attack(Unit defender)
        {
            if (defender.race is Race.Cyborg)
            {
                this.Damage = new Dice(1, 15, 0);
                this.critChance = 0.5f;
            }

            defender.Defend(this);
        }
    }
}
