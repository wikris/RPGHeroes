using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.exceptions
{
    public class InvalidRequiredLevelException : Exception
    {
        public InvalidRequiredLevelException() { }
        public InvalidRequiredLevelException(string? message) : base(message) { }
        public override string Message => "Exception: Hero's required level for item is too low.";
    }
}
