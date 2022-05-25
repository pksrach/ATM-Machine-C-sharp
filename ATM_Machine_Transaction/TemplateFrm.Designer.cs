
namespace ATM_Machine_Transaction
{
    partial class TemplateFrm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chooseTemplates_UC1 = new ATM_Machine_Transaction.ChooseTemplates_UC();
            this.chooseTemplates_UC2 = new ATM_Machine_Transaction.ChooseTemplates_UC();
            this.chooseTemplates_UC3 = new ATM_Machine_Transaction.ChooseTemplates_UC();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.chooseTemplates_UC1);
            this.flowLayoutPanel1.Controls.Add(this.chooseTemplates_UC2);
            this.flowLayoutPanel1.Controls.Add(this.chooseTemplates_UC3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 394);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chooseTemplates_UC1
            // 
            this.chooseTemplates_UC1.BackColor = System.Drawing.Color.SeaGreen;
            this.chooseTemplates_UC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseTemplates_UC1.Location = new System.Drawing.Point(4, 5);
            this.chooseTemplates_UC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseTemplates_UC1.MyAccount = "001 456 987";
            this.chooseTemplates_UC1.MyUsername = "Mr. Samrach";
            this.chooseTemplates_UC1.Name = "chooseTemplates_UC1";
            this.chooseTemplates_UC1.Size = new System.Drawing.Size(300, 80);
            this.chooseTemplates_UC1.TabIndex = 0;
            // 
            // chooseTemplates_UC2
            // 
            this.chooseTemplates_UC2.BackColor = System.Drawing.Color.SeaGreen;
            this.chooseTemplates_UC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseTemplates_UC2.Location = new System.Drawing.Point(4, 95);
            this.chooseTemplates_UC2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseTemplates_UC2.MyAccount = "012 321 456";
            this.chooseTemplates_UC2.MyUsername = "Kunthea";
            this.chooseTemplates_UC2.Name = "chooseTemplates_UC2";
            this.chooseTemplates_UC2.Size = new System.Drawing.Size(300, 80);
            this.chooseTemplates_UC2.TabIndex = 1;
            // 
            // chooseTemplates_UC3
            // 
            this.chooseTemplates_UC3.BackColor = System.Drawing.Color.SeaGreen;
            this.chooseTemplates_UC3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseTemplates_UC3.Location = new System.Drawing.Point(4, 185);
            this.chooseTemplates_UC3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseTemplates_UC3.MyAccount = "Template Account";
            this.chooseTemplates_UC3.MyUsername = "Template Username";
            this.chooseTemplates_UC3.Name = "chooseTemplates_UC3";
            this.chooseTemplates_UC3.Size = new System.Drawing.Size(300, 80);
            this.chooseTemplates_UC3.TabIndex = 2;
            // 
            // TemplateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 394);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TemplateFrm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ChooseTemplates_UC chooseTemplates_UC1;
        private ChooseTemplates_UC chooseTemplates_UC2;
        private ChooseTemplates_UC chooseTemplates_UC3;
    }
}