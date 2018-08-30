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
    public partial class frmUsers : Form
    {

        private DatabaseDataContext Database = new DatabaseDataContext();

        public frmUsers()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            Database = new DatabaseDataContext();
            var data = Database.UsersSelect(0, txtKeyword.Text.Trim());
            grv.Rows.Clear();
            int counter = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.UserID, d.isActive, d.RoleName, d.Username, d.Fullname);
                counter++;
            }

            lblRolesCount.Text = counter.ToString();
        }

        private void InsertData()
        {
            frmUsersManage manage = new frmUsersManage();
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
            LoadData();
        }

        private void UpdateData(long userID)
        {
            frmUsersManage manage = new frmUsersManage(userID);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
            LoadData();
        }

        private void DeleteData(long userID)
        {
            var ans = MessageBox.Show("Are you sure you want to delete this record", Helper.MessageBoxHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == System.Windows.Forms.DialogResult.Yes)
            {
                Database = new DatabaseDataContext();
                Database.UsersDelete(userID);
                LoadData();
            }
        }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grv.CurrentRow.Cells.Count > 0)
            {
                long userID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                DeleteData(userID);
                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                long userID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                UpdateData(userID);

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                long userID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                UpdateData(userID);

            }
        }
    }
}
