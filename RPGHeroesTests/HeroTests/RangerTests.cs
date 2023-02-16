using RPGHeroes.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesTests.HeroTests
{
    public class RangerTests
    {
        [Fact]
        public void Ranger_CreatingMageShouldAddCorrectName()
        {
            // Arrange
            Hero ranger = new Ranger("Ralph");
            string expected = "Ralph";

            // Act
            var actual = ranger.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingMageShouldAddHerousLevelForOne()
        {
            // Arrenge
            Hero ranger = new Ranger("Ralph");
            int expected = 1;

            // Act
            var actual = ranger.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingMageShouldAddCorrectStartingStrengthToLevelAttributes()
        {
            // Arrenge
            Hero ranger = new Ranger("Ralph");
            int expected = 1;

            // Act
            var actual = ranger.LevelAttributes.Strength;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingMageShouldAddCorrectStartingDexterityToLevelAttributes()
        {
            // Arrenge
            Hero ranger = new Ranger("Ralph");
            int expected = 1;

            // Act
            var actual = ranger.LevelAttributes.Dexterity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_CreatingMageShouldAddCorrectStartingIntelligenceToLevelAttributes()
        {
            // Arrenge
            Hero ranger = new Ranger("Ralph");
            int expected = 8;

            // Act
            var actual = ranger.LevelAttributes.Intelligence;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
