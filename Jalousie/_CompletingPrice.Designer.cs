namespace Jalousie
{
    partial class TfCompletingPrice
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb = new System.Windows.Forms.ComboBox();
            this.tbCompletingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCompleting = new Jalousie.Datasets.dsCompleting();
            this.label1 = new System.Windows.Forms.Label();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.tbColorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.кодЦветаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.оптоваяценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Цена = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompletingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompleting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 30);
            this.panel1.TabIndex = 0;
            // 
            // cb
            // 
            this.cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cb.DataSource = this.tbCompletingBindingSource;
            this.cb.DisplayMember = "Название";
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb.FormattingEnabled = true;
            this.cb.Location = new System.Drawing.Point(130, 3);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(495, 21);
            this.cb.TabIndex = 1;
            this.cb.ValueMember = "Код";
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // tbCompletingBindingSource
            // 
            this.tbCompletingBindingSource.DataMember = "tbCompleting";
            this.tbCompletingBindingSource.DataSource = this.dsCompleting;
            // 
            // dsCompleting
            // 
            this.dsCompleting.DataSetName = "dsCompleting";
            this.dsCompleting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Комплектующая";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbg
            // 
            this.dbg.AllowUserToAddRows = false;
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодDataGridViewTextBoxColumn,
            this.кодЦветаDataGridViewTextBoxColumn,
            this.оптоваяценаDataGridViewTextBoxColumn,
            this.Цена});
            this.dbg.DataSource = this.tbDetailBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 30);
            this.dbg.Name = "dbg";
            this.dbg.RowHeadersVisible = false;
            this.dbg.Size = new System.Drawing.Size(630, 419);
            this.dbg.TabIndex = 1;
            this.dbg.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbg_CellValueChanged);
            // 
            // tbColorBindingSource
            // 
            this.tbColorBindingSource.DataMember = "tbColor";
            this.tbColorBindingSource.DataSource = this.dsCompleting;
            // 
            // tbDetailBindingSource
            // 
            this.tbDetailBindingSource.DataMember = "tbDetail";
            this.tbDetailBindingSource.DataSource = this.dsCompleting;
            // 
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код цвета";
            this.кодDataGridViewTextBoxColumn.DataSource = this.tbColorBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.кодDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.кодDataGridViewTextBoxColumn.DisplayMember = "Цвет";
            this.кодDataGridViewTextBoxColumn.HeaderText = "Цвет";
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            this.кодDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.кодDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.кодDataGridViewTextBoxColumn.ValueMember = "Код";
            // 
            // кодЦветаDataGridViewTextBoxColumn
            // 
            this.кодЦветаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.кодЦветаDataGridViewTextBoxColumn.DataPropertyName = "Код цвета";
            this.кодЦветаDataGridViewTextBoxColumn.DataSource = this.tbColorBindingSource;
            this.кодЦветаDataGridViewTextBoxColumn.DisplayMember = "Описание цвета";
            this.кодЦветаDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.кодЦветаDataGridViewTextBoxColumn.Name = "кодЦветаDataGridViewTextBoxColumn";
            this.кодЦветаDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодЦветаDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.кодЦветаDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.кодЦветаDataGridViewTextBoxColumn.ValueMember = "Код";
            // 
            // оптоваяценаDataGridViewTextBoxColumn
            // 
            this.оптоваяценаDataGridViewTextBoxColumn.DataPropertyName = "Оптовая цена";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.оптоваяценаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.оптоваяценаDataGridViewTextBoxColumn.HeaderText = "Оптовая цена";
            this.оптоваяценаDataGridViewTextBoxColumn.Name = "оптоваяценаDataGridViewTextBoxColumn";
            // 
            // Цена
            // 
            this.Цена.DataPropertyName = "Цена";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Цена.DefaultCellStyle = dataGridViewCellStyle4;
            this.Цена.HeaderText = "Цена";
            this.Цена.Name = "Цена";
            // 
            // TfCompletingPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 449);
            this.Controls.Add(this.dbg);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfCompletingPrice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Комплектующие";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbCompletingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompleting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dbg;
        private Jalousie.Datasets.dsCompleting dsCompleting;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.BindingSource tbCompletingBindingSource;
        public System.Windows.Forms.BindingSource tbDetailBindingSource;
        public System.Windows.Forms.ComboBox cb;
        public System.Windows.Forms.BindingSource tbColorBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn кодЦветаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn оптоваяценаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Цена;
    }
}