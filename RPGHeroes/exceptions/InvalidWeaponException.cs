using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.exceptions
{
    // Throws this exception if user tries to equip wrong type of Weapon to Hero
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException() {}
        public InvalidWeaponException(string? message) : base(message) {}
        public override string Message => "Exception: Invalid weapon type for this type of Hero.";
    }
}
