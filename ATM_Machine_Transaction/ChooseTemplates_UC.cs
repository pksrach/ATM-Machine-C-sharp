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
    public partial class ChooseTemplates_UC : UserControl
    {
        TableLayoutPanel tlp;
        public ChooseTemplates_UC(TableLayoutPanel tlp, String username, String account)
        {
            InitializeComponent();
            this.tlp = tlp;
            this.lbAccount.Text = account;
            this.lbUsername.Text = username;
        }

        public ChooseTemplates_UC()
        {
            InitializeComponent();
        }

        private void lbBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void lbBtn_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.SeaGreen;
        }

        private void lbBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
        }
        private void MyMouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.SeaGreen;
        }
        private void MyMouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.SeaGreen;
        }

        
        private void MyClick(object sender, EventArgs e)
        {
            //clsGetData data = new clsGetData();            
            if(DialogResult.Yes == MessageBox.Show("Do you want to click ?", "Get Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                clsGetData.MyUsername = lbUsername.Text;
                clsGetData.MyAccount = lbAccount.Text;
                
            }
        }

    }//
}///
