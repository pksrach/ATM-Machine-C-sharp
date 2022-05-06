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
    public partial class Main_Form_1 : Form
    {
        public Main_Form_1()
        {
            InitializeComponent();
        }

        public void myLoadForm(object frm)
        {
            if (this.panel_ShowForm.Controls.Count > 0)
            {
                this.panel_ShowForm.Controls.RemoveAt(0);
            }
            Form f = frm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel_ShowForm.Controls.Add(f);
            this.panel_ShowForm.Tag = f;
            f.Show();
        }//method lord form

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            myLoadForm(new Deposit_frm());
        }

        private void btnAccountSetting_Click(object sender, EventArgs e)
        {
            myLoadForm(new AccountSetting());
        }
    }
}
