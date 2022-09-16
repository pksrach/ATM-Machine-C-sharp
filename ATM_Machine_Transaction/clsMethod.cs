using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    class clsMethod
    {
        DbConnection db = new DbConnection();
        public void ComboBoxData(ComboBox cbo, string query, string name, string value)
        {
            db.ConectionStr();
            db.da = new OleDbDataAdapter(query, db.con); //call comboBox or display to C#
            DataTable dt = new DataTable();
            db.da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = name;
            cbo.ValueMember = value;
            db.con.Close();
        }//method show data into comboBox

        public void LoadData(DataGridView dgv, string sql)
        {
            db.ConectionStr();
            db.da = new OleDbDataAdapter(sql, db.con);
            DataTable dt = new DataTable();
            db.da.Fill(dt);
            dgv.DataSource = dt;
            db.con.Close();
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ClearSelection();
            
        }//method show data into dataGridView

        //clear box
        public void MyClear(Control p)
        {
            foreach (Control c in p.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = null;
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.SelectedIndex = -1;
                }
            }
        }
        
        //report
        public void previewDepositReport(String excelPath)
        {
            Microsoft.Office.Interop.Excel.Application Xa = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;
            Wb = Xa.Workbooks.Open(excelPath, false, false, true);
            Ws = Wb.Worksheets["sheet1"];
            String sql = "select Tran_Ref, Tran_Date, Deposit_Amount from Cash_Deposit_Transaction_tbl ";
            String where = "where CInt(Dep_UserId) = '" + clsGetData.GetID.ToString() + "' ";
            db.ConectionStr();
            db.cmd = new OleDbCommand(sql + where, db.con);
            //db.cmd.CommandText =;
            OleDbDataReader dr = db.cmd.ExecuteReader();
            int row = 5; //row excel index
            int no = 0;
            while (dr.Read())
            {
                string tran_ref = dr["Tran_Ref"].ToString();
                string tran_date = dr["Tran_Date"].ToString();
                string amount = dr["Deposit_Amount"].ToString();
                no++;
                Ws.Cells[row, 1] = no;
                Ws.Cells[row, 2] = tran_ref;
                Ws.Cells[row, 3] = tran_date;
                Ws.Cells[row, 4] = amount;

                row++;
            }
            dr.Close();

            //if kh set column header in excel to column header kh 
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                Ws.Cells[1, 1] = "ដាក់ប្រាក់";
                Ws.Cells[2, 1] = "របាយការណ៍";
                Ws.Cells[3, 1] = "កាលបរិច្ឆេទ៖";

                Ws.Cells[4, 1] = "ល.រ";
                Ws.Cells[4, 2] = "ប្រតិបត្តិការ";
                Ws.Cells[4, 3] = "កាលបរិច្ឆេទ";
                Ws.Cells[4, 4] = "ចំនួនទឹកប្រាក់";
            }

            //hide row in excel
            for (int i = row; i <= 100; i++)
            {
                Ws.Rows[i].Hidden = true;
            }
            Xa.Visible = true;
            Wb.PrintPreview();

            Wb.Close(false);
            Xa.Quit();
        }//preview deposit

        public void previewWithdrawalReport(String excelPath)
        {
            Microsoft.Office.Interop.Excel.Application Xa = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;
            Wb = Xa.Workbooks.Open(excelPath, false, false, true);
            Ws = Wb.Worksheets["sheet1"];
            String sql = "select Tran_Ref, Tran_Date, Withdrawal_Amount from Cash_Withdrawal_Transaction_tbl ";
            String where = "where CInt(Win_UserId) = '" + clsGetData.GetID.ToString() + "' ";
            db.ConectionStr();
            db.cmd = new OleDbCommand(sql + where, db.con);
            //db.cmd.CommandText =;
            OleDbDataReader dr = db.cmd.ExecuteReader();
            int row = 5; //row excel index
            int no = 0;
            while (dr.Read())
            {
                string tran_ref = dr["Tran_Ref"].ToString();
                string tran_date = dr["Tran_Date"].ToString();
                string amount = dr["Withdrawal_Amount"].ToString();
                no++;
                Ws.Cells[row, 1] = no;
                Ws.Cells[row, 2] = tran_ref;
                Ws.Cells[row, 3] = tran_date;
                Ws.Cells[row, 4] = amount;

                row++;
            }
            dr.Close();

            //if kh set column header in excel to column header kh 
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                Ws.Cells[1, 1] = "ដកប្រាក់";
                Ws.Cells[2, 1] = "របាយការណ៍";
                Ws.Cells[3, 1] = "កាលបរិច្ឆេទ៖";

                Ws.Cells[4, 1] = "ល.រ";
                Ws.Cells[4, 2] = "ប្រតិបត្តិការ";
                Ws.Cells[4, 3] = "កាលបរិច្ឆេទ";
                Ws.Cells[4, 4] = "ចំនួនទឹកប្រាក់";
            }

            //hide row ot mean data in excel
            for (int i = row; i <= 100; i++)
            {
                Ws.Rows[i].Hidden = true;
            }
            Xa.Visible = true;
            Wb.PrintPreview();

            Wb.Close(false);
            Xa.Quit();
        }//previewWithdrawalReport

        public void previewTransferReport(String excelPath)
        {

            Microsoft.Office.Interop.Excel.Application Xa = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;
            Wb = Xa.Workbooks.Open(excelPath, false, false, true);
            Ws = Wb.Worksheets["sheet1"];
            string type = "";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ") type = "type_transaction_kh";
            else type = "type_transaction";
            String sql = "SELECT tf.TRAN_REF, tf.TRAN_DATE, tf.TRANSFER_AMOUNT, c.FullName AS TO_USER, c.AccountNo, tf.NOTES, tt." + type + " FROM Transaction_Type_tbl AS tt INNER JOIN (Cash_Transfer_Transaction AS tf LEFT JOIN Customer_tbl AS c ON tf.TO_USERID = c.CID ) ON tt.type_id = tf.TYPE_ID ";
            String where = "WHERE CInt(tf.FROM_USERID)= '" + clsGetData.GetID + "' OR CInt(tf.TO_USERID)= '" + clsGetData.GetID + "' ";
            db.ConectionStr();
            db.cmd = new OleDbCommand(sql + where, db.con);
            OleDbDataReader dr = db.cmd.ExecuteReader();
            int row = 5; //row excel index
            int no = 0;
            while (dr.Read())
            {
                string tran_ref = dr["TRAN_REF"].ToString();
                string tran_date = dr["TRAN_DATE"].ToString();
                string amount = dr["TRANSFER_AMOUNT"].ToString();
                string to_user = dr["TO_USER"].ToString();
                string accountNo = dr["AccountNo"].ToString();
                string notes = dr["NOTES"].ToString();
                string myType = dr[type].ToString();

                no++;
                Ws.Cells[row, 1] = no;
                Ws.Cells[row, 2] = tran_ref;
                Ws.Cells[row, 3] = tran_date;
                Ws.Cells[row, 4] = amount;
                Ws.Cells[row, 5] = to_user;
                Ws.Cells[row, 6] = accountNo;
                Ws.Cells[row, 7] = notes;
                Ws.Cells[row, 8] = myType;
                row++;
            }
            dr.Close();

            //if kh set column header in excel to column header kh 
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                Ws.Cells[1, 1] = "ផ្ទេរប្រាក់";
                Ws.Cells[2, 1] = "របាយការណ៍";
                Ws.Cells[3, 1] = "កាលបរិច្ឆេទ៖";

                Ws.Cells[4, 1] = "ល.រ";
                Ws.Cells[4, 2] = "ប្រតិបត្តិការ";
                Ws.Cells[4, 3] = "កាលបរិច្ឆេទ";
                Ws.Cells[4, 4] = "ចំនួនទឹកប្រាក់";
                Ws.Cells[4, 5] = "ទៅ អ្នកប្រើប្រាស់";
                Ws.Cells[4, 6] = "លេខកុង";
                Ws.Cells[4, 7] = "ចំណាំ";
                Ws.Cells[4, 8] = "ប្រភេទ";
            }

            //hide row ot mean data in excel
            for (int i = row; i <= 100; i++)
            {
                Ws.Rows[i].Hidden = true;
            }
            Xa.Visible = true;
            Wb.PrintPreview();

            Wb.Close(false);
            Xa.Quit();
        }//previewTransferReport

        public void previewPaymentReport(String excelPath)
        {
            Microsoft.Office.Interop.Excel.Application Xa = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook Wb;
            Microsoft.Office.Interop.Excel.Worksheet Ws;
            Wb = Xa.Workbooks.Open(excelPath, false, false, true);
            Ws = Wb.Worksheets["sheet1"];
            string type = "";
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ") type = "type_transaction_kh";
            else type = "type_transaction";
            String sql = "SELECT bp.Tran_Ref, bp.Tran_Date, bp.Transfer_Amount, bp.Billing_No, tt." + type + " FROM Bill_Payment_Transaction as bp  INNER JOIN Transaction_Type_tbl AS tt ON bp.Billing_Type = tt.type_id ";
            String where = "WHERE CInt(bp.User_ID)= '" + clsGetData.GetID + "' ";
            db.da = new OleDbDataAdapter(sql + where, db.con);
            db.ConectionStr();
            db.cmd = new OleDbCommand(sql + where, db.con);
            OleDbDataReader dr = db.cmd.ExecuteReader();
            int row = 5; //row excel index
            int no = 0;
            while (dr.Read())
            {
                string tran_ref = dr["TRAN_REF"].ToString();
                string tran_date = dr["TRAN_DATE"].ToString();
                string amount = dr["TRANSFER_AMOUNT"].ToString();
                string billing_no = dr["Billing_No"].ToString();
                string myType = dr[type].ToString();

                no++;
                Ws.Cells[row, 1] = no;
                Ws.Cells[row, 2] = tran_ref;
                Ws.Cells[row, 3] = tran_date;
                Ws.Cells[row, 4] = amount;
                Ws.Cells[row, 5] = billing_no;
                Ws.Cells[row, 6] = myType;
                row++;
            }
            dr.Close();

            //if kh set column header in excel to column header kh 
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ")
            {
                Ws.Cells[1, 1] = "ទូទាត់";
                Ws.Cells[2, 1] = "របាយការណ៍";
                Ws.Cells[3, 1] = "កាលបរិច្ឆេទ៖";

                Ws.Cells[4, 1] = "ល.រ";
                Ws.Cells[4, 2] = "ប្រតិបត្តិការ";
                Ws.Cells[4, 3] = "កាលបរិច្ឆេទ";
                Ws.Cells[4, 4] = "ចំនួនទឹកប្រាក់";
                Ws.Cells[4, 5] = "វិក័យប័ត្រ";
                Ws.Cells[4, 6] = "ប្រភេទ";
            }
                
            //hide row ot mean data in excel
            for (int i = row; i <= 100; i++)
            {
                Ws.Rows[i].Hidden = true;
            }
            Xa.Visible = true;
            Wb.PrintPreview();

            Wb.Close(false);
            Xa.Quit();
        }//previewPaymentReport


    }//
}///
