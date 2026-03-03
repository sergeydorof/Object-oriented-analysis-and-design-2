using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFactoryApp.Classes
{
    internal class Client
    {
        private KitchenFactory factory;
        private Dessert dessert;
        private MainCourse mainCourse;
        private Drink drink;

        public Client(KitchenFactory factory)
        {
            this.factory = factory;
        }

        public void SetFactory(KitchenFactory factory)
        {
            this.factory = factory;
        }

        public KitchenFactory GetFactory() {  return this.factory; }
    }
}
