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
    public partial class frmVoidQty : Form
    {
        public decimal Quantity { get; set; }
        public bool Confirm { get; set; } = false;

        public frmVoidQty(decimal qty)
        {
            InitializeComponent();
            Quantity = qty;

            txtQty.Text = qty.ToString("N");
            txtQty.SelectAll();
            txtQty.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVoidQty_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtQty.Text) > Quantity)
            {
                MessageBox.Show("Entered quantity is greater than record", Helper.MessageBoxHeader);
                return;
            }

            Confirm = true;
            this.Close();
        }
    }
}
