
namespace ATM_Machine_Transaction
{
    partial class AlertMessage_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertMessage_frm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbExit = new DevExpress.XtraEditors.LabelControl();
            this.lbAlertTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbTitle.Location = new System.Drawing.Point(0, 33);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(501, 78);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Message Box Alert";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbAlertTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 30);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // lbExit
            // 
            this.lbExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbExit.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lbExit.Appearance.Options.UseFont = true;
            this.lbExit.Appearance.Options.UseForeColor = true;
            this.lbExit.AppearanceHovered.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.AppearanceHovered.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbExit.AppearanceHovered.Options.UseFont = true;
            this.lbExit.AppearanceHovered.Options.UseForeColor = true;
            this.lbExit.AppearancePressed.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbExit.AppearancePressed.Options.UseForeColor = true;
            this.lbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbExit.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbExit.ImageOptions.Image")));
            this.lbExit.Location = new System.Drawing.Point(394, 116);
            this.lbExit.Margin = new System.Windows.Forms.Padding(5);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(93, 36);
            this.lbExit.TabIndex = 27;
            this.lbExit.Text = "OKAY";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // lbAlertTitle
            // 
            this.lbAlertTitle.AutoSize = true;
            this.lbAlertTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbAlertTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlertTitle.ForeColor = System.Drawing.Color.White;
            this.lbAlertTitle.Location = new System.Drawing.Point(3, 5);
            this.lbAlertTitle.Name = "lbAlertTitle";
            this.lbAlertTitle.Size = new System.Drawing.Size(80, 20);
            this.lbAlertTitle.TabIndex = 0;
            this.lbAlertTitle.Text = "Alert Tittle";
            // 
            // AlertMessage_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(501, 155);
            this.ControlBox = false;
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AlertMessage_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AlertMessage_frm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lbExit;
        private System.Windows.Forms.Label lbAlertTitle;
    }
}