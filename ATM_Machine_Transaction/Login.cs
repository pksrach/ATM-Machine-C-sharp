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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtPIN.Focus();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn5.Text;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn9.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPIN.Text += btn0.Text;
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtPIN.Clear();
            txtPIN.Focus();
        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPIN_TextChanged(object sender, EventArgs e)
        {
            if (txtPIN.Text.Count() >= 4)
            {
                if (txtPIN.Text == "3322")
                {
                    MessageBox.Show("Successfully", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPIN.Clear();
                    Main_frm frm = new Main_frm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPIN.Clear();
                }
            }
        }
        private void myEventHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }
        private void myEventLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.White;
        }
        private void myEventClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
        }

        private void myEventDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.DarkGray;
        }
    }
}
