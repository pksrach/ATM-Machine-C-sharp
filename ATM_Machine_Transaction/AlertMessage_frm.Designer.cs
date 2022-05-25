
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
            this.lbAlertTitle = new System.Windows.Forms.Label();
            this.lbExit = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.lbAlertTitle);
            this.panel1.Name = "panel1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // lbAlertTitle
            // 
            resources.ApplyResources(this.lbAlertTitle, "lbAlertTitle");
            this.lbAlertTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbAlertTitle.ForeColor = System.Drawing.Color.White;
            this.lbAlertTitle.Name = "lbAlertTitle";
            // 
            // lbExit
            // 
            resources.ApplyResources(this.lbExit, "lbExit");
            this.lbExit.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbExit.Appearance.Font")));
            this.lbExit.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lbExit.Appearance.Options.UseFont = true;
            this.lbExit.Appearance.Options.UseForeColor = true;
            this.lbExit.AppearanceHovered.Font = ((System.Drawing.Font)(resources.GetObject("lbExit.AppearanceHovered.Font")));
            this.lbExit.AppearanceHovered.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbExit.AppearanceHovered.Options.UseFont = true;
            this.lbExit.AppearanceHovered.Options.UseForeColor = true;
            this.lbExit.AppearancePressed.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbExit.AppearancePressed.Options.UseForeColor = true;
            this.lbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbExit.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbExit.ImageOptions.Image")));
            this.lbExit.Name = "lbExit";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            this.lbExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbExit_KeyDown);
            // 
            // AlertMessage_frm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AlertMessage_frm";
            this.Load += new System.EventHandler(this.AlertMessage_frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AlertMessage_frm_KeyDown);
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