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

        // Creating Hero
        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.Equipment = new Dictionary<Slots, Item?>();
        }

        // Levels up heros current level and LevelAttributes
        public virtual void LevelUp() {}

        // Equips new Weapon to Hero
        public void EquipWeapon(string name, int requiredLevel, Slots slot, WeaponType type, int damage) 
        {
            
            if (Level < requiredLevel)
            {
                throw new InvalidRequiredLevelException();
            }
            
            if (ValidWeaponTypes.Contains(type) && Level >= requiredLevel)
            {
                if (Equipment.ContainsKey(Slots.Weapon))
                {
                    AddNewWeaponToEquipment(name, requiredLevel, slot, type, damage);
                }
                else
                {
                    AddNewWeaponToEquipment(name, requiredLevel, slot, type, damage);
                }
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        // Equips new Armor to Hero
        public void EquipArmor(string name, int requiredLevel, Slots slot, ArmorType type, HeroAttribute armorAttribute)
        {
            
            if (Level < requiredLevel)
            {
                throw new InvalidRequiredLevelException();
            }

            if (ValidArmorTypes.Contains(type) && Level >= requiredLevel)
            {
                if (slot == Slots.Body)
                {
                    if (Equipment.ContainsKey(Slots.Body))
                    {
                        this.Equipment[Slots.Body] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute); 
                    }
                    else
                    {
                        this.Equipment[Slots.Body] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute);
                    }
                    
                }
                else if (slot == Slots.Legs)
                {
                    if (Equipment.ContainsKey(Slots.Legs))
                    {
                        this.Equipment[Slots.Legs] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute);
                    }
                    else
                    {
                        this.Equipment[Slots.Legs] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute);
                    }
                }
                else if (slot == Slots.Head)
                {
                    if (Equipment.ContainsKey(Slots.Head))
                    {
                        this.Equipment[Slots.Head] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute);
                    }
                    else
                    {
                        this.Equipment[Slots.Head] = AddNewArmorToEquipment(name, requiredLevel, slot, type, armorAttribute);
                    }
                } 
            }
            else
            {
                throw new InvalidArmorException();
            }
        }

        // Calculates how much Damage Hero does
        public virtual double Damage() 
        {
            return 1;
        }

        // Calculates value of Hero's total attributes 
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

        // Displays Hero's information
        public string Display()
        {
            return $"Hero Name: {this.Name} \nHero Class: {this.GetType().Name} \nHero Level: {this.Level} \nHero's total strength: {this.TotalAttributes().Strength} \nHero's total Dexterity: {this.TotalAttributes().Dexterity} \nHero's total intelligence: {this.TotalAttributes().Intelligence} \nHero's total damage: {this.Damage()}\n";
        }

        // Creates and adds a new Weapon to specific slot
        private Weapon AddNewWeaponToEquipment(string name, int requiredLevel, Slots slot, WeaponType type, int damage)
        {
            Console.WriteLine("Weapon Equipped!");
            Weapon newWeapon = new Weapon(name, requiredLevel, slot, type, damage);
            this.Equipment[Slots.Weapon] = newWeapon;
            return newWeapon;
        }

        // Creates new armor
        private Armor AddNewArmorToEquipment(string name, int requiredLevel, Slots slot, ArmorType type, HeroAttribute armorAttribute)
        {
            Console.WriteLine("Armor Equipped!");
            Armor newArmor = new Armor(name, requiredLevel, slot, type, armorAttribute);
            return newArmor;
        }
    }
}
