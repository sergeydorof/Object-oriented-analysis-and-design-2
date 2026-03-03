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
        private Client client;

        private Dictionary<string, KitchenFactory> factories = new Dictionary<string, KitchenFactory>()
        {
            { "Японская", new JapaneseKitchenFactory() },
            { "Итальянская", new ItalianKitchenFactory() }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCuisines.Items.AddRange(factories.Keys.ToArray());
            comboBoxCuisines.SelectedIndex = 0;
            client = new Client(factories["Японская"]);
        }

        private void comboBoxCuisines_SelectIndexChanged(object sender, EventArgs e)
        {
            if (client != null)
            {
                string selected = comboBoxCuisines.SelectedItem.ToString();
                client.SetFactory(factories[selected]);
            }
        }

        private void buttonDrink_Click(object sender, EventArgs e)
        {
            string result = client.GetFactory().CreateDrink().GetDescription();
            MessageBox.Show($"Вы купили {result}");
        }

        private void buttonMainCourse_Click(object sender, EventArgs e)
        {
            string result = client.GetFactory().CreateMainCourse().GetDescription();
            MessageBox.Show($"Вы купили {result}");
        }

        private void buttonDessert_Click(object sender, EventArgs e)
        {
            string result = client.GetFactory().CreateDessert().GetDescription();
            MessageBox.Show($"Вы купили {result}");
        }
    }
}

