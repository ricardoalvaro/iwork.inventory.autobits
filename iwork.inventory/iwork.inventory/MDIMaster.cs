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
    public partial class MDIMaster : Form
    {
        
        public MDIMaster()
        {
            InitializeComponent();
        }


        private void MDIMaster_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private frmUsers frmUsers = null;
        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUsers == null)
                frmUsers = new frmUsers();

            if (frmUsers != null)
            {
                if (frmUsers.IsDisposed)
                    frmUsers = new frmUsers();

                frmUsers.MdiParent = this;
                frmUsers.WindowState = FormWindowState.Maximized;
                frmUsers.Show();
            }
        }
        private frmProducts frmProducts = null;
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProducts == null)
                frmProducts = new frmProducts();

            if (frmProducts != null)
            {
                if (frmProducts.IsDisposed)
                    frmProducts = new frmProducts();

                frmProducts.MdiParent = this;
                frmProducts.WindowState = FormWindowState.Maximized;
                frmProducts.Show();
            }
        }


        private frmTransaction frmTransactionIn = null;
        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionIn == null)
                frmTransactionIn = new frmTransaction("IN");

            if (frmTransactionIn != null)
            {
                if (frmTransactionIn.IsDisposed)
                    frmTransactionIn = new frmTransaction("IN");

                frmTransactionIn.MdiParent = this;
                frmTransactionIn.WindowState = FormWindowState.Maximized;
                frmTransactionIn.Show();
            }
        }

        private frmTransaction frmTransactionOUT = null;
        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionOUT == null)
                frmTransactionOUT = new frmTransaction("OUT");

            if (frmTransactionOUT != null)
            {
                if (frmTransactionOUT.IsDisposed)
                    frmTransactionOUT = new frmTransaction("OUT");

                frmTransactionOUT.MdiParent = this;
                frmTransactionOUT.WindowState = FormWindowState.Maximized;
                frmTransactionOUT.Show();
            }
        }

        private frmTransaction frmTransactionADJUST = null;
        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionADJUST == null)
                frmTransactionADJUST = new frmTransaction("ADJUST");

            if (frmTransactionADJUST != null)
            {
                if (frmTransactionADJUST.IsDisposed)
                    frmTransactionADJUST = new frmTransaction("ADJUST");

                frmTransactionADJUST.MdiParent = this;
                frmTransactionADJUST.WindowState = FormWindowState.Maximized;
                frmTransactionADJUST.Show();
            }
        }

        private frmReports frmReports = null;
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmReports == null)
                frmReports = new frmReports();

            if (frmReports != null)
            {
                if (frmReports.IsDisposed)
                    frmReports = new frmReports();

                frmReports.MdiParent = this;
                frmReports.WindowState = FormWindowState.Maximized;
                frmReports.Show();
            }
        }
    }
}
