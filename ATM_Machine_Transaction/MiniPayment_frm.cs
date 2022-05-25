using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class MiniPayment_frm : Form
    {
        public MiniPayment_frm(string title, Image i, TextBox t, TextBox amt, TextBox note)
        {
            InitializeComponent();
            lbTittle.Text = title;
            pic.Image = i;
            txtMobilePhone.Text = t.Text;
            txtMobilePhone.Tag = t.Text;
            txtAmount.Text = amt.Text;
            txtAmount.Tag = amt.Text;
            txtNote.Text = note.Text;
            txtNote.Tag = note.Text;
            if (clsGetData.CheckBtn == "Transfer")
            {
                lbTotalLable.Visible = false;
            }
            else
            {
                lbTotalLable.Visible = true;
                if(clsGetData.CheckBtn== "Choose From Template")
                {
                    txtMobilePhone.Width = 300;
                }
            }
            
        }

        private void MiniPayment_frm_Load(object sender, EventArgs e)
        {
            lbTittle.Focus();
        }

        private void txtBox_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }
            else if (c is ComboBox)
            {
                c = (ComboBox)c;
            }

            if (c.Text == c.Tag.ToString())
            {
                c.Text = "";
                c.ForeColor = Color.Black;
            }
        }
        private void txtBox_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }
            else if (c is ComboBox)
            {
                c = (ComboBox)c;
            }

            if (c.Text.Trim() == "")
            {
                c.Text = c.Tag.ToString();
                c.ForeColor = Color.Silver;
            }
        }
    }
}
