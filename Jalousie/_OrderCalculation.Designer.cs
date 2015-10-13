namespace Jalousie
{
    partial class TfOrderCalculation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSum = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.кодАртикулаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.артикулDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.прИнфоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.инфоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.требуетсяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имеетсяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Заказная = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCalcBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOrderCalculation = new Jalousie.Datasets.dsOrderCalculation();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCalcBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrderCalculation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbSum);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 36);
            this.panel1.TabIndex = 5;
            // 
            // lbSum
            // 
            this.lbSum.BackColor = System.Drawing.SystemColors.Window;
            this.lbSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSum.Location = new System.Drawing.Point(172, 7);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(87, 21);
            this.lbSum.TabIndex = 21;
            this.lbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 21);
            this.label12.TabIndex = 20;
            this.label12.Text = "Расчетная себестоимость";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(763, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dbg
            // 
            this.dbg.AllowUserToAddRows = false;
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AllowUserToResizeRows = false;
            this.dbg.AutoGenerateColumns = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dbg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодАртикулаDataGridViewTextBoxColumn,
            this.артикулDataGridViewTextBoxColumn,
            this.прИнфоDataGridViewTextBoxColumn,
            this.инфоDataGridViewTextBoxColumn,
            this.требуетсяDataGridViewTextBoxColumn,
            this.имеетсяDataGridViewTextBoxColumn,
            this.Заказная,
            this.dataGridViewTextBoxColumn1});
            this.dbg.DataSource = this.tbCalcBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(927, 478);
            this.dbg.TabIndex = 6;
            // 
            // кодАртикулаDataGridViewTextBoxColumn
            // 
            this.кодАртикулаDataGridViewTextBoxColumn.DataPropertyName = "Код артикула";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.кодАртикулаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.кодАртикулаDataGridViewTextBoxColumn.HeaderText = "Код";
            this.кодАртикулаDataGridViewTextBoxColumn.Name = "кодАртикулаDataGridViewTextBoxColumn";
            this.кодАртикулаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // артикулDataGridViewTextBoxColumn
            // 
            this.артикулDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.артикулDataGridViewTextBoxColumn.DataPropertyName = "Артикул";
            this.артикулDataGridViewTextBoxColumn.HeaderText = "Артикул";
            this.артикулDataGridViewTextBoxColumn.Name = "артикулDataGridViewTextBoxColumn";
            this.артикулDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // прИнфоDataGridViewTextBoxColumn
            // 
            this.прИнфоDataGridViewTextBoxColumn.DataPropertyName = "ПрИнфо";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.прИнфоDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.прИнфоDataGridViewTextBoxColumn.HeaderText = "ПрИнфо";
            this.прИнфоDataGridViewTextBoxColumn.Name = "прИнфоDataGridViewTextBoxColumn";
            this.прИнфоDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // инфоDataGridViewTextBoxColumn
            // 
            this.инфоDataGridViewTextBoxColumn.DataPropertyName = "Инфо";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.инфоDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.инфоDataGridViewTextBoxColumn.HeaderText = "Инфо";
            this.инфоDataGridViewTextBoxColumn.Name = "инфоDataGridViewTextBoxColumn";
            this.инфоDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // требуетсяDataGridViewTextBoxColumn
            // 
            this.требуетсяDataGridViewTextBoxColumn.DataPropertyName = "Требуется";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.требуетсяDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.требуетсяDataGridViewTextBoxColumn.HeaderText = "Требуется";
            this.требуетсяDataGridViewTextBoxColumn.Name = "требуетсяDataGridViewTextBoxColumn";
            this.требуетсяDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // имеетсяDataGridViewTextBoxColumn
            // 
            this.имеетсяDataGridViewTextBoxColumn.DataPropertyName = "Имеется";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.имеетсяDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.имеетсяDataGridViewTextBoxColumn.HeaderText = "Имеется";
            this.имеетсяDataGridViewTextBoxColumn.Name = "имеетсяDataGridViewTextBoxColumn";
            this.имеетсяDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Заказная
            // 
            this.Заказная.DataPropertyName = "Заказная";
            this.Заказная.HeaderText = "Заказная";
            this.Заказная.Name = "Заказная";
            this.Заказная.ReadOnly = true;
            this.Заказная.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Заказная.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Заказная.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Расчетная цена";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn1.HeaderText = "Цена закупки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tbCalcBindingSource
            // 
            this.tbCalcBindingSource.DataMember = "tbCalc";
            this.tbCalcBindingSource.DataSource = this.dsOrderCalculation;
            this.tbCalcBindingSource.Sort = "";
            // 
            // dsOrderCalculation
            // 
            this.dsOrderCalculation.DataSetName = "dsOrderCalculation";
            this.dsOrderCalculation.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TfOrderCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 514);
            this.Controls.Add(this.dbg);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfOrderCalculation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Комплектующие заказа";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCalcBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrderCalculation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tbCalcBindingSource;
        public Jalousie.Datasets.dsOrderCalculation dsOrderCalculation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridView dbg;
        public System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодАртикулаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn артикулDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn прИнфоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn инфоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn требуетсяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имеетсяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Заказная;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}