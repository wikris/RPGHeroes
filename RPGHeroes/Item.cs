using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public string[] Slots { get; set; }
    }
}
