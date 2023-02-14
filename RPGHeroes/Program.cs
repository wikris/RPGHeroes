using RPGHeroes.enums;
using RPGHeroes.exceptions;
using RPGHeroes.Hero;
public class Program
   {
   static void Main(string[] args)
      {
        Mage marko = new Mage("marco");

        marko.EquipWeapon("Common Staff", 1, WeaponType.Wand, 12);
        marko.EquipArmor("Standard Helmet", 1, ArmorType.Cloth, new HeroAttribute(1, 2, 1), Slots.Head);

        Console.WriteLine(marko.Equipment[Slots.Head].RequiredLevel);

      }
}