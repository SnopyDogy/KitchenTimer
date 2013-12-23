using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KitchenTimer
{
    public partial class InputBoxForm : Form
    {
        //this is a method to access the calling class
        InputBox callingClass;

        public InputBoxForm(string formTitle, string formQuery, string defaultInput, InputBox callingClassTemp)
        {
            InitializeComponent();
            this.Text = formTitle;
            inputQueryLabel.Text = formQuery;
            inputTextBox.Text = defaultInput;
            callingClass = callingClassTemp;
        }

        private void InputBoxForm_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            callingClass.returnText = inputTextBox.Text;
            this.Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            callingClass.InputCancled = true;
            this.Hide();
        }


    }
}
