using iwork.autobits.inventory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iwork.inventory
{
    public partial class frmUsersManage : Form
    {

        private DatabaseDataContext Database = new DatabaseDataContext();
        private long UserID = 0;

        public frmUsersManage(long userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        public frmUsersManage()
        {
            InitializeComponent();
           
        }

        private bool ValidateSave()
        {
            StringBuilder sb = new StringBuilder();

            //if (string.IsNullOrEmpty(txtRole.Text))
            //{
            //    sb.Append("Role required" + Environment.NewLine);
            //}

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                sb.Append("Full name required" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                sb.Append("User name required" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                sb.Append("Password required" + Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                MessageBox.Show(sb.ToString(), Helper.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }

            return false;
        }


        private void ClearData()
        {
            UserID = 0;
            txtFullName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Text = string.Empty;

        }



        private void frmUsersManage_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;

            if(UserID > 0)
            {
                var data = Database.UsersSelect(UserID, string.Empty);
                foreach (var d in data)
                {
                    chkIsActive.Checked = d.isActive.Value;
                    //cmbRole.Items.Contains(d.RoleID.ToString()).;
                    txtFullName.Text = d.Fullname;
                    txtUsername.Text = d.Username;
                    txtPassword.Text = d.Password;
                }

            }
          
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveNew_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (UserID == 0) //insert
                {
                    long? ID = 0;
                    Database.UsersInsert(ref ID, 1, chkIsActive.Checked, txtUsername.Text, txtPassword.Text, txtFullName.Text);
                    MessageBox.Show("Successfully Saved");
                }
                else
                {
                    Database.UsersUpdate(UserID, 1, chkIsActive.Checked, txtUsername.Text, txtPassword.Text, txtFullName.Text);
                    MessageBox.Show("Successfully Updated");
                }
             
                ClearData();
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (UserID == 0) //insert
                {
                    long? ID = 0;
                    Database.UsersInsert(ref ID, 1, chkIsActive.Checked, txtUsername.Text, txtPassword.Text, txtFullName.Text);
                }
                else
                {
                    Database.UsersUpdate(UserID, 1, chkIsActive.Checked, txtUsername.Text, txtPassword.Text, txtFullName.Text);
                }
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
