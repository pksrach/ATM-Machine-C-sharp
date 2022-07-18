
using System.Windows.Forms;

namespace ATM_Machine_Transaction
{
    partial class ChooseTemplates_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbAccount = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAccount
            // 
            this.lbAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbAccount.ForeColor = System.Drawing.Color.White;
            this.lbAccount.Location = new System.Drawing.Point(0, 40);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(300, 40);
            this.lbAccount.TabIndex = 0;
            this.lbAccount.Text = "Template Account";
            this.lbAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAccount.Click += new System.EventHandler(this.MyClick);
            this.lbAccount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyMouseClick);
            this.lbAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.lbAccount.MouseLeave += new System.EventHandler(this.MyMouseLeave);
            // 
            // lbUsername
            // 
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(0, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(300, 40);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Template Username";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUsername.Click += new System.EventHandler(this.MyClick);
            this.lbUsername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyMouseClick);
            this.lbUsername.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.lbUsername.MouseLeave += new System.EventHandler(this.MyMouseLeave);
            // 
            // ChooseTemplates_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbAccount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChooseTemplates_UC";
            this.Size = new System.Drawing.Size(300, 80);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyMouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.MouseLeave += new System.EventHandler(this.MyMouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        //laeng ng customize properties thae khlun eng
        public string MyUsername
        {
            get => lbUsername.Text;
            set => lbUsername.Text = value;
        }
        public string MyAccount
        {
            get => lbAccount.Text;
            set => lbAccount.Text = value;
        }


        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lbUsername;
    }
}
