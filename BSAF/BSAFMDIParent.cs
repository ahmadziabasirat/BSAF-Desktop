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
    public partial class BSAFMDIParent :MetroFramework.Forms.MetroForm
    {
        public BSAFMDIParent()
        {
            InitializeComponent();
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Dispose();
            }
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void newBeneficaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeneficiaryForm bForm = new BeneficiaryForm(null)
            {
                MdiParent = this,
              
            };
            bForm.Show();
        }

        private void searchBeneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm sForm
                = new SearchForm
            {
                MdiParent = this,
             
            };
            sForm.Show();
        }

        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Dispose();
            }
        }

        private void BSAFMDIParent_Load(object sender, EventArgs e)
        {
            this.menuStrip.Enabled = false;
            var flogin = new LoginForm()
            {
                MdiParent = this
            };
            flogin.Show();
        }

        private void submitRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ssform = new SubmitForm()
            {
                MdiParent = this,
              
            };
            ssform.Show();
        }

        private void closeAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ssform = new OptionsForm()
            {
                MdiParent = this,
               
            };
            ssform.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ssform = new AboutForm()
            {
                MdiParent = this,
               
            };
            ssform.Show();
        }
    }
}
