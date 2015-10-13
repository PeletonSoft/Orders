using Jalousie.Datasets;
namespace Jalousie
{
    partial class TfEditBlanksList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTypeId = new System.Windows.Forms.ComboBox();
            this.tbTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlanks = new Jalousie.Datasets.dsBlanks();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.edBlankId = new System.Windows.Forms.NumericUpDown();
            this.cbFirmId = new System.Windows.Forms.ComboBox();
            this.tbFirmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edCellEssential = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edCellAppendInfo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edCellShopName = new System.Windows.Forms.TextBox();
            this.edCellShopTel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edColumnDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edRowPositionsMaximum = new System.Windows.Forms.NumericUpDown();
            this.edRowFirstPosition = new System.Windows.Forms.NumericUpDown();
            this.edColumnPrice = new System.Windows.Forms.TextBox();
            this.edColumnQuant = new System.Windows.Forms.TextBox();
            this.edCellMountingPeriod = new System.Windows.Forms.TextBox();
            this.edCellClientTel = new System.Windows.Forms.TextBox();
            this.edCellMounter = new System.Windows.Forms.TextBox();
            this.edCellOrderSum = new System.Windows.Forms.TextBox();
            this.edCellClientName = new System.Windows.Forms.TextBox();
            this.edCellOrderId = new System.Windows.Forms.TextBox();
            this.edCellOrderPrepayment = new System.Windows.Forms.TextBox();
            this.edCellDate = new System.Windows.Forms.TextBox();
            this.edCellDraftBlank = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBlankId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFirmsBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRowPositionsMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRowFirstPosition)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTypeId);
            this.groupBox1.Controls.Add(this.edDescription);
            this.groupBox1.Controls.Add(this.edBlankId);
            this.groupBox1.Controls.Add(this.cbFirmId);
            this.groupBox1.Controls.Add(this.cbActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общая информация";
            // 
            // cbTypeId
            // 
            this.cbTypeId.DataSource = this.tbTypesBindingSource;
            this.cbTypeId.DisplayMember = "Название";
            this.cbTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTypeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTypeId.FormattingEnabled = true;
            this.cbTypeId.Location = new System.Drawing.Point(96, 36);
            this.cbTypeId.Name = "cbTypeId";
            this.cbTypeId.Size = new System.Drawing.Size(411, 21);
            this.cbTypeId.TabIndex = 2;
            this.cbTypeId.ValueMember = "Код";
            // 
            // tbTypesBindingSource
            // 
            this.tbTypesBindingSource.DataMember = "tbTypes";
            this.tbTypesBindingSource.DataSource = this.dsBlanks;
            // 
            // dsBlanks
            // 
            this.dsBlanks.DataSetName = "dsBlanks";
            this.dsBlanks.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // edDescription
            // 
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edDescription.Location = new System.Drawing.Point(96, 57);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(487, 20);
            this.edDescription.TabIndex = 3;
            // 
            // edBlankId
            // 
            this.edBlankId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edBlankId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edBlankId.Location = new System.Drawing.Point(96, 15);
            this.edBlankId.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.edBlankId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edBlankId.Name = "edBlankId";
            this.edBlankId.Size = new System.Drawing.Size(74, 20);
            this.edBlankId.TabIndex = 0;
            this.edBlankId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edBlankId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbFirmId
            // 
            this.cbFirmId.DataSource = this.tbFirmsBindingSource;
            this.cbFirmId.DisplayMember = "Название";
            this.cbFirmId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFirmId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFirmId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFirmId.FormattingEnabled = true;
            this.cbFirmId.Location = new System.Drawing.Point(262, 14);
            this.cbFirmId.Name = "cbFirmId";
            this.cbFirmId.Size = new System.Drawing.Size(321, 21);
            this.cbFirmId.TabIndex = 1;
            this.cbFirmId.ValueMember = "Код";
            // 
            // tbFirmsBindingSource
            // 
            this.tbFirmsBindingSource.DataMember = "tbFirms";
            this.tbFirmsBindingSource.DataSource = this.dsBlanks;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbActive.Location = new System.Drawing.Point(513, 38);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(72, 17);
            this.cbActive.TabIndex = 4;
            this.cbActive.Text = "Активно";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Описание";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тип жалюзи";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(173, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фирма";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "№ бланка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edCellEssential);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.edCellAppendInfo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.edCellShopName);
            this.groupBox2.Controls.Add(this.edCellShopTel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.edColumnDiscount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.edRowPositionsMaximum);
            this.groupBox2.Controls.Add(this.edRowFirstPosition);
            this.groupBox2.Controls.Add(this.edColumnPrice);
            this.groupBox2.Controls.Add(this.edColumnQuant);
            this.groupBox2.Controls.Add(this.edCellMountingPeriod);
            this.groupBox2.Controls.Add(this.edCellClientTel);
            this.groupBox2.Controls.Add(this.edCellMounter);
            this.groupBox2.Controls.Add(this.edCellOrderSum);
            this.groupBox2.Controls.Add(this.edCellClientName);
            this.groupBox2.Controls.Add(this.edCellOrderId);
            this.groupBox2.Controls.Add(this.edCellOrderPrepayment);
            this.groupBox2.Controls.Add(this.edCellDate);
            this.groupBox2.Controls.Add(this.edCellDraftBlank);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 170);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Разметка бланка";
            // 
            // edCellEssential
            // 
            this.edCellEssential.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellEssential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellEssential.Location = new System.Drawing.Point(511, 123);
            this.edCellEssential.Name = "edCellEssential";
            this.edCellEssential.Size = new System.Drawing.Size(72, 20);
            this.edCellEssential.TabIndex = 15;
            this.edCellEssential.Text = "A";
            this.edCellEssential.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(262, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(245, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Реквизиты магазина";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edCellAppendInfo
            // 
            this.edCellAppendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellAppendInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellAppendInfo.Location = new System.Drawing.Point(262, 38);
            this.edCellAppendInfo.Name = "edCellAppendInfo";
            this.edCellAppendInfo.Size = new System.Drawing.Size(75, 20);
            this.edCellAppendInfo.TabIndex = 3;
            this.edCellAppendInfo.Text = "A1";
            this.edCellAppendInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(173, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Дополнение";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edCellShopName
            // 
            this.edCellShopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellShopName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellShopName.Location = new System.Drawing.Point(96, 37);
            this.edCellShopName.Name = "edCellShopName";
            this.edCellShopName.Size = new System.Drawing.Size(74, 20);
            this.edCellShopName.TabIndex = 2;
            this.edCellShopName.Text = "A";
            this.edCellShopName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellShopTel
            // 
            this.edCellShopTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellShopTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellShopTel.Location = new System.Drawing.Point(511, 38);
            this.edCellShopTel.Name = "edCellShopTel";
            this.edCellShopTel.Size = new System.Drawing.Size(72, 20);
            this.edCellShopTel.TabIndex = 4;
            this.edCellShopTel.Text = "A";
            this.edCellShopTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(340, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "Телефон магазина";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "Магазин";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edColumnDiscount
            // 
            this.edColumnDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edColumnDiscount.Location = new System.Drawing.Point(173, 145);
            this.edColumnDiscount.Name = "edColumnDiscount";
            this.edColumnDiscount.Size = new System.Drawing.Size(86, 20);
            this.edColumnDiscount.TabIndex = 16;
            this.edColumnDiscount.Text = "A";
            this.edColumnDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 18);
            this.label6.TabIndex = 32;
            this.label6.Text = "Скидка в позиции";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edRowPositionsMaximum
            // 
            this.edRowPositionsMaximum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edRowPositionsMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edRowPositionsMaximum.Location = new System.Drawing.Point(511, 16);
            this.edRowPositionsMaximum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.edRowPositionsMaximum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edRowPositionsMaximum.Name = "edRowPositionsMaximum";
            this.edRowPositionsMaximum.Size = new System.Drawing.Size(72, 20);
            this.edRowPositionsMaximum.TabIndex = 1;
            this.edRowPositionsMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edRowPositionsMaximum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // edRowFirstPosition
            // 
            this.edRowFirstPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edRowFirstPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edRowFirstPosition.Location = new System.Drawing.Point(173, 16);
            this.edRowFirstPosition.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.edRowFirstPosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edRowFirstPosition.Name = "edRowFirstPosition";
            this.edRowFirstPosition.Size = new System.Drawing.Size(86, 20);
            this.edRowFirstPosition.TabIndex = 0;
            this.edRowFirstPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edRowFirstPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // edColumnPrice
            // 
            this.edColumnPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edColumnPrice.Location = new System.Drawing.Point(173, 122);
            this.edColumnPrice.Name = "edColumnPrice";
            this.edColumnPrice.Size = new System.Drawing.Size(86, 20);
            this.edColumnPrice.TabIndex = 14;
            this.edColumnPrice.Text = "A";
            this.edColumnPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edColumnQuant
            // 
            this.edColumnQuant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edColumnQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edColumnQuant.Location = new System.Drawing.Point(511, 145);
            this.edColumnQuant.Name = "edColumnQuant";
            this.edColumnQuant.Size = new System.Drawing.Size(72, 20);
            this.edColumnQuant.TabIndex = 17;
            this.edColumnQuant.Text = "A";
            this.edColumnQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellMountingPeriod
            // 
            this.edCellMountingPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellMountingPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellMountingPeriod.Location = new System.Drawing.Point(511, 101);
            this.edCellMountingPeriod.Name = "edCellMountingPeriod";
            this.edCellMountingPeriod.Size = new System.Drawing.Size(72, 20);
            this.edCellMountingPeriod.TabIndex = 13;
            this.edCellMountingPeriod.Text = "A1";
            this.edCellMountingPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellClientTel
            // 
            this.edCellClientTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellClientTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellClientTel.Location = new System.Drawing.Point(511, 80);
            this.edCellClientTel.Name = "edCellClientTel";
            this.edCellClientTel.Size = new System.Drawing.Size(72, 20);
            this.edCellClientTel.TabIndex = 10;
            this.edCellClientTel.Text = "A1";
            this.edCellClientTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellMounter
            // 
            this.edCellMounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellMounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellMounter.Location = new System.Drawing.Point(511, 59);
            this.edCellMounter.Name = "edCellMounter";
            this.edCellMounter.Size = new System.Drawing.Size(72, 20);
            this.edCellMounter.TabIndex = 7;
            this.edCellMounter.Text = "A1";
            this.edCellMounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellOrderSum
            // 
            this.edCellOrderSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellOrderSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellOrderSum.Location = new System.Drawing.Point(262, 101);
            this.edCellOrderSum.Name = "edCellOrderSum";
            this.edCellOrderSum.Size = new System.Drawing.Size(75, 20);
            this.edCellOrderSum.TabIndex = 12;
            this.edCellOrderSum.Text = "A1";
            this.edCellOrderSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellClientName
            // 
            this.edCellClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellClientName.Location = new System.Drawing.Point(262, 80);
            this.edCellClientName.Name = "edCellClientName";
            this.edCellClientName.Size = new System.Drawing.Size(75, 20);
            this.edCellClientName.TabIndex = 9;
            this.edCellClientName.Text = "A1";
            this.edCellClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellOrderId
            // 
            this.edCellOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellOrderId.Location = new System.Drawing.Point(262, 59);
            this.edCellOrderId.Name = "edCellOrderId";
            this.edCellOrderId.Size = new System.Drawing.Size(75, 20);
            this.edCellOrderId.TabIndex = 6;
            this.edCellOrderId.Text = "A1";
            this.edCellOrderId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellOrderPrepayment
            // 
            this.edCellOrderPrepayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellOrderPrepayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellOrderPrepayment.Location = new System.Drawing.Point(96, 101);
            this.edCellOrderPrepayment.Name = "edCellOrderPrepayment";
            this.edCellOrderPrepayment.Size = new System.Drawing.Size(74, 20);
            this.edCellOrderPrepayment.TabIndex = 11;
            this.edCellOrderPrepayment.Text = "A1";
            this.edCellOrderPrepayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellDate
            // 
            this.edCellDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellDate.Location = new System.Drawing.Point(96, 80);
            this.edCellDate.Name = "edCellDate";
            this.edCellDate.Size = new System.Drawing.Size(74, 20);
            this.edCellDate.TabIndex = 8;
            this.edCellDate.Text = "A1";
            this.edCellDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edCellDraftBlank
            // 
            this.edCellDraftBlank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edCellDraftBlank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edCellDraftBlank.Location = new System.Drawing.Point(96, 59);
            this.edCellDraftBlank.Name = "edCellDraftBlank";
            this.edCellDraftBlank.Size = new System.Drawing.Size(74, 20);
            this.edCellDraftBlank.TabIndex = 5;
            this.edCellDraftBlank.Text = "A1";
            this.edCellDraftBlank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(262, 146);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(245, 18);
            this.label31.TabIndex = 30;
            this.label31.Text = "Количество в позиции";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.Location = new System.Drawing.Point(6, 123);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(164, 18);
            this.label33.TabIndex = 28;
            this.label33.Text = "Цена в позиции";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(340, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(167, 18);
            this.label25.TabIndex = 26;
            this.label25.Text = "Срок исполнения";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(173, 102);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 18);
            this.label27.TabIndex = 24;
            this.label27.Text = "Сумма";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(6, 102);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 18);
            this.label29.TabIndex = 22;
            this.label29.Text = "Предоплата";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(340, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 18);
            this.label19.TabIndex = 20;
            this.label19.Text = "Телефон покупателя";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(173, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 18);
            this.label21.TabIndex = 18;
            this.label21.Text = "Покупатель";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(6, 81);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 18);
            this.label23.TabIndex = 16;
            this.label23.Text = "Дата заказа";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(340, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(167, 18);
            this.label17.TabIndex = 14;
            this.label17.Text = "Установщик";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(173, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 18);
            this.label15.TabIndex = 12;
            this.label15.Text = "№ заказа";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(6, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "Черновик";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(262, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Максимальное количество позиций";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Первая позиция";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 36);
            this.panel1.TabIndex = 4;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(423, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(159, 28);
            this.btOk.TabIndex = 17;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(261, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // TfEditBlanksList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 289);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfEditBlanksList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBlankId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFirmsBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRowPositionsMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRowFirstPosition)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.ComboBox cbFirmId;
        public System.Windows.Forms.BindingSource tbFirmsBindingSource;
        private dsBlanks dsBlanks;
        public System.Windows.Forms.CheckBox cbActive;
        public System.Windows.Forms.NumericUpDown edBlankId;
        public System.Windows.Forms.TextBox edDescription;
        public System.Windows.Forms.TextBox edColumnPrice;
        public System.Windows.Forms.TextBox edColumnQuant;
        public System.Windows.Forms.TextBox edCellMountingPeriod;
        public System.Windows.Forms.TextBox edCellClientTel;
        public System.Windows.Forms.TextBox edCellMounter;
        public System.Windows.Forms.TextBox edCellOrderSum;
        public System.Windows.Forms.TextBox edCellClientName;
        public System.Windows.Forms.TextBox edCellOrderId;
        public System.Windows.Forms.TextBox edCellOrderPrepayment;
        public System.Windows.Forms.TextBox edCellDate;
        public System.Windows.Forms.TextBox edCellDraftBlank;
        public System.Windows.Forms.NumericUpDown edRowPositionsMaximum;
        public System.Windows.Forms.NumericUpDown edRowFirstPosition;
        public System.Windows.Forms.ComboBox cbTypeId;
        public System.Windows.Forms.BindingSource tbTypesBindingSource;
        public System.Windows.Forms.TextBox edColumnDiscount;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox edCellShopName;
        public System.Windows.Forms.TextBox edCellShopTel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox edCellAppendInfo;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox edCellEssential;
        private System.Windows.Forms.Label label10;
    }
}