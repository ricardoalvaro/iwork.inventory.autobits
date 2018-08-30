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
    public partial class frmHistory : Form
    {
        private long ProductID = 0;
        public frmHistory()
        {
            InitializeComponent();
        }

        public frmHistory(long productID)
        {
            InitializeComponent();
            ProductID = productID;
        }
        private DatabaseDataContext database = new DatabaseDataContext();
        private void frmHistory_Load(object sender, EventArgs e)
        {

            var data = database.ProductHistorySelect(ProductID);

            grv.Rows.Clear();
            foreach (var d in data)
            {
                grv.Rows.Add(d.Code, d.Description, d.QtyIn.Value.ToString("N"), d.QtyOut.Value.ToString("N"), d.QtyAdjustment.Value.ToString("N"), d.QtyCurrent.Value.ToString("N"), d.CreatedDate.Value.ToString("MMM-dd-yyyy"), d.Remarks);
               
            }

        }
    }
}
