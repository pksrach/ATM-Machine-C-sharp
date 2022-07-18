using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ATM_Machine_Transaction
{
    public partial class Deposit_frm : Form
    {
        clsCheck check = new clsCheck();
        AlertMessage_frm AlertMessage;
        DbConnection db = new DbConnection();
        public Deposit_frm()
        {
            InitializeComponent();
        }
       
        private void btnClear_Click(object sender, EventArgs e)
        {
            
            //frmMain.MylabelBalance();
            
            txtCash.Clear();
            txtCash.Focus();
        }

        private void myEventHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.DarkSlateGray;
        }
        private void myEventLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.White;
        }
        private void myEventClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.DarkSlateGray;
        }

        private void myEventDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.DarkGray;
        }
        private void myEventClick(object sender, EventArgs e)
        {
            //when text cash is select all
            if (b==true)
            {
                txtCash.Clear();
            }
            b = false;

            Button btn = (Button)sender;
            txtCash.Text += btn.Text;
        }

        private void Deposit_frm_Load(object sender, EventArgs e)
        {
            
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8; // 8 is backspace
            if (e.KeyChar == (char)13)
            {
                btnEnter_Click(null, null);
            }
            
        }
        bool b = false;
        decimal cash;
        decimal total = 0;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (check.isEmptyTextBox(txtCash) == true) { return; }

            //if (txtCash.Text == "")
            //{
            //    txtCash.Focus();
            //}
            //else
            //{
            cash = decimal.Parse(txtCash.Text.Replace("$", "").Replace(",", ""));
            if (cash < 10)
            {
                if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your cash is not enough, Must be big than $10", "Warning");
                else AlertMessage = new AlertMessage_frm("ប្រាក់របស់អ្នក មិនគ្រប់គ្រាន់ទេ, ត្រូវតែធំជាង 10$", "បំរាម");
                AlertMessage.ShowDialog();
                txtCash.Focus();
                txtCash.SelectAll();
                b = true; //clear number for input button number when txtCash is selectAll 
            }
            else
            {
                db.ConectionStr();
                string query = "insert into Cash_Deposit_Transaction_tbl (Tran_Ref, Tran_Date, Deposit_Amount, Dep_UserId) values(@p1, @p2, @p3, @p4)";
                db.cmd = new OleDbCommand(query, db.con);
                db.cmd.Parameters.AddWithValue("@p1", clsGetData.GetCustomerName);
                db.cmd.Parameters.AddWithValue("@p2", DateTime.Now.ToString());
                db.cmd.Parameters.AddWithValue("@p3", txtCash.Text);
                db.cmd.Parameters.AddWithValue("@p4", clsGetData.GetID);
                db.cmd.ExecuteNonQuery();
                //update Balance
                clsGetData.Balance += cash;
                string query2 = "update Customer_User_tbl cu inner join Customer_tbl c on c.CID = cu.UID set Balance = @p1 where cu.UID = @uid";
                db.cmd = new OleDbCommand(query2, db.con);
                db.cmd.Parameters.AddWithValue("@p1", clsGetData.Balance);
                db.cmd.Parameters.AddWithValue("@uid", clsGetData.GetID);
                db.cmd.ExecuteNonQuery();
                db.con.Close();
                //-------------end query--------------------------
                total += cash;
                lbTotal.Text = total.ToString();
                lbTotal.Text = "$ " + string.Format("{0:n0}", decimal.Parse(lbTotal.Text));
                if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your cash has been add $ " + cash, "Information");
                else AlertMessage = new AlertMessage_frm("ប្រាក់របស់អ្នក ដាក់បានជោគជ័យ $ " + cash, "ជោគជ័យ");
                AlertMessage.ShowDialog();
                txtCash.Clear();
                txtCash.Focus();
            }
        }
    }//
}//
