using RPGHeroes.enums;
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
            this.LevelAttributes = new HeroAttribute(1, 7, 1);
            //this.ValidWeaponTypes = new string[] { WeaponType.Bow.ToString() };
            //this.ValidArmorTypes = new string[] { ArmorType.Leather.ToString(), ArmorType.Mail.ToString() };
        }

        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(1, 5, 1);
            this.LevelAttributes += levelingUpHeroAttribute;
        }
    }
}
