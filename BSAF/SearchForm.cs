using BSAF.Entity;
using BSAF.Helper;
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
    public partial class SearchForm : MetroFramework.Forms.MetroForm
    {
        dbContext db = new dbContext();
        public SearchForm()
        {
            InitializeComponent();
            var id = UserInfo.ID;
            var uname = UserInfo.UserName;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            var returnStatus = "";
            var beneficiaryType = "";
            if (this.rdoReturnStatusDeported.Checked)
            {
                returnStatus = "DEP";
            }
            if (this.rdoReturnStatusDocClaimant.Checked)
            {
                returnStatus = "DC";
            }
            if (this.rdoReturnStatusSpontaneous.Checked)
            {
                returnStatus = "SR";
            }
            if (this.rdoBeneficiaryTypeFamily.Checked)
            {
                beneficiaryType = this.rdoBeneficiaryTypeFamily.Text;
            }
            if (this.rdoBeneficiaryTypeIndividual.Checked)
            {
                beneficiaryType = this.rdoBeneficiaryTypeIndividual.Text;
            }
            //var ben = db.Beneficiaries.Where(x => x.IsActive == true && x.IsSubmitted == false).ToList();
            var beneficiares = (from b in db.Beneficiaries
                                join i in db.Individuals
                                on b.BeneficiaryID equals i.BeneficiaryID into individuals
                                where b.IsActive == true && b.IsSubmitted == false

                                select new {
                                    b.BeneficiaryID,
                                    b.ScreeningDate,
                                    b.BeneficiaryType,
                                    b.ReturnStatus,
                                    FamilyMembers = individuals.ToList()
                                }
                                ).ToList();


            if (!string.IsNullOrEmpty(returnStatus))
            {
                beneficiares = beneficiares.Where(b => b.ReturnStatus == returnStatus).ToList();
            }
            if (!string.IsNullOrEmpty(beneficiaryType))
            {
                beneficiares = beneficiares.Where(b => b.BeneficiaryType == beneficiaryType).ToList();
            }

            //beneficiares = beneficiares.Where(b => b.ScreeningDate >= this.dateFromDate.Value.Date.AddDays(-1)).ToList();
            //beneficiares = beneficiares.Where(b => b.ScreeningDate <= this.dateToDate.Value.Date.AddDays(1)).ToList();
            beneficiares = beneficiares.Where(b => 
            b.ScreeningDate.Date >= this.dateFromDate.Value.Date).ToList();
            beneficiares = beneficiares.Where(b => 
            b.ScreeningDate.Date <= this.dateToDate.Value.Date.Date).ToList();

            var searchReasult = beneficiares.Select(b => new
            {
                b.BeneficiaryID,
                b.ScreeningDate,
                b.BeneficiaryType,
                ReturnStatus = (db.LookupValues.Where(l => l.ValueCode == b.ReturnStatus).Select(l => l.EnName).FirstOrDefault()),
                Name = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.Name).FirstOrDefault(),
                FName = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.FName).FirstOrDefault(),
            }).ToList();

            if (!string.IsNullOrWhiteSpace(this.txtMName.Text))
            {
                searchReasult = searchReasult.Where(b => b.Name == this.txtMName.Text.Trim()).ToList();
            }
            if (!string.IsNullOrWhiteSpace(this.txtMFName.Text))
            {
                searchReasult = searchReasult.Where(b => b.Name == this.txtMFName.Text.Trim()).ToList();
            }
            //Clear listview first
            lvBeneficiaries.Items.Clear();
            if (searchReasult.Count != 0)
            {
                foreach (var be in searchReasult)
                {
                    ListViewItem lvi = new ListViewItem(be.BeneficiaryID.ToString());
                    lvi.SubItems.Add(be.Name);
                    lvi.SubItems.Add(be.FName);
                    lvi.SubItems.Add(DateTime.Parse(be.ScreeningDate.ToString()).ToString("MMM dd yyyy"));
                    lvi.SubItems.Add(be.ReturnStatus);
                    lvi.SubItems.Add(be.BeneficiaryType);
                    lvBeneficiaries.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("There is no unsubmitted record to show for the provided search criteria");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMName.Text = string.Empty;
            this.txtMFName.Text = string.Empty;
            this.dateFromDate.Value = DateTime.Now.Date;
            this.dateToDate.Value = DateTime.Now.Date;
            this.rdoBeneficiaryTypeFamily.Checked = false;
            this.rdoBeneficiaryTypeIndividual.Checked = false;
            this.rdoReturnStatusDeported.Checked = false;
            this.rdoReturnStatusDocClaimant.Checked = false;
            this.rdoReturnStatusSpontaneous.Checked = false;
            this.btnSearch_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Call the edit form with selected item ID
            if (lvBeneficiaries.SelectedItems.Count > 0)
            {
                var itemIndex = lvBeneficiaries.SelectedIndices[0];
                var beneficiaryId = int.Parse(lvBeneficiaries.SelectedItems[0].Text);
                BeneficiaryForm bf = new BeneficiaryForm(beneficiaryId)
                {
                    MdiParent = this.MdiParent
                  
                };
                bf.Show();
                this.Dispose();

            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Call the view form with selected item ID
            if (lvBeneficiaries.SelectedItems.Count > 0)
            {
                var itemIndex = lvBeneficiaries.SelectedIndices[0];
                var beneficiaryId = int.Parse(lvBeneficiaries.SelectedItems[0].Text);

            }
        }


    }
}
