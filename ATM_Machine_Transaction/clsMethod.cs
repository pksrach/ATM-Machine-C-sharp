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


    }
}
