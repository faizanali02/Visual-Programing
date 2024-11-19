using System;
using System.Windows.Forms;

namespace PizzaOrderForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            // Get selected pizza size
            string pizzaSize = comboBoxSize.SelectedItem?.ToString() ?? "Unknown Size";

            // Get selected toppings
            string toppings = "";
            if (checkBoxCheese.Checked) toppings += "Cheese, ";
            if (checkBoxPepperoni.Checked) toppings += "Pepperoni, ";
            if (checkBoxMushrooms.Checked) toppings += "Mushrooms, ";

            // Remove the last comma and space
            if (toppings.EndsWith(", ")) toppings = toppings.Remove(toppings.Length - 2);

            if (string.IsNullOrEmpty(toppings))
                toppings = "No Toppings";

            // Get selected crust type
            string crustType = radioButtonThinCrust.Checked ? "Thin Crust" :
                               radioButtonThickCrust.Checked ? "Thick Crust" : "Unknown Crust";

            // Display the order summary
            labelOrderSummary.Text = $"You ordered a {pizzaSize} pizza with:\n" +
                                      $"Toppings: {toppings}\n" +
                                      $"Crust: {crustType}";
        }
    }
}
