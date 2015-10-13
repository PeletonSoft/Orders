namespace Jalousie
{
    partial class TfDictionaryContent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDataType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.Код = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Внешний = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.целоеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дробноеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.текстовоеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.активенDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDictionary = new Jalousie.Datasets.dsDictionary();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbDescription);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lbDataType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Иформация о справочнике";
            // 
            // lbDescription
            // 
            this.lbDescription.BackColor = System.Drawing.SystemColors.Window;
            this.lbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDescription.Location = new System.Drawing.Point(98, 37);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(424, 19);
            this.lbDescription.TabIndex = 16;
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Window;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(98, 14);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(424, 19);
            this.lbName.TabIndex = 15;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDataType
            // 
            this.lbDataType.BackColor = System.Drawing.SystemColors.Window;
            this.lbDataType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDataType.Location = new System.Drawing.Point(98, 59);
            this.lbDataType.Name = "lbDataType";
            this.lbDataType.Size = new System.Drawing.Size(87, 18);
            this.lbDataType.TabIndex = 14;
            this.lbDataType.Text = "Текстовое";
            this.lbDataType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Тип данных";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Справочник";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Описание";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 407);
            this.panel2.TabIndex = 2;
            // 
            // dbg
            // 
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
            this.Код,
            this.Внешний,
            this.целоеDataGridViewTextBoxColumn,
            this.дробноеDataGridViewTextBoxColumn,
            this.текстовоеDataGridViewTextBoxColumn,
            this.активенDataGridViewCheckBoxColumn});
            this.dbg.DataSource = this.tbContentBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.Name = "dbg";
            this.dbg.RowHeadersVisible = false;
            this.dbg.Size = new System.Drawing.Size(525, 405);
            this.dbg.TabIndex = 0;
            this.dbg.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbg_CellValueChanged);
            // 
            // Код
            // 
            this.Код.DataPropertyName = "Код";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Код.DefaultCellStyle = dataGridViewCellStyle2;
            this.Код.Frozen = true;
            this.Код.HeaderText = "Код";
            this.Код.Name = "Код";
            this.Код.ReadOnly = true;
            this.Код.Width = 70;
            // 
            // Внешний
            // 
            this.Внешний.DataPropertyName = "Внешний";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.NullValue = false;
            this.Внешний.DefaultCellStyle = dataGridViewCellStyle3;
            this.Внешний.HeaderText = "Внешний";
            this.Внешний.Name = "Внешний";
            this.Внешний.ReadOnly = true;
            this.Внешний.Width = 70;
            // 
            // целоеDataGridViewTextBoxColumn
            // 
            this.целоеDataGridViewTextBoxColumn.DataPropertyName = "Целое";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.целоеDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.целоеDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.целоеDataGridViewTextBoxColumn.Name = "целоеDataGridViewTextBoxColumn";
            // 
            // дробноеDataGridViewTextBoxColumn
            // 
            this.дробноеDataGridViewTextBoxColumn.DataPropertyName = "Дробное";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.дробноеDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.дробноеDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.дробноеDataGridViewTextBoxColumn.Name = "дробноеDataGridViewTextBoxColumn";
            // 
            // текстовоеDataGridViewTextBoxColumn
            // 
            this.текстовоеDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.текстовоеDataGridViewTextBoxColumn.DataPropertyName = "Текстовое";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.текстовоеDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.текстовоеDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.текстовоеDataGridViewTextBoxColumn.Name = "текстовоеDataGridViewTextBoxColumn";
            // 
            // активенDataGridViewCheckBoxColumn
            // 
            this.активенDataGridViewCheckBoxColumn.DataPropertyName = "Активен";
            this.активенDataGridViewCheckBoxColumn.HeaderText = "Активно";
            this.активенDataGridViewCheckBoxColumn.Name = "активенDataGridViewCheckBoxColumn";
            this.активенDataGridViewCheckBoxColumn.Width = 70;
            // 
            // tbContentBindingSource
            // 
            this.tbContentBindingSource.DataMember = "tbContent";
            this.tbContentBindingSource.DataSource = this.dsDictionary;
            // 
            // dsDictionary
            // 
            this.dsDictionary.DataSetName = "dsDictionary";
            this.dsDictionary.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TfDictionaryContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 489);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfDictionaryContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Содержание справочника";
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private Jalousie.Datasets.dsDictionary dsDictionary;
        public System.Windows.Forms.Label lbDataType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.BindingSource tbContentBindingSource;
        public System.Windows.Forms.Label lbDescription;
        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.DataGridView dbg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Код;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Внешний;
        private System.Windows.Forms.DataGridViewTextBoxColumn целоеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дробноеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn текстовоеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn активенDataGridViewCheckBoxColumn;
    }
}