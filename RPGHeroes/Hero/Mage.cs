using RPGHeroes.enums;
using RPGHeroes.exceptions;
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
            this.LevelAttributes = new HeroAttribute(1, 1, 8);
            this.ValidWeaponTypes = new WeaponType[] { WeaponType.Staff, WeaponType.Wand };
            this.ValidArmorTypes = new ArmorType[] { ArmorType.Cloth };
            //this.ValidArmorTypes = new string[] { ArmorType.Cloth.ToString() };
        }

        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(1, 1, 5);
            this.LevelAttributes += levelingUpHeroAttribute;
        }

        
    }
}