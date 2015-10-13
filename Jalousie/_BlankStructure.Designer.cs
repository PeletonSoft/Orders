namespace Jalousie
{
    partial class TfBlankStructure
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
            this.btCalcField = new System.Windows.Forms.Button();
            this.btOutput = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tbBlankStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlankStructure = new Jalousie.Datasets.dsBlankStructure();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.edColumnField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.edFormatField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edFieldLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAlignmentId = new System.Windows.Forms.ComboBox();
            this.tbAligmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edFieldName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.Номер = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ячейкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.полеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.надписьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодТипаДанныхDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tbDataTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ширина = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDataTypesBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.TabIndex = 0;
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
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 127);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btCalcField);
            this.panel3.Controls.Add(this.btOutput);
            this.panel3.Controls.Add(this.btDelete);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btEdit);
            this.panel3.Controls.Add(this.btAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(710, 40);
            this.panel3.TabIndex = 1;
            // 
            // btCalcField
            // 
            this.btCalcField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCalcField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCalcField.Location = new System.Drawing.Point(348, 5);
            this.btCalcField.Name = "btCalcField";
            this.btCalcField.Size = new System.Drawing.Size(110, 30);
            this.btCalcField.TabIndex = 13;
            this.btCalcField.Text = "Значение";
            this.btCalcField.UseVisualStyleBackColor = true;
            this.btCalcField.Click += new System.EventHandler(this.btCalcField_Click);
            // 
            // btOutput
            // 
            this.btOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOutput.Location = new System.Drawing.Point(463, 5);
            this.btOutput.Name = "btOutput";
            this.btOutput.Size = new System.Drawing.Size(110, 30);
            this.btOutput.TabIndex = 12;
            this.btOutput.Text = "Вывод";
            this.btOutput.UseVisualStyleBackColor = true;
            this.btOutput.Click += new System.EventHandler(this.btOutput_Click);
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
            this.btCancel.Location = new System.Drawing.Point(594, 5);
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
            this.btAdd.Location = new System.Drawing.Point(5, 5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(110, 30);
            this.btAdd.TabIndex = 9;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
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
            this.groupBox2.Enabled = false;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 87);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительная информация";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tbBlankStructureBindingSource, "Невидим", true));
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox2.Location = new System.Drawing.Point(453, 39);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 43;
            this.checkBox2.Text = "Невидим";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tbBlankStructureBindingSource
            // 
            this.tbBlankStructureBindingSource.DataMember = "tbBlankStructure";
            this.tbBlankStructureBindingSource.DataSource = this.dsBlankStructure;
            this.tbBlankStructureBindingSource.Sort = "[Номер] ASC";
            // 
            // dsBlankStructure
            // 
            this.dsBlankStructure.DataSetName = "dsBlankStructure";
            this.dsBlankStructure.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tbBlankStructureBindingSource, "Только чтение", true));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(453, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Только чтение";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // edColumnField
            // 
            this.edColumnField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnField.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Ячейка", true));
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
            this.edFormatField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFormatField.Location = new System.Drawing.Point(566, 60);
            this.edFormatField.Name = "edFormatField";
            this.edFormatField.Size = new System.Drawing.Size(139, 20);
            this.edFormatField.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(453, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Формат вывода";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edFieldLabel
            // 
            this.edFieldLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Надпись", true));
            this.edFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldLabel.Location = new System.Drawing.Point(106, 38);
            this.edFieldLabel.Name = "edFieldLabel";
            this.edFieldLabel.Size = new System.Drawing.Size(342, 20);
            this.edFieldLabel.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
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
            this.cbAlignmentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAlignmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAlignmentId.FormattingEnabled = true;
            this.cbAlignmentId.Location = new System.Drawing.Point(106, 60);
            this.cbAlignmentId.MaxDropDownItems = 9;
            this.cbAlignmentId.Name = "cbAlignmentId";
            this.cbAlignmentId.Size = new System.Drawing.Size(342, 21);
            this.cbAlignmentId.TabIndex = 35;
            this.cbAlignmentId.ValueMember = "Код";
            // 
            // tbAligmentBindingSource
            // 
            this.tbAligmentBindingSource.DataMember = "tbAligment";
            this.tbAligmentBindingSource.DataSource = this.dsBlankStructure;
            // 
            // edFieldName
            // 
            this.edFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbBlankStructureBindingSource, "Поле", true));
            this.edFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldName.Location = new System.Drawing.Point(106, 15);
            this.edFieldName.Name = "edFieldName";
            this.edFieldName.Size = new System.Drawing.Size(342, 20);
            this.edFieldName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Название";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 37;
            this.label9.Text = "Выравнивание";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 414);
            this.panel2.TabIndex = 2;
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
            this.Номер,
            this.ячейкаDataGridViewTextBoxColumn,
            this.полеDataGridViewTextBoxColumn,
            this.надписьDataGridViewTextBoxColumn,
            this.кодТипаДанныхDataGridViewTextBoxColumn,
            this.Ширина});
            this.dbg.DataSource = this.tbBlankStructureBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(708, 412);
            this.dbg.TabIndex = 0;
            this.dbg.DoubleClick += new System.EventHandler(this.btEdit_Click);
            // 
            // Номер
            // 
            this.Номер.DataPropertyName = "Номер";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Номер.DefaultCellStyle = dataGridViewCellStyle2;
            this.Номер.HeaderText = "№";
            this.Номер.Name = "Номер";
            this.Номер.ReadOnly = true;
            this.Номер.Width = 60;
            // 
            // ячейкаDataGridViewTextBoxColumn
            // 
            this.ячейкаDataGridViewTextBoxColumn.DataPropertyName = "Ячейка";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ячейкаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ячейкаDataGridViewTextBoxColumn.HeaderText = "Столбец";
            this.ячейкаDataGridViewTextBoxColumn.Name = "ячейкаDataGridViewTextBoxColumn";
            this.ячейкаDataGridViewTextBoxColumn.ReadOnly = true;
            this.ячейкаDataGridViewTextBoxColumn.Width = 60;
            // 
            // полеDataGridViewTextBoxColumn
            // 
            this.полеDataGridViewTextBoxColumn.DataPropertyName = "Поле";
            this.полеDataGridViewTextBoxColumn.HeaderText = "Поле";
            this.полеDataGridViewTextBoxColumn.Name = "полеDataGridViewTextBoxColumn";
            this.полеDataGridViewTextBoxColumn.ReadOnly = true;
            this.полеDataGridViewTextBoxColumn.Width = 200;
            // 
            // надписьDataGridViewTextBoxColumn
            // 
            this.надписьDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.надписьDataGridViewTextBoxColumn.DataPropertyName = "Надпись";
            this.надписьDataGridViewTextBoxColumn.HeaderText = "Надпись";
            this.надписьDataGridViewTextBoxColumn.Name = "надписьDataGridViewTextBoxColumn";
            this.надписьDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // кодТипаДанныхDataGridViewTextBoxColumn
            // 
            this.кодТипаДанныхDataGridViewTextBoxColumn.DataPropertyName = "Код типа данных";
            this.кодТипаДанныхDataGridViewTextBoxColumn.DataSource = this.tbDataTypesBindingSource;
            this.кодТипаДанныхDataGridViewTextBoxColumn.DisplayMember = "Тип";
            this.кодТипаДанныхDataGridViewTextBoxColumn.HeaderText = "Тип данных";
            this.кодТипаДанныхDataGridViewTextBoxColumn.Name = "кодТипаДанныхDataGridViewTextBoxColumn";
            this.кодТипаДанныхDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодТипаДанныхDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.кодТипаДанныхDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.кодТипаДанныхDataGridViewTextBoxColumn.ValueMember = "Код";
            // 
            // tbDataTypesBindingSource
            // 
            this.tbDataTypesBindingSource.DataMember = "tbDataTypes";
            this.tbDataTypesBindingSource.DataSource = this.dsBlankStructure;
            // 
            // Ширина
            // 
            this.Ширина.DataPropertyName = "Ширина";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Ширина.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ширина.HeaderText = "Ширина";
            this.Ширина.Name = "Ширина";
            this.Ширина.ReadOnly = true;
            this.Ширина.Width = 80;
            // 
            // TfBlankStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 633);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfBlankStructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Структура бланка";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankStructureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDataTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dbg;
        private Jalousie.Datasets.dsBlankStructure dsBlankStructure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbBlankFirm;
        public System.Windows.Forms.Label lbBlankDescription;
        public System.Windows.Forms.Label lbBlankType;
        public System.Windows.Forms.Label lbBlankId;
        public System.Windows.Forms.CheckBox cbBlankActive;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.BindingSource tbDataTypesBindingSource;
        public System.Windows.Forms.BindingSource tbBlankStructureBindingSource;
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
        public System.Windows.Forms.BindingSource tbAligmentBindingSource;
        private System.Windows.Forms.Button btOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер;
        private System.Windows.Forms.DataGridViewTextBoxColumn ячейкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn полеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn надписьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn кодТипаДанныхDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ширина;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btCalcField;
    }
}