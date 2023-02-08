using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Ranger:Hero
    {
        public Ranger(string name) : base(name)
        {
            this.Name = name;
            this.Attributes = new HeroAttribute(1, 7, 1);
        }

        public override void LevelUp()
        {
            this.Level++;
            this.Attributes += new HeroAttribute(1,5,1);
        }
    }
}
