﻿using RPGHeroes.enums;
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
            this.ValidWeaponTypes = new WeaponType[] { WeaponType.Bow };
            this.ValidArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        }

        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(1, 5, 1);
            this.LevelAttributes += levelingUpHeroAttribute;
        }

        public override double Damage()
        {
            var equippedWeapon = Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();

            if (equippedWeapon.Length == 0)
            {
                return 1;
            }

            double damage = Math.Round(equippedWeapon[0].WeaponDamage * (1 + (double)TotalAttributes().Dexterity / (double)100), 2);

            return damage;
        }
    }
}
