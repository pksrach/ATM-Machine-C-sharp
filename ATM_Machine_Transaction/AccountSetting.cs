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
    public partial class AccountSetting : Form
    {
        public AccountSetting()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Main_frm frm = new Main_frm();
            frm.Show();
            this.Hide();
        }

        private void AccountSetting_Load(object sender, EventArgs e)
        {

        }

    }//
}//
