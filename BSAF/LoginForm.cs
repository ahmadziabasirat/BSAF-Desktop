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
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
         
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            this.pbLoginProcess.Visible = true;
            if (!string.IsNullOrWhiteSpace(this.txtUserName.Text) && !string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                var username = this.txtUserName.Text; var password = this.txtPassword.Text;
                try
                {
                    var reponse = UserController.AuthenticateUser(username, password);
                    if (reponse=="success")
                    {
                        BSAFMDIParent mdi = new BSAFMDIParent();
                        Form frm = (Form)this.MdiParent;
                        MenuStrip ms = (MenuStrip)frm.Controls["menuStrip"];
                        ms.Enabled = true;
                        this.pbLoginProcess.Visible = false;
                        MessageBox.Show("Login is successful");
                        this.Dispose();
                    }
                    else
                    {                       
                    
                        lblLoginMessage.Text = reponse;
                        this.pbLoginProcess.Visible = false;
                        lblLoginMessage.Visible = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.pbLoginProcess.Visible = false;
                    lblLoginMessage.Text = "Can not process user login please try again or continue offline.";
                    lblLoginMessage.Visible = true;
                    return;
                }
            }
            else
            {
                lblLoginMessage.Visible = true;
                this.lblLoginMessage.Text = "Please enter username and password.";
                this.pbLoginProcess.Visible = false;
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lblLoginMessage.Visible = false;
            this.lblLoginMessage.Text = string.Empty;
        }

        private void lblContinueOffline_Click(object sender, EventArgs e)
        {
            BSAFMDIParent mdi = new BSAFMDIParent();
            Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip"];
            ms.Enabled = true;
            this.Dispose();
        }





        //public IdentityResult CreateUser(string userName, string password)
        //{
        //    var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext("BSAFconn")));
        //    var user = new IdentityUser { UserName = userName, Email = userName };
        //    return usermanager.Create(user, password);
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var u = txtUserName.Text; var p = txtPassword.Text;
        //    try
        //    {
        //        var t = CreateUser(u, p);
        //        var errores = "";
        //        var err = t.Errors.ToList();
        //        t.Errors.ToList().ForEach(x => errores += x + Environment.NewLine);
        //        MessageBox.Show(t.ToString() + errores);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
