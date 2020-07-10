using BSAF.Controller;
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
    public partial class SubmitForm : MetroFramework.Forms.MetroForm
    {

        dbContext db = new dbContext();
        public SubmitForm()
        {
            InitializeComponent();
        }

        private void SubmitForm_Load(object sender, EventArgs e)
        {
            var beneficiares = (from b in db.Beneficiaries
                                join i in db.Individuals
                                on b.BeneficiaryID equals i.BeneficiaryID into individuals
                                where b.IsActive == true && b.IsSubmitted == false
                                select new { b.BeneficiaryID, b.ScreeningDate, b.BeneficiaryType, b.ReturnStatus, FamilyMembers = individuals.ToList() }).ToList();

            var unSubmittedBeneficiary = beneficiares.Select(b => new {
                b.BeneficiaryID,
                b.ScreeningDate,
                b.BeneficiaryType,
                ReturnStatus = (db.LookupValues.Where(l => l.ValueCode == b.ReturnStatus).Select(l => l.EnName).FirstOrDefault()),
                Name = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.Name).FirstOrDefault(),
                FName = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.FName).FirstOrDefault(),
            }).ToList();

            //Clear listview first
            lvBeneficiaries.Items.Clear();
            foreach (var be in unSubmittedBeneficiary)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblSubmitting.Text = "";
            var beneficiary = db.Beneficiaries.Where(b => b.IsActive == true && b.IsSubmitted == false).Select(b => b.BeneficiaryID);
            if (beneficiary.Count() == 0)
            {
                MessageBox.Show("There is no unsubmitted record");
                return;
            }
            //if (!ConnectionController.IsConnectedToInternet())
            //{
            //    MessageBox.Show("You are not connected to internet please check your connection and try again.");
            //    return;
            //}
            if (UserInfo.token!=null && UserInfo.token != "")
            {
                this.pbSubmitProcess.Visible = true;
                this.btnSubmit.Enabled = false;
                foreach (var b in beneficiary)
                {
                    var benefRecord = BeneficiaryController.GetBeneficiary(b);
                    this.lblSubmitting.Text = "Sending beneficiary with Guid ID : " + benefRecord.CardID;
                    var response = APIController.SubmitBeneficiary(benefRecord);
                    if (response == false)
                    {
                        MessageBox.Show("An error occurred while sending record with ID: " + b + ".");
                            this.pbSubmitProcess.Visible = false;
                            this.btnSubmit.Enabled = true;
                            return;
                        
                    }
                  var benef=  db.Beneficiaries.Find(b);
                    benef.IsSubmitted = true;
                    db.SaveChanges();
                    this.lblSubmitting.Text = "";
                    var beneficiares = (from ben in db.Beneficiaries
                                        join i in db.Individuals
                                        on ben.BeneficiaryID equals i.BeneficiaryID into individuals
                                        where ben.IsActive == true && ben.IsSubmitted == false
                                        select new { ben.BeneficiaryID, ben.ScreeningDate, ben.BeneficiaryType, ben.ReturnStatus, FamilyMembers = individuals.ToList() }).ToList();

                    var unSubmittedBeneficiary = beneficiares.Select(ben => new {
                        ben.BeneficiaryID,
                        ben.ScreeningDate,
                        ben.BeneficiaryType,
                        ReturnStatus = (db.LookupValues.Where(l => l.ValueCode == ben.ReturnStatus).Select(l => l.EnName).FirstOrDefault()),
                        Name = ben.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.Name).FirstOrDefault(),
                        FName = ben.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.FName).FirstOrDefault(),
                    }).ToList();

                    //Clear listview first
                    lvBeneficiaries.Items.Clear();
                    foreach (var be in unSubmittedBeneficiary)
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
                this.pbSubmitProcess.Visible = false;
                this.btnSubmit.Enabled = true;
            }
            else
            {
               
                LoginForm loginForm = new LoginForm();
                loginForm.MdiParent = this.MdiParent;
                loginForm.Show();
                this.Dispose();
            }
          
        }


    }
}
