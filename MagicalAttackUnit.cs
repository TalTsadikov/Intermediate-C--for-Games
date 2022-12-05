using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    //For Magical Units added mana for their attacks.
    abstract class MagicalAttackUnit : Unit
    {
        public virtual int Mana { get; protected set; }

        protected bool ManaCheck()
        {
            return Mana >= 1;
        }
    }
}
