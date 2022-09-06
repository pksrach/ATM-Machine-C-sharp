
namespace ATM_Machine_Transaction
{
    partial class MiniPayment_frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniPayment_frm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lbTittle = new System.Windows.Forms.Label();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnPayNow = new System.Windows.Forms.Button();
            this.lbTotalLable = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.pic);
            this.panel1.Controls.Add(this.lbTittle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pic
            // 
            resources.ApplyResources(this.pic, "pic");
            this.pic.Name = "pic";
            this.pic.TabStop = false;
            // 
            // lbTittle
            // 
            resources.ApplyResources(this.lbTittle, "lbTittle");
            this.lbTittle.ForeColor = System.Drawing.Color.White;
            this.lbTittle.Name = "lbTittle";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.ForeColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.txtMobilePhone, "txtMobilePhone");
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Tag = "";
            this.txtMobilePhone.Enter += new System.EventHandler(this.txtBox_Enter);
            this.txtMobilePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobilePhone_KeyPress);
            this.txtMobilePhone.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.ForeColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Tag = "";
            this.txtAmount.Enter += new System.EventHandler(this.txtBox_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // btnPayNow
            // 
            resources.ApplyResources(this.btnPayNow, "btnPayNow");
            this.btnPayNow.BackColor = System.Drawing.Color.Firebrick;
            this.btnPayNow.ForeColor = System.Drawing.Color.White;
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.UseVisualStyleBackColor = false;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // lbTotalLable
            // 
            resources.ApplyResources(this.lbTotalLable, "lbTotalLable");
            this.lbTotalLable.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbTotalLable.Name = "lbTotalLable";
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.ForeColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            this.txtNote.Tag = "";
            this.txtNote.Enter += new System.EventHandler(this.txtBox_Enter);
            this.txtNote.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // MiniPayment_frm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lbTotalLable);
            this.Controls.Add(this.btnPayNow);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtMobilePhone);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MiniPayment_frm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MiniPayment_frm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnPayNow;
        private System.Windows.Forms.Label lbTotalLable;
        private System.Windows.Forms.RichTextBox txtNote;
    }
}