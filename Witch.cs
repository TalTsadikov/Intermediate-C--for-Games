using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //The witch can control the enemy making him attack himself.
    class Witch : MagicalAttackUnit
    {
        public Witch()
        {
            this.Type = "Witch";
            this.race = Race.Elf;
            this.Damage = new Dice(1, 12, 5);
            this.HP = 40;
            this.Mana = 60;
            this.HitChance = new Dice(1, 8, 0);
            this.DefenseChance = new Dice(1, 5, 0);
            this.Capacity = 15;
        }
       
        public override void Attack(Unit defender)
        {
            if (ManaCheck())
                defender.Defend(defender);
            else
                defender.Defend(this);
        }
    }
}
