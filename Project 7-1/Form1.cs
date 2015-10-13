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

        public decimal OperatorMath(decimal operand1, decimal operand2)
        {
            decimal result = 0;
            string smoothOperator = txtOperator.Text;
            switch (smoothOperator)
            {
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
            }
            return result;

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
            decimal operand2 = Convert.ToDecimal(txtOperand2.Text);

            decimal result = OperatorMath(operand1, operand2);

            txtResult.Text = Convert.ToString(result);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
