using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.exceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException() {}
        public InvalidWeaponException(string? message) : base(message) {}
        public override string Message => "Exception: Invalid weapon type for this type of Hero or your Hero's level is too low for that weapon.";
    }
}
