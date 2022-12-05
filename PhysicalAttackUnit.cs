using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //For physical units added Crit chance to multiply damage.
    abstract class PhysicalAttackUnit : Unit
    {
        public virtual float critChance { get; protected set; }

        public virtual int CritChance()
        {
            Random rand = new Random();
            int damage = Damage.RandomNumber();

            if (rand.NextDouble() <= critChance)
                damage *= 2;

            return damage;
        }

        public override void Defend(Unit attacker)
        {
            if (HitChance.RandomNumber() >= attacker.DefenseChance.RandomNumber())
            {
                attacker.ApplyDamage(Damage.RandomNumber());
            }
        }

        public override void ApplyDamage(int damage)
        {
            damage = CritChance();
            HP -= damage;
        }
    }
}
