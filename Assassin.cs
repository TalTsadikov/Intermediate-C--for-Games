using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The assassin crit multiplier is higher then the other units and attacks twice.
    class Assassin : PhysicalAttackUnit
    {
        public Assassin()
        {
            this.Type = "Assassin";
            this.race = Race.Human;
            this.Damage = new Dice(1, 12, 5);
            this.HP = 30;
            this.critChance = 0.3f;
            this.HitChance = new Dice(1, 14, 0);
            this.DefenseChance = new Dice(1, 3, 0);
            this.Capacity = 13;
        }

        public override int CritChance()
        {
            Random rand = new Random();
            int damage = Damage.RandomNumber();

            if (rand.NextDouble() <= critChance)
                damage *= 3;

            return damage;
        }

        public override void Attack(Unit defender)
        {
            defender.Defend(this);
            defender.Defend(this);
        }
    }
}
