using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The archer base attack and defend mechanics werent changed but added an ability to attack two enemies instead of just one.
    //The archer arrows has a unique ability each arrow has a number written on it when shot the number thats written get added as damage against the unit.
    class Archer : PhysicalAttackUnit
    {
        public IRandomProvider BonusDamage { get; protected set; }

        public Archer()
        {
            this.Type = "Archer";
            this.race = Race.Elf;
            this.Damage = new Dice(1, 12, 5);
            this.BonusDamage = new Bag(6);
            this.HP = 40;
            this.critChance = 0.2f;
            this.HitChance = new Dice(1, 14, 0);
            this.DefenseChance = new Dice(1, 6, 0);
            this.Capacity = 10;
        }

        public override void ApplyDamage(int damage)
        {
            damage = CritChance();
            damage += BonusDamage.RandomNumber();
            HP -= damage;
        }

        public virtual void DoubleShot(Unit defender1, Unit defender2)
        {
            defender1.Defend(this);
            defender2.Defend(this);
        }
    }
}
