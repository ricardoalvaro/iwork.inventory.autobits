using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  iwork.autobits.inventory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new MDIMaster());
            //Application.Run(new frmCustomer());
            //Application.Run(new frmSupplier());
            //Application.Run(new frmExpense());
            //Application.Run(new frmSale());
            //Application.Run(new frmMasterList());
        }
    }
}
