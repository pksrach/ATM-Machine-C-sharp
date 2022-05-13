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
    public partial class ConfirmWithdraw_frm : Form
    {
        AlertMessage_frm AlertMessage;
        public Point mouseLocation;
        public ConfirmWithdraw_frm(string cash)
        {
            InitializeComponent();
            this.txtCash.Text = cash;
        }
        bool b = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //validate
            if (txtCash.Text == "" || txtCash.Text == "0$")
            {
                txtCash.SelectAll();
                txtCash.Focus();
                return;
            }
            double cash = double.Parse(txtCash.Text.Replace("$", "").Replace(",", ""));
            //validate amount for withdraw is bigger than balance
            //double.Parse(txtCash.Text.Replace("$", ""))
            if (cash < 10)
            {
                AlertMessage = new AlertMessage_frm("Your amount is not enough, Must be big than $10", "Warning");
                AlertMessage.ShowDialog();
                txtCash.Focus();
                txtCash.SelectAll();
                b = true; //clear number for input button number when txtCash is selectAll 
            }
            else if (cash > clsGetData.Balance)
            {
                AlertMessage = new AlertMessage_frm("The entered " + txtCash.Text + " is higher than your balance " + clsGetData.Balance + "$ , Pleases enter lower amount !", "Warning");
                AlertMessage.ShowDialog();
            }
            else
            {
                clsGetData.Balance -= double.Parse(txtCash.Text.Replace("$", ""));
                AlertMessage = new AlertMessage_frm("Your amount " + txtCash.Text + " has been withdraw successfully, Your balance " + clsGetData.Balance + "$", "Warning");
                AlertMessage.ShowDialog();
            }
            this.Close();
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            //txtCash.Text = string.Format("{0:#,##}", double.Parse(txtCash.Text));
            if (txtCash.Text != "")
            {
                //txtCash.Text = String.Format("{0:c0}", double.Parse(txtCash.Text.Replace("$", "")));
                //String.Format("{0:c0}", 122231).
            }
            else
            {
                txtCash.Text = "0$";
                txtCash.SelectAll();
                txtCash.Focus();
            }
            
        }

        private void ConfirmWithdraw_frm_Load(object sender, EventArgs e)
        {

        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(sender, e);
            }
        }
    }//
}///
