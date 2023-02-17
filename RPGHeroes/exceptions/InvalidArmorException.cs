using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.exceptions
{
    // Throws this exception if user tries to equip wrong type of Armor to Hero
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException() { }
        public InvalidArmorException(string? message) : base(message) { }
        public override string Message => "Exception: Invalid armor type for this type of Hero.";
    }
}
