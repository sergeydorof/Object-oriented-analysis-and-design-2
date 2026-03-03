using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class MatchaTea : Drink
    {
        private string description = "зеленый чай матча";

        public override string GetDescription() { return description; }
    }
}
