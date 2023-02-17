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
        public int WeaponDamage { get; set; }
        public WeaponType type { get; set; }
        
        // Creates new Weapon
        public Weapon(string name, int requiredLevel, Slots slot, WeaponType weaponType, int damage) : base(name,requiredLevel, slot)
        { 
            this.type = weaponType;
            this.WeaponDamage = damage;
            this.Slot = Slots.Weapon;
        }
    }
}
