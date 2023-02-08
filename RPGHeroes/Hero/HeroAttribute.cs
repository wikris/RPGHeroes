using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public static HeroAttribute operator +(HeroAttribute lhs, HeroAttribute rhs)
        {
            return new HeroAttribute (lhs.Strength + rhs.Strength, lhs.Dexterity + rhs.Dexterity, lhs.Intelligence + rhs.Intelligence );
        }
    }
}
