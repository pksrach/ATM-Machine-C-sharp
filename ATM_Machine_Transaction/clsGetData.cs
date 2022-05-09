using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_Transaction
{
    class clsGetData
    {
        private static double balance;
       public static double Balance{
            get => balance;                     //get { return name; }   // get method
            set => balance = value;     //set { name = value; }  // set method
        }
       
    }//
}///
