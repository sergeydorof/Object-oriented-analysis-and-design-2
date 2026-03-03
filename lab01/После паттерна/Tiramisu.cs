using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Tiramisu : Dessert
    {
        private string description = "классический тирамису";

        public override string GetDescription() { return description; }
    }
}
