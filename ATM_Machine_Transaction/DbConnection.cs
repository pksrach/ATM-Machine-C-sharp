using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_Transaction
{
    class DbConnection
    {
        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataReader dr;
        public OleDbDataAdapter da;
        public DataTable dt;


        //dbcon.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Git\Project For Midterm\ATM_Machine_Transaction\bin\Debug\ATM_DB.accdb; Persist Security Info = False;";
        //private string constr = "Provider = Microsoft.ACE.OleDb.16.0; Data Source = ATM_DB.accdb";
        public void ConectionStr()
        {
            con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.ACE.OleDb.16.0; Data Source = ATM_DB.accdb";
            con.Open();
        }
        //public void myConnection()
        //{
        //    con = new OleDbConnection();
        //    //dbcon.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Git\Project For Midterm\ATM_Machine_Transaction\bin\Debug\ATM_DB.accdb; Persist Security Info = False;";
        //    con.ConnectionString = "Provider = Microsoft.ACE.OleDb.16.0; Data Source = ATM_DB.accdb";
        //    con.Open();
        //}



    }
}
