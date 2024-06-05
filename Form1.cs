using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //Fields
        Double result = 0;
        string operation = string.Empty;
        string fstNum,sndNum;
        bool enterValue = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnMathOperations_Click(object sender, EventArgs e)
        {
            if (result != 0) BtnEquals.PerformClick();
            else result = Double.Parse(TxtDisplay2.Text);

            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;
            if (TxtDisplay2.Text != "0")
            {
                TxtDisplay2.Text = fstNum = $"{result}{operation}";
                TxtDisplay2.Text = string.Empty;
            }
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            sndNum = TxtDisplay2.Text;
            TxtDisplay2.Text = $"{TxtDisplay1.Text} = {TxtDisplay2.Text} =";
            if (TxtDisplay2.Text != string.Empty)
            {
                if (TxtDisplay2.Text == "0") TxtDisplay2.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        TxtDisplay2.Text = (result + Double.Parse(TxtDisplay2.Text)).ToString();
                        break;
                    case "-":
                        TxtDisplay2.Text = (result - Double.Parse(TxtDisplay2.Text)).ToString();
                        break;
                    case "×":
                        TxtDisplay2.Text = (result * Double.Parse(TxtDisplay2.Text)).ToString();
                        break;
                    case "÷":
                        TxtDisplay2.Text = (result / Double.Parse(TxtDisplay2.Text)).ToString();
                        break;
                    default: TxtDisplay1.Text = $"{TxtDisplay2.Text} = ";
                        break;
                }
            }
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay2.Text == "0"||enterValue) TxtDisplay2.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if(!TxtDisplay2.Text.Contains("."))
                    TxtDisplay2.Text = TxtDisplay2.Text + button.Text;  
            }
              else TxtDisplay2.Text = TxtDisplay2.Text + button.Text;
        }
    }
}
