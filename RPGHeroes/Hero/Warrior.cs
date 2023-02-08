using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Warrior:Hero
    {
        private HeroAttribute attributes = new HeroAttribute(5, 2, 1);
        public Warrior(string name) : base(name)
        {
            this.Name = name;
        }

        public override void LevelUp()
        {
            this.Level++;
            this.Attributes = new HeroAttribute(3,2,1);
        }
    }
}
