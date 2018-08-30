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
    public partial class frmReports : Form
    {
        private DatabaseDataContext Database = new DatabaseDataContext();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-30);
            LoadProductAutoComplete();

            LoadData();

        }

        private void LoadData()
        {
            Database = new DatabaseDataContext();
            var data = Database.ProductHistorySelectRange(txtKeyword.Text.Trim(), dtFrom.Value, dtTo.Value);

            grv.Rows.Clear();
            int counter = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.Code, d.Description, d.SupCus, d.TransType, d.QtyIn.Value.ToString("N"), d.QtyOut.Value.ToString("N"), d.QtyAdjustment.Value.ToString("N"), d.QtyCurrent.Value.ToString("N"), d.CreatedDate.Value.ToString("MMM-dd-yyyy"), d.Remarks, d.Name);
                counter++;
            }
            lblCount.Text = counter.ToString();
        }

        private void LoadProductAutoComplete()
        {
            AutoCompleteStringCollection product_code = new AutoCompleteStringCollection();

            var data = Database.ProductSelect(0, string.Empty);

            foreach (var p in data) { product_code.Add(p.Code); }

            txtKeyword.AutoCompleteCustomSource = product_code;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }
    }
}
