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
    /// <summary>
    /// A dialog used to get user input in the form of a text string.
    /// </summary>
    public class InputBox
    {       
        // create new instance of the inputbox form
        InputBoxForm inputBoxForm;

        string title;
        string queryText;
        string inputText;
        bool inputCanceled;

        public InputBox(string formTitle, string formQuery, string defaultInput)
        {
            title = formTitle;
            queryText = formQuery;
            inputText = defaultInput;
            inputCanceled = false;
            inputBoxForm = new InputBoxForm(title, queryText, inputText, this);
        }

        public void Show()
        {
            inputBoxForm.ShowDialog();
        }


        /// <summary>
        /// gets or sets the text inputted by the user
        /// </summary>
        public string returnText
        {
            get { return inputText; }
            set { inputText = value; }
        }

        /// <summary>
        /// gets or sets weither or not the user cancled the input.
        /// </summary>
        public bool InputCancled
        {
            get { return inputCanceled; }
            set { inputCanceled = value; }
        }
    }
}
