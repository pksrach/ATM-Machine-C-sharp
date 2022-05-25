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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lbLanguage.Text = clsGetData.MyLanguage;
            lbLanguage.Image = clsGetData.MyImage;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtPIN.Focus();
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
                    //MessageBox.Show("Successfully", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPIN.Clear();
                    //Main_frm frm = new Main_frm();
                    Main_Form_1 frm = new Main_Form_1();
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
            Control c = (Control)sender;
            c.ForeColor = Color.Black;
        }
        private void myEventLeave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.ForeColor = Color.White;
        }
        private void myEventClick(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.ForeColor = Color.White;
        }

        private void myEventDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.ForeColor = Color.DarkGray;
        }
        private void myClick(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            txtPIN.Text += c.Text;
        }
        private void lbLanguage_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to change ?, តើអ្នកចង់ផ្លាស់ប្ដូរដែរទេ ?", "Language, ភាសា", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                switch (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
                {
                    case "km-KH":
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                        lbLanguage.Text = "English";
                        lbLanguage.Image = Image.FromFile("Imgaes\\Flate eng-01.png");
                        break;
                    case "en-US":
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("km-KH");
                        lbLanguage.Text = "ខ្មែរ";
                        lbLanguage.Image = Image.FromFile("Imgaes\\Flate kh 16px-01.png");
                        break;
                }
            }//if
            else return;
            
            clsGetData.MyLanguage = lbLanguage.Text;
            clsGetData.MyImage = lbLanguage.Image;
        }
    }//
}///
