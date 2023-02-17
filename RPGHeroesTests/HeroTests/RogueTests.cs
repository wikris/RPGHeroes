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
    public class RogueTests
    {
        Hero rogue = new Rogue("Ralph");

        [Fact]
        public void Rogue_CreatingRogueShouldAddCorrectName()
        {
            // Arrange
            string expected = "Ralph";

            // Act
            var actual = rogue.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_CreatingRogueShouldAddHerousLevelForOne()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = rogue.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_CreatingRogueShouldAddCorrectStartingStrengthToLevelAttributes()
        {
            // Arrenge
            int expected = 2;

            // Act
            var actual = rogue.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_CreatingRogueShouldAddCorrectStartingDexterityToLevelAttributes()
        {
            // Arrenge
            int expected = 6;

            // Act
            var actual = rogue.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_CreatingRogueShouldAddCorrectStartingIntelligenceToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = rogue.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_IncreasingRoguesLevelByOneShouldReturnCurrentLevelPlusOne()
        {
            // Arrenge
            int expected = 2;

            // Act
            rogue.LevelUp();
            var actual = rogue.Level;

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeStrength()
        {
            // Arrenge
            int expected = 3;

            // Act
            rogue.LevelUp();
            var actual = rogue.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeDexterity()
        {
            // Arrenge
            int expected = 10;

            // Act
            rogue.LevelUp();
            var actual = rogue.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeIntelligence()
        {
            // Arrenge
            int expected = 2;

            // Act
            rogue.LevelUp();
            var actual = rogue.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectName()
        {
            // Arrenge
            string expected = "Mighty Sword";

            // Act
            rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Sword, 34);
            var actual = rogue.Equipment[Slots.Weapon].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Sword, 34);
            var actual = rogue.Equipment[Slots.Weapon].RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Weapon;

            // Act
            rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Sword, 34);
            var equippedWeapon = rogue.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectWeaponType()
        {
            // Arrenge
            WeaponType expected = WeaponType.Sword;

            // Act
            rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Sword, 34);
            var equippedWeapon = rogue.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectDamage()
        {
            // Arrenge
            int expected = 34;

            // Act
            rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Sword, 34);
            var equippedWeapon = rogue.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectName()
        {
            // Arrenge
            string expected = "Silver Helmet";

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var actual = rogue.Equipment[Slots.Legs].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var actual = rogue.Equipment[Slots.Legs].RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Legs;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var actual = rogue.Equipment[Slots.Legs].Slot;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorArmorType()
        {
            // Arrenge
            ArmorType expected = ArmorType.Mail;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var equippedArmor = rogue.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorType;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeStrength()
        {
            // Arrenge
            int expected = 10;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var equippedArmor = rogue.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeDexterity()
        {
            // Arrenge
            int expected = 4;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 2));
            var equippedArmor = rogue.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeIntelligence()
        {
            // Arrenge
            int expected = 12;

            // Act
            rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            var equippedArmor = rogue.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
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
            Assert.Throws<InvalidRequiredLevelException>(() => rogue.EquipWeapon("Mighty Sword", 4, Slots.Weapon, WeaponType.Sword, 34)).ToString();
        }

        [Fact]
        public void EquipWeapon_IfWeaponTypeIsWrongForHeroShouldThrowInvalidWeaponException()
        {
            // Arrenge
            string expected = "Exception: Invalid weapon type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon("Mighty Sword", 1, Slots.Weapon, WeaponType.Wand, 22)).ToString();
        }

        [Fact]
        public void EquipArmor_IfHerosLevelTooLowShouldThrowInvalidRequiredLevelException()
        {
            // Arrenge
            string expected = "Exception: Hero's required level for item is too low.";

            // Act & Assert
            Assert.Throws<InvalidRequiredLevelException>(() => rogue.EquipArmor("Silver Helmet", 5, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12))).ToString();
        }

        [Fact]
        public void EquipWeapon_IfArmorTypeIsWrongForHeroShouldThrowInvalidArmorException()
        {
            // Arrenge
            string expected = "Exception: Invalid armor type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor("Silver Helmet", 1, Slots.Legs, ArmorType.Cloth, new HeroAttribute(10, 4, 12))).ToString();
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeStrength()
        {
            // Arrenge
            int expected = 2;

            // Act
            var actual = rogue.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeDexterity()
        {
            // Arrenge
            int expected = 6;

            // Act
            var actual = rogue.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeIntelligence()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = rogue.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 12;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            var actual = rogue.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 10;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            var actual = rogue.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 13;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            var actual = rogue.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 14;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 11;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 14;

            // Act
            rogue.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 4;

            // Act
            rogue.EquipArmor("Golden Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 7;

            // Act
            rogue.EquipArmor("Golden Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 2;

            // Act
            rogue.EquipArmor("Golden Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(10, 4, 12));
            rogue.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(2, 1, 1));
            var actual = rogue.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithoutEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 3.18;

            // Act
            rogue.EquipWeapon("Basic Sword", 1, Slots.Weapon, WeaponType.Dagger, 3);
            var actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithReplacedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 82.68;

            // Act
            rogue.EquipWeapon("Basic Sword", 1, Slots.Weapon, WeaponType.Dagger, 3);
            rogue.EquipWeapon("Ultra Sword", 1, Slots.Weapon, WeaponType.Dagger, 78);
            var actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponAndEquippedArmorShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 3.42;

            // Act
            rogue.EquipWeapon("Basic Sword", 1, Slots.Weapon, WeaponType.Dagger, 3);
            rogue.EquipArmor("Super Chestplate", 1, Slots.Body, ArmorType.Leather, new HeroAttribute(5, 8, 9));
            var actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Display_DisplaysHerosStateShouldGiveCorrectInformation()
        {

            // Arrenge
            string expected = "Hero Name: Ralph \nHero Class: Rogue \nHero Level: 1 \nHero's total strength: 2 \nHero's total Dexterity: 6 \nHero's total intelligence: 1 \nHero's total damage: 1\n";

            // Act
            var actual = rogue.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
