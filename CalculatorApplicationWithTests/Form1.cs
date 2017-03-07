using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplicationWithTests
{
    public partial class Form1 : Form
    {
        List<string> operand1 = new List<string>();
        string operand2 = string.Empty;
        string result;
        double test;
        char operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button[] calcButtons = new Button[]
            {
                btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnDot
            };

            foreach(var btn in calcButtons)
            {
                btn.Click += new EventHandler(btn_Click);
            }
        }

        public void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;

                switch (btn.Name)
                {
                    case "btn1":
                        calculatorValues.Text += "1";
                        break;
                    case "btn2":
                        calculatorValues.Text += "2";
                        break;
                    case "btn3":
                        calculatorValues.Text += "3";
                        break;
                    case "btn4":
                        calculatorValues.Text += "4";
                        break;
                    case "btn5":
                        calculatorValues.Text += "5";
                        break;
                    case "btn6":
                        calculatorValues.Text += "6";
                        break;
                    case "btn7":
                        calculatorValues.Text += "7";
                        break;
                    case "btn8":
                        calculatorValues.Text += "8";
                        break;
                    case "btn9":
                        calculatorValues.Text += "9";
                        break;
                    case "btn0":
                        calculatorValues.Text += "0";
                        break;
                    case "btnDot":
                        if (!calculatorValues.Text.Contains("."))
                            calculatorValues.Text += ".";
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry for the inconvenience, Unexpected error occured. Details: " +
                    ex.Message);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operand1.Add(calculatorValues.Text);
            operation = '+';
            calculatorValues.Text = string.Empty;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            operand1.Add(calculatorValues.Text);
            operation = '-';
            calculatorValues.Text = string.Empty;
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            operand1.Add(calculatorValues.Text);
            operation = '*';
            calculatorValues.Text = string.Empty;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            operand1.Add(calculatorValues.Text);
            operation = '/';
            calculatorValues.Text = string.Empty;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            operand2 = calculatorValues.Text;
            string[] opr1 = operand1.ToArray();

            double opr2;

            double.TryParse(operand2, out opr2);
            double[] doubleArray = new double[opr1.Length];

            for (int i = 0; i < opr1.Length; i++)
            {
                doubleArray[i] = Double.Parse(opr1[i]);
            }

            switch (operation)
            {
                case '+':
                    test = doubleArray.Aggregate((a, b) => a + b);
                    result = (test + opr2).ToString();
                    break;

                case '-':
                    test = doubleArray.Aggregate((a, b) => a - b);
                    result = (test - opr2).ToString();
                    break;

                case '*':
                    test = doubleArray.Aggregate((a, b) => a * b);
                    result = (test * opr2).ToString();
                    break;

                case '/':
                    if (opr2 != 0)
                    {
                        test = doubleArray.Aggregate((a, b) => a / b);
                        result = (test / opr2).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Can't divide by zero");
                    }
                    break;
            }

            calculatorValues.Text = result.ToString();
        }


        private void reset_Click(object sender, EventArgs e)
        {
            calculatorValues.Text = string.Empty;
            operand1 = new List<string>();
            operand2 = string.Empty; 
        }
    }
}
