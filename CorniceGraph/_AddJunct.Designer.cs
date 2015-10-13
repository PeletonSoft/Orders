namespace CorniceGraph
{
    partial class TfAddJunct
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
            this.edLeft = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edRight = new System.Windows.Forms.NumericUpDown();
            this.tb = new System.Windows.Forms.TrackBar();
            this.btOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.edLeft)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edLeft
            // 
            this.edLeft.DecimalPlaces = 3;
            this.edLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edLeft.Location = new System.Drawing.Point(5, 6);
            this.edLeft.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.edLeft.Name = "edLeft";
            this.edLeft.Size = new System.Drawing.Size(92, 20);
            this.edLeft.TabIndex = 8;
            this.edLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edLeft.ValueChanged += new System.EventHandler(this.edLeft_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.edRight);
            this.panel2.Controls.Add(this.tb);
            this.panel2.Controls.Add(this.edLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 66);
            this.panel2.TabIndex = 3;
            // 
            // edRight
            // 
            this.edRight.DecimalPlaces = 3;
            this.edRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edRight.Location = new System.Drawing.Point(201, 3);
            this.edRight.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.edRight.Name = "edRight";
            this.edRight.Size = new System.Drawing.Size(92, 20);
            this.edRight.TabIndex = 12;
            this.edRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edRight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edRight.ValueChanged += new System.EventHandler(this.edRight_ValueChanged);
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(1, 32);
            this.tb.Maximum = 100;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(300, 45);
            this.tb.TabIndex = 11;
            this.tb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb.Value = 50;
            this.tb.Scroll += new System.EventHandler(this.tb_Scroll);
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
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 42);
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
            // TfAddJunct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 108);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfAddJunct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расстыковка секции";
            ((System.ComponentModel.ISupportInitialize)(this.edLeft)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown edLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.TrackBar tb;
        public System.Windows.Forms.NumericUpDown edRight;
    }
}