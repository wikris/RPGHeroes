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
    public class RangerTests
    {
        Hero ranger = new Ranger("Ralph");

        [Fact]
        public void Ranger_CreatingRangerShouldAddCorrectName()
        {
            // Arrange
            string expected = "Ralph";

            // Act
            var actual = ranger.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingRangerShouldAddHerousLevelForOne()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingRangerShouldAddCorrectStartingStrengthToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingRangerShouldAddCorrectStartingDexterityToLevelAttributes()
        {
            // Arrenge
            int expected = 7;

            // Act
            var actual = ranger.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingRangerShouldAddCorrectStartingIntelligenceToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_IncreasingMagesLevelByOneShouldReturnCurrentLevelPlusOne()
        {
            // Arrenge
            int expected = 2;

            // Act
            ranger.LevelUp();
            var actual = ranger.Level;

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeStrength()
        {
            // Arrenge
            int expected = 2;

            // Act
            ranger.LevelUp();
            var actual = ranger.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeDexterity()
        {
            // Arrenge
            int expected = 12;

            // Act
            ranger.LevelUp();
            var actual = ranger.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeIntelligence()
        {
            // Arrenge
            int expected = 2;

            // Act
            ranger.LevelUp();
            var actual = ranger.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectName()
        {
            // Arrenge
            string expected = "Moderate Bow";

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 22);
            var actual = ranger.Equipment[Slots.Weapon].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 22);
            var actual = ranger.Equipment[Slots.Weapon].RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Weapon;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 22);
            var equippedWeapon = ranger.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectWeaponType()
        {
            // Arrenge
            WeaponType expected = WeaponType.Bow;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 22);
            var equippedWeapon = ranger.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectDamage()
        {
            // Arrenge
            int expected = 22;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 22);
            var equippedWeapon = ranger.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectName()
        {
            // Arrenge
            string expected = "Golden Boots";

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.Equipment[Slots.Legs].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.Equipment[Slots.Legs].RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Legs;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.Equipment[Slots.Legs].Slot;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorArmorType()
        {
            // Arrenge
            ArmorType expected = ArmorType.Leather;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var equippedArmor = ranger.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorType;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeStrength()
        {
            // Arrenge
            int expected = 9;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var equippedArmor = ranger.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeDexterity()
        {
            // Arrenge
            int expected = 6;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var equippedArmor = ranger.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
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
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var equippedArmor = ranger.Equipment.Where(kvp => kvp.Key == Slots.Legs).Select(kvp => (Armor?)kvp.Value).ToArray();
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
            Assert.Throws<InvalidRequiredLevelException>(() => ranger.EquipWeapon("Moderate Bow", 4, Slots.Weapon, WeaponType.Bow, 22)).ToString();
        }

        [Fact]
        public void EquipWeapon_IfWeaponTypeIsWrongForHeroShouldThrowInvalidWeaponException()
        {
            // Arrenge
            string expected = "Exception: Invalid weapon type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Wand, 22)).ToString();
        }

        [Fact]
        public void EquipArmor_IfHerosLevelTooLowShouldThrowInvalidRequiredLevelException()
        {
            // Arrenge
            string expected = "Exception: Hero's required level for item is too low.";

            // Act & Assert
            Assert.Throws<InvalidRequiredLevelException>(() => ranger.EquipArmor("Golden Boots", 3, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12))).ToString();
        }

        [Fact]
        public void EquipWeapon_IfArmorTypeIsWrongForHeroShouldThrowInvalidArmorException()
        {
            // Arrenge
            string expected = "Exception: Invalid armor type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Cloth, new HeroAttribute(9, 6, 12))).ToString();
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeStrength()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeDexterity()
        {
            // Arrenge
            int expected = 7;

            // Act
            var actual = ranger.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeIntelligence()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 10;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 13;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 13;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            var actual = ranger.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 11;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueTwoPiecesOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 15;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 16;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 2;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 9;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 4;

            // Act
            ranger.EquipArmor("Golden Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(9, 6, 12));
            ranger.EquipArmor("Basic Boots", 1, Slots.Legs, ArmorType.Leather, new HeroAttribute(1, 2, 3));
            var actual = ranger.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithoutEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 21.4;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 20);
            var actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithReplacedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 58.85;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 20);
            ranger.EquipWeapon("Super Bow", 1, Slots.Weapon, WeaponType.Bow, 55);
            var actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponAndEquippedArmorShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 24.2;

            // Act
            ranger.EquipWeapon("Moderate Bow", 1, Slots.Weapon, WeaponType.Bow, 20);
            ranger.EquipArmor("Super Helmet", 1, Slots.Head, ArmorType.Mail, new HeroAttribute(13, 14, 15));
            var actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Display_DisplaysHerosStateShouldGiveCorrectInformation()
        {

            // Arrenge
            string expected = "Hero Name: Ralph \nHero Class: Ranger \nHero Level: 1 \nHero's total strength: 1 \nHero's total Dexterity: 7 \nHero's total intelligence: 1 \nHero's total damage: 1\n";

            // Act
            var actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
