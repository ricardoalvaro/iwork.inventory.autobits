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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void LoadData()
        {
            Database = new DatabaseDataContext();

            var data = Database.ProductSelect(0, txtKeyword.Text.Trim());

            grv.Rows.Clear();
            int counter = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.ID, d.Code, d.Description, d.CurrentQuantity.Value.ToString("N"), d.LastUpdated.Value.ToString("MMM-dd-yyyy"));
                counter++;
            }

            lblCount.Text = counter.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmProductsManage manage = new frmProductsManage();
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                long productID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                frmProductsManage manage = new frmProductsManage(productID);
                manage.StartPosition = FormStartPosition.CenterParent;
                manage.ShowDialog();
                LoadData();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                long productID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                frmProductsManage manage = new frmProductsManage(productID);
                manage.StartPosition = FormStartPosition.CenterParent;
                manage.ShowDialog();
                LoadData();

            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                long productID = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                frmHistory manage = new frmHistory(productID);
                manage.StartPosition = FormStartPosition.CenterParent;
                manage.ShowDialog();
            }
       }
    }
}
