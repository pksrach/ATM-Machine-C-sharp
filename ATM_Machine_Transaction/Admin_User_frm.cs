using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Admin_User_frm : Form
    {
        clsMethod md = new clsMethod();
        DbConnection db = new DbConnection();
        clsCheck check = new clsCheck();
        public Admin_User_frm()
        {
            InitializeComponent();
            //md.con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source=ATM_DB.accdb");
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            //Login frm = new Login();
            Admin_Management_frm frm = new Admin_Management_frm(); 
            frm.Show();
            this.Hide();
        }

        private void Admin_User_frm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            MyRefresh();
        }

        private void MyRefresh()
        {
            md.ComboBoxData(cboName, "SELECT CID, FullName FROM Customer_tbl LEFT JOIN Customer_User_tbl ON Customer_tbl.CID = Customer_User_tbl.UID WHERE (((UID) Is Null))", "FullName", "CID");
            md.LoadData(dataGridView1, "Select UID, UserName, Password, Active, Balance from Customer_User_tbl");
            dataGridView1.Columns["UID"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;

            dataGridView1.ClearSelection();
            txtPassword.Text = null;
            txtUsername.Text = null;
            txtUsername.Focus();
            btnSave.Enabled = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            MyRefresh();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check.isEmptyTextBox(txtUsername) == true) return;
            else if (check.isEmptyTextBox(txtPassword) == true) return;
            else if (check.isNotSelectCombobox(cboName) == true) return;

            //md.con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source=ATM_DB.accdb");

            string existsUsername = "select UserName from Customer_User_tbl where UserName = @existsUsername";
            db.ConectionStr();
            db.cmd = new OleDbCommand(existsUsername, db.con);
            db.cmd.Parameters.AddWithValue("@existsUsername", this.txtUsername.Text);
            db.dr = db.cmd.ExecuteReader();
            string usernameInDb="";
            if (db.dr.Read())
            {
                usernameInDb = db.dr["UserName"].ToString();
            }
            if (txtUsername.Text == usernameInDb)
            {
                MessageBox.Show("Username already exists !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                db.con.Close();
                return;
            }
            db.con.Close();

            string query = "INSERT INTO Customer_User_tbl VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)";
            db.cmd = new OleDbCommand(query, db.con);

            db.cmd.Parameters.AddWithValue("@p1", cboName.SelectedValue); // insert id from customer CID = UID
            db.cmd.Parameters.AddWithValue("@p2", txtUsername.Text);
            db.cmd.Parameters.AddWithValue("@p3", txtPassword.Text);
            db.cmd.Parameters.AddWithValue("@p4", chbActive.Checked);
            db.cmd.Parameters.AddWithValue("@p5", 0.00);
            db.cmd.Parameters.AddWithValue("@p6", clsGetData.GetID);
            db.cmd.Parameters.AddWithValue("@p7", DateTime.Now.ToString());
            db.cmd.Parameters.AddWithValue("@p8", clsGetData.GetID);
            db.cmd.Parameters.AddWithValue("@p9", DateTime.Now.ToString());

            db.con.Open();
            db.cmd.ExecuteNonQuery();
            db.con.Close();
            MessageBox.Show("Save Successfull", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MyRefresh();
        }

        private int uid = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count is 0) return;

            DialogResult result = MessageBox.Show("Do you want to update ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            string query = "UPDATE Customer_User_tbl cu inner join Customer_tbl c on c.CID = cu.UID set cu.UserName=@username, cu.Password=@pass, Active=@active, UpdatedBy='"+ clsGetData.GetID + "', UpdatedDate='"+ DateTime.Now.ToString() + "' WHERE c.CID=cu.UID and cu.UID = @uid ";
            db.ConectionStr();
            db.cmd = new OleDbCommand(query, db.con);

            db.cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            db.cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            db.cmd.Parameters.AddWithValue("@active", chbActive.Checked);
            db.cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));

            db.cmd.ExecuteNonQuery();
            db.con.Close();

            //MessageBox.Show("Update Successfull");
            MyRefresh();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //laeng ng samrab yok data pi datagridview yok dak jol tv textbox 
            if (dataGridView1.SelectedRows.Count > -1) btnSave.Enabled = false;
            else btnSave.Enabled = true;
            uid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UID"].Value.ToString());
            txtUsername.Text = dataGridView1.CurrentRow.Cells["UserName"].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
            chbActive.Checked = (bool)dataGridView1.CurrentRow.Cells["Active"].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //protect validate
            if (dataGridView1.SelectedRows.Count is 0) return;
            DialogResult result = MessageBox.Show("Do you want to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            //-------------------
            try
            {
                string query = "DELETE FROM Customer_User_tbl WHERE UID = @uid";
                db.ConectionStr();
                db.cmd = new OleDbCommand(query, db.con);
                db.cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));

                db.cmd.ExecuteNonQuery();
                db.con.Close();
                MyRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5) e.CellStyle.Format = "$#,##0.00";
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }
    }//
}//
