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
        HeroAttribute ArmorAttribute { get; set; }
        public ArmorType ArmorType{ get; set; }

        public Armor(string name, int requiredLevel, ArmorType armorType, HeroAttribute armorAttributes, Slots slot) : base(name, requiredLevel)
        {
            this.ArmorAttribute = armorAttributes;
            this.ArmorType = armorType;
        }
    }
}