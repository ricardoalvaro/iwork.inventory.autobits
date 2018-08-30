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
    public partial class frmSale : Form
    {
        private DatabaseDataContext Database = new DatabaseDataContext();
        public decimal TotalAmount { get; set; } = 0;
        public frmSale()
        {
            InitializeComponent();
        }
        
        private void FillCustomer()
        {
            Database = new DatabaseDataContext();
            cmbCustomer.DataSource = Database.Customers.ToList<Customer>();
            cmbCustomer.ValueMember = "ID";
            cmbCustomer.DisplayMember = "Name";
        }

        private bool isDecimal(string value)
        {
            try { decimal.Parse(value); }
            catch { return false; }

            return true;
        }

        private void LoadProductAutoComplete()
        {
            AutoCompleteStringCollection product_code = new AutoCompleteStringCollection();

            var data = Database.ProductSelect(0, string.Empty);

            foreach (var p in data) { product_code.Add(p.Code); }

            txtCode.AutoCompleteCustomSource = product_code;
        }
        
        private bool ValidProductCode(string productCode)
        {
            var data = Database.Products.Where(x => x.Code == productCode.Trim());

            if (data.Count() > 0)
            {

                return true;
            }
            return false;

        }
        
        private void ExecuteTransaction()
        {
            grv.Rows.Add(0,txtCode.Text, txtQty.Text,txtPrice.Text, (decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text)).ToString("N"));


            TotalAmount += (decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text));
            txtTotalAmount.Text = TotalAmount.ToString("N");


            //----------clear
            txtCode.Text = string.Empty;
            txtQty.Text = "0";
            txtPrice.Text = "0";
            //-----------------
            txtCode.Focus();
            txtCode.SelectAll();



        }

        private void frmSale_Load(object sender, EventArgs e)
        {
           
            cmbPaymentType.SelectedIndex = 0;
            this.FillCustomer(); this.LoadProductAutoComplete();
            this.ActiveControl = txtCode;
        }
        
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmCustomerManage manage = new frmCustomerManage(0);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();

            this.FillCustomer();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!ValidProductCode(txtCode.Text))
                {
                    MessageBox.Show("Not valid product code");
                    txtCode.Focus();
                    txtCode.SelectAll();
                }
                else
                {
                    var s = Database.Products.SingleOrDefault(x => x.Code == txtCode.Text.Trim());
                    txtPrice.Text = s.Price.Value.ToString("N");
                    txtQty.Focus();
                    txtQty.Text = "1";
                    txtQty.SelectAll();
                }
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!ValidProductCode(txtCode.Text))
            {
                //MessageBox.Show("Not valid product code");
                //txtCode.Focus();
                //txtCode.SelectAll();
            }
            else
            {
                var s = Database.Products.SingleOrDefault(x => x.Code == txtCode.Text.Trim());
                txtPrice.Text = s.Price.Value.ToString("N");
                txtQty.Focus();
                txtQty.Text = "1";
                txtQty.SelectAll();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!isDecimal(txtQty.Text))
                {
                    txtQty.Text = "0";
                    txtQty.SelectAll();
                    txtQty.Focus();
                    return;
                }

                ExecuteTransaction();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!isDecimal(txtQty.Text))
                {
                    txtPrice.Text = "0";
                    txtPrice.SelectAll();
                    txtPrice.Focus();
                    return;
                }
                ExecuteTransaction();
            }
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grv.SelectedRows.Count != 0)
            {

                foreach (DataGridViewRow item in this.grv.SelectedRows)
                {
                    DataGridViewRow row = this.grv.SelectedRows[0];
                    TotalAmount -= decimal.Parse(row.Cells[4].Value.ToString());
                    txtTotalAmount.Text = TotalAmount.ToString("N");
                    grv.Rows.RemoveAt(item.Index);
                   
                }

               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!isDecimal(txtPrice.Text))
            {
                txtPrice.Text = "0";
                txtPrice.SelectAll();
                txtPrice.Focus();
                return;
            }

            if (!isDecimal(txtQty.Text))
            {
                txtQty.Text = "1";
                txtQty.SelectAll();
                txtQty.Focus();
                return;
            }

            if (grv.RowCount <= 0)
            {
                MessageBox.Show("Item(s) required", Helper.MessageBoxHeader);
                return;
            }


            //----Validate before inserting---------------------
            Customer cust = cmbCustomer.SelectedItem as Customer;

            Sale sale = new Sale()
            {
                CustomerID = cust.ID,
                CustomerName = cust.Name,
                CreatedDate = dtDate.Value,
                PaymentType = cmbPaymentType.Text,
                Remarks = txtRemarks.Text.Trim(),
                SIOR = txtSINO.Text.Trim()

            };

            Database = new DatabaseDataContext();
            Database.Sales.InsertOnSubmit(sale);
            Database.SubmitChanges();


            ////loop all detail


            int counter = 0;
            foreach (DataGridViewRow item in this.grv.Rows)
            {
                DataGridViewRow row = this.grv.Rows[counter];

                string code = row.Cells[1].Value.ToString().Trim();
                decimal qty = decimal.Parse(row.Cells[2].Value.ToString());
                decimal price = decimal.Parse(row.Cells[3].Value.ToString());
                long product_id = Database.Products.SingleOrDefault(x => x.Code == code).ID;
                Database.SaleDetails.InsertOnSubmit(
                    new SaleDetail()
                    {
                        ProductID = product_id,
                        SaleID = sale.ID,
                        Price = price,
                        Qty = qty
                    });

                Database.SubmitChanges();
                Database.ProductStockOut(product_id, qty, cust.Name, txtRemarks.Text, Helper.FULLNAME);
                counter++;
            }


            MessageBox.Show("Successfully saved", Helper.MessageBoxHeader);

            //clearing
            grv.Rows.Clear();
            ClearTextBoxes();

        }
        
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (!isDecimal(txtQty.Text))
            {
                txtQty.Text = "1";
                txtQty.SelectAll();
                txtQty.Focus();
                return;
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (!isDecimal(txtPrice.Text))
            {
                txtPrice.Text = "0";
                txtPrice.SelectAll();
                txtPrice.Focus();
                return;
            }
        }
    }
}
