namespace Jalousie
{
    partial class TfEditBlankStructure
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.edWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.edColumnField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.edFormatField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edFieldLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAlignmentId = new System.Windows.Forms.ComboBox();
            this.tbAligmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlankStructure = new Jalousie.Datasets.dsBlankStructure();
            this.edFieldName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDictionaryContentId = new System.Windows.Forms.ComboBox();
            this.tbContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDictionary = new Jalousie.Datasets.dsDictionary();
            this.lbdValue = new System.Windows.Forms.Label();
            this.cbDictionaryId = new System.Windows.Forms.ComboBox();
            this.tbDictionaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbDictionary = new System.Windows.Forms.RadioButton();
            this.edText = new System.Windows.Forms.TextBox();
            this.lbtValue = new System.Windows.Forms.Label();
            this.edFloat = new System.Windows.Forms.NumericUpDown();
            this.lbfValue = new System.Windows.Forms.Label();
            this.edInteger = new System.Windows.Forms.NumericUpDown();
            this.lbiValue = new System.Windows.Forms.Label();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbFloat = new System.Windows.Forms.RadioButton();
            this.rbInteger = new System.Windows.Forms.RadioButton();
            this.edNumer = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.cbInvisible = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDictionaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edInteger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNumer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbInvisible);
            this.panel1.Controls.Add(this.cbReadOnly);
            this.panel1.Controls.Add(this.edNumer);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.edWidth);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.edColumnField);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbPreview);
            this.panel1.Controls.Add(this.edFormatField);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edFieldLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbAlignmentId);
            this.panel1.Controls.Add(this.edFieldName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 119);
            this.panel1.TabIndex = 0;
            // 
            // edWidth
            // 
            this.edWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edWidth.Location = new System.Drawing.Point(103, 71);
            this.edWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edWidth.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.edWidth.Name = "edWidth";
            this.edWidth.Size = new System.Drawing.Size(83, 20);
            this.edWidth.TabIndex = 32;
            this.edWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ширина";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edColumnField
            // 
            this.edColumnField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edColumnField.Location = new System.Drawing.Point(349, 71);
            this.edColumnField.Name = "edColumnField";
            this.edColumnField.Size = new System.Drawing.Size(109, 20);
            this.edColumnField.TabIndex = 4;
            this.edColumnField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(190, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "Столбец в бланке";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPreview
            // 
            this.cbPreview.AutoSize = true;
            this.cbPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPreview.Location = new System.Drawing.Point(464, 74);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(137, 17);
            this.cbPreview.TabIndex = 3;
            this.cbPreview.Text = "Быстрый просмотр";
            this.cbPreview.UseVisualStyleBackColor = true;
            // 
            // edFormatField
            // 
            this.edFormatField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFormatField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFormatField.Location = new System.Drawing.Point(462, 49);
            this.edFormatField.Name = "edFormatField";
            this.edFormatField.Size = new System.Drawing.Size(138, 20);
            this.edFormatField.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(349, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Формат вывода";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edFieldLabel
            // 
            this.edFieldLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldLabel.Location = new System.Drawing.Point(103, 26);
            this.edFieldLabel.Name = "edFieldLabel";
            this.edFieldLabel.Size = new System.Drawing.Size(497, 20);
            this.edFieldLabel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Надпись";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAlignmentId
            // 
            this.cbAlignmentId.DataSource = this.tbAligmentBindingSource;
            this.cbAlignmentId.DisplayMember = "Выравнивание";
            this.cbAlignmentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlignmentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAlignmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAlignmentId.FormattingEnabled = true;
            this.cbAlignmentId.Location = new System.Drawing.Point(103, 48);
            this.cbAlignmentId.MaxDropDownItems = 10;
            this.cbAlignmentId.Name = "cbAlignmentId";
            this.cbAlignmentId.Size = new System.Drawing.Size(242, 21);
            this.cbAlignmentId.TabIndex = 5;
            this.cbAlignmentId.ValueMember = "Код";
            // 
            // tbAligmentBindingSource
            // 
            this.tbAligmentBindingSource.DataMember = "tbAligment";
            this.tbAligmentBindingSource.DataSource = this.dsBlankStructure;
            // 
            // dsBlankStructure
            // 
            this.dsBlankStructure.DataSetName = "dsBlankStructure";
            this.dsBlankStructure.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // edFieldName
            // 
            this.edFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edFieldName.Location = new System.Drawing.Point(103, 3);
            this.edFieldName.Name = "edFieldName";
            this.edFieldName.Size = new System.Drawing.Size(497, 20);
            this.edFieldName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Название";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Выравнивание";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btOk);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 344);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(606, 37);
            this.panel3.TabIndex = 20;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(442, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(159, 28);
            this.btOk.TabIndex = 19;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(280, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 20;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 225);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDictionaryContentId);
            this.groupBox1.Controls.Add(this.lbdValue);
            this.groupBox1.Controls.Add(this.cbDictionaryId);
            this.groupBox1.Controls.Add(this.rbDictionary);
            this.groupBox1.Controls.Add(this.edText);
            this.groupBox1.Controls.Add(this.lbtValue);
            this.groupBox1.Controls.Add(this.edFloat);
            this.groupBox1.Controls.Add(this.lbfValue);
            this.groupBox1.Controls.Add(this.edInteger);
            this.groupBox1.Controls.Add(this.lbiValue);
            this.groupBox1.Controls.Add(this.rbText);
            this.groupBox1.Controls.Add(this.rbFloat);
            this.groupBox1.Controls.Add(this.rbInteger);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 225);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип данных";
            // 
            // cbDictionaryContentId
            // 
            this.cbDictionaryContentId.DataSource = this.tbContentBindingSource;
            this.cbDictionaryContentId.DisplayMember = "Текстовое";
            this.cbDictionaryContentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDictionaryContentId.Enabled = false;
            this.cbDictionaryContentId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDictionaryContentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDictionaryContentId.FormattingEnabled = true;
            this.cbDictionaryContentId.Location = new System.Drawing.Point(263, 193);
            this.cbDictionaryContentId.MaxDropDownItems = 9;
            this.cbDictionaryContentId.Name = "cbDictionaryContentId";
            this.cbDictionaryContentId.Size = new System.Drawing.Size(338, 21);
            this.cbDictionaryContentId.TabIndex = 25;
            this.cbDictionaryContentId.ValueMember = "Код";
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
            // lbdValue
            // 
            this.lbdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbdValue.Enabled = false;
            this.lbdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbdValue.Location = new System.Drawing.Point(106, 194);
            this.lbdValue.Name = "lbdValue";
            this.lbdValue.Size = new System.Drawing.Size(153, 20);
            this.lbdValue.TabIndex = 24;
            this.lbdValue.Text = "Значение по умолчанию";
            this.lbdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDictionaryId
            // 
            this.cbDictionaryId.DataSource = this.tbDictionaryBindingSource;
            this.cbDictionaryId.DisplayMember = "Название";
            this.cbDictionaryId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDictionaryId.Enabled = false;
            this.cbDictionaryId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDictionaryId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDictionaryId.FormattingEnabled = true;
            this.cbDictionaryId.Location = new System.Drawing.Point(106, 166);
            this.cbDictionaryId.MaxDropDownItems = 9;
            this.cbDictionaryId.Name = "cbDictionaryId";
            this.cbDictionaryId.Size = new System.Drawing.Size(495, 21);
            this.cbDictionaryId.TabIndex = 23;
            this.cbDictionaryId.ValueMember = "Код";
            // 
            // tbDictionaryBindingSource
            // 
            this.tbDictionaryBindingSource.DataMember = "tbDictionary";
            this.tbDictionaryBindingSource.DataSource = this.dsDictionary;
            this.tbDictionaryBindingSource.CurrentChanged += new System.EventHandler(this.tbDictionaryBindingSource_CurrentChanged);
            // 
            // rbDictionary
            // 
            this.rbDictionary.AutoSize = true;
            this.rbDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDictionary.Location = new System.Drawing.Point(44, 143);
            this.rbDictionary.Name = "rbDictionary";
            this.rbDictionary.Size = new System.Drawing.Size(84, 17);
            this.rbDictionary.TabIndex = 22;
            this.rbDictionary.Text = "Справочник";
            this.rbDictionary.UseVisualStyleBackColor = true;
            this.rbDictionary.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // edText
            // 
            this.edText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edText.Enabled = false;
            this.edText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edText.Location = new System.Drawing.Point(263, 120);
            this.edText.Name = "edText";
            this.edText.Size = new System.Drawing.Size(338, 20);
            this.edText.TabIndex = 21;
            // 
            // lbtValue
            // 
            this.lbtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtValue.Enabled = false;
            this.lbtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbtValue.Location = new System.Drawing.Point(106, 120);
            this.lbtValue.Name = "lbtValue";
            this.lbtValue.Size = new System.Drawing.Size(153, 20);
            this.lbtValue.TabIndex = 20;
            this.lbtValue.Text = "Значение по умолчанию";
            this.lbtValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edFloat
            // 
            this.edFloat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFloat.DecimalPlaces = 2;
            this.edFloat.Enabled = false;
            this.edFloat.Location = new System.Drawing.Point(263, 78);
            this.edFloat.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edFloat.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.edFloat.Name = "edFloat";
            this.edFloat.Size = new System.Drawing.Size(83, 20);
            this.edFloat.TabIndex = 19;
            this.edFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbfValue
            // 
            this.lbfValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbfValue.Enabled = false;
            this.lbfValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbfValue.Location = new System.Drawing.Point(106, 78);
            this.lbfValue.Name = "lbfValue";
            this.lbfValue.Size = new System.Drawing.Size(153, 20);
            this.lbfValue.TabIndex = 18;
            this.lbfValue.Text = "Значение по умолчанию";
            this.lbfValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edInteger
            // 
            this.edInteger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edInteger.Location = new System.Drawing.Point(263, 36);
            this.edInteger.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edInteger.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.edInteger.Name = "edInteger";
            this.edInteger.Size = new System.Drawing.Size(83, 20);
            this.edInteger.TabIndex = 17;
            this.edInteger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbiValue
            // 
            this.lbiValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbiValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbiValue.Location = new System.Drawing.Point(106, 36);
            this.lbiValue.Name = "lbiValue";
            this.lbiValue.Size = new System.Drawing.Size(153, 20);
            this.lbiValue.TabIndex = 16;
            this.lbiValue.Text = "Значение по умолчанию";
            this.lbiValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbText.Location = new System.Drawing.Point(44, 101);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(78, 17);
            this.rbText.TabIndex = 15;
            this.rbText.Text = "Текстовое";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // rbFloat
            // 
            this.rbFloat.AutoSize = true;
            this.rbFloat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbFloat.Location = new System.Drawing.Point(44, 59);
            this.rbFloat.Name = "rbFloat";
            this.rbFloat.Size = new System.Drawing.Size(69, 17);
            this.rbFloat.TabIndex = 14;
            this.rbFloat.Text = "Дробное";
            this.rbFloat.UseVisualStyleBackColor = true;
            this.rbFloat.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // rbInteger
            // 
            this.rbInteger.AutoSize = true;
            this.rbInteger.Checked = true;
            this.rbInteger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbInteger.Location = new System.Drawing.Point(44, 19);
            this.rbInteger.Name = "rbInteger";
            this.rbInteger.Size = new System.Drawing.Size(56, 17);
            this.rbInteger.TabIndex = 13;
            this.rbInteger.TabStop = true;
            this.rbInteger.Text = "Целое";
            this.rbInteger.UseVisualStyleBackColor = true;
            this.rbInteger.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // edNumer
            // 
            this.edNumer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edNumer.Location = new System.Drawing.Point(103, 93);
            this.edNumer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edNumer.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.edNumer.Name = "edNumer";
            this.edNumer.Size = new System.Drawing.Size(83, 20);
            this.edNumer.TabIndex = 34;
            this.edNumer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Номер";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbReadOnly
            // 
            this.cbReadOnly.AutoSize = true;
            this.cbReadOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbReadOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbReadOnly.Location = new System.Drawing.Point(191, 94);
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.Size = new System.Drawing.Size(110, 17);
            this.cbReadOnly.TabIndex = 35;
            this.cbReadOnly.Text = "Только чтение";
            this.cbReadOnly.UseVisualStyleBackColor = true;
            // 
            // cbInvisible
            // 
            this.cbInvisible.AutoSize = true;
            this.cbInvisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbInvisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbInvisible.Location = new System.Drawing.Point(307, 94);
            this.cbInvisible.Name = "cbInvisible";
            this.cbInvisible.Size = new System.Drawing.Size(76, 17);
            this.cbInvisible.TabIndex = 36;
            this.cbInvisible.Text = "Невидим";
            this.cbInvisible.UseVisualStyleBackColor = true;
            // 
            // TfEditBlankStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 381);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfEditBlankStructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAligmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlankStructure)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDictionaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edInteger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNumer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.TextBox edFormatField;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edFieldLabel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbAlignmentId;
        public System.Windows.Forms.TextBox edFieldName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox cbPreview;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox edColumnField;
        private Jalousie.Datasets.dsBlankStructure dsBlankStructure;
        public System.Windows.Forms.BindingSource tbAligmentBindingSource;
        public System.Windows.Forms.ComboBox cbDictionaryContentId;
        private System.Windows.Forms.Label lbdValue;
        public System.Windows.Forms.ComboBox cbDictionaryId;
        public System.Windows.Forms.RadioButton rbDictionary;
        public System.Windows.Forms.TextBox edText;
        private System.Windows.Forms.Label lbtValue;
        public System.Windows.Forms.NumericUpDown edFloat;
        private System.Windows.Forms.Label lbfValue;
        public System.Windows.Forms.NumericUpDown edInteger;
        private System.Windows.Forms.Label lbiValue;
        public System.Windows.Forms.RadioButton rbText;
        public System.Windows.Forms.RadioButton rbFloat;
        public System.Windows.Forms.RadioButton rbInteger;
        public System.Windows.Forms.BindingSource tbDictionaryBindingSource;
        private Jalousie.Datasets.dsDictionary dsDictionary;
        public System.Windows.Forms.BindingSource tbContentBindingSource;
        public System.Windows.Forms.NumericUpDown edWidth;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox cbInvisible;
        public System.Windows.Forms.CheckBox cbReadOnly;
        public System.Windows.Forms.NumericUpDown edNumer;
        private System.Windows.Forms.Label label7;
    }
}