using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                TxtDisplay1.Text = fstNum = $"{result}{operation}";
                TxtDisplay2.Text = string.Empty;
            }
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            sndNum = TxtDisplay2.Text;
            TxtDisplay1.Text = $"{TxtDisplay1.Text}{TxtDisplay2.Text} =";
            if (RtBoxDisplayHistory.Text == "There's no history yet.") RtBoxDisplayHistory.Text = "";
            if (TxtDisplay2.Text != string.Empty)
            {
                if (TxtDisplay2.Text == "0") TxtDisplay1.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        TxtDisplay2.Text = (result + Double.Parse(TxtDisplay2.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{sndNum} = {TxtDisplay2.Text} \n");
                        break;
                    case "-":
                        TxtDisplay2.Text = (result - Double.Parse(TxtDisplay2.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{sndNum} = {TxtDisplay2.Text} \n");
                        break;
                    case "×":
                        TxtDisplay2.Text = (result * Double.Parse(TxtDisplay2.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{sndNum} = {TxtDisplay2.Text} \n");
                        break;
                    case "÷":
                        if (sndNum == "0")
                        {
                            TxtDisplay2.Text = ("Error");
                            break;
                        }
                        TxtDisplay2.Text = (result / Double.Parse(TxtDisplay2.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{sndNum} = {TxtDisplay2.Text} \n");   
                        break;
                    default: TxtDisplay1.Text = $"{TxtDisplay2.Text}= ";
                        break;
                }
                if (TxtDisplay2.Text == "Error") operation = string.Empty;
                else 
                {
                    result = Double.Parse(TxtDisplay2.Text);
                    operation = string.Empty;
                }
                enterValue = true;


            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? PnlHistory.Height = 345 : 5;
        }

        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if (RtBoxDisplayHistory.Text == string.Empty)
                RtBoxDisplayHistory.Text = "There's no history yet.";
        }

        private void BtnBackSpace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay2.Text.Length > 0)
                TxtDisplay2.Text = TxtDisplay2.Text.Remove(TxtDisplay2.Text.Length - 1, 1);
            if (TxtDisplay2.Text == string.Empty) TxtDisplay2.Text = "0";
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay2.Text = "0";
            TxtDisplay1.Text = string.Empty;
            result = 0;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay2.Text = "0";
        }

        private void BtnComplexOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            switch (operation)
            {
                case "√x":
                    TxtDisplay1.Text = $"√({TxtDisplay2.Text})";
                    TxtDisplay2.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay2.Text)));
                    break;
                case "^2":
                    TxtDisplay1.Text = $"({TxtDisplay2.Text})^2";
                    TxtDisplay2.Text = Convert.ToString(Convert.ToDouble(TxtDisplay2.Text)* Convert.ToDouble(TxtDisplay2.Text));
                    break;
                case "⅟x":
                    TxtDisplay1.Text = $"⅟({TxtDisplay2.Text})";
                    TxtDisplay2.Text = Convert.ToString(1.0 / Convert.ToDouble(TxtDisplay2.Text));
                    break;
                case "%":
                    TxtDisplay1.Text = $"%({TxtDisplay2.Text})";
                    TxtDisplay2.Text = Convert.ToString(Convert.ToDouble(TxtDisplay2.Text)/ Convert.ToDouble(100));
                    break;
                case "±":
                    TxtDisplay1.Text = $"±({TxtDisplay2.Text})";
                    TxtDisplay2.Text = Convert.ToString(-1 * Convert.ToDouble(TxtDisplay2.Text));
                    break;
            }
            RtBoxDisplayHistory.AppendText($"{TxtDisplay1.Text} = {TxtDisplay2.Text} \n");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {

            if (TxtDisplay2.Text == "0" || enterValue) TxtDisplay2.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (TxtDisplay2.Text == "") TxtDisplay2.Text = "0,";
                if (!TxtDisplay2.Text.Contains(","))
                    TxtDisplay2.Text = TxtDisplay2.Text + button.Text;  
            }
              else TxtDisplay2.Text = TxtDisplay2.Text + button.Text;
        }
    }
}
