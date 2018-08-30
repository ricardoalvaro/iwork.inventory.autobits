using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iwork.autobits.inventory.Model;

namespace  iwork.autobits.inventory
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void LoadData()
        {
            Database = new DatabaseDataContext();
            var data = Database.Suppliers.Where(x => x.Name.Contains(txtKeyword.Text.Trim())).ToList<Supplier>();

            grv.Rows.Clear();
            int counter = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.ID, d.Name, d.Mobile, d.Phone, d.Email, d.CompleteAddress);
                counter++;
            }

            lblCount.Text = counter.ToString();
        }

        private void SupplierManage(long supplier_id)
        {
            frmSupplierManage manage = new frmSupplierManage(supplier_id);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
        }

        private void EditSupplier()
        {
            if (grv.SelectedRows.Count != 0)
            {
                long supplier_id = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                this.SupplierManage(supplier_id);
                this.LoadData();
            }
        }


        private void frmSupplier_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.SupplierManage(0);//insert
            this.LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditSupplier();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditSupplier();
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditSupplier();
        }
    }
}
