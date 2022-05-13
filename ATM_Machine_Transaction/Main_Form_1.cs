using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Main_Form_1 : Form
    {
        public Main_Form_1()
        {
            InitializeComponent();
            //MylabelBalance();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void myEventHoverButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Return")
            {
                Login frm = new Login();
                frm.Show();
                this.Hide();
            }
            else if (button.Text == "Deposit")
            {
                myLoadForm(new Deposit_frm());
            }
           else if (button.Text == "Withdraw")
            {
                myLoadForm(new Withdraw_frm());
            }
            else if (button.Text == "Account Setting")
            {
                myLoadForm(new AccountSetting());
            }
        }//

        private void Main_Form_1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            clsGetData.Balance = double.Parse(lbBalance.Text.Replace("$","").Replace(",",""));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("dddd, dd/MMM/yyyy");
            lbTime.Text = DateTime.Now.ToLongTimeString();
            lbBalance.Text = "$ " + String.Format("{0:n0}", clsGetData.Balance);
        }

    }//
}//
