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
    public partial class Main_frm : Form
    {
        public Main_frm()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            checkBoxEnglish.AutoCheck = false;
            //if (checkBoxKhmer.Checked == true)
            //{
            //    labelWelcome.Text = "សូមស្វាគមន៍";
            //}
            //else
            //{
            //    labelWelcome.Text = default;
            //}
        }

        private void checkBoxEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnglish.Checked == true)
            {
                checkBoxEnglish.AutoCheck = false;
                checkBoxKhmer.Checked = false;
                checkBoxKhmer.AutoCheck = true;

                labelWelcome.Font = new Font("Microsoft YaHei UI", 14);
                labelWelcome.Text = "Welcome";
            }
        }

        private void checkBoxKhmer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKhmer.Checked == true)
            {
                checkBoxKhmer.AutoCheck = false;
                checkBoxEnglish.Checked = false;
                checkBoxEnglish.AutoCheck = true;
                labelWelcome.Font = new Font("KH ABC TEXT 04", 14);
                labelWelcome.Text = "សូមស្វាគមន៍";
            }
        }

        private void btnAccountSetting_Click(object sender, EventArgs e)
        {
            AccountSetting frm = new AccountSetting();
            frm.ShowDialog();
        }
    }//
}///
