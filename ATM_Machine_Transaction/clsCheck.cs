using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    class clsCheck
    {
        //check combobox not select
        public Boolean isNotSelectCombobox(ComboBox cbo)
        {
            bool check;
            if (cbo.SelectedItem == null)
            {
                cbo.DroppedDown = true;
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }

        //check empty textbox
        public Boolean isEmptyTextBox(TextBox txt)
        {
            bool check;
            if (txt.Text == "")
            {
                txt.ForeColor = Color.White;
                txt.BackColor = Color.DarkRed;
                check = true;
            }
            else
            {
                txt.ForeColor = Color.Black;
                txt.BackColor = Color.White;
                check = false;
            }    
            return check;
        }

        //check empty string
        public Boolean isEmptyTextBox(Label txt)
        {
            bool check;
            if (txt.Text == "")
            {
                txt.ForeColor = Color.White;
                txt.BackColor = Color.DarkRed;
                check = true;
            }
            else
            {
                txt.ForeColor = Color.Black;
                txt.BackColor = Color.White;
                check = false;
            }
            return check;
        }

        //check Button.text
        private static string btnText;
        public static String MyCheckBtn
        {
            get => btnText;
            set => btnText = value;
        }

        }//
}///
