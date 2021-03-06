﻿using System;
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
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
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
            BeneficiaryForm bForm = new BeneficiaryForm
            {
                MdiParent = this
            };
            bForm.Show();
        }

        private void searchBeneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBeneficiary sForm = new SearchBeneficiary
            {
                MdiParent = this
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
    }
}
