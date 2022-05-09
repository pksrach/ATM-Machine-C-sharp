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
    public partial class AlertMessage_frm : Form
    {
        public Point mouseLocation;
        public AlertMessage_frm(string lb, string title)
        {
            InitializeComponent();
            this.lbTitle.Text = lb;
            this.lbAlertTitle.Text = title;

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AlertMessage_frm_Load(object sender, EventArgs e)
        {
            
        }
        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose =  Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

    }//
}///
