using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Admin_Customer_frm : Form
    {
        DbConnection db = new DbConnection();
        clsCheck check = new clsCheck();
        public Admin_Customer_frm()
        {
            InitializeComponent();
            db.con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source=ATM_DB.accdb");
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            //Login frm = new Login();
            Admin_Management_frm frm = new Admin_Management_frm(); 
            frm.Show();
            this.Hide();
        }

        private void AccountSetting_Load(object sender, EventArgs e)
        {
            txtFullname.Focus();
            MyRefresh();
        }
        
        private void LoadDataInDb()
        {
            db.dt = new DataTable();
            db.da = new OleDbDataAdapter("select CID, FullName, Gender, DOB, PhoneNum, Address, AccountNo from Customer_tbl", db.con);
            db.con.Open();
            //String.Format("dd-MM-yyyy", dt.Columns[3]);
            db.da.Fill(db.dt);
            dataGridView1.DataSource = db.dt;
            dataGridView1.Columns["CID"].Visible = false;
            dataGridView1.Columns["DOB"].HeaderText = "Date of Birth";
            dataGridView1.Columns["DOB"].DefaultCellStyle.Format = "dd-MM-yyyy";

            db.con.Close();
        }
        private int num = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check.isEmptyTextBox(txtFullname) == true) return;
            else if (check.isEmptyTextBox(txtPhoneNum) == true) return;
            else if (check.isEmptyTextBox(lbAccount) == true) return;
            string query = "insert into Customer_tbl (FullName, Gender, DOB, PhoneNum, Address, AccountNo) values(@p1, @p2, @p3, @p4, @p5, @p7)";
            db.cmd = new OleDbCommand(query, db.con);
            db.cmd.Parameters.AddWithValue("@p1", txtFullname.Text);
            string gender = "";
            if (chbMale.Checked) gender = chbMale.Text;
            else gender = chbFemale.Text;
            db.cmd.Parameters.AddWithValue("@p2", gender);
            db.cmd.Parameters.AddWithValue("@p3", String.Format("{0:dd-MMM-yyyy}", dob.Value));
            db.cmd.Parameters.AddWithValue("@p4", txtPhoneNum.Text);
            db.cmd.Parameters.AddWithValue("@p5", txtAddress.Text);
            //cmd.Parameters.AddWithValue("@p6", picBox);
            db.cmd.Parameters.AddWithValue("@p7", lbAccount.Text.Replace(" ", ""));

            db.con.Open();
            db.cmd.ExecuteNonQuery();
            db.con.Close();
            //MessageBox.Show("Save Successfull");
            LoadDataInDb();
            MyRefresh();

            //try
            //{
            //    con.myConnection();
            //    OleDbCommand cmd = new OleDbCommand();
            //    cmd.Connection = con.dbcon;
            //    string gender = "";
            //    if (chbMale.Checked) gender = chbMale.Text;
            //    else gender = chbFemale.Text;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "insert into Customer_tbl (FullName, Gender, DOB, PhoneNum, Address, Pic, AccountNo) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
            //    cmd.Parameters.AddWithValue("@p1", txtFullname.Text);
            //    cmd.Parameters.AddWithValue("@p2", gender);
            //    cmd.Parameters.AddWithValue("@p3", String.Format("{0:dd-MMM-yyyy}", dob.Value) );
            //    cmd.Parameters.AddWithValue("@p4", txtPhoneNum.Text);
            //    cmd.Parameters.AddWithValue("@p5", txtAddress.Text);
            //    cmd.Parameters.AddWithValue("@p6", picBox);
            //    cmd.Parameters.AddWithValue("@p7", lbAccount.Text);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Save Successfull");
            //    con.dbcon.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void lbAccount_TextChanged(object sender, EventArgs e)
        {
            if (lbAccount.Text != "")
            {
                if (lbAccount.Text.Replace(" ", "").Length > 9)
                {
                    MessageBox.Show(lbAccount.Handle.ToString());
                }
                else
                {
                    int num = int.Parse(lbAccount.Text.Replace(" ", ""));
                    lbAccount.Text = string.Format("{0:000 ### ###}", num);
                }
            }//if
        }
        private void MyRefresh()
        {
            LoadDataInDb();

            dataGridView1.ClearSelection();
            txtFullname.Text = "";
            lbAccount.Text = "";
            txtAddress.Text = "";
            txtPhoneNum.Text = "";
            //picBox.ImageLocation = @"Imgaes\NoImageFound.png";
            btnSave.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MyRefresh();
        }

        private void lbAccount_Click(object sender, EventArgs e)
        {
            Random rdm = new Random();
            int num = rdm.Next(0, 99999999);
            lbAccount.Text = string.Format("{0:000 ### ###}", num);
        }
        private int cid = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count is 0) return;

            DialogResult result = MessageBox.Show("Do you want to update ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            string query = "UPDATE Customer_tbl SET FullName=@p1, Gender=@p2, DOB=@p3, PhoneNum=@p4, Address=@p5, AccountNo=@p7 WHERE CID = @cid";

            db.cmd = new OleDbCommand(query, db.con);
            db.cmd.Parameters.AddWithValue("@p1", txtFullname.Text);
            string gender = "";
            if (chbMale.Checked) gender = chbMale.Text;
            else gender = chbFemale.Text;
            db.cmd.Parameters.AddWithValue("@p2", gender);
            db.cmd.Parameters.AddWithValue("@p3", String.Format("{0:dd-MMM-yyyy}", dob.Value));
            db.cmd.Parameters.AddWithValue("@p4", txtPhoneNum.Text);
            db.cmd.Parameters.AddWithValue("@p5", txtAddress.Text);
            //cmd.Parameters.AddWithValue("@p6", picBox);
            db.cmd.Parameters.AddWithValue("@p7", lbAccount.Text);
            db.cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(cid));

            db.con.Open();
            db.cmd.ExecuteNonQuery();
            db.con.Close();

            //MessageBox.Show("Update Successfull");
            MyRefresh();
        }//

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //laeng ng samrab yok data pi datagridview yok dak jol tv textbox 
            if (dataGridView1.SelectedRows.Count > -1)  btnSave.Enabled = false;
            else btnSave.Enabled = true;
            cid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CID"].Value.ToString());
            txtFullname.Text = dataGridView1.CurrentRow.Cells["FullName"].Value.ToString();
            string gender = dataGridView1.CurrentRow.Cells["Gender"].Value.ToString();
            if (gender == chbMale.Text)
            {
                chbMale.Checked = true;
                chbFemale.Checked = false;
            }
            else
            {
                chbFemale.Checked = true;
                chbMale.Checked = false;
            }
            dob.Text = dataGridView1.CurrentRow.Cells["DOB"].Value.ToString();
            txtPhoneNum.Text = dataGridView1.CurrentRow.Cells["PhoneNum"].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
            lbAccount.Text = dataGridView1.CurrentRow.Cells["AccountNo"].Value.ToString();
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
                string query = "DELETE FROM Customer_tbl WHERE CID = @cid";
                db.cmd = new OleDbCommand(query, db.con);
                db.cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(cid));

                db.con.Open();
                db.cmd.ExecuteNonQuery();
                db.con.Close();

                //MessageBox.Show("Delete Successfull");
                MyRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMale.CheckState == CheckState.Checked)
            {
                chbFemale.CheckState = CheckState.Unchecked;
            }
            else if (chbMale.CheckState == CheckState.Unchecked)
            {
                chbFemale.CheckState = CheckState.Checked;
            }
        }

        private void chbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFemale.CheckState == CheckState.Checked)
            {
                chbMale.CheckState = CheckState.Unchecked;
            }
            else if (chbFemale.CheckState==CheckState.Unchecked)
            {
                chbMale.CheckState = CheckState.Checked;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
    }//
}//
