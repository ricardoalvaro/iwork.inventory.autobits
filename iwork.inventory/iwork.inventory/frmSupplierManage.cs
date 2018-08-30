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

namespace  iwork.autobits.inventory
{
    public partial class frmSupplierManage : Form
    {
        public long SupplierID { get; set; } = 0;


        public frmSupplierManage(long supplier_id)
        {
            InitializeComponent();
            SupplierID = supplier_id;
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
            if (SupplierID > 0)
            {

                var s = Database.Suppliers.SingleOrDefault(x => x.ID == SupplierID);
                s.Name = txtName.Text;
                s.Mobile = txtMobile.Text;
                s.Phone = txtPhone.Text;
                s.Email = txtEmail.Text;
                s.CompleteAddress = txtAddress.Text;

            }
            else
            {
                Database.Suppliers.InsertOnSubmit(new Supplier() { Name = txtName.Text, Mobile = txtMobile.Text, Phone = txtPhone.Text, Email = txtEmail.Text, CompleteAddress = txtAddress.Text });
            }

            Database.SubmitChanges();

            MessageBox.Show("Successfully saved", Helper.MessageBoxHeader);
            if (action == "close") { this.Close(); }
            else { this.ClearTextBoxes(); SupplierID = 0; }
        }

        private DatabaseDataContext Database = new DatabaseDataContext();

        private void frmSupplierManage_Load(object sender, EventArgs e)
        {
            if (SupplierID > 0)
            {
                var data = Database.Suppliers.Where(x => x.ID == SupplierID);
                foreach (var d in data)
                {
                    txtName.Text = d.Name;
                    txtMobile.Text = d.Mobile;
                    txtPhone.Text = d.Phone;
                    txtEmail.Text = d.Email;
                    txtAddress.Text = d.CompleteAddress;
                }
            }
        }

        private void SaveNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                DoTransaction("new");

            }
            else
            {
                MessageBox.Show("Name required!", Helper.MessageBoxHeader);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                DoTransaction("close");
            }
            else
            {
                MessageBox.Show("Name required!", Helper.MessageBoxHeader);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
