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
    public partial class Admin_Staff_frm : Form
    {
        DbConnection db = new DbConnection();
         clsCheck check = new clsCheck();
        clsMethod md = new clsMethod();
        public Admin_Staff_frm()
        {
            InitializeComponent();
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
            MyRefresh();
            Clear();
            txtFullname.Focus();
        }

        private void MyRefresh()
        {
            md.LoadData(dataGridView1, "Select * from Staff_tbl");
            dataGridView1.Columns["SID"].Visible = false;
            dataGridView1.Columns["StaffName"].HeaderText = "Staff Name";
            dataGridView1.Columns["username"].HeaderText = "Username";
            dataGridView1.Columns["pass"].HeaderText = "Password";
            dataGridView1.Columns["pass"].Visible = false;
            dataGridView1.Columns["MyPosition"].HeaderText = "Position";

            txtFullname.Focus();
            btnSave.Enabled = true;
        }
        private void Clear()
        {
            txtFullname.Text = null;
            txtUsername.Text = null;
            txtPassword.Text = null;
            cboPosition.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            MyRefresh();
            //md.MyClear(panel_info);

            Clear();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check.isEmptyTextBox(txtFullname) == true) return;
            else if (check.isEmptyTextBox(txtUsername) == true) return;
            else if (check.isEmptyTextBox(txtPassword) == true) return;
            else if (check.isNotSelectCombobox(cboPosition) == true) return;
            else if (check.isNotSelectCombobox(cboRole) == true) return;

            //check already exists username
            db.ConectionStr();
            string existsUsername = "select username from Staff_tbl where username = @existsUsername";
            db.cmd = new OleDbCommand(existsUsername, db.con);
            db.cmd.Parameters.AddWithValue("@existsUsername", this.txtUsername.Text);
            
            db.dr = db.cmd.ExecuteReader();
            string usernameInDb = "";
            if (db.dr.Read())
            {
                usernameInDb = db.dr["username"].ToString();
            }
            if (txtUsername.Text == usernameInDb)
            {
                MessageBox.Show("Username already exists !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                db.con.Close();
                return;
            }
            db.con.Close();
            //---------------End check already exists username------------------------

            string query = "insert into Staff_tbl (StaffName, username, pass, MyPosition, Role, Active) values (@p1, @p2, @p3, @p4, @p5, @p6)";
            db.cmd = new OleDbCommand(query, db.con);


            db.cmd.Parameters.AddWithValue("@p1", txtFullname.Text);
            db.cmd.Parameters.AddWithValue("@p2", txtUsername.Text);
            db.cmd.Parameters.AddWithValue("@p3", txtPassword.Text);
            db.cmd.Parameters.AddWithValue("@p4", cboPosition.SelectedItem.ToString());
            db.cmd.Parameters.AddWithValue("@p5", cboRole.Text);
            db.cmd.Parameters.AddWithValue("@p6", chbActive.Checked);
            db.con.Open();
            db.cmd.ExecuteNonQuery();
            db.con.Close();
            MessageBox.Show("Save Successfull", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MyRefresh();
            Clear();
        }

        private int sid = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count is 0) return;

            DialogResult result = MessageBox.Show("Do you want to update ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            string query = "UPDATE Staff_tbl SET StaffName=@p1, username=@p2, pass=@p3, MyPosition=@p4, Role=@p5, Active=@p6 WHERE SID = @sid ";

            db.ConectionStr();
            db.cmd = new OleDbCommand(query, db.con);
            db.cmd.Parameters.AddWithValue("@p1", txtFullname.Text);
            db.cmd.Parameters.AddWithValue("@p2", txtUsername.Text);
            db.cmd.Parameters.AddWithValue("@p3", txtPassword.Text);
            db.cmd.Parameters.AddWithValue("@p4", cboPosition.SelectedItem);
            db.cmd.Parameters.AddWithValue("@p5", cboRole.SelectedItem);
            db.cmd.Parameters.AddWithValue("@p6", chbActive.Checked);
            db.cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(sid));

            db.cmd.ExecuteNonQuery();
            db.con.Close();

            //MessageBox.Show("Update Successfull");
            //md.MyClear(panel_info); //doy sa text box dak knong panel jg laeng ng trov dak panel_info jg hz ber vea min knong panel yg dak this
            MyRefresh();
            Clear();
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
                string query = "DELETE FROM Staff_tbl WHERE SID = @sid";
                db.ConectionStr();
                db.cmd = new OleDbCommand(query, db.con);
                db.cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(sid));
                db.cmd.ExecuteNonQuery();
                db.con.Close();

                //MessageBox.Show("Delete Successfull");
                MyRefresh();
                Clear();
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //laeng ng samrab yok data pi datagridview yok dak jol tv textbox 
            if (dataGridView1.SelectedRows.Count > -1) btnSave.Enabled = false;
            else btnSave.Enabled = true;
            sid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SID"].Value.ToString());
            txtFullname.Text = dataGridView1.CurrentRow.Cells["StaffName"].Value.ToString();
            txtUsername.Text = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells["pass"].Value.ToString();
            cboPosition.Text = dataGridView1.CurrentRow.Cells["MyPosition"].Value.ToString();
            cboRole.Text = dataGridView1.CurrentRow.Cells["Role"].Value.ToString();
            chbActive.Checked = (bool)dataGridView1.CurrentRow.Cells["Active"].Value;
           
        //code khang krom ng use in selectedChange in datagridview
            //sid = (int)dataGridView1.SelectedCells[1].Value;
            //txtFullname.Text = dataGridView1.SelectedCells[2].Value.ToString();
            //txtUsername.Text = dataGridView1.SelectedCells[3].Value.ToString();
            //txtPassword.Text = dataGridView1.SelectedCells[4].Value.ToString();
            //cboPosition.Text = dataGridView1.SelectedCells[5].Value.ToString();
            //cboRole.Text = dataGridView1.SelectedCells[6].Value.ToString();
            //chbActive.Checked = (bool)dataGridView1.SelectedCells[7].Value;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }
    }//
}//
