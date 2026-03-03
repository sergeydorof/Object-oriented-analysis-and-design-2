using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Mochi : Dessert
    {
        private string description = "клубничный моти";

        public override string GetDescription() { return description; }
    }
}
