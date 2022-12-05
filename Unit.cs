using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    abstract class Unit 
    {
        public string Type { get; protected set; }
        public IRandomProvider Damage { get; protected set; }
        public int HP { get; protected set; }
        public Race race { get; protected set; }
        public IRandomProvider HitChance { get; protected set; }
        public IRandomProvider DefenseChance { get;  protected set; }
        public int Capacity { get; protected set; }
        public bool IsDead => HP < 0;

        public enum Race
        {
            Elf,
            Human,
            Cyborg
        }

        public virtual void Attack(Unit defender)
        {
            if (HitChance.RandomNumber() >= defender.DefenseChance.RandomNumber())
            {
                defender.Defend(this);
            }
        }

        public virtual void Defend(Unit attacker)
        {
            if (HitChance.RandomNumber() >= attacker.DefenseChance.RandomNumber())
            {
                attacker.ApplyDamage(Damage.RandomNumber());
            }
        }

        public virtual void ApplyDamage(int damage)
        {
            HP -= damage;
        }
    }
}