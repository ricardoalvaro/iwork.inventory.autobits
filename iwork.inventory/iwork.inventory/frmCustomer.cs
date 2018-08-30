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


namespace iwork.autobits.inventory
{
    public partial class frmCustomer : Form
    {
        private DatabaseDataContext Database = new DatabaseDataContext();

        private void LoadData()
        {
            Database = new DatabaseDataContext();
            var data = Database.Customers.Where(x => x.Name.Contains(txtKeyword.Text.Trim())).ToList<Customer>();

            grv.Rows.Clear();
            int counter = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.ID, d.Name, d.Mobile, d.Phone, d.Email, d.CompleteAddress);
                counter++;
            }

            lblCount.Text = counter.ToString();
        }

        private void CustomerManage(long customer_id)
        {
            frmCustomerManage manage = new frmCustomerManage(customer_id);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
        }

        private void EditCustomer()
        {
            if (grv.SelectedRows.Count != 0)
            {
                long customer_id = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                this.CustomerManage(customer_id);
                this.LoadData();
            }
        }

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.CustomerManage(0);//insert
            this.LoadData();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditCustomer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditCustomer();
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditCustomer();
        }
    }
    
 }
