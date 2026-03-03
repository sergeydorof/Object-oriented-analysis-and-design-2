using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class ItalianKitchenFactory : KitchenFactory
    {
        public override Dessert CreateDessert()
        {
            return new Tiramisu();
        }

        public override Drink CreateDrink()
        {
            return new Espresso();
        }

        public override MainCourse CreateMainCourse()
        {
            return new Pasta();
        }
    }
}
