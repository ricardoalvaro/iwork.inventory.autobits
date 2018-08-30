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
    public partial class frmProductsManage : Form
    {
        public frmProductsManage()
        {
            InitializeComponent();
        }

        private long ProductID = 0;
        public frmProductsManage(long productID)
        {
            InitializeComponent();
            ProductID = productID;
        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void frmProductsManage_Load(object sender, EventArgs e)
        {
            if (ProductID != 0)
            {
                var data = Database.ProductSelect(ProductID, string.Empty);

                foreach (var item in data)
                {
                    txtCode.Text = item.Code;
                    txtDesc.Text = item.Description;
                    txtNotes.Text = item.Notes;
                    txtPrice.Text = item.Price.Value.ToString("N");
                    txtCost.Text = item.Cost.Value.ToString("N");
                    txtOpening.Text = item.CurrentQuantity.Value.ToString("N");
                    txtOpening.Enabled = false;
                    lblOpeningBalance.Text = "Current Qty :";
                }
            }

        }


        private bool ValidateProduct()
        {
            if (txtCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product code required!");
                return false;
            }
            else if (!Helper.IsMoney(txtPrice.Text.Trim()))
            {
                MessageBox.Show("Invalid price!");
                txtPrice.Text = "0";
                return false;
            }

            else if (!Helper.IsMoney(txtCost.Text.Trim()))
            {
                MessageBox.Show("Invalid cost!");
                txtCost.Text = "0";
                return false;
            }

            else if (!Helper.IsMoney(txtOpening.Text.Trim()))
            {
                MessageBox.Show("Invalid opening balance!");
                txtOpening.Text = "0";
                return false;
            }
            else
            {
                return true;
            }
        }


        private void SaveUpdate()
        {
            Database = new DatabaseDataContext();
            if (ProductID == 0) // insert
            {
                long? product_id = 0;
                Database.ProductInsert(ref product_id, txtCode.Text.Trim(), txtDesc.Text.Trim(), txtNotes.Text.Trim(), decimal.Parse(txtCost.Text.Trim()), decimal.Parse(txtPrice.Text.Trim()), decimal.Parse(txtOpening.Text.Trim()));
            }
            else
            {
                Database.ProductUpdate(ProductID, txtCode.Text.Trim(), txtDesc.Text.Trim(), txtNotes.Text.Trim(), decimal.Parse(txtCost.Text.Trim()), decimal.Parse(txtPrice.Text.Trim()));
            }
            
        }

        private void Clear()
        {
            ProductID = 0;
            txtCode.Text = "";
            txtDesc.Text = "";
            txtNotes.Text = "";
            txtPrice.Text = "0";
            txtCost.Text = "0";
            txtOpening.Text = "0";
        }

        private void SaveNew_Click(object sender, EventArgs e)
        {
            if (ValidateProduct())
            {
                SaveUpdate(); Clear();
                MessageBox.Show("Successfully saved");

                //incase of edit then save
                txtOpening.Enabled = true;
                lblOpeningBalance.Text = "Opening Balance :";

            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (ValidateProduct())
            {
                SaveUpdate(); this.Close();
                MessageBox.Show("Successfully updated");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
