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
    public partial class Admin_Management_frm : Form
    {
        public Admin_Management_frm()
        {
            InitializeComponent();
            if (clsGetData.GetRole != "Admin")
            {
                btnStaff.Visible = false;
                btnCustomer.Visible = false;
            }
            else
            {
                btnStaff.Visible = true;
                btnCustomer.Visible = true;
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            //Login frm = new Login();
            Login_frm frm = new Login_frm(); 
            frm.Show();
            this.Hide();
        }

        private void myEventActionButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Return" || button.Text == "ចាកចេញ")
            {
                //Login_old frm = new Login();
                Login_frm frm = new Login_frm();
                frm.Show();
                this.Hide();
            }
            else if (button.Text == "Staff Management" || button.Text == "គ្រប់គ្រង បុគ្គលិក")
            {
                Admin_Staff_frm frm = new Admin_Staff_frm();
                frm.Show();
                this.Hide();
            }
            else if (button.Text == "Customer Management" || button.Text == "គ្រប់គ្រង អតិថិជន")
            {
                Admin_Customer_frm frm = new Admin_Customer_frm();
                frm.Show();
                this.Hide();
            }
            else if (button.Text == "User Management" || button.Text == "គ្រប់គ្រង អ្នកប្រើប្រាស់")
            {
                Admin_User_frm frm = new Admin_User_frm();
                frm.Show();
                this.Hide();
            }
            clsGetData.CheckBtn = button.Text;
        }
    }//
}//
