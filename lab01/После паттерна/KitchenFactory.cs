using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal abstract class KitchenFactory
    {
        public abstract Drink CreateDrink();
        public abstract MainCourse CreateMainCourse();
        public abstract Dessert CreateDessert();
    }
}
