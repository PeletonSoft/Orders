namespace CorniceGraph
{
    partial class TfEditSide
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
            this.btOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFirstSide = new System.Windows.Forms.CheckBox();
            this.edFirstSide = new System.Windows.Forms.NumericUpDown();
            this.edFirstStep = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLastSide = new System.Windows.Forms.CheckBox();
            this.edLastSide = new System.Windows.Forms.NumericUpDown();
            this.edLastStep = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFirstSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFirstStep)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLastSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLastStep)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 42);
            this.panel1.TabIndex = 2;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbFirstSide);
            this.groupBox1.Controls.Add(this.edFirstSide);
            this.groupBox1.Controls.Add(this.edFirstStep);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Боковина в начале";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Отступ от начала (длина)";
            // 
            // cbFirstSide
            // 
            this.cbFirstSide.AutoSize = true;
            this.cbFirstSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFirstSide.Location = new System.Drawing.Point(12, 44);
            this.cbFirstSide.Name = "cbFirstSide";
            this.cbFirstSide.Size = new System.Drawing.Size(150, 17);
            this.cbFirstSide.TabIndex = 23;
            this.cbFirstSide.Text = "Боковина в начале (угол)";
            this.cbFirstSide.UseVisualStyleBackColor = true;
            this.cbFirstSide.CheckedChanged += new System.EventHandler(this.rbFirstStep_CheckedChanged);
            // 
            // edFirstSide
            // 
            this.edFirstSide.DecimalPlaces = 1;
            this.edFirstSide.Enabled = false;
            this.edFirstSide.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.edFirstSide.Location = new System.Drawing.Point(186, 44);
            this.edFirstSide.Maximum = new decimal(new int[] {
            145,
            0,
            0,
            0});
            this.edFirstSide.Minimum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.edFirstSide.Name = "edFirstSide";
            this.edFirstSide.Size = new System.Drawing.Size(104, 20);
            this.edFirstSide.TabIndex = 21;
            this.edFirstSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edFirstSide.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // edFirstStep
            // 
            this.edFirstStep.DecimalPlaces = 3;
            this.edFirstStep.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.edFirstStep.Location = new System.Drawing.Point(187, 18);
            this.edFirstStep.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edFirstStep.Name = "edFirstStep";
            this.edFirstStep.Size = new System.Drawing.Size(104, 20);
            this.edFirstStep.TabIndex = 19;
            this.edFirstStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbLastSide);
            this.groupBox2.Controls.Add(this.edLastSide);
            this.groupBox2.Controls.Add(this.edLastStep);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Боковина в конце";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Отступ от конца (длина)";
            // 
            // cbLastSide
            // 
            this.cbLastSide.AutoSize = true;
            this.cbLastSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLastSide.Location = new System.Drawing.Point(12, 45);
            this.cbLastSide.Name = "cbLastSide";
            this.cbLastSide.Size = new System.Drawing.Size(145, 17);
            this.cbLastSide.TabIndex = 22;
            this.cbLastSide.Text = "Боковина в конце (угол)";
            this.cbLastSide.UseVisualStyleBackColor = true;
            this.cbLastSide.CheckedChanged += new System.EventHandler(this.rbFirstStep_CheckedChanged);
            // 
            // edLastSide
            // 
            this.edLastSide.DecimalPlaces = 1;
            this.edLastSide.Enabled = false;
            this.edLastSide.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.edLastSide.Location = new System.Drawing.Point(186, 44);
            this.edLastSide.Maximum = new decimal(new int[] {
            145,
            0,
            0,
            0});
            this.edLastSide.Minimum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.edLastSide.Name = "edLastSide";
            this.edLastSide.Size = new System.Drawing.Size(104, 20);
            this.edLastSide.TabIndex = 21;
            this.edLastSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edLastSide.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // edLastStep
            // 
            this.edLastStep.DecimalPlaces = 3;
            this.edLastStep.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.edLastStep.Location = new System.Drawing.Point(187, 18);
            this.edLastStep.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edLastStep.Name = "edLastStep";
            this.edLastStep.Size = new System.Drawing.Size(104, 20);
            this.edLastStep.TabIndex = 19;
            this.edLastStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TfEditSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 188);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfEditSide";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Боковины линии";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFirstSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFirstStep)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLastSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLastStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown edFirstSide;
        public System.Windows.Forms.NumericUpDown edFirstStep;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown edLastSide;
        public System.Windows.Forms.NumericUpDown edLastStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox cbFirstSide;
        public System.Windows.Forms.CheckBox cbLastSide;
    }
}