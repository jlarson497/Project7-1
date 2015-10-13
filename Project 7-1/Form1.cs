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
        //range validation
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
        //presence validation
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
        //decimal type validation
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
        //Form validation
        public bool IsValidForm()
        {
            return
                isPresent(txtOperand1, "Operand 1") && IsDecimal(txtOperand1, "Operand 1") && IsWithinRange(txtOperand1, "Operand 1", 0, 1000000)
                && isPresent(txtOperand2, "Operand 2") && IsDecimal(txtOperand2, "Operand 2") && IsWithinRange(txtOperand2, "Operand 2", 0, 1000000)
                && isPresent(txtOperator, "Operator");
        }

        //method for completing the operation.  Uses a switch statment to determine what the result will be
        public string OperatorMath(decimal operand1, decimal operand2)
        {
            decimal result = 0;
            string resultString = " ";
            string smoothOperator = txtOperator.Text;
            
            switch (smoothOperator)
            {
                case "*":
                    result = operand1 * operand2;
                    resultString = Convert.ToString(result);
                    break;
                case "/":
                    result = operand1 / operand2;
                    resultString = Convert.ToString(result);
                    break;
                case "+":
                    result = operand1 + operand2;
                    resultString = Convert.ToString(result);
                    break;
                case "-":
                    result = operand1 - operand2;
                    resultString = Convert.ToString(result);
                    break;
                default:
                    MessageBox.Show("Invalid Operator selection.  Your choices are * / + -", "Entry Error");
                    txtResult.Clear();
                    txtOperator.Clear();
                    txtOperator.Focus();
                    break;
            }
            
            return resultString;

        }

        //Click event for calculate button
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                return;
            }
            decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
            decimal operand2 = Convert.ToDecimal(txtOperand2.Text);

            string resultString = OperatorMath(operand1, operand2);

            txtResult.Text = resultString;

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
