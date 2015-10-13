namespace Jalousie
{
    partial class TfConstraints
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
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.tbConstraintsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsConstraints = new Jalousie.Datasets.dsConstraints();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBlankActive = new System.Windows.Forms.CheckBox();
            this.lbBlankFirm = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBlankDescription = new System.Windows.Forms.Label();
            this.lbBlankType = new System.Windows.Forms.Label();
            this.lbBlankId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.приоритетDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tbExpressionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Операция = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tbOperationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.активенDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbConstraintsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsConstraints)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExpressionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOperationsBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPreview
            // 
            this.cbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPreview.AutoSize = true;
            this.cbPreview.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tbConstraintsBindingSource, "Активен", true));
            this.cbPreview.Enabled = false;
            this.cbPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPreview.Location = new System.Drawing.Point(818, 164);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(72, 17);
            this.cbPreview.TabIndex = 33;
            this.cbPreview.Text = "Активно";
            this.cbPreview.UseVisualStyleBackColor = true;
            // 
            // tbConstraintsBindingSource
            // 
            this.tbConstraintsBindingSource.DataMember = "tbConstraints";
            this.tbConstraintsBindingSource.DataSource = this.dsConstraints;
            this.tbConstraintsBindingSource.Sort = "[Операция] ASC, [Приоритет] DESC";
            // 
            // dsConstraints
            // 
            this.dsConstraints.DataSetName = "dsConstraints";
            this.dsConstraints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 39;
            this.label6.Text = "Сообщение";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBlankActive);
            this.groupBox1.Controls.Add(this.lbBlankFirm);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbBlankDescription);
            this.groupBox1.Controls.Add(this.lbBlankType);
            this.groupBox1.Controls.Add(this.lbBlankId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Бланк заказа";
            // 
            // cbBlankActive
            // 
            this.cbBlankActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBlankActive.AutoSize = true;
            this.cbBlankActive.Checked = true;
            this.cbBlankActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBlankActive.Enabled = false;
            this.cbBlankActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBlankActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBlankActive.Location = new System.Drawing.Point(818, 18);
            this.cbBlankActive.Name = "cbBlankActive";
            this.cbBlankActive.Size = new System.Drawing.Size(72, 17);
            this.cbBlankActive.TabIndex = 10;
            this.cbBlankActive.Text = "Активно";
            this.cbBlankActive.UseVisualStyleBackColor = true;
            // 
            // lbBlankFirm
            // 
            this.lbBlankFirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankFirm.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankFirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankFirm.Location = new System.Drawing.Point(517, 41);
            this.lbBlankFirm.Name = "lbBlankFirm";
            this.lbBlankFirm.Size = new System.Drawing.Size(373, 21);
            this.lbBlankFirm.TabIndex = 7;
            this.lbBlankFirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(399, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Фирма";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBlankDescription
            // 
            this.lbBlankDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankDescription.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankDescription.Location = new System.Drawing.Point(124, 66);
            this.lbBlankDescription.Name = "lbBlankDescription";
            this.lbBlankDescription.Size = new System.Drawing.Size(766, 21);
            this.lbBlankDescription.TabIndex = 5;
            this.lbBlankDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBlankType
            // 
            this.lbBlankType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankType.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankType.Location = new System.Drawing.Point(124, 41);
            this.lbBlankType.Name = "lbBlankType";
            this.lbBlankType.Size = new System.Drawing.Size(271, 21);
            this.lbBlankType.TabIndex = 4;
            this.lbBlankType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBlankId
            // 
            this.lbBlankId.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankId.Location = new System.Drawing.Point(124, 16);
            this.lbBlankId.Name = "lbBlankId";
            this.lbBlankId.Size = new System.Drawing.Size(87, 21);
            this.lbBlankId.TabIndex = 3;
            this.lbBlankId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип жалюзей";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер бланка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 120);
            this.label7.TabIndex = 38;
            this.label7.Text = "Ограничение";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(5, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 21);
            this.label9.TabIndex = 37;
            this.label9.Text = "Описание";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 431);
            this.panel2.TabIndex = 5;
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
            this.приоритетDataGridViewTextBoxColumn,
            this.описаниеDataGridViewTextBoxColumn,
            this.dataGridViewComboBoxColumn1,
            this.Операция,
            this.активенDataGridViewCheckBoxColumn});
            this.dbg.DataSource = this.tbConstraintsBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(894, 429);
            this.dbg.TabIndex = 2;
            this.dbg.DoubleClick += new System.EventHandler(this.btEdit_Click);
            // 
            // приоритетDataGridViewTextBoxColumn
            // 
            this.приоритетDataGridViewTextBoxColumn.DataPropertyName = "Приоритет";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.приоритетDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.приоритетDataGridViewTextBoxColumn.HeaderText = "Приоритет";
            this.приоритетDataGridViewTextBoxColumn.Name = "приоритетDataGridViewTextBoxColumn";
            this.приоритетDataGridViewTextBoxColumn.ReadOnly = true;
            this.приоритетDataGridViewTextBoxColumn.Width = 80;
            // 
            // описаниеDataGridViewTextBoxColumn
            // 
            this.описаниеDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.описаниеDataGridViewTextBoxColumn.DataPropertyName = "Описание";
            this.описаниеDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.описаниеDataGridViewTextBoxColumn.Name = "описаниеDataGridViewTextBoxColumn";
            this.описаниеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "Тип выражения";
            this.dataGridViewComboBoxColumn1.DataSource = this.tbExpressionTypeBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewComboBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewComboBoxColumn1.DisplayMember = "Название";
            this.dataGridViewComboBoxColumn1.HeaderText = "Тип выражения";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.ValueMember = "Код";
            // 
            // tbExpressionTypeBindingSource
            // 
            this.tbExpressionTypeBindingSource.DataMember = "tbExpressionType";
            this.tbExpressionTypeBindingSource.DataSource = this.dsConstraints;
            // 
            // Операция
            // 
            this.Операция.DataPropertyName = "Операция";
            this.Операция.DataSource = this.tbOperationsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Операция.DefaultCellStyle = dataGridViewCellStyle4;
            this.Операция.DisplayMember = "Название";
            this.Операция.HeaderText = "Операция";
            this.Операция.Name = "Операция";
            this.Операция.ReadOnly = true;
            this.Операция.ValueMember = "Код";
            this.Операция.Width = 150;
            // 
            // tbOperationsBindingSource
            // 
            this.tbOperationsBindingSource.DataMember = "tbOperations";
            this.tbOperationsBindingSource.DataSource = this.dsConstraints;
            // 
            // активенDataGridViewCheckBoxColumn
            // 
            this.активенDataGridViewCheckBoxColumn.DataPropertyName = "Активен";
            this.активенDataGridViewCheckBoxColumn.HeaderText = "Активно";
            this.активенDataGridViewCheckBoxColumn.Name = "активенDataGridViewCheckBoxColumn";
            this.активенDataGridViewCheckBoxColumn.ReadOnly = true;
            this.активенDataGridViewCheckBoxColumn.Width = 70;
            // 
            // btDelete
            // 
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(233, 5);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(110, 30);
            this.btDelete.TabIndex = 11;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btDelete);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btEdit);
            this.panel3.Controls.Add(this.btAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 735);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(896, 40);
            this.panel3.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(779, 5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(110, 30);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEdit.Location = new System.Drawing.Point(119, 5);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(110, 30);
            this.btEdit.TabIndex = 10;
            this.btEdit.Text = "Редактировать";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.ForeColor = System.Drawing.Color.Red;
            this.btAdd.Location = new System.Drawing.Point(4, 5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(110, 30);
            this.btAdd.TabIndex = 9;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbOperation);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbPreview);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 523);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 212);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительная информация";
            // 
            // cbOperation
            // 
            this.cbOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOperation.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tbConstraintsBindingSource, "Операция", true));
            this.cbOperation.DataSource = this.tbOperationsBindingSource;
            this.cbOperation.DisplayMember = "Название";
            this.cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperation.DropDownWidth = 300;
            this.cbOperation.Enabled = false;
            this.cbOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Location = new System.Drawing.Point(485, 185);
            this.cbOperation.MaxDropDownItems = 20;
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(404, 21);
            this.cbOperation.TabIndex = 50;
            this.cbOperation.ValueMember = "Код";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(408, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 21);
            this.label14.TabIndex = 49;
            this.label14.Text = "Операция";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tbConstraintsBindingSource, "Тип выражения", true));
            this.comboBox1.DataSource = this.tbExpressionTypeBindingSource;
            this.comboBox1.DisplayMember = "Название";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(272, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.ValueMember = "Код";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(165, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 21);
            this.label13.TabIndex = 47;
            this.label13.Text = "Тип выражения";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbConstraintsBindingSource, "Приоритет", true));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(105, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 46;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "Приоритет";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbConstraintsBindingSource, "Описание", true));
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(105, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(706, 21);
            this.label12.TabIndex = 44;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbConstraintsBindingSource, "Сообщение", true));
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(105, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(785, 21);
            this.label11.TabIndex = 43;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbConstraintsBindingSource, "Ограничение", true));
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(105, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(785, 120);
            this.label10.TabIndex = 42;
            // 
            // TfConstraints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 775);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfConstraints";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ограничения";
            ((System.ComponentModel.ISupportInitialize)(this.tbConstraintsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsConstraints)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExpressionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOperationsBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox cbPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox cbBlankActive;
        public System.Windows.Forms.Label lbBlankFirm;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbBlankDescription;
        public System.Windows.Forms.Label lbBlankType;
        public System.Windows.Forms.Label lbBlankId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dbg;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label11;
        private Jalousie.Datasets.dsConstraints dsConstraints;
        public System.Windows.Forms.BindingSource tbConstraintsBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.BindingSource tbExpressionTypeBindingSource;
        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.BindingSource tbOperationsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn приоритетDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Операция;
        private System.Windows.Forms.DataGridViewCheckBoxColumn активенDataGridViewCheckBoxColumn;
    }
}