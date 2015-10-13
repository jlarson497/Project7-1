using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsWithinRange(TextBox textbox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text);
            if (number > max || number < min)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + max.ToString(), "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }

            return true;
        }

        public bool isPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show(name + " is a required field", "Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textbox, string name)
        {
            decimal number = 0;
            if (decimal.TryParse(textbox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal.", "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }

        }
    }
}
