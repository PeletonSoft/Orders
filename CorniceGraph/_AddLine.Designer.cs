namespace CorniceGraph
{
    partial class TfAddLine
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
            this.edDiag = new System.Windows.Forms.NumericUpDown();
            this.rbDiag = new System.Windows.Forms.RadioButton();
            this.edCorner = new System.Windows.Forms.NumericUpDown();
            this.edLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rbCorner = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLength)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 42);
            this.panel1.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(151, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(142, 32);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "Готово";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(5, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(142, 32);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.edDiag);
            this.panel2.Controls.Add(this.rbDiag);
            this.panel2.Controls.Add(this.edCorner);
            this.panel2.Controls.Add(this.edLength);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbCorner);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 98);
            this.panel2.TabIndex = 1;
            // 
            // edDiag
            // 
            this.edDiag.DecimalPlaces = 3;
            this.edDiag.Enabled = false;
            this.edDiag.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edDiag.Location = new System.Drawing.Point(190, 68);
            this.edDiag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edDiag.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.edDiag.Name = "edDiag";
            this.edDiag.Size = new System.Drawing.Size(104, 20);
            this.edDiag.TabIndex = 13;
            this.edDiag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edDiag.ValueChanged += new System.EventHandler(this.edDiag_ValueChanged);
            // 
            // rbDiag
            // 
            this.rbDiag.AutoSize = true;
            this.rbDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDiag.Location = new System.Drawing.Point(13, 68);
            this.rbDiag.Name = "rbDiag";
            this.rbDiag.Size = new System.Drawing.Size(162, 17);
            this.rbDiag.TabIndex = 14;
            this.rbDiag.Text = "Диагональ между стенами";
            this.rbDiag.UseVisualStyleBackColor = true;
            this.rbDiag.CheckedChanged += new System.EventHandler(this.rbCorner_CheckedChanged);
            // 
            // edCorner
            // 
            this.edCorner.DecimalPlaces = 1;
            this.edCorner.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.edCorner.Location = new System.Drawing.Point(190, 38);
            this.edCorner.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.edCorner.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.edCorner.Name = "edCorner";
            this.edCorner.Size = new System.Drawing.Size(104, 20);
            this.edCorner.TabIndex = 9;
            this.edCorner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edCorner.ValueChanged += new System.EventHandler(this.edCorner_ValueChanged);
            // 
            // edLength
            // 
            this.edLength.DecimalPlaces = 3;
            this.edLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edLength.Location = new System.Drawing.Point(190, 9);
            this.edLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.edLength.Name = "edLength";
            this.edLength.Size = new System.Drawing.Size(104, 20);
            this.edLength.TabIndex = 8;
            this.edLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edLength.ValueChanged += new System.EventHandler(this.edLength_ValueChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Длина стены";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbCorner
            // 
            this.rbCorner.AutoSize = true;
            this.rbCorner.Checked = true;
            this.rbCorner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCorner.Location = new System.Drawing.Point(13, 38);
            this.rbCorner.Name = "rbCorner";
            this.rbCorner.Size = new System.Drawing.Size(131, 17);
            this.rbCorner.TabIndex = 10;
            this.rbCorner.TabStop = true;
            this.rbCorner.Text = "Угол между стенами";
            this.rbCorner.UseVisualStyleBackColor = true;
            this.rbCorner.CheckedChanged += new System.EventHandler(this.rbCorner_CheckedChanged);
            // 
            // TfAddLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 140);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfAddLine";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление стены";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown edDiag;
        public System.Windows.Forms.RadioButton rbDiag;
        public System.Windows.Forms.NumericUpDown edCorner;
        public System.Windows.Forms.NumericUpDown edLength;
        public System.Windows.Forms.RadioButton rbCorner;
    }
}