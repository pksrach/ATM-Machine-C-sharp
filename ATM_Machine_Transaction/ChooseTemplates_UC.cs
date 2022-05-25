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
    public partial class ChooseTemplates_UC : UserControl
    {
        public ChooseTemplates_UC()
        {
            InitializeComponent();
        }

        private void lbBtn_Click(object sender, EventArgs e)
        {
            clsGetData data = new clsGetData();
            data.MyUsername = lbUsername.Text;
            data.MyAccount = lbAccount.Text;
            MessageBox.Show(data.MyUsername + "\n" + data.MyAccount);
            clsGetData.CheckCloseFrm = true;
            TemplateFrm frm = new TemplateFrm();
            frm.Close();
        }
    }
}
