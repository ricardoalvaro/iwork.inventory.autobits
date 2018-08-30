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
    public partial class frmMasterListManage : Form
    {
        public long SaleID { get; set; } = 0;
        private DatabaseDataContext Database = new DatabaseDataContext();

        public frmMasterListManage(long sale_id)
        {
            InitializeComponent();
            SaleID = sale_id;
        }

        public decimal TotalNet { get; set; } = 0;
        public decimal TotalGross { get; set; } = 0;
        private void frmMasterListManage_Load(object sender, EventArgs e)
        {
            if (SaleID > 0)
            {
                //do some logic
                var sales = Database.Sales.Where(x => x.ID == SaleID);
                foreach (var s in sales)
                {
                    txtSINO.Text = s.SIOR;
                    txtPaymentType.Text = s.PaymentType;
                    txtCustomer.Text = s.CustomerName;
                    txtRemarks.Text = s.Remarks;
                    dtDate.Value = s.CreatedDate.Value;
                }

                var details = Database.SaleDetails.Where(x => x.SaleID == SaleID);

                foreach (var d in details)
                {

                    var pro = Database.Products.SingleOrDefault(x => x.ID == d.ProductID);
                    var net = (d.Qty.Value * d.Price.Value);
                    var gross = net - (d.Qty.Value * pro.Cost.Value);
                    grv.Rows.Add(d.ID, pro.Code, d.Qty.Value.ToString("N"), d.Price.Value.ToString("N"), pro.Cost.Value.ToString("N"), net.ToString("N"), gross.ToString("N"));

                    TotalGross += gross;
                    TotalNet += net;
                }

                txtTotalNet.Text = TotalNet.ToString("N");
                txtTotalGross.Text = TotalGross.ToString("N");


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
             if (grv.SelectedRows.Count != 0)
            {

                frmVoidQty manage = new frmVoidQty(decimal.Parse(grv.CurrentRow.Cells[2].Value.ToString()));
                manage.StartPosition = FormStartPosition.CenterParent;
                manage.ShowDialog();

                if (manage.Confirm)
                {
                    Database = new DatabaseDataContext();
                    long detail_id = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                    var pro = Database.Products.SingleOrDefault(x => x.Code == grv.CurrentRow.Cells[1].Value.ToString());
                    decimal return_void_qty = decimal.Parse(manage.txtQty.Text);
                    decimal current_qty = decimal.Parse(grv.CurrentRow.Cells[2].Value.ToString());

                    //ibabalik sa stock yung qty and product ID
                    Database.ProductStockInVOID(pro.ID, return_void_qty, Helper.FULLNAME, txtCustomer.Text);
                    if (return_void_qty == current_qty)//delete
                    {
                        Database.SaleDetails.DeleteOnSubmit(Database.SaleDetails.SingleOrDefault(x => x.ID == detail_id));
                        Database.SubmitChanges();
                    }
                    else//update
                    {
                        var detail_update = Database.SaleDetails.SingleOrDefault(x => x.ID == detail_id);
                        detail_update.Qty = detail_update.Qty - return_void_qty;
                        Database.SubmitChanges();
                    }
                    //remove or update on the sale detail
                    
                    foreach (DataGridViewRow item in this.grv.SelectedRows)
                    {
                        DataGridViewRow row = this.grv.SelectedRows[0];
                        TotalNet -= decimal.Parse(row.Cells[5].Value.ToString());
                        txtTotalNet.Text = TotalNet.ToString("N");

                        TotalGross -= decimal.Parse(row.Cells[6].Value.ToString());
                        txtTotalGross.Text = TotalGross.ToString("N");
                        
                        //
                        grv.Rows.RemoveAt(item.Index);

                    }

                    //-----update grid
                    Database = new DatabaseDataContext();
                    var grid_update = Database.SaleDetails.SingleOrDefault(x => x.ID == detail_id);
                    var net = (grid_update.Qty.Value * grid_update.Price.Value);
                    var gross = net - (grid_update.Qty.Value * pro.Cost.Value);
                    grv.Rows.Add(detail_id, pro.Code, (grid_update.Qty.Value).ToString("N"), grid_update.Price.Value.ToString("N"), pro.Cost.Value.ToString("N"), net.ToString("N"), gross.ToString("N"));



                }



            }
        }
    }
}
