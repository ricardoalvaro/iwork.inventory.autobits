using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iwork.autobits.inventory.Model;


namespace iwork.autobits.inventory
{
    public partial class frmExpense : Form
    {

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void LoadData()
        {
            Database = new DatabaseDataContext();

            var data = new List<Expense>();

            if (string.IsNullOrEmpty(txtKeyword.Text))
            {
                data = Database.Expenses.Where(x => x.CreatedDate.Value >= dtFrom.Value).Where(x => x.CreatedDate.Value <= dtTo.Value).ToList<Expense>();
            }
            else
            {
                Database.Expenses.Where(x => x.CreatedDate.Value >= dtFrom.Value).Where(x => x.CreatedDate.Value <= dtTo.Value).Where(x => x.ExpenseType.Contains(txtKeyword.Text)).ToList<Expense>();
            }
            
            grv.Rows.Clear();
            decimal total = 0;
            foreach (var d in data)
            {
                grv.Rows.Add(d.ID, d.ExpenseType, d.Amount.Value.ToString("N"), d.CreatedDate.Value.ToString("MMM-dd-yyyy"));
                total+=d.Amount.Value;
            }

            lblCount.Text = total.ToString("N");
        }

        private void ExpenseManage(long expense_id)
        {
            frmExpenseManage manage = new frmExpenseManage(expense_id);
            manage.StartPosition = FormStartPosition.CenterParent;
            manage.ShowDialog();
        }

        private void EditExpense()
        {
            if (grv.SelectedRows.Count != 0)
            {
                long expense_id = long.Parse(grv.CurrentRow.Cells[0].Value.ToString());
                this.ExpenseManage(expense_id);
                this.LoadData();
            }
        }



        public frmExpense()
        {
            InitializeComponent();
        }

        private void frmExpense_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-30);
            this.LoadData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.ExpenseManage(0);//insert
            this.LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditExpense();
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditExpense();
        }

        private void grv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditExpense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
