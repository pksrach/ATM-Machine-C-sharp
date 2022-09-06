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
    public partial class TemplateFrm : Form
    {
        public Point mouseLocation;
        DbConnection db = new DbConnection();
        public TemplateFrm()
        {
            InitializeComponent();
        }

        private void TemplateFrm_Load(object sender, EventArgs e)
        {

            //add user control jol table layout panel jea array with loop
            /*ChooseTemplates_UC[] ch = { new ChooseTemplates_UC(this), new ChooseTemplates_UC(this), new ChooseTemplates_UC(this), new ChooseTemplates_UC(this), 
                                                             new ChooseTemplates_UC(this), new ChooseTemplates_UC(this),new ChooseTemplates_UC(this),new ChooseTemplates_UC(this)};*/

            int row = 0;
            try
            {
                string sql = "select FullName, AccountNo from Customer_tbl ";
                db.ConectionStr();
                OleDbCommand cmd = new OleDbCommand(sql, db.con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string fullname = dr["FullName"].ToString();
                    string accountNo = dr["AccountNo"].ToString();
                    ChooseTemplates_UC obj = new ChooseTemplates_UC(tableLayoutPanel1, fullname, accountNo);
                    tableLayoutPanel1.Controls.Add(obj, 0, row);
                    row++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*somrab add jol table layout panel muy muy*/
            //ChooseTemplates_UC ch = new ChooseTemplates_UC();
            //ChooseTemplates_UC ch1 = new ChooseTemplates_UC();
            //ChooseTemplates_UC ch2 = new ChooseTemplates_UC();
            //ChooseTemplates_UC ch3 = new ChooseTemplates_UC();
            //ChooseTemplates_UC ch4 = new ChooseTemplates_UC();

            //ch.MyUsername = "Phan Kongsamrach";
            //ch.MyAccount = "002 234 544";

            //ch1.MyUsername = "Suon Pisey";
            //ch1.MyAccount = "005 667 998";

            //ch2.MyUsername = "Suon Pisey";
            //ch2.MyAccount = "001 553 987";

            //ch3.MyUsername = "Nim Phol";
            //ch3.MyAccount = "002 543 123";

            //tableLayoutPanel1.Controls.Add(ch, 0, 0);
            //tableLayoutPanel1.Controls.Add(ch1, 0, 1);
            //tableLayoutPanel1.Controls.Add(ch2, 0, 2);
            //tableLayoutPanel1.Controls.Add(ch3, 0, 3);
            //tableLayoutPanel1.Controls.Add(ch4, 0, 4);
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (clsGetData.MyLanguage == "ភាសាខ្មែរ") clsGetData.MyAccount = "ដាក់លេខគណនីទទួល";
            else clsGetData.MyAccount = "Enter receiver account number";
        }

        public void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//
}///
