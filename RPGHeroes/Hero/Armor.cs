using RPGHeroes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Armor : Item
    {
        public HeroAttribute ArmorAttribute { get; set; }
        public ArmorType ArmorType{ get; set; }

        // Creates new Armor
        public Armor(string name, int requiredLevel, Slots slot, ArmorType armorType, HeroAttribute armorAttributes) : base(name, requiredLevel, slot)
        {
            this.ArmorAttribute = armorAttributes;
            this.ArmorType = armorType;
        }
    }
}