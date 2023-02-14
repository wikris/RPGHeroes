using RPGHeroes.enums;
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
            //this.ValidWeaponTypes = new string[] { WeaponType.Axe.ToString(), WeaponType.Hammer.ToString(), WeaponType.Sword.ToString() };
            //this.ValidArmorTypes = new string[] { ArmorType.Mail.ToString(), ArmorType.Plate.ToString() };
        }

        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(3, 2, 1);
            this.LevelAttributes += levelingUpHeroAttribute;
        }
    }
}
