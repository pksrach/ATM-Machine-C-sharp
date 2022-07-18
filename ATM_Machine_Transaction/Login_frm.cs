using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Login_frm : Form
    {
        DbConnection db = new DbConnection();
        
        private Point mouseLocation;
        public Login_frm()
        {
            InitializeComponent();
            //dbcon.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Git\Project For Midterm\ATM_Machine_Transaction\bin\Debug\ATM_DB.accdb; Persist Security Info = False;";
            pictureBox1.Focus();
            lbLanguage.Text = clsGetData.MyLanguage;
            //db.con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source=ATM_DB.accdb");
            cboRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Username" && txtPass.Text == "Password")
            {
                txtUser.Focus();
                return;
            }
            if (cboRole.Text == "Staff")
            {
                db.ConectionStr();
                db.cmd = new OleDbCommand();
                db.cmd.Connection = db.con;
                db.cmd.CommandText = "select Username, Pass, Role, Active from Staff_tbl where  Username ='" + txtUser.Text + "' and Pass= '" + txtPass.Text + "' ";
                db.dr = db.cmd.ExecuteReader(); 
                int count = 0;
                bool active = false;
                while (db.dr.Read())
                {
                    clsGetData.GetRole = db.dr["Role"].ToString();
                    active = (bool)db.dr["Active"];
                    count = count + 1;
                }
                if (count == 1)
                {
                    if (active != true)
                    {
                        MessageBox.Show("Your user is not active please contact to admin !");
                        db.con.Close();
                        return;
                    }
                    Admin_Management_frm frm = new Admin_Management_frm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username and Password is not correct");
                }
                db.con.Close();
            }
            else
            {
                db.ConectionStr();
                db.cmd = new OleDbCommand();
                db.cmd.Connection = db.con;
                db.cmd.CommandText = "select UID, UserName, Password, Active, Balance, FullName, AccountNo from Customer_tbl inner join Customer_User_tbl on Customer_tbl.CID = Customer_User_tbl.UID where UserName ='" + txtUser.Text + "' and Password= '" + txtPass.Text + "' ";
                db.dr = db.cmd.ExecuteReader();
                int count = 0;
                bool active = false;
                while (db.dr.Read())
                {
                    count = count + 1;
                    active = (bool)db.dr["Active"];
                    clsGetData.GetCustomerName = db.dr["FullName"].ToString();
                    clsGetData.AccountNo = db.dr["AccountNo"].ToString();
                    clsGetData.Balance = Convert.ToDecimal(db.dr["Balance"]);
                    clsGetData.GetID = Convert.ToInt32(db.dr["UID"]);
                }
                if (count == 1)
                {
                    if (active != true)
                    {
                        MessageBox.Show("Your user is not active please contact to admin !");
                        db.con.Close();
                        return;
                    }
                    Main_Form_1 frm = new Main_Form_1();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username and Password is not correct");
                }
                db.con.Close();
            }
        }//

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void myMouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void myMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }
            else if (c is ComboBox)
            {
                c = (ComboBox)c;
            }

            if (c.Text == c.Tag.ToString())
            {
                c.Text = "";
                c.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }
            else if (c is ComboBox)
            {
                c = (ComboBox)c;
            }

            if (c.Text.Trim() == "")
            {
                c.Text = c.Tag.ToString();
                c.ForeColor = Color.Silver;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void Login_frm_Shown(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void lbLanguage_MouseDown(object sender, MouseEventArgs e)
        {
            lbLanguage.ForeColor = Color.Gray;
        }

        private void lbLanguage_MouseEnter(object sender, EventArgs e)
        {
            lbLanguage.ForeColor = Color.SeaGreen;
        }

        private void lbLanguage_MouseLeave(object sender, EventArgs e)
        {
            lbLanguage.ForeColor = Color.Black;
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
                        //lbLanguage.Image = Image.FromFile("Imgaes\\Flate eng-01.png");
                        break;
                    case "en-US":
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("km-KH");
                        lbLanguage.Text = "ភាសាខ្មែរ";
                        //lbLanguage.Image = Image.FromFile("Imgaes\\Flate kh 16px-01.png");
                        break;
                }
            }//if
            else return;
            
            clsGetData.MyLanguage = lbLanguage.Text;
        }

        private void lbLanguage_MouseClick(object sender, MouseEventArgs e)
        {
            lbLanguage.ForeColor = Color.SeaGreen;
        }

        private void cboRole_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }//
}///
