namespace iwork.inventory
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grv = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockOUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockADJUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Current = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtTo);
            this.panel3.Controls.Add(this.dtFrom);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.txtKeyword);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.panel39);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1333, 162);
            this.panel3.TabIndex = 45;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "MMM-dd-yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(462, 125);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(215, 32);
            this.dtTo.TabIndex = 18;
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "MMM-dd-yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(228, 125);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(215, 32);
            this.dtFrom.TabIndex = 17;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(104)))), ((int)(((byte)(142)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(104)))), ((int)(((byte)(142)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(692, 126);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtKeyword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtKeyword.Location = new System.Drawing.Point(14, 126);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(195, 32);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.label13.Location = new System.Drawing.Point(9, 4);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 30);
            this.label13.TabIndex = 8;
            this.label13.Text = "REPORTS";
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.panel39.Location = new System.Drawing.Point(14, 28);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(1714, 1);
            this.panel39.TabIndex = 16;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblCount);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Controls.Add(this.panel1);
            this.panel9.Controls.Add(this.panel19);
            this.panel9.Controls.Add(this.panel18);
            this.panel9.Location = new System.Drawing.Point(14, 35);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(743, 85);
            this.panel9.TabIndex = 14;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(9, 48);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(51, 28);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "369";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "TOTAL NO. OF TRANSACTION";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(742, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 58);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 58);
            this.panel1.TabIndex = 6;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.panel19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel19.Location = new System.Drawing.Point(0, 84);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(743, 1);
            this.panel19.TabIndex = 5;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(127)))), ((int)(((byte)(172)))));
            this.panel18.Controls.Add(this.label3);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(743, 26);
            this.panel18.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "TRANSACTION ACTIVITY";
            // 
            // grv
            // 
            this.grv.AllowUserToAddRows = false;
            this.grv.AllowUserToDeleteRows = false;
            this.grv.BackgroundColor = System.Drawing.Color.White;
            this.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Description,
            this.Stock,
            this.StockOUT,
            this.StockADJUST,
            this.Current,
            this.LastTransaction,
            this.Remarks,
            this.Namex});
            this.grv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv.Location = new System.Drawing.Point(0, 162);
            this.grv.MultiSelect = false;
            this.grv.Name = "grv";
            this.grv.ReadOnly = true;
            this.grv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grv.Size = new System.Drawing.Size(1333, 270);
            this.grv.TabIndex = 46;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 150;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 50;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "IN";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 150;
            // 
            // StockOUT
            // 
            this.StockOUT.HeaderText = "OUT";
            this.StockOUT.Name = "StockOUT";
            this.StockOUT.ReadOnly = true;
            this.StockOUT.Width = 150;
            // 
            // StockADJUST
            // 
            this.StockADJUST.HeaderText = "ADJUST";
            this.StockADJUST.Name = "StockADJUST";
            this.StockADJUST.ReadOnly = true;
            // 
            // Current
            // 
            this.Current.HeaderText = "CURRENT";
            this.Current.Name = "Current";
            this.Current.ReadOnly = true;
            this.Current.Width = 150;
            // 
            // LastTransaction
            // 
            this.LastTransaction.HeaderText = "Last Transaction";
            this.LastTransaction.Name = "LastTransaction";
            this.LastTransaction.ReadOnly = true;
            this.LastTransaction.Width = 200;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 300;
            // 
            // Namex
            // 
            this.Namex.HeaderText = "Name";
            this.Namex.Name = "Namex";
            this.Namex.ReadOnly = true;
            this.Namex.Width = 200;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1333, 432);
            this.Controls.Add(this.grv);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView grv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockOUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockADJUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn Current;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namex;
    }
}