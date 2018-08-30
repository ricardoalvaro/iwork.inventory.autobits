using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iwork.inventory.Model;

namespace iwork.inventory
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool ValidatePage()
        {
            bool error = true;
            errorProvider1.Clear();

            if (txtUserName.Text == string.Empty)
            {
                errorProvider1.SetError(txtUserName, "Username Required");
                error = false;
            }

            if (txtPassword.Text == string.Empty)
            {
                errorProvider1.SetError(txtPassword, "Password Required");
                error = false;
            }

            return error;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                bool? isSuccess = false;
                var result = Database.AuthenticateUsers(txtUserName.Text.Trim(), txtPassword.Text.Trim(), ref isSuccess);

                if (isSuccess.Value)
                {
                    foreach (var User in result)
                    {
                        Helper.USERID = User.UserID;
                        Helper.ROLEID = User.RoleID.Value;
                        Helper.ROLE_NAME = Database.Roles.SingleOrDefault(x => x.ID == User.RoleID).Role1;
                        Helper.USERNAME = User.Username;
                        Helper.FULLNAME = User.Fullname;
                        break;
                    }

                    MDIMaster create = new MDIMaster();
                    create.StartPosition = FormStartPosition.CenterParent;
                    this.Hide();
                    create.ShowDialog();

                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password", Helper.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, new KeyEventArgs(Keys.Enter));
            }
        }
    }
}
