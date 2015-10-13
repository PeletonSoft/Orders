namespace Jalousie
{
    partial class TfInsertDictionary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edText = new System.Windows.Forms.TextBox();
            this.lbtValue = new System.Windows.Forms.Label();
            this.edFloat = new System.Windows.Forms.NumericUpDown();
            this.lbfValue = new System.Windows.Forms.Label();
            this.edInteger = new System.Windows.Forms.NumericUpDown();
            this.lbiValue = new System.Windows.Forms.Label();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbFloat = new System.Windows.Forms.RadioButton();
            this.rbInteger = new System.Windows.Forms.RadioButton();
            this.edName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edInteger)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 36);
            this.panel1.TabIndex = 2;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(428, 3);
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
            this.btCancel.Location = new System.Drawing.Point(266, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.edName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.edDescription);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 188);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edText);
            this.groupBox1.Controls.Add(this.lbtValue);
            this.groupBox1.Controls.Add(this.edFloat);
            this.groupBox1.Controls.Add(this.lbfValue);
            this.groupBox1.Controls.Add(this.edInteger);
            this.groupBox1.Controls.Add(this.lbiValue);
            this.groupBox1.Controls.Add(this.rbText);
            this.groupBox1.Controls.Add(this.rbFloat);
            this.groupBox1.Controls.Add(this.rbInteger);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 142);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип данных";
            // 
            // edText
            // 
            this.edText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edText.Enabled = false;
            this.edText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edText.Location = new System.Drawing.Point(162, 117);
            this.edText.Name = "edText";
            this.edText.Size = new System.Drawing.Size(336, 20);
            this.edText.TabIndex = 12;
            // 
            // lbtValue
            // 
            this.lbtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtValue.Enabled = false;
            this.lbtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbtValue.Location = new System.Drawing.Point(92, 117);
            this.lbtValue.Name = "lbtValue";
            this.lbtValue.Size = new System.Drawing.Size(66, 20);
            this.lbtValue.TabIndex = 11;
            this.lbtValue.Text = "Значение";
            this.lbtValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edFloat
            // 
            this.edFloat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edFloat.DecimalPlaces = 2;
            this.edFloat.Enabled = false;
            this.edFloat.Location = new System.Drawing.Point(162, 75);
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
            this.edFloat.TabIndex = 10;
            this.edFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbfValue
            // 
            this.lbfValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbfValue.Enabled = false;
            this.lbfValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbfValue.Location = new System.Drawing.Point(92, 75);
            this.lbfValue.Name = "lbfValue";
            this.lbfValue.Size = new System.Drawing.Size(66, 20);
            this.lbfValue.TabIndex = 9;
            this.lbfValue.Text = "Значение";
            this.lbfValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edInteger
            // 
            this.edInteger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edInteger.Location = new System.Drawing.Point(162, 33);
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
            this.edInteger.TabIndex = 8;
            this.edInteger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbiValue
            // 
            this.lbiValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbiValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbiValue.Location = new System.Drawing.Point(92, 33);
            this.lbiValue.Name = "lbiValue";
            this.lbiValue.Size = new System.Drawing.Size(66, 20);
            this.lbiValue.TabIndex = 7;
            this.lbiValue.Text = "Значение";
            this.lbiValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbText.Location = new System.Drawing.Point(30, 98);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(78, 17);
            this.rbText.TabIndex = 2;
            this.rbText.Text = "Текстовое";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.Click += new System.EventHandler(this.rbInteger_CheckedChanged);
            this.rbText.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // rbFloat
            // 
            this.rbFloat.AutoSize = true;
            this.rbFloat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbFloat.Location = new System.Drawing.Point(30, 56);
            this.rbFloat.Name = "rbFloat";
            this.rbFloat.Size = new System.Drawing.Size(69, 17);
            this.rbFloat.TabIndex = 1;
            this.rbFloat.Text = "Дробное";
            this.rbFloat.UseVisualStyleBackColor = true;
            this.rbFloat.Click += new System.EventHandler(this.rbInteger_CheckedChanged);
            this.rbFloat.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // rbInteger
            // 
            this.rbInteger.AutoSize = true;
            this.rbInteger.Checked = true;
            this.rbInteger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbInteger.Location = new System.Drawing.Point(30, 16);
            this.rbInteger.Name = "rbInteger";
            this.rbInteger.Size = new System.Drawing.Size(56, 17);
            this.rbInteger.TabIndex = 0;
            this.rbInteger.TabStop = true;
            this.rbInteger.Text = "Целое";
            this.rbInteger.UseVisualStyleBackColor = true;
            this.rbInteger.CheckedChanged += new System.EventHandler(this.rbInteger_CheckedChanged);
            // 
            // edName
            // 
            this.edName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edName.Location = new System.Drawing.Point(94, 2);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(494, 20);
            this.edName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edDescription
            // 
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edDescription.Location = new System.Drawing.Point(94, 24);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(494, 20);
            this.edDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Описание";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TfInsertDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 224);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfInsertDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление справочника";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edInteger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbiValue;
        public System.Windows.Forms.TextBox edText;
        private System.Windows.Forms.Label lbtValue;
        private System.Windows.Forms.Label lbfValue;
        public System.Windows.Forms.RadioButton rbText;
        public System.Windows.Forms.RadioButton rbFloat;
        public System.Windows.Forms.RadioButton rbInteger;
        public System.Windows.Forms.NumericUpDown edInteger;
        public System.Windows.Forms.NumericUpDown edFloat;
    }
}