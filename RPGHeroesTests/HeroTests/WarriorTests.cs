using RPGHeroes.enums;
using RPGHeroes;
using RPGHeroes.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RPGHeroes.exceptions;

namespace RPGHeroesTests.HeroTests
{
    public class WarriorTests
    {
        Hero warrior = new Warrior("Maximus");

        [Fact]
        public void Warrior_CreatingWarriorShouldAddCorrectName()
        {
            // Arrange
            string expected = "Maximus";

            // Act
            var actual = warrior.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_CreatingWarriorShouldAddHerousLevelForOne()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = warrior.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_CreatingWarriorShouldAddCorrectStartingStrengthToLevelAttributes()
        {
            // Arrenge
            int expected = 5;

            // Act
            var actual = warrior.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_CreatingWarriorShouldAddCorrectStartingDexterityToLevelAttributes()
        {
            // Arrenge
            int expected = 2;

            // Act
            var actual = warrior.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_CreatingWarriorShouldAddCorrectStartingIntelligenceToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = warrior.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_IncreasingWarriorsLevelByOneShouldReturnCurrentLevelPlusOne()
        {
            // Arrenge
            int expected = 2;

            // Act
            warrior.LevelUp();
            var actual = warrior.Level;

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeStrength()
        {
            // Arrenge
            int expected = 8;

            // Act
            warrior.LevelUp();
            var actual = warrior.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeDexterity()
        {
            // Arrenge
            int expected = 4;

            // Act
            warrior.LevelUp();
            var actual = warrior.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeIntelligence()
        {
            // Arrenge
            int expected = 2;

            // Act
            warrior.LevelUp();
            var actual = warrior.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectName()
        {
            // Arrenge
            string expected = "Basic Hammer";

            // Act
            warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Hammer, 21);
            var actual = warrior.Equipment[Slots.Weapon]?.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Hammer, 21);
            var actual = warrior.Equipment[Slots.Weapon]?.RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Weapon;

            // Act
            warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Hammer, 21);
            var equippedWeapon = warrior.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0]?.Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectWeaponType()
        {
            // Arrenge
            WeaponType expected = WeaponType.Hammer;

            // Act
            warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Hammer, 21);
            var equippedWeapon = warrior.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0]?.type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectDamage()
        {
            // Arrenge
            int expected = 21;

            // Act
            warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Hammer, 21);
            var equippedWeapon = warrior.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0]?.WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectName()
        {
            // Arrenge
            string expected = "Hyperior Boots";

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.Equipment[Slots.Legs].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.Equipment[Slots.Legs].RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Legs;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.Equipment[Slots.Legs].Slot;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorArmorType()
        {
            // Arrenge
            ArmorType expected = ArmorType.Plate;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var equippedArmor = warrior.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorType;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeStrength()
        {
            // Arrenge
            int expected = 19;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var equippedArmor = warrior.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeDexterity()
        {
            // Arrenge
            int expected = 16;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var equippedArmor = warrior.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeIntelligence()
        {
            // Arrenge
            int expected = 22;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var equippedArmor = warrior.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_IfHerosLevelTooLowShouldThrowInvalidRequiredLevelException()
        {
            // Arrenge
            string expected = "Exception: Hero's required level for item is too low.";
           
            // Act & Assert
            Assert.Throws<InvalidRequiredLevelException>(() => warrior.EquipWeapon("Basic Hammer", 4, Slots.Weapon, WeaponType.Hammer, 21)).ToString();
        }

        [Fact]
        public void EquipWeapon_IfWeaponTypeIsWrongForHeroShouldThrowInvalidWeaponException()
        {
            // Arrenge
            string expected = "Exception: Invalid weapon type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon("Basic Hammer", 1, Slots.Weapon, WeaponType.Bow, 21)).ToString();
        }

        [Fact]
        public void EquipArmor_IfHerosLevelTooLowShouldThrowInvalidRequiredLevelException()
        {
            // Arrenge
            string expected = "Exception: Hero's required level for item is too low.";

            // Act & Assert
            Assert.Throws<InvalidRequiredLevelException>(() => warrior.EquipArmor("Hyperior Boots", 6, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22))).ToString();
        }

        [Fact]
        public void EquipWeapon_IfArmorTypeIsWrongForHeroShouldThrowInvalidArmorException()
        {
            // Arrenge
            string expected = "Exception: Invalid armor type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Cloth, new HeroAttribute(19, 16, 22))).ToString();
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeStrength()
        {
            // Arrenge
            int expected = 5;

            // Act
            var actual = warrior.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeDexterity()
        {
            // Arrenge
            int expected = 2;

            // Act
            var actual = warrior.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeIntelligence()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = warrior.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 24;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 18;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 23;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            var actual = warrior.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 25;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPieceseOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 20;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 24;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 6;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 4;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 2;

            // Act
            warrior.EquipArmor("Hyperior Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(19, 16, 22));
            warrior.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(1, 2, 1));
            var actual = warrior.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithoutEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 35.7;

            // Act
            warrior.EquipWeapon("Golden Axe", 1, Slots.Weapon, WeaponType.Axe, 34);
            var actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithReplaceddWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 26.25;

            // Act
            warrior.EquipWeapon("Golden Axe", 1, Slots.Weapon, WeaponType.Axe, 34);
            warrior.EquipWeapon("Fire Sword", 1, Slots.Weapon, WeaponType.Sword, 25);
            var actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponAndEquippedArmorShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 37.06;

            // Act
            warrior.EquipWeapon("Golden Axe", 1, Slots.Weapon, WeaponType.Axe, 34);
            warrior.EquipArmor("Fighting Boots", 1, Slots.Legs, ArmorType.Plate, new HeroAttribute(4, 7, 8));
            var actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Display_DisplaysHerosStateShouldGiveCorrectInformation()
        {

            // Arrenge
            string expected = "Hero Name: Maximus \nHero Class: Warrior \nHero Level: 1 \nHero's total strength: 5 \nHero's total Dexterity: 2 \nHero's total intelligence: 1 \nHero's total damage: 1\n";

            // Act
            var actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
