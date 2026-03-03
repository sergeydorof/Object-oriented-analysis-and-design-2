using KitchenFactoryApp.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenFactoryApp
{
    public partial class Form1 : Form
    {
        private List<string> kitchens = new List<string> { "Японская", "Итальянская" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCuisines.Items.AddRange(kitchens.ToArray());
            comboBoxCuisines.SelectedIndex = 0;
        }

        private void comboBoxCuisines_SelectIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDrink_Click(object sender, EventArgs e)
        {
            string result;

            if (comboBoxCuisines.SelectedItem.ToString() == "Итальянская")
            {
                Espresso espresso = new Espresso();
                result = espresso.GetDescription();
            }
            else
            {
                MatchaTea tea = new MatchaTea();
                result = tea.GetDescription();
            }

            MessageBox.Show($"Вы купили {result}");
        }

        private void buttonMainCourse_Click(object sender, EventArgs e)
        {
            string result;

            if (comboBoxCuisines.SelectedItem.ToString() == "Японская")
            {
                Sushi sushi = new Sushi();
                result = sushi.GetDescription();
            }
            else
            {
                Pasta pasta = new Pasta();
                result = pasta.GetDescription();
            }

            MessageBox.Show($"Вы купили {result}");
        }

        private void buttonDessert_Click(object sender, EventArgs e)
        {
            string result;

            if (comboBoxCuisines.SelectedItem.ToString() == "Японская")
            {
                Mochi mochi = new Mochi();
                result = mochi.GetDescription();
            }
            else
            {
                Tiramisu tiramisu = new Tiramisu();
                result = tiramisu.GetDescription();
            }

            MessageBox.Show($"Вы купили {result}");
        }
    }
}

