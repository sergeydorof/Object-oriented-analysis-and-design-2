using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Sushi : MainCourse
    {
        private string description = "сет суши";

        public override string GetDescription() { return description; }
    }
}
