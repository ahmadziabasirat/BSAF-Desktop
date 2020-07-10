using BSAF.Entity;
using BSAF.Helper;
using BSAF.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSAF
{
    public partial class OptionsForm : MetroFramework.Forms.MetroForm
    {
        dbContext db = new dbContext();
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            txtLoginURL.Text = Variables.loginUrl;
            txtSubmitURL.Text = Variables.beneficiaryUrl;
            var provinceList = db.Provinces.Where(p => p.IsActive == true).Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            provinceList.Insert(0, new { ProvinceCode = "0", ProvinceName = "-- Please Select --" });
            cmbProvince.DataSource = provinceList;
            cmbProvince.DisplayMember = "ProvinceName";
            cmbProvince.ValueMember = "ProvinceCode";
            cmbProvince.SelectedIndex = 0;
            var borderPointList = db.BorderCrossingPoints.Where(b => b.IsActive == true).Select(b => new { b.BCPCode, BorderPointName = b.EnName }).ToList();
            borderPointList.Insert(0, new { BCPCode = "0", BorderPointName = "-Please Select-" });
            cmbBCP.DataSource = borderPointList;
            cmbBCP.DisplayMember = "BorderPointName";
            cmbBCP.ValueMember = "BCPCode";
            cmbBCP.SelectedIndex = 0;
            if (db.UserSettings.Count() > 0)
            {
                var setting = db.UserSettings.FirstOrDefault();
                cmbProvince.SelectedValue = setting.Province;
                cmbBCP.SelectedValue = setting.BCP;
                txtName.Text = setting.Name;
                txtAlphabet.Text = setting.Alphabet;

            }
        }

        private void btnChangeURLs_Click(object sender, EventArgs e)
        {
            if(txtAlphabet.Text.Count() == 1)
            {
                if (txtPassword.Text == "AhmadZiaBasirat")
                {
                    Variables.loginUrl = txtLoginURL.Text;
                    Variables.beneficiaryUrl = txtSubmitURL.Text;
                    if (db.UserSettings.Count() > 0)
                    {
                        var setting =db.UserSettings.FirstOrDefault();
                        setting.Name = txtName.Text;
                        setting.Province = cmbProvince.SelectedValue.ToString();
                        setting.BCP = cmbBCP.SelectedValue.ToString();
                        setting.Alphabet= txtAlphabet.Text;
                        db.SaveChanges();
                    }
                    else
                    {
                        var setting = new UserSettings
                        {
                            Name = txtName.Text,
                            Province = cmbProvince.SelectedValue.ToString(),
                            BCP = cmbBCP.SelectedValue.ToString(),
                            Alphabet = txtAlphabet.Text,
                            RecentReturnNumber = 0
                        };
                        db.UserSettings.Add(setting);
                        db.SaveChanges();
                    }
                    this.Dispose();
                   
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                MessageBox.Show("Only one alphabet is required");
            }
        

        }
    }
}
