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

        private void Transaction_frm_Load(object sender, EventArgs e)
        {
            label1.Focus();
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
            this.dataGridView1.Rows.Add("T000000001", DateTime.Now.ToLongDateString(), clsGetData.AccountNo, "Helloworld service");
        }
    }//
}///
