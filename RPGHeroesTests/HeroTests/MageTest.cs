using RPGHeroes.Hero;

namespace RPGHeroesTests.HeroTests
{
    public class MageTest
    {
        [Fact]
        public void Mage_CreatingMageShouldAddCorrectName()
        {
            // Arrange
            Hero mage = new Mage("Mike");
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
            Hero mage = new Mage("Mike");
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
            Hero mage = new Mage("Mike");
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
            Hero mage = new Mage("Mike");
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
            Hero mage = new Mage("Mike");
            int expected = 8;

            // Act
            var actual = mage.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

// Arrenge


// Act

// Assert