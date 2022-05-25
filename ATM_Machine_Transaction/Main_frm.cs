using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Main_frm : Form
    {
        public Main_frm()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("km");
            InitializeComponent();
            
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Login frm = new Login();
            frm.Show();
            this.Hide();
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

                //labelWelcome.Font = new Font("Microsoft YaHei UI", 14);
                //labelWelcome.Text = "Welcome";
            }
        }
        
        private void checkBoxKhmer_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to change language ?", "Language", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (checkBoxKhmer.Checked == true)
                {
                    checkBoxKhmer.AutoCheck = false;
                    checkBoxEnglish.Checked = false;
                    checkBoxEnglish.AutoCheck = true;

                    //labelWelcome.Font = new Font("KH ABC TEXT 04", 14);
                    //labelWelcome.Text = "សូមស្វាគមន៍";
                    //MessageBox.Show(c.Tag.ToString());
                    //b = new Label();
                    //b.Font = new Font("KH ABC TEXT 04", 14);
                    //b.Text = b.Tag.ToString();
                    switch (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
                    {
                        case "km":
                            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                            break;
                        case "en-US":
                            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("km");
                            break;
                    }
                    this.Controls.Clear();
                    InitializeComponent();

                }
            }
        }

        private void btnAccountSetting_Click(object sender, EventArgs e)
        {
            AccountSetting frm = new AccountSetting();
            frm.Show();
            this.Hide();
        }

        private void btnDiposit_Click(object sender, EventArgs e)
        {
            Deposit_frm frm = new Deposit_frm();
            frm.Show();
            this.Hide();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentUICulture.IetfLanguageTag.ToString();
            //switch (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
            //{
            //    case "km":
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //        break;
            //    case "en-US":
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("km");
            //        break;
            //}

        }
    }//
}///
