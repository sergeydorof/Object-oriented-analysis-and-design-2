using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Espresso : Drink
    {
        private string description = "еспрессо";

        public override string GetDescription() { return description; }
    }
}
