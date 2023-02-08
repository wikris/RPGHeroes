using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Hero
    {
        protected string heroName;
        protected int level = 1;
        protected double LevelAttributes;
        protected string[] equipment = new string[2];

        public Hero(string name)
        {
            this.heroName = name;
        }

        public void LevelUp()
        {
            this.level++;
        }

        public void Equip(string armor)
        {
            
        }

        public void Equip(string[] weapons)
        {

        }

        public void TotalAttributes()
        {

        }

        public void Display()
        {

        }
    }
}
