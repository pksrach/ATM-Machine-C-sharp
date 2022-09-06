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
        clsMethod md = new clsMethod();
        DbConnection db = new DbConnection();
        private void myDisplay()
        {
            string sql = "select Tran_Ref, Tran_Date, Deposit_Amount where Dep_UserId = '" + clsGetData.GetID + "' ";
            db.ConectionStr();
            db.cmd = new OleDbCommand(sql, db.con);

        }

        private void Transaction_frm_Load(object sender, EventArgs e)
        {
            label1.Focus();

           /* this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");*/
        }

        private void lbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            lbSearch.ForeColor = Color.White;
        }

        private void lbSearch_MouseEnter(object sender, EventArgs e)
        {
            lbSearch.ForeColor = Color.Silver;
        }

        private void lbSearch_MouseLeave(object sender, EventArgs e)
        {
            lbSearch.ForeColor = Color.White;
        }

        private void lbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            lbSearch.ForeColor = Color.Silver;
        }
    }//
}///
