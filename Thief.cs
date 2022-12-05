using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The Thief can evade enemy attacks.
    class Thief : PhysicalAttackUnit
    {
        public virtual float EvadeChance { get; protected set; }

        public Thief()
        {
            this.Type = "Thief";
            this.race = Race.Elf;
            this.Damage = new Dice(1, 10, 4);
            this.HP = 35;
            this.critChance = 0.25f;
            this.EvadeChance = 0.2f;
            this.HitChance = new Dice(1, 10, 0);
            this.DefenseChance = new Dice(1, 4, 0);
            this.Capacity = 20;
        }

        public bool Evade()
        {
            Random rand = new Random();

            if (rand.NextDouble() <= EvadeChance)
                return true;
            else
                return false;
        }

        public override void Defend(Unit attacker)
        {
            if (!Evade())
            {
                if (HitChance.RandomNumber() >= attacker.DefenseChance.RandomNumber())
                {
                    attacker.ApplyDamage(Damage.RandomNumber());
                }
            }
        }
    }
}
