namespace Jalousie
{
    partial class TfAdvPrice
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
            this.btDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAdvPriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdvPrice = new Jalousie.Datasets.dsAdvPrice();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
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
            this.Приоритет = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодБланкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.условиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.выражениеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.оптDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.приоритетDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdvPriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdvPrice)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btDelete);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btEdit);
            this.panel3.Controls.Add(this.btAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 732);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 43);
            this.panel3.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(768, 5);
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
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 497);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 235);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительная информация";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.tbAdvPriceBindingSource, "Выражение", true));
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbAdvPriceBindingSource, "Выражение", true));
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(106, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(773, 103);
            this.label11.TabIndex = 43;
            // 
            // tbAdvPriceBindingSource
            // 
            this.tbAdvPriceBindingSource.DataMember = "tbAdvPrice";
            this.tbAdvPriceBindingSource.DataSource = this.dsAdvPrice;
            this.tbAdvPriceBindingSource.Sort = "[Опт] ASC, [Приоритет] DESC";
            // 
            // dsAdvPrice
            // 
            this.dsAdvPrice.DataSetName = "dsAdvPrice";
            this.dsAdvPrice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbAdvPriceBindingSource, "Условие", true));
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(106, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(773, 108);
            this.label10.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 103);
            this.label6.TabIndex = 39;
            this.label6.Text = "Выражение";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 108);
            this.label7.TabIndex = 38;
            this.label7.Text = "Условие";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 405);
            this.panel2.TabIndex = 8;
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
            this.Приоритет,
            this.кодDataGridViewTextBoxColumn,
            this.кодБланкаDataGridViewTextBoxColumn,
            this.условиеDataGridViewTextBoxColumn,
            this.суммаDataGridViewTextBoxColumn,
            this.выражениеDataGridViewTextBoxColumn,
            this.описаниеDataGridViewTextBoxColumn,
            this.оптDataGridViewCheckBoxColumn,
            this.приоритетDataGridViewTextBoxColumn});
            this.dbg.DataSource = this.tbAdvPriceBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(882, 403);
            this.dbg.TabIndex = 8;
            this.dbg.DoubleClick += new System.EventHandler(this.btEdit_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(884, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Бланк заказа";
            // 
            // cbBlankActive
            // 
            this.cbBlankActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBlankActive.AutoSize = true;
            this.cbBlankActive.Checked = true;
            this.cbBlankActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBlankActive.Enabled = false;
            this.cbBlankActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBlankActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBlankActive.Location = new System.Drawing.Point(808, 18);
            this.cbBlankActive.Name = "cbBlankActive";
            this.cbBlankActive.Size = new System.Drawing.Size(72, 17);
            this.cbBlankActive.TabIndex = 10;
            this.cbBlankActive.Text = "Активно";
            this.cbBlankActive.UseVisualStyleBackColor = true;
            // 
            // lbBlankFirm
            // 
            this.lbBlankFirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankFirm.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankFirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankFirm.Location = new System.Drawing.Point(497, 41);
            this.lbBlankFirm.Name = "lbBlankFirm";
            this.lbBlankFirm.Size = new System.Drawing.Size(384, 21);
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
            this.lbBlankDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankDescription.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankDescription.Location = new System.Drawing.Point(124, 66);
            this.lbBlankDescription.Name = "lbBlankDescription";
            this.lbBlankDescription.Size = new System.Drawing.Size(757, 21);
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
            // Приоритет
            // 
            this.Приоритет.DataPropertyName = "Приоритет";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Приоритет.DefaultCellStyle = dataGridViewCellStyle2;
            this.Приоритет.HeaderText = "Приоритет";
            this.Приоритет.Name = "Приоритет";
            this.Приоритет.ReadOnly = true;
            // 
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код";
            this.кодDataGridViewTextBoxColumn.HeaderText = "Код";
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            this.кодDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // кодБланкаDataGridViewTextBoxColumn
            // 
            this.кодБланкаDataGridViewTextBoxColumn.DataPropertyName = "Код бланка";
            this.кодБланкаDataGridViewTextBoxColumn.HeaderText = "Код бланка";
            this.кодБланкаDataGridViewTextBoxColumn.Name = "кодБланкаDataGridViewTextBoxColumn";
            this.кодБланкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // условиеDataGridViewTextBoxColumn
            // 
            this.условиеDataGridViewTextBoxColumn.DataPropertyName = "Условие";
            this.условиеDataGridViewTextBoxColumn.HeaderText = "Условие";
            this.условиеDataGridViewTextBoxColumn.Name = "условиеDataGridViewTextBoxColumn";
            this.условиеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // суммаDataGridViewTextBoxColumn
            // 
            this.суммаDataGridViewTextBoxColumn.DataPropertyName = "Сумма";
            this.суммаDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.суммаDataGridViewTextBoxColumn.Name = "суммаDataGridViewTextBoxColumn";
            this.суммаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // выражениеDataGridViewTextBoxColumn
            // 
            this.выражениеDataGridViewTextBoxColumn.DataPropertyName = "Выражение";
            this.выражениеDataGridViewTextBoxColumn.HeaderText = "Выражение";
            this.выражениеDataGridViewTextBoxColumn.Name = "выражениеDataGridViewTextBoxColumn";
            this.выражениеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // описаниеDataGridViewTextBoxColumn
            // 
            this.описаниеDataGridViewTextBoxColumn.DataPropertyName = "Описание";
            this.описаниеDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.описаниеDataGridViewTextBoxColumn.Name = "описаниеDataGridViewTextBoxColumn";
            this.описаниеDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // оптDataGridViewCheckBoxColumn
            // 
            this.оптDataGridViewCheckBoxColumn.DataPropertyName = "Опт";
            this.оптDataGridViewCheckBoxColumn.HeaderText = "Опт";
            this.оптDataGridViewCheckBoxColumn.Name = "оптDataGridViewCheckBoxColumn";
            this.оптDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // приоритетDataGridViewTextBoxColumn
            // 
            this.приоритетDataGridViewTextBoxColumn.DataPropertyName = "Приоритет";
            this.приоритетDataGridViewTextBoxColumn.HeaderText = "Приоритет";
            this.приоритетDataGridViewTextBoxColumn.Name = "приоритетDataGridViewTextBoxColumn";
            this.приоритетDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TfAdvPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 775);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfAdvPrice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дополнительные расценки";
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbAdvPriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdvPrice)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dbg;
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
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private Jalousie.Datasets.dsAdvPrice dsAdvPrice;
        public System.Windows.Forms.BindingSource tbAdvPriceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Приоритет;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодБланкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn условиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn выражениеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn оптDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn приоритетDataGridViewTextBoxColumn;
    }
}