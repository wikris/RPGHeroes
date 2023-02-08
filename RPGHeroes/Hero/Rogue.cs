using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Rogue:Hero
    {
        private HeroAttribute attributes = new HeroAttribute(2, 6, 1);
        public Rogue(string name) : base(name)
        {
            this.Name = name;
        }

        public override void LevelUp()
        {
            this.Level++;
            this.Attributes += new HeroAttribute(1,4,1);
        }

    }
}
