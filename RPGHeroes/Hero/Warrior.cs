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
        // Creating Hero type of Warrior
        public Warrior(string name) : base(name)
        {
            this.Name = name;
            this.LevelAttributes = new HeroAttribute(5, 2, 1);
            this.ValidWeaponTypes = new WeaponType[] { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword };
            this.ValidArmorTypes = new ArmorType[] { ArmorType.Mail, ArmorType.Plate };
        }

        // Levels up heros current level and LevelAttributes
        public override void LevelUp()
        {
            this.Level++;
            HeroAttribute levelingUpHeroAttribute = new HeroAttribute(3, 2, 1);
            this.LevelAttributes += levelingUpHeroAttribute;
        }

        // Calculates how much Damage Hero does
        public override double Damage()
        {
            var equippedWeapon = Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();

            if (equippedWeapon.Length == 0)
            {
                return 1;
            }

            double damage = Math.Round(equippedWeapon[0].WeaponDamage * (1 + (double)TotalAttributes().Strength / (double)100), 2);

            return damage;
        }
    }
}
