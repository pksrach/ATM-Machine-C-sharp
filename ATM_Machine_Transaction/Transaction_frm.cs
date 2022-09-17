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
    public partial class Transaction_frm : Form
    {
        public Transaction_frm()
        {
            InitializeComponent();
        }

        private void myEventButtonMoney(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //txtCash.Text = btn.Text;
            ConfirmWithdraw_frm confirmFrm = new ConfirmWithdraw_frm(btn.Text);
            confirmFrm.ShowDialog();
            //txtCash.Text.Replace(" ", "$");
        }

        DbConnection db = new DbConnection();
        private void display_Deposit()
        {
            db.ConectionStr();
            
            db.dt = new DataTable();
            db.da = new OleDbDataAdapter("select Tran_Ref, Tran_Date, Deposit_Amount from Cash_Deposit_Transaction_tbl where CInt(Dep_UserId) = '" + clsGetData.GetID.ToString() + "' and DateValue(Tran_Date) BETWEEN " + dateStart.Value.ToString("#dd/MMM/yyyy#") +" AND "+dateEnd.Value.ToString("#dd/MMM/yyyy#") +" ", db.con);
            db.da.Fill(db.dt);
            dataGridView1.DataSource = db.dt;
            dataGridView1.Columns["Tran_Ref"].HeaderText = "Transaction Reference";
            dataGridView1.Columns["Tran_Date"].HeaderText = "Date";
            dataGridView1.Columns["Deposit_Amount"].HeaderText = "Deposit Amount";
            dataGridView1.Columns["Deposit_Amount"].DefaultCellStyle.Format = "$#,##0.00";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                dataGridView1.Columns["colNo"].HeaderText = "ល.រ";
                dataGridView1.Columns["Tran_Ref"].HeaderText = "ប្រតិបត្តិការ";
                dataGridView1.Columns["Tran_Date"].HeaderText = "កាលបរិច្ឆេទ";
                dataGridView1.Columns["Deposit_Amount"].HeaderText = "ចំនួនទឹកប្រាក់";
            }
            db.con.Close();

            //dataGridView1.Rows.Clear();
            //dataGridView1.ClearSelection();
            //int i = 0;
            //db.ConectionStr();
            //db.cmd = new OleDbCommand("select Tran_Ref, Tran_Date, Deposit_Amount from Cash_Deposit_Transaction_tbl where CInt(Dep_UserId) = '" + clsGetData.GetID.ToString() + "' ", db.con);
            //db.dr = db.cmd.ExecuteReader();
            //while (db.dr.Read())
            //{
            //    i++;
            //    dataGridView1.Rows.Add(i, db.dr["Tran_Ref"].ToString(), db.dr["Tran_Date"].ToString(), db.dr["Deposit_Amount"].ToString());
            //}
            //db.dr.Close();
            //db.con.Close();

        }

        void display_Withdraw()
        {
            db.ConectionStr();
            db.dt = new DataTable();
            db.da = new OleDbDataAdapter("select Tran_Ref, Tran_Date, Withdrawal_Amount from Cash_Withdrawal_Transaction_tbl where CInt(Win_UserId) = '" + clsGetData.GetID.ToString() + "' and DateValue(Tran_Date) BETWEEN " + dateStart.Value.ToString("#dd/MMM/yyyy#") + " AND " + dateEnd.Value.ToString("#dd/MMM/yyyy#") + " ", db.con);
            db.da.Fill(db.dt);
            dataGridView1.DataSource = db.dt;
            dataGridView1.Columns["Tran_Ref"].HeaderText = "Transaction Reference";
            dataGridView1.Columns["Tran_Date"].HeaderText = "Date";
            dataGridView1.Columns["Withdrawal_Amount"].HeaderText = "Withdrawal Amount";
            dataGridView1.Columns["Withdrawal_Amount"].DefaultCellStyle.Format = "$#,##0.00";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                dataGridView1.Columns["colNo"].HeaderText = "ល.រ";
                dataGridView1.Columns["Tran_Ref"].HeaderText = "ប្រតិបត្តិការ";
                dataGridView1.Columns["Tran_Date"].HeaderText = "កាលបរិច្ឆេទ";
                dataGridView1.Columns["Withdrawal_Amount"].HeaderText = "ចំនួនទឹកប្រាក់";
            }
            db.con.Close();
        }

        void display_Transfer()
        {
            db.ConectionStr();
            db.dt = new DataTable();
            string type = "";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ") type = "type_transaction_kh";
            else type = "type_transaction";
            string sql = "SELECT tf.TRAN_REF, tf.TRAN_DATE, tf.TRANSFER_AMOUNT, c.FullName AS TO_USER, c.AccountNo, tf.NOTES, tt." + type + " FROM Transaction_Type_tbl AS tt INNER JOIN (Cash_Transfer_Transaction AS tf LEFT JOIN Customer_tbl AS c ON tf.TO_USERID = c.CID ) ON tt.type_id = tf.TYPE_ID ";
            string where = "WHERE CInt(tf.FROM_USERID)= '" + clsGetData.GetID + "' AND DateValue(tf.TRAN_DATE) BETWEEN " + dateStart.Value.ToString("#dd/MMM/yyyy#") + " AND " + dateEnd.Value.ToString("#dd/MMM/yyyy#") + " "; 
            db.da = new OleDbDataAdapter(sql + where, db.con);
            db.da.Fill(db.dt);
            dataGridView1.DataSource = db.dt;
            dataGridView1.Columns["TRAN_REF"].HeaderText = "Tran Ref";
            dataGridView1.Columns["TRAN_DATE"].HeaderText = "Date";
            dataGridView1.Columns["TRAN_DATE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["TRANSFER_AMOUNT"].HeaderText = "Amount";
            dataGridView1.Columns["TRANSFER_AMOUNT"].DefaultCellStyle.Format = "$#,##0.00";
            dataGridView1.Columns["TRANSFER_AMOUNT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["TO_USER"].HeaderText = "To User";
            dataGridView1.Columns["NOTES"].HeaderText = "Notes";
            dataGridView1.Columns[type].HeaderText = "Type";
            dataGridView1.Columns[type].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                dataGridView1.Columns["colNo"].HeaderText = "ល.រ";
                dataGridView1.Columns["TRAN_REF"].HeaderText = "ប្រតិបត្តិការ";
                dataGridView1.Columns["TRAN_DATE"].HeaderText = "កាលបរិច្ឆេទ";
                dataGridView1.Columns["TRANSFER_AMOUNT"].HeaderText = "ចំនួនទឹកប្រាក់";
                dataGridView1.Columns["TO_USER"].HeaderText = "ទៅ អ្នកប្រើប្រាស់";
                dataGridView1.Columns["AccountNo"].HeaderText = "លេខកុង"; 
                dataGridView1.Columns["NOTES"].HeaderText = "ចំណាំ";
                dataGridView1.Columns[type].HeaderText = "ប្រភេទ";
            }
                db.con.Close();
        }

        void display_Payment()
        {
            db.ConectionStr();
            db.dt = new DataTable();
            string type = "";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ") type = "type_transaction_kh";
            else type = "type_transaction";
            string sql = "SELECT bp.Tran_Ref, bp.Tran_Date, bp.Transfer_Amount, bp.Billing_No, tt." + type + " FROM Bill_Payment_Transaction as bp  INNER JOIN Transaction_Type_tbl AS tt ON bp.Billing_Type = tt.type_id ";
            string where = "WHERE CInt(bp.User_ID)= '" + clsGetData.GetID + "' and DateValue(bp.Tran_Date) BETWEEN " + dateStart.Value.ToString("#dd/MMM/yyyy#") + " AND " + dateEnd.Value.ToString("#dd/MMM/yyyy#") + " ";
            db.da = new OleDbDataAdapter(sql + where, db.con);
            db.da.Fill(db.dt);
            dataGridView1.DataSource = db.dt;
            dataGridView1.Columns["Tran_Ref"].HeaderText = "Tran Ref";
            dataGridView1.Columns["Tran_Date"].HeaderText = "Date";
            dataGridView1.Columns["TRAN_DATE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Transfer_Amount"].HeaderText = "Amount";
            dataGridView1.Columns["Transfer_Amount"].DefaultCellStyle.Format = "$#,##0.00";
            dataGridView1.Columns["Transfer_Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Billing_No"].HeaderText = "Billing No";
            dataGridView1.Columns[type].HeaderText = "Type";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                dataGridView1.Columns["colNo"].HeaderText = "ល.រ";
                dataGridView1.Columns["Tran_Ref"].HeaderText = "ប្រតិបត្តិការ";
                dataGridView1.Columns["Tran_Date"].HeaderText = "កាលបរិច្ឆេទ";
                dataGridView1.Columns["Transfer_Amount"].HeaderText = "ចំនួនទឹកប្រាក់";
                dataGridView1.Columns["Billing_No"].HeaderText = "វិក័យប័ត្រ";
                dataGridView1.Columns[type].HeaderText = "ប្រភេទ";
            }
            db.con.Close();
        }

        private void Transaction_frm_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
        }

        private void pSearch_Click(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedItem == null) dataGridView1.Rows.Clear();
            else if(cmbSelect.SelectedItem.ToString() == "Deposit")
            {
                display_Deposit();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Withdraw")
            {
                display_Withdraw();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Transfer")
            {
                display_Transfer();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Payment")
            {
                display_Payment();
            }

        }

        private void pPreview_Click(object sender, EventArgs e)
        {
            clsMethod mtd = new clsMethod();
            if (cmbSelect.SelectedItem == null) return;
            string str = cmbSelect.SelectedItem.ToString();
            switch (str) {
                case "Deposit":
                    mtd.previewDepositReport(Application.StartupPath + @"\reports\deposit_rpt_template.xlsx", dateStart, dateEnd);
                    break;
                case "Withdraw":
                    mtd.previewWithdrawalReport(Application.StartupPath + @"\reports\withdraw_rpt_template.xlsx", dateStart, dateEnd);
                    break;
                case "Transfer":
                    mtd.previewTransferReport(Application.StartupPath + @"\reports\transfer_rpt_template.xlsx", dateStart, dateEnd);
                    break;
                case "Payment":
                    mtd.previewPaymentReport(Application.StartupPath + @"\reports\payment_rpt_template.xlsx", dateStart, dateEnd);
                    break;
                default:
                    break;
            }
            
            //else if (cmbSelect.SelectedItem.ToString() == "Deposit")
            //{
                
            //}
            //else if (cmbSelect.SelectedItem.ToString() == "Withdraw")
            //{
                
            //}
            //else if (cmbSelect.SelectedItem.ToString() == "Transfer")
            //{
                
            //}
            //else if (cmbSelect.SelectedItem.ToString() == "Payment")
            //{
                
            //}
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }
    }//
}///
