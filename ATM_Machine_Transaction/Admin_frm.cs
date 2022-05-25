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
    public partial class Admin_frm : Form
    {
        public Admin_frm()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void AccountSetting_Load(object sender, EventArgs e)
        {
            txtFullname.Focus();
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "|*.jpg||*.jpeg||*.png|All|*.*";
            openFileDialog1.Multiselect = false;
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                String path = openFileDialog1.FileName;
                picBox.ImageLocation = path;
                //pictureBox1.Image = Image.FromFile(path);
            }
        }

        private void lbGenerateAccount_Click(object sender, EventArgs e)
        {
            Random rdm = new Random();
            int num = rdm.Next(0, 99999999);
            txtAccount.Text = string.Format("{0:000 ### ###}", num);
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.Text != "")
            {
                if (txtAccount.Text.Replace(" ", "").Length > 9)
                {
                    MessageBox.Show(txtAccount.Handle.ToString());
                    
                }
                else
                {
                    int num = int.Parse(txtAccount.Text.Replace(" ", ""));
                    txtAccount.Text = string.Format("{0:000 ### ###}", num);
                }
            }//if
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }//
}//
