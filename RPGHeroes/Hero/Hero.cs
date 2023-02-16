using RPGHeroes.enums;
using RPGHeroes.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using RPGHeroes;
using RPGHeroes.exceptions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace RPGHeroes.Hero
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttribute LevelAttributes { get; set; }
        public Dictionary<Slots, Item?> Equipment  { get; set; }
        public WeaponType[] ValidWeaponTypes { get; set; }
        public ArmorType[] ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.Equipment = new Dictionary<Slots, Item?>();
        }

        public virtual void LevelUp() {}

        public void EquipWeapon(string name, int requiredLevel, Slots slot, WeaponType type, int damage) 
        {
            try
            {
                if (Level < requiredLevel)
                {
                    throw new InvalidRequiredLevelException();
                }
            }
            catch (InvalidRequiredLevelException exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            try
            {
                if (ValidWeaponTypes.Contains(type) && Level >= requiredLevel)
                {
                    Console.WriteLine("Weapon Equipped!");
                    Weapon newWeapon = new Weapon(name, requiredLevel, slot, type, damage);
                    this.Equipment.Add(Slots.Weapon, newWeapon);
                }
                else
                {
                    throw new InvalidWeaponException();
                }
            }
            catch (InvalidWeaponException ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        public void EquipArmor(string name, int requiredLevel, Slots slot, ArmorType type, HeroAttribute armorAttribute)
        {
            try
            {
                if (Level < requiredLevel)
                {
                    throw new InvalidRequiredLevelException();
                }
            }
            catch (InvalidRequiredLevelException exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            try
            {
                if (ValidArmorTypes.Contains(type) && Level >= requiredLevel)
                {
                    if(slot == Slots.Body)
                    {
                        this.Equipment.Add(Slots.Body, addNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute));
                    }
                    else if(slot == Slots.Legs)
                    {
                        this.Equipment.Add(Slots.Legs, addNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute));
                    }
                    else if(slot == Slots.Head)
                    {
                        this.Equipment.Add(Slots.Head, addNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute));
                    }
                }
                else
                {
                    throw new InvalidArmorException();
                }
            }
            catch (InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual double Damage() 
        {
            return 1;
        }

        public HeroAttribute TotalAttributes()
        {
            HeroAttribute totalAttibutes = new HeroAttribute(0,0,0);
            totalAttibutes += this.LevelAttributes;

            var armorSlots = Equipment.Where(kvp => kvp.Key != Slots.Weapon).Select(kvp => (Armor?)kvp.Value).ToArray();

            for(int i = 0; i < armorSlots.Length; i++)
            {
                totalAttibutes += armorSlots[i].ArmorAttribute;
            }

            return totalAttibutes;
        }

        public string Display()
        {
            return $"Hero Name: {this.Name} \nHero Class: {this.GetType().Name} \nHero Level: {this.Level} \nHero's total strength: {this.TotalAttributes().Strength} \nHero's total Dexterity: {this.TotalAttributes().Dexterity} \nHero's total intelligence: {this.TotalAttributes().Intelligence} \nHero's total damage: {this.Damage()}\n";
        }

        private Armor addNewArmorToEquipment(string name, int requiredLevel, Slots slot, ArmorType type, HeroAttribute armorAttribute)
        {
            Console.WriteLine("Armor Equipped!");
            Armor newArmor = new Armor(name, requiredLevel, slot, type, armorAttribute);
            return newArmor;
        }
    }
}
