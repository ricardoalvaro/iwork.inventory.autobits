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

namespace  iwork.autobits.inventory
{
    public partial class frmExpenseManage : Form
    {
        public long ExpenseID { get; set; } = 0;
        public frmExpenseManage(long expense_id)
        {
            InitializeComponent();
            ExpenseID = expense_id;
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

        private void DoTransaction(string action)
        {

            Database = new DatabaseDataContext();
            if (ExpenseID > 0)
            {

                var s = Database.Expenses.SingleOrDefault(x => x.ID == ExpenseID);
                s.ExpenseType = txtExpenseType.Text;
                s.Amount = decimal.Parse(txtAmount.Text);
                s.CreatedDate = dtDate.Value;
                
            }
            else
            {
                Database.Expenses.InsertOnSubmit(new Expense() { ExpenseType =  txtExpenseType.Text , Amount = decimal.Parse(txtAmount.Text), CreatedDate = dtDate.Value});
            }

            Database.SubmitChanges();

            MessageBox.Show("Successfully saved", Helper.MessageBoxHeader);
            if (action == "close") { this.Close(); }
            else { this.ClearTextBoxes(); ExpenseID = 0; }
        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void frmExpenseManage_Load(object sender, EventArgs e)
        {
            if (ExpenseID > 0)
            {
                var data = Database.Expenses.Where(x => x.ID == ExpenseID);
                foreach (var d in data)
                {
                    txtExpenseType.Text = d.ExpenseType;
                    txtAmount.Text = d.Amount.Value.ToString("N");
                    dtDate.Value = d.CreatedDate.Value;
                   
                }
            }
        }

        private void SaveNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExpenseType.Text))
            {
                DoTransaction("new");

            }
            else
            {
                MessageBox.Show("Expense type required!", Helper.MessageBoxHeader);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExpenseType.Text))
            {
                DoTransaction("close");
            }
            else
            {
                MessageBox.Show("Expense type required!", Helper.MessageBoxHeader);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtAmount.Text);
            }
            catch
            {
                txtAmount.Text = "0";
                txtAmount.Focus();
                txtAmount.SelectAll();
            }
        }
    }
}
