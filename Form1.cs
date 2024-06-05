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

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay2.Text == "0"||enterValue) TxtDisplay2.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if(TxtDisplay2.Text.Contains("."))
                    TxtDisplay2.Text = TxtDisplay2.Text + button.Text;  
            }
              else TxtDisplay2.Text = TxtDisplay2.Text + button.Text;
        }
    }
}
