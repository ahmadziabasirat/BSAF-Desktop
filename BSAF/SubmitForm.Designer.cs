namespace BSAF
{
    partial class SubmitForm
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
            this.lvBeneficiaries = new MetroFramework.Controls.MetroListView();
            this.BeneficiaryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MFName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BeneficiaryType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.lblSubmitting = new MetroFramework.Controls.MetroLabel();
            this.pbSubmitProcess = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmitProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // lvBeneficiaries
            // 
            this.lvBeneficiaries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBeneficiaries.BackColor = System.Drawing.SystemColors.Window;
            this.lvBeneficiaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BeneficiaryID,
            this.MName,
            this.MFName,
            this.SDate,
            this.ReturnStatus,
            this.BeneficiaryType});
            this.lvBeneficiaries.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvBeneficiaries.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvBeneficiaries.FullRowSelect = true;
            this.lvBeneficiaries.GridLines = true;
            this.lvBeneficiaries.Location = new System.Drawing.Point(15, 112);
            this.lvBeneficiaries.Name = "lvBeneficiaries";
            this.lvBeneficiaries.OwnerDraw = true;
            this.lvBeneficiaries.Size = new System.Drawing.Size(1250, 625);
            this.lvBeneficiaries.TabIndex = 1;
            this.lvBeneficiaries.UseCompatibleStateImageBehavior = false;
            this.lvBeneficiaries.UseSelectable = true;
            this.lvBeneficiaries.View = System.Windows.Forms.View.Details;
            // 
            // BeneficiaryID
            // 
            this.BeneficiaryID.Text = "ID";
            this.BeneficiaryID.Width = 128;
            // 
            // MName
            // 
            this.MName.Text = "Name";
            this.MName.Width = 128;
            // 
            // MFName
            // 
            this.MFName.Text = "FatherName";
            this.MFName.Width = 156;
            // 
            // SDate
            // 
            this.SDate.Text = "Screening Date";
            this.SDate.Width = 167;
            // 
            // ReturnStatus
            // 
            this.ReturnStatus.Text = "Return Status";
            this.ReturnStatus.Width = 162;
            // 
            // BeneficiaryType
            // 
            this.BeneficiaryType.Text = "Beneficiary Type";
            this.BeneficiaryType.Width = 257;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.White;
            this.btnSubmit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSubmit.Location = new System.Drawing.Point(1138, 42);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 50);
            this.btnSubmit.TabIndex = 68;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSubmitting
            // 
            this.lblSubmitting.AutoSize = true;
            this.lblSubmitting.Location = new System.Drawing.Point(530, 73);
            this.lblSubmitting.Name = "lblSubmitting";
            this.lblSubmitting.Size = new System.Drawing.Size(0, 0);
            this.lblSubmitting.TabIndex = 70;
            this.lblSubmitting.Visible = false;
            // 
            // pbSubmitProcess
            // 
            this.pbSubmitProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSubmitProcess.Image = global::BSAF.Properties.Resources.circle_prociess;
            this.pbSubmitProcess.Location = new System.Drawing.Point(1048, 42);
            this.pbSubmitProcess.Name = "pbSubmitProcess";
            this.pbSubmitProcess.Size = new System.Drawing.Size(50, 50);
            this.pbSubmitProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSubmitProcess.TabIndex = 71;
            this.pbSubmitProcess.TabStop = false;
            this.pbSubmitProcess.Visible = false;
            // 
            // SubmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pbSubmitProcess);
            this.Controls.Add(this.lblSubmitting);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lvBeneficiaries);
            this.Name = "SubmitForm";
            this.Text = "Submit Records to the Main Server";
            this.Load += new System.EventHandler(this.SubmitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmitProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroListView lvBeneficiaries;
        private System.Windows.Forms.ColumnHeader BeneficiaryID;
        private System.Windows.Forms.ColumnHeader MName;
        private System.Windows.Forms.ColumnHeader MFName;
        private System.Windows.Forms.ColumnHeader SDate;
        private System.Windows.Forms.ColumnHeader ReturnStatus;
        private System.Windows.Forms.ColumnHeader BeneficiaryType;
        private MetroFramework.Controls.MetroButton btnSubmit;

        private MetroFramework.Controls.MetroLabel lblSubmitting;
        private System.Windows.Forms.PictureBox pbSubmitProcess;
    }
}