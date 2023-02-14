using RPGHeroes.enums;
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
            //this.ValidWeaponTypes = new string[] { WeaponType.Dagger.ToString(), WeaponType.Sword.ToString() };
           //this.ValidArmorTypes = new string[] { ArmorType.Leather.ToString(), ArmorType.Mail.ToString() };
        }

        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(1, 4, 1);
            this.LevelAttributes += levelingUpHeroAttribute;
        }

    }
}
