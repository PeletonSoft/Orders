namespace Clients
{
    partial class TfEditClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfEditClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBuisiness = new System.Windows.Forms.RadioButton();
            this.cbPerson = new System.Windows.Forms.RadioButton();
            this.lbName = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbEmpty = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edEmail = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.stTelephone = new System.Windows.Forms.Label();
            this.pcWrong = new System.Windows.Forms.PictureBox();
            this.pcCheck = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.edTelephone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edTelephoneDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edTelephoneFace = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Face = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appendix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb = new System.Windows.Forms.ToolStrip();
            this.btItemPlus = new System.Windows.Forms.ToolStripButton();
            this.btItemMinus = new System.Windows.Forms.ToolStripButton();
            this.separate = new System.Windows.Forms.ToolStripSeparator();
            this.btItemSave = new System.Windows.Forms.ToolStripButton();
            this.btItemCancel = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcWrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCheck)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            this.tb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbBuisiness);
            this.panel1.Controls.Add(this.cbPerson);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 26);
            this.panel1.TabIndex = 4;
            // 
            // cbBuisiness
            // 
            this.cbBuisiness.AutoSize = true;
            this.cbBuisiness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBuisiness.Location = new System.Drawing.Point(125, 4);
            this.cbBuisiness.Name = "cbBuisiness";
            this.cbBuisiness.Size = new System.Drawing.Size(119, 17);
            this.cbBuisiness.TabIndex = 1;
            this.cbBuisiness.Text = "Юридическое лицо";
            this.cbBuisiness.UseVisualStyleBackColor = true;
            this.cbBuisiness.CheckedChanged += new System.EventHandler(this.cbBuisiness_CheckedChanged);
            this.cbBuisiness.Click += new System.EventHandler(this.propertyForm_Click);
            // 
            // cbPerson
            // 
            this.cbPerson.AutoSize = true;
            this.cbPerson.Checked = true;
            this.cbPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPerson.Location = new System.Drawing.Point(4, 4);
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(115, 17);
            this.cbPerson.TabIndex = 0;
            this.cbPerson.TabStop = true;
            this.cbPerson.Text = "Физическое лицо";
            this.cbPerson.UseVisualStyleBackColor = true;
            this.cbPerson.CheckedChanged += new System.EventHandler(this.cbPerson_CheckedChanged);
            this.cbPerson.Click += new System.EventHandler(this.propertyForm_Click);
            // 
            // lbName
            // 
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(0, 26);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(625, 21);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "[Фамилия] + [Инициалы]";
            // 
            // edName
            // 
            this.edName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edName.Dock = System.Windows.Forms.DockStyle.Top;
            this.edName.Location = new System.Drawing.Point(0, 47);
            this.edName.Multiline = true;
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(625, 39);
            this.edName.TabIndex = 0;
            this.edName.TextChanged += new System.EventHandler(this.edName_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbEmpty);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 44);
            this.panel2.TabIndex = 3;
            // 
            // cbEmpty
            // 
            this.cbEmpty.AutoSize = true;
            this.cbEmpty.ForeColor = System.Drawing.Color.Red;
            this.cbEmpty.Location = new System.Drawing.Point(4, 6);
            this.cbEmpty.Name = "cbEmpty";
            this.cbEmpty.Size = new System.Drawing.Size(198, 30);
            this.cbEmpty.TabIndex = 2;
            this.cbEmpty.Text = "Подтверждаю, что данный клиент\r\nне предоставил номер телефона";
            this.cbEmpty.UseVisualStyleBackColor = true;
            this.cbEmpty.CheckedChanged += new System.EventHandler(this.cbEmpty_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(376, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(121, 35);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(500, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(121, 35);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.edDescription);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.edEmail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 188);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(625, 49);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дополнительно";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edDescription
            // 
            this.edDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edDescription.Location = new System.Drawing.Point(117, 24);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(504, 20);
            this.edDescription.TabIndex = 1;
            this.edDescription.TextChanged += new System.EventHandler(this.edDescription_TextChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-mail";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edEmail
            // 
            this.edEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edEmail.Location = new System.Drawing.Point(117, 2);
            this.edEmail.Name = "edEmail";
            this.edEmail.Size = new System.Drawing.Size(504, 20);
            this.edEmail.TabIndex = 0;
            this.edEmail.TextChanged += new System.EventHandler(this.edEmail_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.btAdd);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.edTelephone);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.edTelephoneDescription);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.edTelephoneFace);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(625, 115);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.stTelephone);
            this.panel5.Controls.Add(this.pcWrong);
            this.panel5.Controls.Add(this.pcCheck);
            this.panel5.Location = new System.Drawing.Point(3, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(618, 40);
            this.panel5.TabIndex = 11;
            // 
            // stTelephone
            // 
            this.stTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stTelephone.Location = new System.Drawing.Point(0, 0);
            this.stTelephone.Name = "stTelephone";
            this.stTelephone.Size = new System.Drawing.Size(532, 40);
            this.stTelephone.TabIndex = 0;
            this.stTelephone.Text = "(4822) 42-51-52 доб. 1241";
            this.stTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcWrong
            // 
            this.pcWrong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcWrong.Image = ((System.Drawing.Image)(resources.GetObject("pcWrong.Image")));
            this.pcWrong.InitialImage = null;
            this.pcWrong.Location = new System.Drawing.Point(532, 0);
            this.pcWrong.Name = "pcWrong";
            this.pcWrong.Size = new System.Drawing.Size(43, 40);
            this.pcWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcWrong.TabIndex = 2;
            this.pcWrong.TabStop = false;
            // 
            // pcCheck
            // 
            this.pcCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcCheck.Image = ((System.Drawing.Image)(resources.GetObject("pcCheck.Image")));
            this.pcCheck.InitialImage = null;
            this.pcCheck.Location = new System.Drawing.Point(575, 0);
            this.pcCheck.Name = "pcCheck";
            this.pcCheck.Size = new System.Drawing.Size(43, 40);
            this.pcCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcCheck.TabIndex = 1;
            this.pcCheck.TabStop = false;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.Location = new System.Drawing.Point(500, 2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(121, 22);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Еще телефон...";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btItemPlus_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(2, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Телефон";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edTelephone
            // 
            this.edTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edTelephone.Location = new System.Drawing.Point(118, 3);
            this.edTelephone.Name = "edTelephone";
            this.edTelephone.Size = new System.Drawing.Size(379, 20);
            this.edTelephone.TabIndex = 0;
            this.edTelephone.TextChanged += new System.EventHandler(this.edTelephone_TextChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Примечание";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edTelephoneDescription
            // 
            this.edTelephoneDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edTelephoneDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edTelephoneDescription.Location = new System.Drawing.Point(118, 91);
            this.edTelephoneDescription.Name = "edTelephoneDescription";
            this.edTelephoneDescription.Size = new System.Drawing.Size(504, 20);
            this.edTelephoneDescription.TabIndex = 3;
            this.edTelephoneDescription.TextChanged += new System.EventHandler(this.edTelephoneDescription_TextChanged);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(2, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Контактное лицо";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edTelephoneFace
            // 
            this.edTelephoneFace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edTelephoneFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edTelephoneFace.Location = new System.Drawing.Point(118, 69);
            this.edTelephoneFace.Name = "edTelephoneFace";
            this.edTelephoneFace.Size = new System.Drawing.Size(504, 20);
            this.edTelephoneFace.TabIndex = 2;
            this.edTelephoneFace.TextChanged += new System.EventHandler(this.edTelephoneFace_TextChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dbg);
            this.panel6.Controls.Add(this.tb);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 86);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(625, 0);
            this.panel6.TabIndex = 5;
            // 
            // dbg
            // 
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dbg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Telephone,
            this.Face,
            this.Appendix});
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 25);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(625, 0);
            this.dbg.TabIndex = 1;
            this.dbg.SelectionChanged += new System.EventHandler(this.dbg_SelectionChanged);
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            this.Telephone.HeaderText = "Телефон";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            this.Telephone.Width = 150;
            // 
            // Face
            // 
            this.Face.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Face.DataPropertyName = "Face";
            this.Face.HeaderText = "Контактное лицо";
            this.Face.Name = "Face";
            this.Face.ReadOnly = true;
            // 
            // Appendix
            // 
            this.Appendix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Appendix.DataPropertyName = "Appendix";
            this.Appendix.HeaderText = "Примечание";
            this.Appendix.Name = "Appendix";
            this.Appendix.ReadOnly = true;
            // 
            // tb
            // 
            this.tb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btItemPlus,
            this.btItemMinus,
            this.separate,
            this.btItemSave,
            this.btItemCancel});
            this.tb.Location = new System.Drawing.Point(0, 0);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(625, 25);
            this.tb.TabIndex = 0;
            this.tb.Text = "toolStrip1";
            // 
            // btItemPlus
            // 
            this.btItemPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btItemPlus.Image = ((System.Drawing.Image)(resources.GetObject("btItemPlus.Image")));
            this.btItemPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btItemPlus.Name = "btItemPlus";
            this.btItemPlus.Size = new System.Drawing.Size(23, 22);
            this.btItemPlus.ToolTipText = "Добавить";
            this.btItemPlus.Click += new System.EventHandler(this.btItemPlus_Click);
            // 
            // btItemMinus
            // 
            this.btItemMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btItemMinus.Image = ((System.Drawing.Image)(resources.GetObject("btItemMinus.Image")));
            this.btItemMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btItemMinus.Name = "btItemMinus";
            this.btItemMinus.Size = new System.Drawing.Size(23, 22);
            this.btItemMinus.ToolTipText = "Удалить";
            this.btItemMinus.Click += new System.EventHandler(this.btItemMinus_Click);
            // 
            // separate
            // 
            this.separate.Name = "separate";
            this.separate.Size = new System.Drawing.Size(6, 25);
            // 
            // btItemSave
            // 
            this.btItemSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btItemSave.Image = ((System.Drawing.Image)(resources.GetObject("btItemSave.Image")));
            this.btItemSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btItemSave.Name = "btItemSave";
            this.btItemSave.Size = new System.Drawing.Size(23, 22);
            this.btItemSave.ToolTipText = "Сохранить";
            this.btItemSave.Click += new System.EventHandler(this.btItemSave_Click);
            // 
            // btItemCancel
            // 
            this.btItemCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btItemCancel.Image = ((System.Drawing.Image)(resources.GetObject("btItemCancel.Image")));
            this.btItemCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btItemCancel.Name = "btItemCancel";
            this.btItemCancel.Size = new System.Drawing.Size(23, 22);
            this.btItemCancel.ToolTipText = "Отменить";
            this.btItemCancel.Click += new System.EventHandler(this.btItemCancel_Click);
            // 
            // TfEditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 281);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 320);
            this.Name = "TfEditClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Shown += new System.EventHandler(this.TfEditClient_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcWrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCheck)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            this.tb.ResumeLayout(false);
            this.tb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton cbBuisiness;
        private System.Windows.Forms.RadioButton cbPerson;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edEmail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edTelephone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edTelephoneDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edTelephoneFace;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label stTelephone;
        private System.Windows.Forms.PictureBox pcWrong;
        private System.Windows.Forms.PictureBox pcCheck;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dbg;
        private System.Windows.Forms.ToolStrip tb;
        private System.Windows.Forms.ToolStripButton btItemPlus;
        private System.Windows.Forms.ToolStripButton btItemMinus;
        private System.Windows.Forms.ToolStripSeparator separate;
        private System.Windows.Forms.ToolStripButton btItemSave;
        private System.Windows.Forms.ToolStripButton btItemCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Face;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appendix;
        private System.Windows.Forms.CheckBox cbEmpty;
    }
}