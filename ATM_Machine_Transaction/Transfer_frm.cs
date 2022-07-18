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
    public partial class Transfer_frm : Form
    {
        public Transfer_frm()
        {
            InitializeComponent();
        }

        private void myLoadMiniFrm(object frm)
        {
            if (this.panel_DisplayMini.Controls.Count > 0)
            {
                this.panel_DisplayMini.Controls.RemoveAt(0);
            }
            Form f = frm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel_DisplayMini.Controls.Add(f);
            this.panel_DisplayMini.Tag = f;
            f.Show();
        }
        private void myEventButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsGetData data = new clsGetData();
            TextBox t = new TextBox();
            TextBox amt = new TextBox();
            TextBox note = new TextBox();
            if (btn.Text == "     Choose From Template" || btn.Text == "     ជ្រើសរើសគំរូ")
            {
                TemplateFrm frm = new TemplateFrm();
                frm.ShowDialog();
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខទូរស័ព្ទ";
                else t.Text = "Quick Transfer";
            }
            else if(btn.Text == "     Tranfser to own account" || btn.Text == "     ផ្ទេរប្រាក់ទៅគណនីខ្លួនឯង")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "បញ្ចូលគណនីទទួល";
                else t.Text = "Transfer To";
            }
            else if (btn.Text == "     Tranfser to other account" || btn.Text == "     ផ្ទេរទៅគណនីណាមួយ")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "ដាក់លេខគណនីទទួល";
                else t.Text = "Enter receiver account number";
            }
            else if (btn.Text == "     Transfer to cards" || btn.Text == "     ផ្ទេរទៅកាន់កាត")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខកាតរបស់អ្នកទទួល";
                else t.Text = "Receiver card number";
            }
            //check text box amount and note in mini payment
            if (clsGetData.MyLanguage == "ខ្មែរ")
            {
                amt.Text = "​ចំនួនទឹកប្រាក់";
                note.Text = "ចំណាំ (មិនដាក់់ក៏បាន)";
            }
            else
            {
                amt.Text = "​Amount";
                note.Text = "Remark (optional)";
            }
            clsCheck.MyCheckBtn = btn.Text;
            data.MyIcon = btn.Image;
            myLoadMiniFrm(new MiniPayment_frm(data.MyTitle, data.MyIcon, t, amt, note));
        }

        private void Payment_frm_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }//
}///
