using RPGHeroes.enums;
using RPGHeroes.exceptions;
using RPGHeroes.Hero;
using System.Reflection.Emit;

public class Program
   {
   static void Main(string[] args)
      {
        Mage marco = new Mage("Marco");
        marco.LevelUp();
        marco.EquipWeapon("Common Staff", 1, Slots.Weapon, WeaponType.Wand, 12);
        marco.EquipArmor("Standard Helmet", 1, Slots.Head, ArmorType.Cloth, new HeroAttribute(1, 2, 1));
        marco.EquipArmor("Super Body Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(10, 10, 10));   
        Console.WriteLine("Total damage: " + marco.Damage());
        Console.WriteLine(marco.Display());

        Ranger heikki = new Ranger("Heikki");
        heikki.LevelUp();
        heikki.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 21);
        heikki.EquipArmor("Super Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(13, 14, 15));
        Console.WriteLine("Total damage: " + heikki.Damage());
        Console.WriteLine(heikki.Display());

        Rogue late = new Rogue("Late");
        late.LevelUp();
        late.EquipWeapon("Basic Sword", 1, Slots.Weapon, WeaponType.Dagger, 3);
        late.EquipArmor("Super Chestplate", 1, Slots.Body, ArmorType.Leather, new HeroAttribute(5, 8, 9));
        Console.WriteLine("Total damage: " + late.Damage());
        Console.WriteLine(late.Display());


        Warrior maximus = new Warrior("Maximus");
        maximus.LevelUp();
        maximus.EquipWeapon("Golden Axe", 1, Slots.Weapon, WeaponType.Axe, 34);
        maximus.EquipArmor("Fighting Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(4, 7, 8));
        Console.WriteLine("Total damage: " + maximus.Damage());
        Console.WriteLine(maximus.Display());
    }
}