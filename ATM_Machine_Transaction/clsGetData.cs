﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    class clsGetData
    {
        //get account no 
        private static string accountNo;
        public static string AccountNo
        {
            get => accountNo;
            set => accountNo = value;
        }
        //get Balance for customer
        private static double balance;
        public static double Balance {
            get => balance;                     //get { return name; }   // get method
            set => balance = value;     //set { name = value; }  // set method
        }

        //check and get langauge to remember
        private static string language = "English";
        public static string MyLanguage
        {
            get => language;
            set => language = value;
        }
        //check langauge first is null logo
        private static Image image;
        private static Image Img(Image img)
        {
            if (img is null)
            {
                img = Image.FromFile("Imgaes\\Flate eng-01.png");
            }
            else
            {
                return image;
            }
            return img;
        }
        public static Image MyImage
        {
            get => Img(image);
            set => image = value;
        }

        //get icon and text in button payment and transfer
        private Image my_icon;
        public Image MyIcon
        {
            get => my_icon;
            set => my_icon = value;
        }
        private string title;
        public string MyTitle
        {
            get => title;
            set => title = value;
        }
        //check button transfer and payment to hids textbox total
        private static string checkBtn;
        public static string CheckBtn
        {
            get => checkBtn;
            set => checkBtn = value;
        }


        //get data from choose template uc
        private string username;
        private string account;
        public string MyUsername
        {
            get => username;
            set => username = value;
        }
        public string MyAccount
        {
            get => account;
            set => account = value;
        }
        //check frm to close
        private static bool b;
        public static bool CheckCloseFrm
        {
            get => b;
            set => b = value;
        }
    }//
}///
