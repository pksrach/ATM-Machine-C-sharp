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
    public partial class MiniPayment_frm : Form
    {
        DbConnection db = new DbConnection();
        AlertMessage_frm AlertMessage;
        public MiniPayment_frm()
        {
            InitializeComponent();
        }
        public MiniPayment_frm(string title, Image i, TextBox t, TextBox amt, TextBox note)
        {
            InitializeComponent();
            lbTittle.Text = title;
            pic.Image = i;
            txtMobilePhone.Text = t.Text;
            txtMobilePhone.Tag = t.Text;
            txtAmount.Text = amt.Text;
            txtAmount.Tag = amt.Text;
            txtNote.Text = note.Text;
            txtNote.Tag = note.Text;

            if (clsGetData.CheckBtn == "Transfer")
            {          
                if (clsCheck.MyCheckBtn == "     Choose From Template")
                {
                    if(clsGetData.MyAccount != "Enter receiver account number")
                    {
                        txtMobilePhone.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtMobilePhone.ForeColor = Color.Silver;
                    }
                    txtMobilePhone.Text = clsGetData.MyAccount;
                    txtMobilePhone.Width = 300;
                }
                else
                {
                    txtMobilePhone.Text = t.Text;
                    txtMobilePhone.Tag = t.Text;
                }
            }
            else
            {
                if(clsGetData.CheckBtn == "Choose From Template")
                {
                    txtMobilePhone.Text = clsGetData.MyAccount;
                    txtMobilePhone.ForeColor = Color.Silver;
                    txtMobilePhone.Width = 300;
                }
            }
            lbTittle.Focus();
        }
        int typeNum = 0; //1 = Transfer to other account, 2 = Transfer to card
        private void MiniPayment_frm_Load(object sender, EventArgs e)
        {
            lbTittle.Focus();
        }

        private void txtBox_Enter(object sender, EventArgs e)
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
        private void txtBox_Leave(object sender, EventArgs e)
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
        private void Clear()
        {
            txtMobilePhone.Text = txtMobilePhone.Tag.ToString();
            txtMobilePhone.ForeColor = Color.Silver;
            txtAmount.Text = txtAmount.Tag.ToString();
            txtAmount.ForeColor = Color.Silver;
            txtNote.Text = txtNote.Tag.ToString();
            txtNote.ForeColor = Color.Silver;
        }
        private void Insert_To_Transfer(string nameSender, string datetime_now, string amount, int id_sender, int id_receiver, string notes, int type)
        {
            //add into transfer 
            db.ConectionStr();
            string query_insert_transfer = "insert into Cash_Transfer_Transaction (TRAN_REF, TRAN_DATE, TRANSFER_AMOUNT, FROM_USERID, TO_USERID, NOTES, TYPE_ID) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
            db.cmd = new OleDbCommand(query_insert_transfer, db.con);
            db.cmd.Parameters.AddWithValue("@p1", nameSender); //clsGetData.GetCustomerName
            db.cmd.Parameters.AddWithValue("@p2", datetime_now); //DateTime.Now.ToString()
            db.cmd.Parameters.AddWithValue("@p3", amount); //txtAmount.Text
            db.cmd.Parameters.AddWithValue("@p4", id_sender); //clsGetData.GetID
            db.cmd.Parameters.AddWithValue("@p5", id_receiver); //uid
            if (notes == "Remark (optional)") notes = "";
            db.cmd.Parameters.AddWithValue("@p6", notes); //txtNote.Text
            db.cmd.Parameters.AddWithValue("@p7", type); //lbTittle.Text
            db.cmd.ExecuteNonQuery();
            db.con.Close();
        }
        private void update_balance(decimal balance, int sender_id)
        {
            db.ConectionStr();
            string query_update_balance = "update Customer_User_tbl cu inner join Customer_tbl c on c.CID = cu.UID set Balance = @balance where cu.UID = @uid";
            db.cmd = new OleDbCommand(query_update_balance, db.con);
            db.cmd.Parameters.AddWithValue("@balance", balance); //clsGetData.Balance
            db.cmd.Parameters.AddWithValue("@uid", sender_id); //clsGetData.GetID
            db.cmd.ExecuteNonQuery();
            db.con.Close();
        }
        private void Transfer_To_Other()
        {
            string query_check_acccount_no = "select UID, FullName, AccountNo, Balance from Customer_User_tbl inner join Customer_tbl on Customer_User_tbl.UID = Customer_tbl.CID where AccountNo = '" + txtMobilePhone.Text +"'";
            db.ConectionStr();
            db.cmd = new OleDbCommand();
            db.cmd.Connection = db.con;
            db.cmd.CommandText = query_check_acccount_no;
            db.dr = db.cmd.ExecuteReader();
            int count = 0;
            int uid=0;
            string name = "";
            string account_no = "";
            decimal receiver_balance = 0;
            while (db.dr.Read())
            {
                count = count + 1;
                uid = (int)db.dr["UID"];
                name = db.dr["FullName"].ToString();
                account_no = db.dr["AccountNo"].ToString();
                receiver_balance = (decimal)db.dr["Balance"];
            }
            db.con.Close();
            if (count == 1)
            {
                if (account_no == clsGetData.AccountNo)
                {
                    //MessageBox.Show("This is your account no = " + account_no + ", Please input again!");
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Fullname = " + name + "\nAccount No=" + account_no + "\nDo you want to confirm?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        //validate
                        if (Convert.ToDecimal(txtAmount.Text) > clsGetData.Balance || Convert.ToDecimal(txtAmount.Text) <= 0)
                        {
                            if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Your cash is not enough!", "Warning");
                            else AlertMessage = new AlertMessage_frm("ទឹកប្រាក់របស់អ្នក មិនគ្រប់គ្រាន់ទេ!", "បំរាម");
                            AlertMessage.ShowDialog();
                            return;
                        }
                        //calculate balance user using this account <Customer sender>
                        clsGetData.Balance -= Convert.ToDecimal(txtAmount.Text);
                        update_balance(clsGetData.Balance, clsGetData.GetID);
                        //-------------------end update user sender---------------------------

                        //calculate balance user receiver <Customer receiver>
                        receiver_balance += Convert.ToDecimal(txtAmount.Text);
                        //update balance user user receiver
                        string query_update_receiver_balance = "update Customer_User_tbl cu inner join Customer_tbl c on c.CID = cu.UID set Balance = @balance where cu.UID = @uid";
                        db.ConectionStr();
                        db.cmd = new OleDbCommand(query_update_receiver_balance, db.con);
                        db.cmd.Parameters.AddWithValue("@balance", receiver_balance);
                        db.cmd.Parameters.AddWithValue("@uid", uid);
                        db.cmd.ExecuteNonQuery();
                        db.con.Close();
                        //add into transfer 
                        db.ConectionStr();
                        Insert_To_Transfer(clsGetData.GetCustomerName, DateTime.Now.ToString(), txtAmount.Text, clsGetData.GetID, uid, txtNote.Text, 1);
                        if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("You has been transfer $ " + txtAmount.Text + " to another account no " + account_no + " successfully", "Information");
                        else AlertMessage = new AlertMessage_frm("អ្នកបានផ្ទេរប្រាក់ $ " + txtAmount.Text + " ទៅឲ្យគណនី " + account_no + " បានដោយជោគជ័យ", "ជោគជ័យ");
                        AlertMessage.ShowDialog();
                        Clear();
                    }//if confirm
                }//else  account_no receiver != clsGetData.AccountNo sender
            }// count ==1
            else
            {
                if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid account", "Information");
                else AlertMessage = new AlertMessage_frm("គណនីរកមិនឃើញ!", "ព័ត៌មាន");
                AlertMessage.ShowDialog();
            }
            db.con.Close();
        }//Transfer to other
        //------------------------------------------------

        private void Payment(string notes, string datetime_now, string amount, string billing_no, int type, int uid)
        {
            //add into transfer 
            db.ConectionStr();
            string query_insert = "insert into Bill_Payment_Transaction (Tran_Ref, Tran_Date, Transfer_Amount, Billing_No, Billing_Type, User_ID) values(@p1, @p2, @p3, @p4, @p5, @p6)";
            db.cmd = new OleDbCommand(query_insert, db.con);
            if (notes == "Note") notes = "";
            db.cmd.Parameters.AddWithValue("@p1", notes); //txtNote.Text
            db.cmd.Parameters.AddWithValue("@p2", datetime_now); //DateTime.Now.ToString()
            db.cmd.Parameters.AddWithValue("@p3", amount); //txtAmount.Text
            db.cmd.Parameters.AddWithValue("@p4", billing_no); //clsGetData.GetID
            db.cmd.Parameters.AddWithValue("@p5", type); //lbTittle.Text
            db.cmd.Parameters.AddWithValue("@p6", uid);
            db.cmd.ExecuteNonQuery();
            db.con.Close();

            //calculate balance user using this account <Customer sender>
            clsGetData.Balance -= Convert.ToDecimal(txtAmount.Text);
            update_balance(clsGetData.Balance, clsGetData.GetID);
            
            //message
            if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("You has been payment $ " + txtAmount.Text + " on your number phone " + txtMobilePhone.Text + " successfully", "Information");
            else AlertMessage = new AlertMessage_frm("អ្នកបានបញ្ចូលទឹកប្រាក់ $ " + txtAmount.Text + " ទៅកាន់លេខ " + txtMobilePhone.Text + " បានដោយជោគជ័យ", "ជោគជ័យ");
            AlertMessage.ShowDialog();
            Clear();
        }//MobileTopUp


        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (txtMobilePhone.Text == txtMobilePhone.Tag.ToString()) return;
            if (txtAmount.Text == txtAmount.Tag.ToString()) return;
            if(lbTittle.Text == "Tranfser to other account" || lbTittle.Text == "ផ្ទេរទៅគណនីណាមួយ")
            {
                typeNum = 1;
                Transfer_To_Other();
            }
            else if (lbTittle.Text == "Transfer to cards" || lbTittle.Text == "ផ្ទេរទៅកាន់កាត")
            {
                typeNum = 2;
                if (txtMobilePhone.TextLength == txtMobilePhone.MaxLength)
                {
                    clsGetData.Balance -= Convert.ToDecimal(txtAmount.Text);
                    //update balance user using this account
                    update_balance(clsGetData.Balance, clsGetData.GetID);
                    Insert_To_Transfer(clsGetData.GetCustomerName, DateTime.Now.ToString(), txtAmount.Text, clsGetData.GetID, 0, txtNote.Text, typeNum);

                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("You has been transfer $ " + txtAmount.Text + " to cards " + txtMobilePhone.Text + " successfully", "Information");
                    else AlertMessage = new AlertMessage_frm("អ្នកបានផ្ទេរប្រាក់ $ " + txtAmount.Text + " ទៅឲ្យកាត " + txtMobilePhone.Text + " បានដោយជោគជ័យ", "ជោគជ័យ");
                    AlertMessage.ShowDialog();
                    Clear();
                }
                else
                {
                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid Cards!", "Information");
                    else AlertMessage = new AlertMessage_frm("កាតមិនត្រឹមត្រូវ!", "ព័ត៌មាន");
                    AlertMessage.ShowDialog();
                }
            }
            else if(lbTittle.Text == "Mobile Top-up" || lbTittle.Text == "បញ្ចូលលុយទូរស័ព្ទ")
            {
                typeNum = 3;
                if (txtMobilePhone.Text.Length <=8 || txtMobilePhone.Text.Length >= 12)
                {
                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid Phone Number!", "Information");
                    else AlertMessage = new AlertMessage_frm("លេខទូរស័ព្ទ មិនត្រឹមត្រូវ!", "ព័ត៌មាន");
                    AlertMessage.ShowDialog();
                    return;
                }
                Payment(txtNote.Text, DateTime.Now.ToString(), txtAmount.Text, txtMobilePhone.Text, typeNum, clsGetData.GetID);
            }
            else if (lbTittle.Text == "Internet && TV" || lbTittle.Text == "អ៊ីនធឺណិត && ទូរទស្សន៍")
            {
                typeNum = 4;
                if (txtMobilePhone.Text.Length >= 10)
                {
                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid Customer ID!", "Information");
                    else AlertMessage = new AlertMessage_frm("លេខសម្គាល់អតិថិជន មិនត្រឹមត្រូវ!", "ព័ត៌មាន");
                    AlertMessage.ShowDialog();
                    return;
                }
                Payment(txtNote.Text, DateTime.Now.ToString(), txtAmount.Text, txtMobilePhone.Text, typeNum, clsGetData.GetID);
            }
            else if (lbTittle.Text == "Utilities" || lbTittle.Text == "ទឹកភ្លើង && សំរាម")
            {
                typeNum = 5;
                if (txtMobilePhone.Text.Length >= 10)
                {
                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid Consumer ID!", "Information");
                    else AlertMessage = new AlertMessage_frm("លេខសម្គាល់ មិនត្រឹមត្រូវ!", "ព័ត៌មាន");
                    AlertMessage.ShowDialog();
                    return;
                }
                Payment(txtNote.Text, DateTime.Now.ToString(), txtAmount.Text, txtMobilePhone.Text, typeNum, clsGetData.GetID);
            }
            else if (lbTittle.Text == "Education" || lbTittle.Text == "ការអប់រំ")
            {
                typeNum = 6;
                if (txtMobilePhone.Text.Length >= 10)
                {
                    if (clsGetData.MyLanguage == "English") AlertMessage = new AlertMessage_frm("Invalid Student ID!", "Information");
                    else AlertMessage = new AlertMessage_frm("លេខសម្គាល់សិស្ស មិនត្រឹមត្រូវ!", "ព័ត៌មាន");
                    AlertMessage.ShowDialog();
                    return;
                }
                Payment(txtNote.Text, DateTime.Now.ToString(), txtAmount.Text, txtMobilePhone.Text, typeNum, clsGetData.GetID);
            }


        }//

        private void txtMobilePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMobilePhone_TextChanged(object sender, EventArgs e)
        {
            
        }
    }//
}///
