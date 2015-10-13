namespace CorniceGraph
{
    partial class TfDeleteCorner
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
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbWall = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(152, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(142, 32);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "Удалить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbLeft.Location = new System.Drawing.Point(13, 33);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(200, 17);
            this.rbLeft.TabIndex = 14;
            this.rbLeft.Text = "Удалить угол и предыдущую стену";
            this.rbLeft.UseVisualStyleBackColor = true;
            // 
            // rbWall
            // 
            this.rbWall.AutoSize = true;
            this.rbWall.Checked = true;
            this.rbWall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbWall.Location = new System.Drawing.Point(13, 10);
            this.rbWall.Name = "rbWall";
            this.rbWall.Size = new System.Drawing.Size(130, 17);
            this.rbWall.TabIndex = 10;
            this.rbWall.TabStop = true;
            this.rbWall.Text = "Удалить только угол";
            this.rbWall.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbRight);
            this.panel2.Controls.Add(this.rbLeft);
            this.panel2.Controls.Add(this.rbWall);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 85);
            this.panel2.TabIndex = 5;
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbRight.Location = new System.Drawing.Point(13, 56);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(194, 17);
            this.rbRight.TabIndex = 15;
            this.rbRight.Text = "Удалить угол и следующую стену";
            this.rbRight.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(4, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(142, 32);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 42);
            this.panel1.TabIndex = 4;
            // 
            // TfDeleteCorner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 127);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfDeleteCorner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Удаление угла";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        public System.Windows.Forms.RadioButton rbLeft;
        public System.Windows.Forms.RadioButton rbWall;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panel1;
    }
}