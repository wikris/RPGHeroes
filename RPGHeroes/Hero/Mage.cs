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
        // Creating Hero type of Mage
        public Mage(string name) : base(name)
        {
            this.Name = name;
            this.LevelAttributes = new HeroAttribute(1, 1, 8);
            this.ValidWeaponTypes = new WeaponType[] { WeaponType.Staff, WeaponType.Wand };
            this.ValidArmorTypes = new ArmorType[] { ArmorType.Cloth }; 
        }

        // Levels up heros current level and LevelAttributes
        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(1, 1, 5);
            this.LevelAttributes += levelingUpHeroAttribute;
        }

        // Calculates how much Damage Hero does
        public override double Damage()
        {
            var equippedWeapon = Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();

            if(equippedWeapon.Length == 0)
            {
                return 1;
            }
            
            double HeroDamage = Math.Round(equippedWeapon[0].WeaponDamage * (1 + (double)TotalAttributes().Intelligence / (double)100), 2);
            
            return HeroDamage;
        }
    }
}