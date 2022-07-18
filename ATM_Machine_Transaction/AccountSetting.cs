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
    public partial class AccountSetting : Form
    {
        DbConnection db = new DbConnection();
        clsCheck check = new clsCheck();
        AlertMessage_frm AlertMessage;
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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (check.isEmptyTextBox(txtCurrentPW) == true) return;
            else if (check.isEmptyTextBox(txtNewPW) == true) return;
            else if (check.isEmptyTextBox(txtConfirmPW) == true) return;

            db.ConectionStr();
            db.cmd = new OleDbCommand();
            db.cmd.Connection = db.con;
            db.cmd.CommandText = "select Password from Customer_User_tbl where UID = @uid ";
            db.cmd.Parameters.AddWithValue("@uid", clsGetData.GetID);
            db.dr = db.cmd.ExecuteReader();
            string password = "";
            if (db.dr.Read())
            {
                password = db.dr["Password"].ToString();
            }
            db.con.Close();
            if(txtCurrentPW.Text != password)
            {
                if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your current password is not correct, please try again!", "Warning");
                else AlertMessage = new AlertMessage_frm("លេខសម្ងាត់ បច្ចុប្បន្នរបស់មិនត្រឹមត្រូវទេ, សូមព្យាយាមម្ដងទៀត!", "បំរាម");
                AlertMessage.ShowDialog();
                txtCurrentPW.SelectAll();
                txtCurrentPW.Focus();
                return;
            }
            if(txtNewPW.Text != txtConfirmPW.Text)
            {
                if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your new password is not correct confirm password, please try again!", "Warning");
                else AlertMessage = new AlertMessage_frm("លេខសម្ងាត់ថ្មី របស់អ្នកមិនត្រឹមត្រូវជាមួយ លេខសម្ងាត់បញ្ជាក់ទេ, សូមព្យាយាមម្ដងទៀត!", "បំរាម");
                AlertMessage.ShowDialog();
                txtCurrentPW.SelectAll();
                txtCurrentPW.Focus();
                return;
            }
            //update password
            db.ConectionStr();
            db.cmd = new OleDbCommand("UPDATE Customer_User_tbl cu inner join Customer_tbl c on c.CID = cu.UID set cu.Password = @password WHERE c.CID=cu.UID and cu.UID = @uid ", db.con);
            db.cmd.Parameters.AddWithValue("@password", txtNewPW.Text);
            db.cmd.Parameters.AddWithValue("@uid", clsGetData.GetID);
            db.cmd.ExecuteNonQuery();
            db.con.Close();

            //show message success
            if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your password has been change success!", "Success");
            else AlertMessage = new AlertMessage_frm("លេខសម្ងាត់ របស់អ្នកកែប្រែបាន ដោយជោគជ័យ", "ជោគជ័យ");
            AlertMessage.ShowDialog();

            txtCurrentPW.Clear();
            txtNewPW.Clear();
            txtConfirmPW.Clear();
            txtCurrentPW.Focus();
        }

        private void txtConfirmPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEnter_Click(null, null);
        }

        private void txtNewPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtConfirmPW.Focus();
        }

        private void txtCurrentPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtNewPW.Focus();
        }
    }//
}//
