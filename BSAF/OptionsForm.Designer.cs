namespace BSAF
{
    partial class OptionsForm
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtSubmitURL = new MetroFramework.Controls.MetroTextBox();
            this.txtLoginURL = new MetroFramework.Controls.MetroTextBox();
            this.btnChangeURLs = new MetroFramework.Controls.MetroButton();
            this.cmbBCP = new MetroFramework.Controls.MetroComboBox();
            this.cmbProvince = new MetroFramework.Controls.MetroComboBox();
            this.txtAlphabet = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(436, 333);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Login URL";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(436, 408);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(189, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Record submission URL";
            // 
            // txtSubmitURL
            // 
            // 
            // 
            // 
            this.txtSubmitURL.CustomButton.Image = null;
            this.txtSubmitURL.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtSubmitURL.CustomButton.Name = "";
            this.txtSubmitURL.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtSubmitURL.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSubmitURL.CustomButton.TabIndex = 1;
            this.txtSubmitURL.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSubmitURL.CustomButton.UseSelectable = true;
            this.txtSubmitURL.CustomButton.Visible = false;
            this.txtSubmitURL.Lines = new string[0];
            this.txtSubmitURL.Location = new System.Drawing.Point(436, 436);
            this.txtSubmitURL.MaxLength = 32767;
            this.txtSubmitURL.Name = "txtSubmitURL";
            this.txtSubmitURL.PasswordChar = '\0';
            this.txtSubmitURL.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSubmitURL.SelectedText = "";
            this.txtSubmitURL.SelectionLength = 0;
            this.txtSubmitURL.SelectionStart = 0;
            this.txtSubmitURL.ShortcutsEnabled = true;
            this.txtSubmitURL.Size = new System.Drawing.Size(400, 30);
            this.txtSubmitURL.TabIndex = 4;
            this.txtSubmitURL.UseSelectable = true;
            this.txtSubmitURL.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSubmitURL.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtLoginURL
            // 
            // 
            // 
            // 
            this.txtLoginURL.CustomButton.Image = null;
            this.txtLoginURL.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtLoginURL.CustomButton.Name = "";
            this.txtLoginURL.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLoginURL.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLoginURL.CustomButton.TabIndex = 1;
            this.txtLoginURL.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLoginURL.CustomButton.UseSelectable = true;
            this.txtLoginURL.CustomButton.Visible = false;
            this.txtLoginURL.Lines = new string[0];
            this.txtLoginURL.Location = new System.Drawing.Point(436, 361);
            this.txtLoginURL.MaxLength = 32767;
            this.txtLoginURL.Name = "txtLoginURL";
            this.txtLoginURL.PasswordChar = '\0';
            this.txtLoginURL.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLoginURL.SelectedText = "";
            this.txtLoginURL.SelectionLength = 0;
            this.txtLoginURL.SelectionStart = 0;
            this.txtLoginURL.ShortcutsEnabled = true;
            this.txtLoginURL.Size = new System.Drawing.Size(400, 30);
            this.txtLoginURL.TabIndex = 5;
            this.txtLoginURL.UseSelectable = true;
            this.txtLoginURL.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLoginURL.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnChangeURLs
            // 
            this.btnChangeURLs.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnChangeURLs.Location = new System.Drawing.Point(686, 564);
            this.btnChangeURLs.Name = "btnChangeURLs";
            this.btnChangeURLs.Size = new System.Drawing.Size(150, 50);
            this.btnChangeURLs.TabIndex = 6;
            this.btnChangeURLs.Text = "Save Changes";
            this.btnChangeURLs.UseSelectable = true;
            this.btnChangeURLs.Click += new System.EventHandler(this.btnChangeURLs_Click);
            // 
            // cmbBCP
            // 
            this.cmbBCP.FormattingEnabled = true;
            this.cmbBCP.ItemHeight = 23;
            this.cmbBCP.Location = new System.Drawing.Point(436, 211);
            this.cmbBCP.Name = "cmbBCP";
            this.cmbBCP.Size = new System.Drawing.Size(400, 29);
            this.cmbBCP.TabIndex = 17;
            this.cmbBCP.UseSelectable = true;
            // 
            // cmbProvince
            // 
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.ItemHeight = 23;
            this.cmbProvince.Location = new System.Drawing.Point(436, 138);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(400, 29);
            this.cmbProvince.TabIndex = 16;
            this.cmbProvince.UseSelectable = true;
            // 
            // txtAlphabet
            // 
            this.txtAlphabet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtAlphabet.CustomButton.Image = null;
            this.txtAlphabet.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtAlphabet.CustomButton.Name = "";
            this.txtAlphabet.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtAlphabet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAlphabet.CustomButton.TabIndex = 1;
            this.txtAlphabet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAlphabet.CustomButton.UseSelectable = true;
            this.txtAlphabet.CustomButton.Visible = false;
            this.txtAlphabet.Lines = new string[0];
            this.txtAlphabet.Location = new System.Drawing.Point(436, 283);
            this.txtAlphabet.MaxLength = 32767;
            this.txtAlphabet.Name = "txtAlphabet";
            this.txtAlphabet.PasswordChar = '\0';
            this.txtAlphabet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAlphabet.SelectedText = "";
            this.txtAlphabet.SelectionLength = 0;
            this.txtAlphabet.SelectionStart = 0;
            this.txtAlphabet.ShortcutsEnabled = true;
            this.txtAlphabet.Size = new System.Drawing.Size(400, 30);
            this.txtAlphabet.TabIndex = 15;
            this.txtAlphabet.UseSelectable = true;
            this.txtAlphabet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAlphabet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(436, 255);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(153, 25);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Assigned Alphabet";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(432, 183);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(120, 25);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Crossing Point";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(432, 109);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(77, 25);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Province";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(436, 61);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(400, 30);
            this.txtName.TabIndex = 11;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(435, 32);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(58, 25);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Name";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(436, 515);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(400, 30);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(436, 487);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 25);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Password";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmbBCP);
            this.Controls.Add(this.cmbProvince);
            this.Controls.Add(this.txtAlphabet);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.btnChangeURLs);
            this.Controls.Add(this.txtLoginURL);
            this.Controls.Add(this.txtSubmitURL);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtSubmitURL;
        private MetroFramework.Controls.MetroTextBox txtLoginURL;
        private MetroFramework.Controls.MetroButton btnChangeURLs;
        private MetroFramework.Controls.MetroComboBox cmbBCP;
        private MetroFramework.Controls.MetroComboBox cmbProvince;
        private MetroFramework.Controls.MetroTextBox txtAlphabet;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}