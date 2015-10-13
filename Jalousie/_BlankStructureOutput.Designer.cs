namespace Jalousie
{
    partial class TfBlankStructureOutput
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
            this.tbBlankStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlankStructure = new Jalousie.Datasets.dsBlankStructure();
            this.tbAligmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.значениеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.заменаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOputputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edColumnField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.edFormatField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edFieldLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAlignmentId = new System.Windows.Forms.ComboBox();
            this.edFieldName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btDelete = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOputputBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBlankStructureBindingSource
            // 
            this.tbBlankStructureBindingSource.DataMember = "tbBlankStructure";
            this.tbBlankStructureBindingSource.DataSource = this.dsBlankStructure;
            // 
            // dsBlankStructure
            // 
            this.dsBlankStructure.DataSetName = "dsBlankStructure";
            this.dsBlankStructure.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbAligmentBindingSource
            // 
            this.tbAligmentBindingSource.DataMember = "tbAligment";
            this.tbAligmentBindingSource.DataSource = this.dsBlankStructure;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 324);
            this.panel2.TabIndex = 5;
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
            this.значениеDataGridViewTextBoxColumn,
            this.заменаDataGridViewTextBoxColumn});
            this.dbg.DataSource = this.tbOputputBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 180);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(710, 142);
            this.dbg.TabIndex = 2;
            this.dbg.DoubleClick += new System.EventHandler(this.btEdit_Click);
            // 
            // значениеDataGridViewTextBoxColumn
            // 
            this.значениеDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.значениеDataGridViewTextBoxColumn.DataPropertyName = "Значение";
            this.значениеDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.значениеDataGridViewTextBoxColumn.Name = "значениеDataGridViewTextBoxColumn";
            this.значениеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // заменаDataGridViewTextBoxColumn
            // 
            this.заменаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.заменаDataGridViewTextBoxColumn.DataPropertyName = "Замена";
            this.заменаDataGridViewTextBoxColumn.HeaderText = "Замена";
            this.заменаDataGridViewTextBoxColumn.Name = "заменаDataGridViewTextBoxColumn";
            this.заменаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tbOputputBindingSource
            // 
            this.tbOputputBindingSource.DataMember = "tbOputput";
            this.tbOputputBindingSource.DataSource = this.dsBlankStructure;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(710, 180);
            this.panel4.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edColumnField);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbPreview);
            this.groupBox2.Controls.Add(this.edFormatField);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.edFieldLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbAlignmentId);
            this.groupBox2.Controls.Add(this.edFieldName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 85);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Атрибут в бланке";
            // 
            // edColumnField
            // 
            this.edColumnField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnField.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Ячейка", true));
            this.edColumnField.Enabled = false;
            this.edColumnField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edColumnField.Location = new System.Drawing.Point(646, 37);
            this.edColumnField.Name = "edColumnField";
            this.edColumnField.Size = new System.Drawing.Size(59, 20);
            this.edColumnField.TabIndex = 34;
            this.edColumnField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(567, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Столбец";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPreview
            // 
            this.cbPreview.AutoSize = true;
            this.cbPreview.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tbBlankStructureBindingSource, "Краткий обзор", true));
            this.cbPreview.Enabled = false;
            this.cbPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPreview.Location = new System.Drawing.Point(567, 15);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(137, 17);
            this.cbPreview.TabIndex = 33;
            this.cbPreview.Text = "Быстрый просмотр";
            this.cbPreview.UseVisualStyleBackColor = true;
            // 
            // edFormatField
            // 
            this.edFormatField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFormatField.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Формат", true));
            this.edFormatField.Enabled = false;
            this.edFormatField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFormatField.Location = new System.Drawing.Point(497, 60);
            this.edFormatField.Name = "edFormatField";
            this.edFormatField.Size = new System.Drawing.Size(208, 20);
            this.edFormatField.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(379, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Формат вывода";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edFieldLabel
            // 
            this.edFieldLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Надпись", true));
            this.edFieldLabel.Enabled = false;
            this.edFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldLabel.Location = new System.Drawing.Point(124, 38);
            this.edFieldLabel.Name = "edFieldLabel";
            this.edFieldLabel.Size = new System.Drawing.Size(438, 20);
            this.edFieldLabel.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 39;
            this.label6.Text = "Надпись";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAlignmentId
            // 
            this.cbAlignmentId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tbBlankStructureBindingSource, "Код выравнивания", true));
            this.cbAlignmentId.DataSource = this.tbAligmentBindingSource;
            this.cbAlignmentId.DisplayMember = "Выравнивание";
            this.cbAlignmentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlignmentId.Enabled = false;
            this.cbAlignmentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAlignmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAlignmentId.FormattingEnabled = true;
            this.cbAlignmentId.Location = new System.Drawing.Point(124, 60);
            this.cbAlignmentId.MaxDropDownItems = 9;
            this.cbAlignmentId.Name = "cbAlignmentId";
            this.cbAlignmentId.Size = new System.Drawing.Size(251, 21);
            this.cbAlignmentId.TabIndex = 35;
            this.cbAlignmentId.ValueMember = "Код";
            // 
            // edFieldName
            // 
            this.edFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Поле", true));
            this.edFieldName.Enabled = false;
            this.edFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldName.Location = new System.Drawing.Point(124, 15);
            this.edFieldName.Name = "edFieldName";
            this.edFieldName.Size = new System.Drawing.Size(438, 20);
            this.edFieldName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Название";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 18);
            this.label9.TabIndex = 37;
            this.label9.Text = "Выравнивание";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.Size = new System.Drawing.Size(710, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Бланк заказа";
            // 
            // cbBlankActive
            // 
            this.cbBlankActive.AutoSize = true;
            this.cbBlankActive.Checked = true;
            this.cbBlankActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBlankActive.Enabled = false;
            this.cbBlankActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBlankActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBlankActive.Location = new System.Drawing.Point(632, 18);
            this.cbBlankActive.Name = "cbBlankActive";
            this.cbBlankActive.Size = new System.Drawing.Size(72, 17);
            this.cbBlankActive.TabIndex = 10;
            this.cbBlankActive.Text = "Активно";
            this.cbBlankActive.UseVisualStyleBackColor = true;
            // 
            // lbBlankFirm
            // 
            this.lbBlankFirm.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankFirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankFirm.Location = new System.Drawing.Point(497, 41);
            this.lbBlankFirm.Name = "lbBlankFirm";
            this.lbBlankFirm.Size = new System.Drawing.Size(208, 21);
            this.lbBlankFirm.TabIndex = 7;
            this.lbBlankFirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(379, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Фирма";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBlankDescription
            // 
            this.lbBlankDescription.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankDescription.Location = new System.Drawing.Point(124, 66);
            this.lbBlankDescription.Name = "lbBlankDescription";
            this.lbBlankDescription.Size = new System.Drawing.Size(581, 21);
            this.lbBlankDescription.TabIndex = 5;
            this.lbBlankDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBlankType
            // 
            this.lbBlankType.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankType.Location = new System.Drawing.Point(124, 41);
            this.lbBlankType.Name = "lbBlankType";
            this.lbBlankType.Size = new System.Drawing.Size(251, 21);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 43);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btDelete);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btEdit);
            this.panel3.Controls.Add(this.btAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 42);
            this.panel3.TabIndex = 1;
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
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(596, 5);
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
            // TfBlankStructureOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 367);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfBlankStructureOutput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Автозамена при выводе";
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankStructureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOputputBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource tbBlankStructureBindingSource;
        private Jalousie.Datasets.dsBlankStructure dsBlankStructure;
        public System.Windows.Forms.BindingSource tbAligmentBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridView dbg;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox edColumnField;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox cbPreview;
        public System.Windows.Forms.TextBox edFormatField;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edFieldLabel;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbAlignmentId;
        public System.Windows.Forms.TextBox edFieldName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn значениеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn заменаDataGridViewTextBoxColumn;
        public System.Windows.Forms.BindingSource tbOputputBindingSource;
    }
}