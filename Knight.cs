using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The knight take half damage from all attacks.
    class Knight : PhysicalAttackUnit
    {
        public Knight()
        {
            this.Type = "Knight";
            this.race = Race.Human;
            this.Damage = new Dice(1,8,2);
            this.HP = 65;
            this.critChance = 0.2f;
            this.HitChance = new Dice(1, 6, 0);
            this.DefenseChance = new Dice(1, 8, 0);
            this.Capacity = 15;
        }

        public override void Defend(Unit attacker)
        {
            if (HitChance.RandomNumber() >= attacker.DefenseChance.RandomNumber())
            {
                attacker.ApplyDamage(Damage.RandomNumber() / 2);
            }
        }
    }
}
