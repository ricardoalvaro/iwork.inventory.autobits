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

namespace iwork.autobits.inventory
{
    public partial class frmMasterList : Form
    {

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void LoadData()
        {
            Database = new DatabaseDataContext();
            var data = new List<Sale>();
            if (string.IsNullOrEmpty(txtKeyword.Text))//select all
            {
                data = Database.Sales.Where(x => x.CreatedDate.Value >= dtFrom.Value).Where(x => x.CreatedDate.Value <= dtTo.Value).ToList<Sale>();
            }
            else
            {
                data = Database.Sales.Where(x => x.CreatedDate.Value >= dtFrom.Value).Where(x => x.CreatedDate.Value <= dtTo.Value).Where(x => x.CustomerName.Contains(txtKeyword.Text)).Where(x => x.SIOR.Contains(txtKeyword.Text)).ToList<Sale>();
            }
          
            
            grv.Rows.Clear();
            decimal count = 0;
            decimal totalNet = 0;
            decimal totalGross = 0;
            foreach (var d in data)
            {
                decimal net = 0;
                decimal gross = 0;

                GetSaleTotalAmount(d.ID, ref net, ref gross);

                grv.Rows.Add(d.ID, d.CreatedDate.Value.ToString("MMM-dd-yyyy"), d.SIOR, d.CustomerName, d.PaymentType, net.ToString("N"), gross.ToString("N"), d.Remarks);


                totalNet += net;
                totalGross += gross;
                count++;
            }

            var exp_data =  Database.Expenses.Where(x => x.CreatedDate.Value >= dtFrom.Value).Where(x => x.CreatedDate.Value <= dtTo.Value).ToList<Expense>();
            decimal total_exp = 0;
            foreach (var d in exp_data) { total_exp += d.Amount.Value; }

            lblSummary.Text = (totalGross - total_exp).ToString("N");
            lblTotalExpenses.Text = total_exp.ToString("N");
            lblTotalAmount.Text = totalNet.ToString("N");
            lblGross.Text = totalGross.ToString("N");
            lblCount.Text = count.ToString();
        }


        private void GetSaleTotalAmount(long sale_id, ref decimal net, ref decimal gross)
        {
            net = 0;
            gross = 0;
            var detail = Database.SaleDetails.Where(x => x.SaleID == sale_id);

            foreach (var d in detail)
            {
                net += (d.Qty.Value * d.Price.Value);
                var current_net = (d.Qty.Value * d.Price.Value);
                gross += current_net - (d.Qty.Value * Database.Products.SingleOrDefault(x => x.ID == d.ProductID.Value).Cost.Value);
            }

           // return total;
        }

        public frmMasterList()
        {
            InitializeComponent();
        }

        private void frmMasterList_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-30);
            this.LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                ManageSale();
            }
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {
                ManageSale();
            }
        }


        private void ManageSale()
        {
            long sale_id = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
            frmMasterListManage manage = new frmMasterListManage(sale_id);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
            this.LoadData();
        }
    }
}
