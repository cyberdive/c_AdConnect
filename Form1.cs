using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AdConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
        public string PathBase()
        {
            return string.Format("LDAP://{0}/{1}", (object)string.Format("{0}:{1}", (object)this.txtServer.Text, (object)this.txtPort.Text), (object)this.txtContainer.Text);
        }

        private void InitConfiguration()
        {
            /// this.environnements = ((IEnumerable<string>)ConfigurationManager.AppSettings["ENVIRONNEMENTS"].Split(',')).ToList<string>();
            this.lstEnv.DataSource = (object)this.environnements;
        }

        private void InitForm(string environnement)
        {
            ///  this.txtServer.Text = ConfigurationManager.AppSettings[string.Format("{0}_SERVER_HOST", (object)environnement)];
            ///  this.txtPort.Text = ConfigurationManager.AppSettings[string.Format("{0}_SERVER_PORT", (object)environnement)];
            ///  this.txtContainer.Text = ConfigurationManager.AppSettings[string.Format("{0}_SERVER_CONTAINER", (object)environnement)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.txtServer.Text;
                if (string.IsNullOrEmpty(this.txtPort.Text))
                {
                    string str = text + ":" + this.txtPort.Text;
                }
                /// this.txtOutput.Text = string.Format("{0} results found", (object)new DirectorySearcher(this.CreateDirectoryEntry(this.PathBase()))
                {
                    ///    Filter = this.txtFilter.Text
                }///.FindAll().Count);
            }
            catch (Exception ex)
            {
                this.txtOutput.Text = ex.ToString() + ex.InnerException?.ToString();
            }
        }

        public DirectoryEntry CreateDirectoryEntry(string path)
        {
            if (this.chkSSL.Checked)
                return new DirectoryEntry(path, string.IsNullOrWhiteSpace(this.txtLogin.Text) ? (string)null : this.txtLogin.Text, string.IsNullOrWhiteSpace(this.txtPassword.Text) ? (string)null : this.txtPassword.Text, AuthenticationTypes.Secure | AuthenticationTypes.Encryption);
            return new DirectoryEntry(path, string.IsNullOrWhiteSpace(this.txtLogin.Text) ? (string)null : this.txtLogin.Text, string.IsNullOrWhiteSpace(this.txtPassword.Text) ? (string)null : this.txtPassword.Text);
        }

        private void lstEnv_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.InitForm(this.lstEnv.SelectedValue.ToString());
        }
    }
}
