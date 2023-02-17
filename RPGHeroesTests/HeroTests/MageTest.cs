using RPGHeroes;
using RPGHeroes.enums;
using RPGHeroes.exceptions;
using RPGHeroes.Hero;
using System.Text.RegularExpressions;

namespace RPGHeroesTests.HeroTests
{
    public class MageTest
    {
        Hero mage = new Mage("Mike");

        [Fact]
        public void Mage_CreatingMageShouldAddCorrectName()
        {
            // Arrange
            string expected = "Mike";

            // Act
            var actual = mage.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_CreatingMageShouldAddHerousLevelForOne()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_CreatingMageShouldAddCorrectStartingStrengthToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_CreatingMageShouldAddCorrectStartingDexterityToLevelAttributes()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_CreatingMageShouldAddCorrectStartingIntelligenceToLevelAttributes()
        {
            // Arrenge
            int expected = 8;

            // Act
            var actual = mage.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_IncreasingMagesLevelByOneShouldReturnCurrentLevelPlusOne()
        {
            // Arrenge
            int expected = 2;

            // Act
            mage.LevelUp();
            var actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeStrength()
        {
            // Arrenge
            int expected = 2;

            // Act
            mage.LevelUp();
            var actual = mage.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeDexterity()
        {
            // Arrenge
            int expected = 2;

            // Act
            mage.LevelUp();
            var actual = mage.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpShouldIncreaseLevelAttributeIntelligence()
        {
            // Arrenge
            int expected = 13;

            // Act
            mage.LevelUp();
            var actual = mage.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectName()
        {
            // Arrenge
            string expected = "Super Wand";

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 11);
            var actual = mage.Equipment[Slots.Weapon].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 11);
            var actual = mage.Equipment[Slots.Weapon].RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Weapon;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 11);
            var equippedWeapon = mage.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectWeaponType()
        {
            // Arrenge
            WeaponType expected= WeaponType.Wand;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 11);
            var equippedWeapon = mage.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipWeapon_EquippedWeaponShouldCorrectDamage()
        {
            // Arrenge
            int expected = 11;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 11);
            var equippedWeapon = mage.Equipment.Where(kvp => kvp.Key == Slots.Weapon).Select(kvp => (Weapon?)kvp.Value).ToArray();
            var actual = equippedWeapon[0].WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectName()
        {
            // Arrenge
            string expected = "Super Chest Plate";

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.Equipment[Slots.Body].Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectRequiredLevel()
        {
            // Arrenge
            int expected = 1;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.Equipment[Slots.Body].RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectSlot()
        {
            // Arrenge
            Slots expected = Slots.Body;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.Equipment[Slots.Body].Slot;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorArmorType()
        {
            // Arrenge
            ArmorType expected = ArmorType.Cloth;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var equippedArmor = mage.Equipment.Where(kvp => kvp.Key == Slots.Body).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorType;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeStrength()
        {
            // Arrenge
            int expected = 5;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var equippedArmor = mage.Equipment.Where(kvp => kvp.Key == Slots.Body).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeDexterity()
        {
            // Arrenge
            int expected = 3;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var equippedArmor = mage.Equipment.Where(kvp => kvp.Key == Slots.Body).Select(kvp => (Armor?)kvp.Value).ToArray();
            var actual = equippedArmor[0].ArmorAttribute.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipArmor_EquippedArmorShouldHaveCorrectArmorAttributeIntelligence()
        {
            // Arrenge
            int expected = 7;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var equippedArmor = mage.Equipment.Where(kvp => kvp.Key == Slots.Body).Select(kvp => (Armor?)kvp.Value).ToArray();
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
            Assert.Throws<InvalidRequiredLevelException>(() => mage.EquipWeapon("Super Wand", 4, Slots.Weapon, WeaponType.Wand, 11)).ToString();
        }

        [Fact]
        public void EquipWeapon_IfWeaponTypeIsWrongForHeroShouldThrowInvalidWeaponException()
        {
            // Arrenge
            string expected = "Exception: Invalid weapon type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Bow, 11)).ToString();
        }

        [Fact]
        public void EquipArmor_IfHerosLevelTooLowShouldThrowInvalidRequiredLevelException()
        {
            // Arrenge
            string expected = "Exception: Hero's required level for item is too low.";

            // Act & Assert
            Assert.Throws<InvalidRequiredLevelException>(() => mage.EquipArmor("Super Chest Plate", 3, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7))).ToString();
        }

        [Fact]
        public void EquipWeapon_IfArmorTypeIsWrongForHeroShouldThrowInvalidArmorException()
        {
            // Arrenge
            string expected = "Exception: Invalid armor type for this type of Hero.";

            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Mail, new HeroAttribute(5, 3, 7))).ToString();
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeStrength()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeDexterity()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithNoEquipmentForAttributeIntelligence()
        {
            // Arrenge
            int expected = 8;

            // Act
            var actual = mage.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 6;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 4;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithOnePieceOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 15;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            var actual = mage.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 7;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 7;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithTwoPiecesOfArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 17;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Helmet", 1, Slots.Head, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeStrength()
        {
            // Arrenge
            int expected = 2;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithWithReplacedArmorForAttributeDexterity()
        {
            // Arrenge
            int expected = 4;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalAttributes_TotalAttributesShouldCalculateCorrectValueWithReplacedArmorForAttributeIntelligence()
        {
            // Arrenge
            int expected = 10;

            // Act
            mage.EquipArmor("Super Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(5, 3, 7));
            mage.EquipArmor("Basic Chest Plate", 1, Slots.Body, ArmorType.Cloth, new HeroAttribute(1, 3, 2));
            var actual = mage.TotalAttributes().Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithoutEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            int expected = 1;

            // Act
            var actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 10.8;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 10);
            var actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithReplacedWeaponShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 37.8;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 10);
            mage.EquipWeapon("Hyper Wand", 1, Slots.Weapon, WeaponType.Wand, 35);
            var actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_DamageWithEquippedWeaponAndEquippedArmorShouldCalculateCorrectValueForDamage()
        {
            // Arrenge
            double expected = 11.8;

            // Act
            mage.EquipWeapon("Super Wand", 1, Slots.Weapon, WeaponType.Wand, 10);
            mage.EquipArmor("Standard Helmet", 1, Slots.Legs, ArmorType.Cloth, new HeroAttribute(10, 20, 10));
            var actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Display_DisplaysHerosStateShouldGiveCorrectInformation()
        {

            // Arrenge
            string expected = "Hero Name: Mike \nHero Class: Mage \nHero Level: 1 \nHero's total strength: 1 \nHero's total Dexterity: 1 \nHero's total intelligence: 8 \nHero's total damage: 1\n";

            // Act
            var actual = mage.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

