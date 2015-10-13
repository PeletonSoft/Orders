namespace Jalousie
{
    partial class TfDictionary
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
            this.названиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Описание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.названиеDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодТипаДанныхDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tbTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDictionary = new Jalousie.Datasets.dsDictionary();
            this.Внешний = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbDictionaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btContent = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btCompleting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDictionaryBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // названиеDataGridViewTextBoxColumn
            // 
            this.названиеDataGridViewTextBoxColumn.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn.Name = "названиеDataGridViewTextBoxColumn";
            this.названиеDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.названиеDataGridViewTextBoxColumn.Width = 200;
            // 
            // описаниеDataGridViewTextBoxColumn
            // 
            this.описаниеDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.описаниеDataGridViewTextBoxColumn.DataPropertyName = "Описание";
            this.описаниеDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.описаниеDataGridViewTextBoxColumn.Name = "описаниеDataGridViewTextBoxColumn";
            // 
            // Название
            // 
            this.Название.DataPropertyName = "Название";
            this.Название.HeaderText = "Название";
            this.Название.Name = "Название";
            // 
            // Описание
            // 
            this.Описание.DataPropertyName = "Описание";
            this.Описание.HeaderText = "Описание";
            this.Описание.Name = "Описание";
            // 
            // dbg
            // 
            this.dbg.AllowUserToAddRows = false;
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AllowUserToResizeRows = false;
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
            this.названиеDataGridViewTextBoxColumn1,
            this.описаниеDataGridViewTextBoxColumn1,
            this.кодТипаДанныхDataGridViewTextBoxColumn,
            this.Внешний});
            this.dbg.DataSource = this.tbDictionaryBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Top;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(584, 671);
            this.dbg.TabIndex = 0;
            this.dbg.DoubleClick += new System.EventHandler(this.btEdit_Click);
            // 
            // названиеDataGridViewTextBoxColumn1
            // 
            this.названиеDataGridViewTextBoxColumn1.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn1.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn1.Name = "названиеDataGridViewTextBoxColumn1";
            this.названиеDataGridViewTextBoxColumn1.ReadOnly = true;
            this.названиеDataGridViewTextBoxColumn1.Width = 150;
            // 
            // описаниеDataGridViewTextBoxColumn1
            // 
            this.описаниеDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.описаниеDataGridViewTextBoxColumn1.DataPropertyName = "Описание";
            this.описаниеDataGridViewTextBoxColumn1.HeaderText = "Описание";
            this.описаниеDataGridViewTextBoxColumn1.Name = "описаниеDataGridViewTextBoxColumn1";
            this.описаниеDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // кодТипаДанныхDataGridViewTextBoxColumn
            // 
            this.кодТипаДанныхDataGridViewTextBoxColumn.DataPropertyName = "Код типа данных";
            this.кодТипаДанныхDataGridViewTextBoxColumn.DataSource = this.tbTypesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.кодТипаДанныхDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.кодТипаДанныхDataGridViewTextBoxColumn.DisplayMember = "Тип";
            this.кодТипаДанныхDataGridViewTextBoxColumn.HeaderText = "Тип данных";
            this.кодТипаДанныхDataGridViewTextBoxColumn.Name = "кодТипаДанныхDataGridViewTextBoxColumn";
            this.кодТипаДанныхDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодТипаДанныхDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.кодТипаДанныхDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.кодТипаДанныхDataGridViewTextBoxColumn.ValueMember = "Код";
            // 
            // tbTypesBindingSource
            // 
            this.tbTypesBindingSource.DataMember = "tbTypes";
            this.tbTypesBindingSource.DataSource = this.dsDictionary;
            // 
            // dsDictionary
            // 
            this.dsDictionary.DataSetName = "dsDictionary";
            this.dsDictionary.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Внешний
            // 
            this.Внешний.DataPropertyName = "Внешний";
            this.Внешний.HeaderText = "Внешний";
            this.Внешний.Name = "Внешний";
            this.Внешний.ReadOnly = true;
            // 
            // tbDictionaryBindingSource
            // 
            this.tbDictionaryBindingSource.DataMember = "tbDictionary";
            this.tbDictionaryBindingSource.DataSource = this.dsDictionary;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCompleting);
            this.panel1.Controls.Add(this.btContent);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btEdit);
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 671);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 39);
            this.panel1.TabIndex = 1;
            // 
            // btContent
            // 
            this.btContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btContent.Location = new System.Drawing.Point(235, 6);
            this.btContent.Name = "btContent";
            this.btContent.Size = new System.Drawing.Size(114, 28);
            this.btContent.TabIndex = 4;
            this.btContent.Text = "Содержание";
            this.btContent.UseVisualStyleBackColor = true;
            this.btContent.Click += new System.EventHandler(this.btContent_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(467, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(114, 28);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEdit.Location = new System.Drawing.Point(119, 6);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(114, 28);
            this.btEdit.TabIndex = 3;
            this.btEdit.Text = "Редактировать";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.ForeColor = System.Drawing.Color.Red;
            this.btAdd.Location = new System.Drawing.Point(3, 6);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(114, 28);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCompleting
            // 
            this.btCompleting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCompleting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCompleting.Location = new System.Drawing.Point(351, 6);
            this.btCompleting.Name = "btCompleting";
            this.btCompleting.Size = new System.Drawing.Size(114, 28);
            this.btCompleting.TabIndex = 5;
            this.btCompleting.Text = "Комплектующие";
            this.btCompleting.UseVisualStyleBackColor = true;
            this.btCompleting.Click += new System.EventHandler(this.btCompleting_Click);
            // 
            // TfDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 710);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dbg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочники";
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDictionaryBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jalousie.Datasets.dsDictionary dsDictionary;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Описание;
        private System.Windows.Forms.DataGridView dbg;
        public System.Windows.Forms.BindingSource tbTypesBindingSource;
        public System.Windows.Forms.BindingSource tbDictionaryBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn кодТипаДанныхDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Внешний;
        private System.Windows.Forms.Button btCompleting;
    }
}