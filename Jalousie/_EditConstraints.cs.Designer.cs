namespace Jalousie
{
    partial class TfEditConstraints
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.tbOperationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsConstraints = new Jalousie.Datasets.dsConstraints();
            this.label1 = new System.Windows.Forms.Label();
            this.cbExpressionType = new System.Windows.Forms.ComboBox();
            this.tbExpressionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edPriority = new System.Windows.Forms.NumericUpDown();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.edMessage = new System.Windows.Forms.TextBox();
            this.edConstraint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOperationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsConstraints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExpressionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btOk);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 553);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 37);
            this.panel3.TabIndex = 21;
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Red;
            this.btOk.Location = new System.Drawing.Point(709, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(159, 28);
            this.btOk.TabIndex = 19;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Green;
            this.btCancel.Location = new System.Drawing.Point(547, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 28);
            this.btCancel.TabIndex = 20;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbOperation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbExpressionType);
            this.groupBox2.Controls.Add(this.edPriority);
            this.groupBox2.Controls.Add(this.edDescription);
            this.groupBox2.Controls.Add(this.edMessage);
            this.groupBox2.Controls.Add(this.edConstraint);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbActive);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 590);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительная информация";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(448, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 53;
            this.label2.Text = "Операция";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbOperation
            // 
            this.cbOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOperation.DataSource = this.tbOperationsBindingSource;
            this.cbOperation.DisplayMember = "Название";
            this.cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperation.DropDownWidth = 300;
            this.cbOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Location = new System.Drawing.Point(562, 528);
            this.cbOperation.MaxDropDownItems = 20;
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(228, 21);
            this.cbOperation.TabIndex = 52;
            this.cbOperation.ValueMember = "Код";
            // 
            // tbOperationsBindingSource
            // 
            this.tbOperationsBindingSource.DataMember = "tbOperations";
            this.tbOperationsBindingSource.DataSource = this.dsConstraints;
            // 
            // dsConstraints
            // 
            this.dsConstraints.DataSetName = "dsConstraints";
            this.dsConstraints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(158, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 51;
            this.label1.Text = "Тип выражения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbExpressionType
            // 
            this.cbExpressionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbExpressionType.DataSource = this.tbExpressionTypeBindingSource;
            this.cbExpressionType.DisplayMember = "Название";
            this.cbExpressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExpressionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbExpressionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbExpressionType.FormattingEnabled = true;
            this.cbExpressionType.Location = new System.Drawing.Point(276, 528);
            this.cbExpressionType.Name = "cbExpressionType";
            this.cbExpressionType.Size = new System.Drawing.Size(168, 21);
            this.cbExpressionType.TabIndex = 50;
            this.cbExpressionType.ValueMember = "Код";
            // 
            // tbExpressionTypeBindingSource
            // 
            this.tbExpressionTypeBindingSource.DataMember = "tbExpressionType";
            this.tbExpressionTypeBindingSource.DataSource = this.dsConstraints;
            // 
            // edPriority
            // 
            this.edPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edPriority.Location = new System.Drawing.Point(104, 528);
            this.edPriority.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edPriority.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.edPriority.Name = "edPriority";
            this.edPriority.Size = new System.Drawing.Size(49, 20);
            this.edPriority.TabIndex = 49;
            this.edPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edDescription
            // 
            this.edDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edDescription.Location = new System.Drawing.Point(104, 485);
            this.edDescription.Multiline = true;
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(764, 41);
            this.edDescription.TabIndex = 48;
            // 
            // edMessage
            // 
            this.edMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edMessage.Location = new System.Drawing.Point(104, 442);
            this.edMessage.Multiline = true;
            this.edMessage.Name = "edMessage";
            this.edMessage.Size = new System.Drawing.Size(764, 41);
            this.edMessage.TabIndex = 47;
            // 
            // edConstraint
            // 
            this.edConstraint.AcceptsReturn = true;
            this.edConstraint.AcceptsTab = true;
            this.edConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edConstraint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edConstraint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edConstraint.HideSelection = false;
            this.edConstraint.Location = new System.Drawing.Point(105, 16);
            this.edConstraint.Multiline = true;
            this.edConstraint.Name = "edConstraint";
            this.edConstraint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edConstraint.Size = new System.Drawing.Size(764, 424);
            this.edConstraint.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 528);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "Приоритет";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbActive
            // 
            this.cbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbActive.Location = new System.Drawing.Point(796, 529);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(72, 17);
            this.cbActive.TabIndex = 33;
            this.cbActive.Text = "Активно";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 41);
            this.label6.TabIndex = 39;
            this.label6.Text = "Сообщение";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 424);
            this.label7.TabIndex = 38;
            this.label7.Text = "Ограничение";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(5, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 41);
            this.label9.TabIndex = 37;
            this.label9.Text = "Описание";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TfEditConstraints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 590);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfEditConstraints";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOperationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsConstraints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExpressionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox edDescription;
        public System.Windows.Forms.TextBox edMessage;
        public System.Windows.Forms.TextBox edConstraint;
        public System.Windows.Forms.NumericUpDown edPriority;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbExpressionType;
        private Datasets.dsConstraints dsConstraints;
        public System.Windows.Forms.BindingSource tbExpressionTypeBindingSource;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbOperation;
        public System.Windows.Forms.BindingSource tbOperationsBindingSource;
    }
}