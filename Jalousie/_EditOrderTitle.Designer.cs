namespace Jalousie
{
    partial class TfEditOrderTitle
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
            this.lbBlankFirm = new System.Windows.Forms.Label();
            this.cbCashless = new System.Windows.Forms.CheckBox();
            this.cbWhole = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbExpress = new System.Windows.Forms.CheckBox();
            this.btInstallDate = new System.Windows.Forms.Button();
            this.cbIsOrdered = new System.Windows.Forms.CheckBox();
            this.cbMounterId = new System.Windows.Forms.ComboBox();
            this.tbMountersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOrders = new Jalousie.Datasets.dsOrders();
            this.label12 = new System.Windows.Forms.Label();
            this.edDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.lbCode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.edAddInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUserId = new System.Windows.Forms.ComboBox();
            this.tbUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btClient = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbClientTel = new System.Windows.Forms.Label();
            this.lbClientName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBlankDescription = new System.Windows.Forms.Label();
            this.lbBlankId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbBlankType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMountersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsersBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBlankFirm
            // 
            this.lbBlankFirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankFirm.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankFirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankFirm.Location = new System.Drawing.Point(308, 16);
            this.lbBlankFirm.Name = "lbBlankFirm";
            this.lbBlankFirm.Size = new System.Drawing.Size(345, 21);
            this.lbBlankFirm.TabIndex = 15;
            this.lbBlankFirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCashless
            // 
            this.cbCashless.AutoSize = true;
            this.cbCashless.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCashless.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCashless.Location = new System.Drawing.Point(232, 66);
            this.cbCashless.Name = "cbCashless";
            this.cbCashless.Size = new System.Drawing.Size(66, 17);
            this.cbCashless.TabIndex = 49;
            this.cbCashless.Text = "Безнал";
            this.cbCashless.UseVisualStyleBackColor = true;
            // 
            // cbWhole
            // 
            this.cbWhole.AutoSize = true;
            this.cbWhole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWhole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbWhole.Location = new System.Drawing.Point(308, 66);
            this.cbWhole.Name = "cbWhole";
            this.cbWhole.Size = new System.Drawing.Size(92, 17);
            this.cbWhole.TabIndex = 48;
            this.cbWhole.Text = "Мелкий опт";
            this.cbWhole.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbExpress);
            this.groupBox2.Controls.Add(this.btInstallDate);
            this.groupBox2.Controls.Add(this.cbIsOrdered);
            this.groupBox2.Controls.Add(this.cbMounterId);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.edDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbCode);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbCashless);
            this.groupBox2.Controls.Add(this.cbWhole);
            this.groupBox2.Controls.Add(this.edAddInfo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbUserId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 137);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о заказе";
            // 
            // cbExpress
            // 
            this.cbExpress.AutoSize = true;
            this.cbExpress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbExpress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbExpress.Location = new System.Drawing.Point(408, 66);
            this.cbExpress.Name = "cbExpress";
            this.cbExpress.Size = new System.Drawing.Size(113, 17);
            this.cbExpress.TabIndex = 58;
            this.cbExpress.Text = "Срочный заказ";
            this.cbExpress.UseVisualStyleBackColor = true;
            // 
            // btInstallDate
            // 
            this.btInstallDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInstallDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btInstallDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btInstallDate.Location = new System.Drawing.Point(530, 38);
            this.btInstallDate.Name = "btInstallDate";
            this.btInstallDate.Size = new System.Drawing.Size(123, 25);
            this.btInstallDate.TabIndex = 57;
            this.btInstallDate.Text = "<не указана>";
            this.btInstallDate.UseVisualStyleBackColor = true;
            this.btInstallDate.Click += new System.EventHandler(this.lbInstallDate_Click);
            // 
            // cbIsOrdered
            // 
            this.cbIsOrdered.AutoSize = true;
            this.cbIsOrdered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIsOrdered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIsOrdered.Location = new System.Drawing.Point(530, 66);
            this.cbIsOrdered.Name = "cbIsOrdered";
            this.cbIsOrdered.Size = new System.Drawing.Size(118, 17);
            this.cbIsOrdered.TabIndex = 56;
            this.cbIsOrdered.Text = "Заказная ткань";
            this.cbIsOrdered.UseVisualStyleBackColor = true;
            this.cbIsOrdered.CheckedChanged += new System.EventHandler(this.cbIsOrdered_CheckedChanged);
            // 
            // cbMounterId
            // 
            this.cbMounterId.DataSource = this.tbMountersBindingSource;
            this.cbMounterId.DisplayMember = "ФИО";
            this.cbMounterId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMounterId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbMounterId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMounterId.FormattingEnabled = true;
            this.cbMounterId.Location = new System.Drawing.Point(125, 38);
            this.cbMounterId.MaxDropDownItems = 9;
            this.cbMounterId.Name = "cbMounterId";
            this.cbMounterId.Size = new System.Drawing.Size(277, 21);
            this.cbMounterId.TabIndex = 54;
            this.cbMounterId.ValueMember = "Код";
            // 
            // tbMountersBindingSource
            // 
            this.tbMountersBindingSource.DataMember = "tbUsers";
            this.tbMountersBindingSource.DataSource = this.dsOrders;
            // 
            // dsOrders
            // 
            this.dsOrders.DataSetName = "dsOrders";
            this.dsOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(7, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 18);
            this.label12.TabIndex = 55;
            this.label12.Text = "Установщик";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edDate
            // 
            this.edDate.Enabled = false;
            this.edDate.Location = new System.Drawing.Point(530, 13);
            this.edDate.Name = "edDate";
            this.edDate.Size = new System.Drawing.Size(123, 20);
            this.edDate.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(408, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 21);
            this.label11.TabIndex = 52;
            this.label11.Text = "Дата";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCode
            // 
            this.lbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCode.Location = new System.Drawing.Point(125, 65);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(101, 18);
            this.lbCode.TabIndex = 51;
            this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(7, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 18);
            this.label10.TabIndex = 50;
            this.label10.Text = "Номер заказа";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edAddInfo
            // 
            this.edAddInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edAddInfo.Location = new System.Drawing.Point(125, 88);
            this.edAddInfo.Multiline = true;
            this.edAddInfo.Name = "edAddInfo";
            this.edAddInfo.Size = new System.Drawing.Size(528, 44);
            this.edAddInfo.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 44);
            this.label5.TabIndex = 42;
            this.label5.Text = "Дополнительно";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(408, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "Дата готовности";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbUserId
            // 
            this.cbUserId.DataSource = this.tbUsersBindingSource;
            this.cbUserId.DisplayMember = "ФИО";
            this.cbUserId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserId.Enabled = false;
            this.cbUserId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUserId.FormattingEnabled = true;
            this.cbUserId.Location = new System.Drawing.Point(125, 13);
            this.cbUserId.MaxDropDownItems = 9;
            this.cbUserId.Name = "cbUserId";
            this.cbUserId.Size = new System.Drawing.Size(277, 21);
            this.cbUserId.TabIndex = 38;
            this.cbUserId.ValueMember = "Код";
            // 
            // tbUsersBindingSource
            // 
            this.tbUsersBindingSource.DataMember = "tbUsers";
            this.tbUsersBindingSource.DataSource = this.dsOrders;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(7, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Заказ принял";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btClient
            // 
            this.btClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btClient.Location = new System.Drawing.Point(494, 16);
            this.btClient.Name = "btClient";
            this.btClient.Size = new System.Drawing.Size(159, 46);
            this.btClient.TabIndex = 21;
            this.btClient.Text = "Выбрать покупателя";
            this.btClient.UseVisualStyleBackColor = true;
            this.btClient.Click += new System.EventHandler(this.btClient_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btClient);
            this.groupBox3.Controls.Add(this.lbClientTel);
            this.groupBox3.Controls.Add(this.lbClientName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(0, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 68);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информацмя о покупателе";
            // 
            // lbClientTel
            // 
            this.lbClientTel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClientTel.BackColor = System.Drawing.SystemColors.Window;
            this.lbClientTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbClientTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbClientTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbClientTel.Location = new System.Drawing.Point(125, 41);
            this.lbClientTel.Name = "lbClientTel";
            this.lbClientTel.Size = new System.Drawing.Size(366, 21);
            this.lbClientTel.TabIndex = 15;
            this.lbClientTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbClientName
            // 
            this.lbClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClientName.BackColor = System.Drawing.SystemColors.Window;
            this.lbClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbClientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbClientName.Location = new System.Drawing.Point(125, 16);
            this.lbClientName.Name = "lbClientName";
            this.lbClientName.Size = new System.Drawing.Size(366, 21);
            this.lbClientName.TabIndex = 14;
            this.lbClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(7, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Телефон";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "ФИО";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(230, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 14;
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
            this.lbBlankDescription.Location = new System.Drawing.Point(125, 66);
            this.lbBlankDescription.Name = "lbBlankDescription";
            this.lbBlankDescription.Size = new System.Drawing.Size(528, 21);
            this.lbBlankDescription.TabIndex = 13;
            this.lbBlankDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBlankId
            // 
            this.lbBlankId.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankId.Location = new System.Drawing.Point(125, 16);
            this.lbBlankId.Name = "lbBlankId";
            this.lbBlankId.Size = new System.Drawing.Size(101, 21);
            this.lbBlankId.TabIndex = 11;
            this.lbBlankId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 205);
            this.panel1.TabIndex = 25;
            // 
            // lbBlankType
            // 
            this.lbBlankType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlankType.BackColor = System.Drawing.SystemColors.Window;
            this.lbBlankType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBlankType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBlankType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlankType.Location = new System.Drawing.Point(125, 41);
            this.lbBlankType.Name = "lbBlankType";
            this.lbBlankType.Size = new System.Drawing.Size(528, 21);
            this.lbBlankType.TabIndex = 12;
            this.lbBlankType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Описание";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbBlankFirm);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbBlankDescription);
            this.groupBox1.Controls.Add(this.lbBlankType);
            this.groupBox1.Controls.Add(this.lbBlankId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 93);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Бланк заказа";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип жалюзей";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Номер бланка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btOk);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(659, 37);
            this.panel3.TabIndex = 24;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(493, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(159, 28);
            this.btOk.TabIndex = 19;
            this.btOk.Text = "Редактировать";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(331, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 20;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // TfEditOrderTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 335);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfEditOrderTitle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование заголовка заказа";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMountersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsersBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbBlankFirm;
        public System.Windows.Forms.CheckBox cbCashless;
        public System.Windows.Forms.CheckBox cbWhole;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox edAddInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbUserId;
        public System.Windows.Forms.BindingSource tbUsersBindingSource;
        private Jalousie.Datasets.dsOrders dsOrders;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btClient;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lbClientTel;
        public System.Windows.Forms.Label lbClientName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbBlankDescription;
        public System.Windows.Forms.Label lbBlankId;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbBlankType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lbCode;
        public System.Windows.Forms.DateTimePicker edDate;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cbMounterId;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.BindingSource tbMountersBindingSource;
        public System.Windows.Forms.CheckBox cbIsOrdered;
        public System.Windows.Forms.Button btInstallDate;
        public System.Windows.Forms.CheckBox cbExpress;
    }
}