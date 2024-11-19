using System;
using System.Windows.Forms;

namespace WelcomeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGreet_Click(object sender, EventArgs e)
        {
            // Check if the user has entered a name
            if (!string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                // Display the personalized greeting
                labelMessage.Text = $"Hello, {textBoxName.Text}! Welcome!";
            }
            else
            {
                // Prompt the user to enter their name
                labelMessage.Text = "Please enter your name.";
            }
        }
    }
}
