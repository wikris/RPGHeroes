using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttribute Attributes { get; set; }
        public string[] Equipment { get; set; }
        public string[] ValidWeaponTypes { get; set; }
        public string[] ValidArmorTyp { get; set; }


        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
        }

        public virtual void LevelUp() {}

        public void Equip(string armor)
        {

        }

        public void Equip(string[] weapons)
        {

        }

        public void Damage(int damage)
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
