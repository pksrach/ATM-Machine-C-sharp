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
    public partial class Payment_frm : Form
    {
        public Payment_frm()
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
            //panel_DisplayMini.Controls.Clear();
        }
        private void myEventButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsGetData data = new clsGetData();
            TextBox t = new TextBox();
            TextBox amt = new TextBox();
            TextBox note = new TextBox();
            if (btn.Text == "     Mobile Top-up" || btn.Text == "     បញ្ចូលលុយទូរស័ព្ទ")
            {
                data.MyTitle = btn.Text.Trim();
                
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខទូរស័ព្ទ";
                else t.Text = "Mobile Phone";
            }
            else if(btn.Text == "     Internet && TV" || btn.Text == "     អ៊ីនធឺណិត && ទូរទស្សន៍")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខសម្គាល់អតិថិជន";
                else t.Text = "Customer ID";
            }
            else if (btn.Text == "     Utilities" || btn.Text == "     ទឹកភ្លើង && សំរាម")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខទីតាំងប្រើប្រាស់ចរន្ត";
                else t.Text = "CONSUMMER No.";
            }
            else if (btn.Text == "     Education" || btn.Text == "     ការអប់រំ")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខសម្គាល់សិស្ស";
                else t.Text = "Student ID";
            }
            else if (btn.Text == "     Entertainment" || btn.Text == "     កម្សាន្ត")
            {
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "លេខសម្គាល់អ្នកប្រើប្រាស់";
                else t.Text = "User ID";
            }
            else if (btn.Text == "     Choose From Template" || btn.Text == "     ជ្រើសរើសគំរូ")
            {
                TemplateFrm frm = new TemplateFrm();
                frm.ShowDialog();
                data.MyTitle = btn.Text.Trim();
                if (clsGetData.MyLanguage == "ខ្មែរ") t.Text = "បញ្ចូល";
                else t.Text = "Enter";
            }
            //check text box amount and note in mini payment
            if (clsGetData.MyLanguage == "ខ្មែរ")
            {
                amt.Text = "​ប្រាក់សរុប";
                note.Text = "សំគាល់";
            }
            else
            {
                amt.Text = "​Amount";
                note.Text = "Note";
            }
            data.MyIcon = btn.Image;
            clsGetData.CheckBtn = btn.Text.Trim();
            //MessageBox.Show(clsGetData.CheckBtn);
            myLoadMiniFrm(new MiniPayment_frm(data.MyTitle, data.MyIcon, t, amt, note));
        }

        private void Payment_frm_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }//
}///
