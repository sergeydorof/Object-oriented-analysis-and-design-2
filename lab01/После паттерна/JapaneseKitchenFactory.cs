using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class JapaneseKitchenFactory : KitchenFactory
    {
        public override Dessert CreateDessert()
        {
            return new Mochi();
        }

        public override Drink CreateDrink()
        {
            return new MatchaTea();
        }

        public override MainCourse CreateMainCourse()
        {
            return new Sushi();
        }
    }
}
