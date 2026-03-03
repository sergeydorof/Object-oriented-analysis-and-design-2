using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Pasta : MainCourse
    {
        private string description = "паста карбонара";

        public override string GetDescription() { return description; }
    }
}
