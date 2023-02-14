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
        public Dictionary<Slots, Item> Equipment { get; set; }
        //public int[] ValidWeaponTypes { get; set; } tällä toimi sama EquipWeapon methodissa
        public WeaponType[] ValidWeaponTypes { get; set; }
        //public string[] ValidArmorTypes { get; set; }
        public ArmorType[] ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.Equipment = new Dictionary<Slots, Item>();
        }

        public virtual void LevelUp() {}

        public void EquipWeapon(string name, int requiredLevel, WeaponType type, int damage) 
        {
                try
                {
                    if (ValidWeaponTypes.Contains(type) && Level >= requiredLevel)
                    {
                        Console.WriteLine("Weapon Equipped!");
                        Weapon newWeapon = new Weapon(name, requiredLevel, type, damage);
                        this.Equipment.Add(Slots.Weapon, newWeapon);
                        //Console.WriteLine(Equipment[Slots.Weapon].Name);
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

        public void EquipArmor(string name, int requiredLevel, ArmorType type, HeroAttribute armorAttribute, Slots slot)
        {
            try
            {
                if (ValidArmorTypes.Contains(type) && Level >= requiredLevel)
                {
                    if(slot == Slots.Body)
                    {
                        //Console.WriteLine("Armor Equipped!");
                        //Armor newArmor = new Armor(name, requiredLevel, type, armorAttribute, slot);
                        //this.Equipment.Add(Slots.Body, newArmor);
                        this.Equipment.Add(Slots.Body, addNewArmorToEquipment(name, requiredLevel, type, armorAttribute, slot));
                    }
                    else if(slot == Slots.Legs)
                    {
                        //Console.WriteLine("Armor Equipped!");
                        //Armor newArmor = new Armor(name, requiredLevel, type, armorAttribute, slot);
                        this.Equipment.Add(Slots.Legs, addNewArmorToEquipment(name, requiredLevel, type, armorAttribute, slot));
                    }
                    else if(slot == Slots.Head)
                    {
                        this.Equipment.Add(Slots.Head, addNewArmorToEquipment(name, requiredLevel, type, armorAttribute, slot));
                    }
                    
                    //Console.WriteLine(Equipment[Slots.Weapon].Name);
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

        public void Damage(int damage)
        {

        }

        //public int TotalAttributes()
        //{
        //    Item headArmor;
        //    Equipment.TryGetValue(Slots.Head, out headArmor);
        //    return LevelAttributes + headArmor.ArmoAttribute;
        //}

        public void Display()
        {

        }

        public Armor addNewArmorToEquipment(string name, int requiredLevel, ArmorType type, HeroAttribute armorAttribute, Slots slot)
        {
            Console.WriteLine("Armor Equipped!");
            Armor newArmor = new Armor(name, requiredLevel, type, armorAttribute, slot);
            return newArmor;
        }
    }
}
