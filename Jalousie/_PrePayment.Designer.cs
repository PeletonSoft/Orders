namespace Jalousie
{
    partial class TfPrePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSum = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Карта = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Безнал = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Возврат = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbPrepaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrePayment = new Jalousie.Datasets.dsPrePayment();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrepaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbSum);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 36);
            this.panel1.TabIndex = 5;
            // 
            // lbSum
            // 
            this.lbSum.BackColor = System.Drawing.SystemColors.Window;
            this.lbSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSum.ForeColor = System.Drawing.Color.Red;
            this.lbSum.Location = new System.Drawing.Point(162, 7);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(97, 21);
            this.lbSum.TabIndex = 23;
            this.lbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(3, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 21);
            this.label17.TabIndex = 22;
            this.label17.Text = "Предоплата";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(647, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dbg
            // 
            this.dbg.AllowUserToAddRows = false;
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AllowUserToResizeRows = false;
            this.dbg.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dbg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодDataGridViewTextBoxColumn,
            this.датаDataGridViewTextBoxColumn,
            this.суммаDataGridViewTextBoxColumn,
            this.Карта,
            this.Безнал,
            this.Возврат});
            this.dbg.DataSource = this.tbPrepaymentBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(811, 522);
            this.dbg.TabIndex = 6;
            // 
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.кодDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.кодDataGridViewTextBoxColumn.HeaderText = "№";
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            this.кодDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодDataGridViewTextBoxColumn.Width = 50;
            // 
            // датаDataGridViewTextBoxColumn
            // 
            this.датаDataGridViewTextBoxColumn.DataPropertyName = "Дата";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.датаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.датаDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.датаDataGridViewTextBoxColumn.Name = "датаDataGridViewTextBoxColumn";
            this.датаDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаDataGridViewTextBoxColumn.Width = 80;
            // 
            // суммаDataGridViewTextBoxColumn
            // 
            this.суммаDataGridViewTextBoxColumn.DataPropertyName = "Сумма";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.суммаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.суммаDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.суммаDataGridViewTextBoxColumn.Name = "суммаDataGridViewTextBoxColumn";
            this.суммаDataGridViewTextBoxColumn.ReadOnly = true;
            this.суммаDataGridViewTextBoxColumn.Width = 70;
            // 
            // Карта
            // 
            this.Карта.DataPropertyName = "Карта";
            this.Карта.HeaderText = "Карта";
            this.Карта.Name = "Карта";
            this.Карта.ReadOnly = true;
            // 
            // Безнал
            // 
            this.Безнал.DataPropertyName = "Безнал";
            this.Безнал.HeaderText = "Безнал";
            this.Безнал.Name = "Безнал";
            this.Безнал.ReadOnly = true;
            // 
            // Возврат
            // 
            this.Возврат.DataPropertyName = "Возврат";
            this.Возврат.HeaderText = "Возврат";
            this.Возврат.Name = "Возврат";
            this.Возврат.ReadOnly = true;
            // 
            // tbPrepaymentBindingSource
            // 
            this.tbPrepaymentBindingSource.DataMember = "tbPrepayment";
            this.tbPrepaymentBindingSource.DataSource = this.dsPrePayment;
            // 
            // dsPrePayment
            // 
            this.dsPrePayment.DataSetName = "dsPrePayment";
            this.dsPrePayment.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TfPrePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 558);
            this.Controls.Add(this.dbg);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfPrePayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Платежи по заказу";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrepaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrePayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridView dbg;
        private Jalousie.Datasets.dsPrePayment dsPrePayment;
        public System.Windows.Forms.BindingSource tbPrepaymentBindingSource;
        public System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Карта;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Безнал;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Возврат;
    }
}