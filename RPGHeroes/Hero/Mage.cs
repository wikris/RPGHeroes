using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Mage:Hero
    {
        public Mage(string name) : base(name)
        {
            this.Name = name;
            this.Attributes = new HeroAttribute(1, 1, 8);
        }

        public override void LevelUp()
        {
            this.Level++;
            this.Attributes += new HeroAttribute(1, 1, 5);
        }

    }
}
