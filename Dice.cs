using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    struct Dice : IRandomProvider
    {
         uint Scalar;
         uint BaseDie;
         int Modifier;

        public Dice(uint scalar, uint baseDie, int modifier)
        {
            this.Scalar = scalar;
            this.BaseDie = baseDie;
            this.Modifier = modifier;
        }

        public int RandomNumber()
        {
            int roll = Modifier;

            return roll + Random.Shared.Next((int)Scalar, (int)(BaseDie * Scalar));
        }

        public override string ToString()
        {
            return Scalar + "d" + BaseDie + "" + (Modifier >= 0 ? "+" : "-") + Modifier;
        }

        public override bool Equals(object obj)
        {
            Dice dice = (Dice)obj;
            return Scalar == dice.Scalar && BaseDie == dice.BaseDie && Modifier == dice.Modifier;
        }
    }
}
