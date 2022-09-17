using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    public partial class Main_Form_1 : Form
    {
        public Main_Form_1()
        {
            InitializeComponent();
            //MylabelBalance();
        }

        public void myLoadForm(object frm)
        {
            
            if (this.panel_ShowForm.Controls.Count > 0)
            {
                this.panel_ShowForm.Controls.RemoveAt(0);
            }
            Form f = frm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel_ShowForm.Controls.Add(f);
            this.panel_ShowForm.Tag = f;
            f.Show();
        }//method lord form

        private void myEventHoverButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Return" || button.Text == "ចាកចេញ")
            {
                //Login_old frm = new Login();
                Login_frm frm = new Login_frm();
                frm.Show();
                this.Hide();
            }
            else if (button.Text == "Deposit" || button.Text == "ដាក់ប្រាក់")
            {
                myLoadForm(new Deposit_frm());
            }
           else if (button.Text == "Withdraw" || button.Text == "ដកប្រាក់")
            {
                myLoadForm(new Withdraw_frm());
            }
            else if (button.Text == "Transfer" || button.Text == "ផ្ទេរប្រាក់")
            {
                myLoadForm(new Transfer_frm());
            }
            else if (button.Text == "Payment" || button.Text == "ទូទាត់ប្រាក់")
            {
                myLoadForm(new Payment_frm());
            }
            else if (button.Text == "Account Setting" || button.Text == "គណនី")
            {
                myLoadForm(new AccountSetting());
            }
            else if (button.Text == "Transaction" || button.Text == "ប្រតិបត្តិការ")
            {
                myLoadForm(new Transaction_frm());
            }
            clsGetData.CheckBtn = button.Text;
        }//

        private void Main_Form_1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbCustomerName.Text = clsGetData.GetCustomerName;
            //double.Parse(lbBalance.Text.Replace("$", "").Replace(",", "")) = clsGetData.Balance;
            lbBalance.Text = clsGetData.Balance.ToString();
            lbAccountNumber.Text = clsGetData.AccountNo;
            label1.Focus();

            hashNum.Add("0", "0");
            hashNum.Add("1", "១");
            hashNum.Add("2", "២");
            hashNum.Add("3", "៣");
            hashNum.Add("4", "៤");
            hashNum.Add("5", "៥");
            hashNum.Add("6", "៦");
            hashNum.Add("7", "៧");
            hashNum.Add("8", "៨");
            hashNum.Add("9", "៩");

            hashDay.Add("monday", "ចន្ទ");
            hashDay.Add("tuesday", "អង្គារ");
            hashDay.Add("wednesday", "ពុធ");
            hashDay.Add("thursday", "ព្រហស្សត៌៍");
            hashDay.Add("friday", "សុក្រ");
            hashDay.Add("saturday", "សៅរ៍");
            hashDay.Add("sunday", "អាទិត្យ");

            hashMonth.Add("january", "មករា");
            hashMonth.Add("february", "កុម្ភៈ");
            hashMonth.Add("march", "មិនា");
            hashMonth.Add("april", "មេសា");
            hashMonth.Add("may", "ឧសភា");
            hashMonth.Add("june", "មិថុនា");
            hashMonth.Add("july", "កក្កដា");
            hashMonth.Add("august", "សីហា");
            hashMonth.Add("september", "កញ្ញា");
            hashMonth.Add("october", "តុលា");
            hashMonth.Add("november", "វិច្ជិកា");
            hashMonth.Add("december", "ធ្នូ");
        }
        Hashtable hashNum = new Hashtable();
        Hashtable hashDay = new Hashtable();
        Hashtable hashMonth = new Hashtable();
        private void myConvertDate(Label myStr)
        {
            if (clsGetData.MyLanguage == "English")
            {
                myStr.Text = DateTime.Now.ToString("dddd, dd/MMM/yyyy");
            }
            else
            {
                char[] dayNum = DateTime.Now.ToString("dd").ToCharArray();
                string day = DateTime.Now.ToString("dddd").ToString().ToLower();
                string month = DateTime.Now.ToString("MMMM").ToLower();
                char[] year = DateTime.Now.ToString("yyyy").ToCharArray();

                string dayKh = hashDay[day].ToString();
                string monthKh = hashMonth[month].ToString();
                string getElement, yearKh = "", dayNumKh = "";
                for (int i = 0; i < dayNum.Length; i++)
                {
                    getElement = dayNum[i].ToString();
                    dayNumKh += hashNum[getElement];
                }
                for (int i = 0; i < year.Length; i++)
                {
                    getElement = year[i].ToString();
                    yearKh += hashNum[getElement];
                }
                myStr.Text = "ថ្ងៃ" + dayKh + " ទី" + dayNumKh + " ខែ" + monthKh + " ឆ្នាំ" + yearKh;
            }
        }//method convert date to khmer date
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lbDate.Text = DateTime.Now.ToString("dddd, dd/MMM/yyyy");
            myConvertDate(lbDate);
            lbTime.Text = DateTime.Now.ToLongTimeString();
            lbBalance.Text = "$ " + String.Format("{0:n0}", clsGetData.Balance);
        }

    }//
}//
