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
    public partial class Withdraw_frm : Form
    {
        public Withdraw_frm()
        {
            InitializeComponent();
        }


        private void myEventButtonMoney(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //txtCash.Text = btn.Text;
            ConfirmWithdraw_frm confirmFrm = new ConfirmWithdraw_frm(btn.Text);
            confirmFrm.ShowDialog();
            //txtCash.Text.Replace(" ", "$");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ConfirmWithdraw_frm frm = new ConfirmWithdraw_frm("");
            frm.ShowDialog();
        }
    }//
}///
