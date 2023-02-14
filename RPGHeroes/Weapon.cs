using RPGHeroes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Weapon : Item
    {
        private int WeaponDamage { get; set; }
        public WeaponType type { get; set; }
        public Weapon(string name, int requiredLevel, WeaponType weaponType, int damage) : base(name,requiredLevel)
        { 
            this.type = weaponType;
            this.WeaponDamage = damage;
            this.Slot = Slots.Weapon;
        }
    }
}
