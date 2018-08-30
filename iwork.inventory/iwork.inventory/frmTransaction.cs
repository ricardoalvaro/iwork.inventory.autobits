using  iwork.autobits.inventory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  iwork.autobits.inventory
{
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        private string TransactionType = string.Empty;
        private long ProductID = 0;
        private DatabaseDataContext Database = new DatabaseDataContext();

        public frmTransaction(string _type)
        {
            InitializeComponent();
            TransactionType = _type;
        }


        private void frmTransaction_Load(object sender, EventArgs e)
        {
            LoadProductAutoComplete();

            if (TransactionType == "IN"){InLayout();}
            else if (TransactionType == "OUT"){OutLayout();  }
            else if (TransactionType == "ADJUST"){AdjustLayout();}
            this.ActiveControl = txtCode;
        }

        private void InLayout()
        {
            pnlIdentifier.BackColor = Color.Green;
            btnTransaction.BackColor = Color.Green;
            lblTransName.Text = "STOCK IN";


            //supplier config
            lblSupplier.Visible = true;
            cmbSupplier.Visible = true;
            btnAddSupplier.Visible = true;
            cmbSupplier.DataSource = Database.Suppliers.ToList<Supplier>();
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.DisplayMember = "Name";




        }

        private void OutLayout()
        {
            pnlIdentifier.BackColor = Color.Blue;
            btnTransaction.BackColor = Color.Blue;
            lblTransName.Text = "STOCK OUT";
        }

        private void AdjustLayout()
        {
            pnlIdentifier.BackColor = Color.Crimson;
            btnTransaction.BackColor = Color.Crimson;
            lblTransName.Text = "STOCK ADJUST";
        }

        private void LoadProductAutoComplete()
        {
            AutoCompleteStringCollection product_code = new AutoCompleteStringCollection();

            var data = Database.ProductSelect(0, string.Empty);

            foreach (var p in data) { product_code.Add(p.Code); }

            txtCode.AutoCompleteCustomSource = product_code;
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
                    txtQty.Focus();
                    txtQty.Text = "1";
                    txtQty.SelectAll();
                }
            }
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

        private void frmTransaction_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {

            if (!ValidProductCode(txtCode.Text))
            {
                //MessageBox.Show("Not valid product code");
                txtCode.Focus();
                txtCode.SelectAll();
            }
            else
            {
                txtQty.Focus();
            }
        }


        private void ExecuteTransaciton()
        {


            if (!Helper.IsMoney(txtQty.Text))
            {
                MessageBox.Show("Invalid qty");
                txtQty.SelectAll(); txtQty.Focus();
                return;
            }
            Database = new DatabaseDataContext();

            try { 
            ProductID = Database.Products.SingleOrDefault(x => x.Code == txtCode.Text.Trim()).ID;
            }
            catch
            {
                MessageBox.Show("Invalid product code");
                txtCode.Focus();
                txtCode.SelectAll();
                return;
            }
            if (TransactionType == "IN")
            {
                Supplier supp = cmbSupplier.SelectedItem as Supplier;

                Database.ProductStockIn(ProductID, decimal.Parse(txtQty.Text), txtRemarks.Text, Helper.FULLNAME, supp.Name);
            }
            else if (TransactionType == "OUT")
            {
                //Database.ProductStockOut(ProductID, decimal.Parse(txtQty.Text), txtRemarks.Text, Helper.FULLNAME);
            }
            else if (TransactionType == "ADJUST")
            {
                Database.ProductStockADJUST(ProductID, decimal.Parse(txtQty.Text), txtRemarks.Text, Helper.FULLNAME);
            }



            //insert to grid

            grv.Rows.Add(txtCode.Text, txtQty.Text, txtRemarks.Text);

            //clear data 

            ProductID = 0;
            txtQty.Text = "0";
            txtCode.Text = "";
            txtCode.Focus();
            txtRemarks.Text = "";

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteTransaciton();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            ExecuteTransaciton();
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteTransaciton();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierManage manage = new frmSupplierManage(0);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();

            Database = new DatabaseDataContext();
            cmbSupplier.DataSource = Database.Suppliers.ToList<Supplier>();
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.DisplayMember = "Name";

        }
    }
}
