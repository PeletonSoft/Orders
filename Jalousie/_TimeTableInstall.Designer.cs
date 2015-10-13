namespace Jalousie
{
    partial class TfTimeTableInstall
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnSelect = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dbg = new System.Windows.Forms.DataGridView();
            this.ReadyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeekDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNotFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOrders = new Jalousie.Datasets.dsOrders();
            this.pnlDifCat = new System.Windows.Forms.Panel();
            this.cbJalType = new System.Windows.Forms.ComboBox();
            this.tbTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlanks = new Jalousie.Datasets.dsBlanks();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).BeginInit();
            this.pnlDifCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSelect
            // 
            this.pnSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSelect.Controls.Add(this.btOk);
            this.pnSelect.Controls.Add(this.btCancel);
            this.pnSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSelect.Location = new System.Drawing.Point(0, 361);
            this.pnSelect.Name = "pnSelect";
            this.pnSelect.Size = new System.Drawing.Size(411, 45);
            this.pnSelect.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOk.ForeColor = System.Drawing.Color.Green;
            this.btOk.Location = new System.Drawing.Point(246, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(160, 36);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Выбрать";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(80, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(160, 36);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dbg
            // 
            this.dbg.AllowUserToAddRows = false;
            this.dbg.AllowUserToDeleteRows = false;
            this.dbg.AllowUserToResizeRows = false;
            this.dbg.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReadyDate,
            this.WeekDay,
            this.Cnt,
            this.IsFree,
            this.IsNotFree});
            this.dbg.DataSource = this.tbPlanBindingSource;
            this.dbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg.Location = new System.Drawing.Point(0, 0);
            this.dbg.MultiSelect = false;
            this.dbg.Name = "dbg";
            this.dbg.ReadOnly = true;
            this.dbg.RowHeadersVisible = false;
            this.dbg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbg.Size = new System.Drawing.Size(411, 320);
            this.dbg.TabIndex = 1;
            this.dbg.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dbg_CellPainting);
            this.dbg.DoubleClick += new System.EventHandler(this.btOk_Click);
            // 
            // ReadyDate
            // 
            this.ReadyDate.DataPropertyName = "Дата";
            this.ReadyDate.HeaderText = "Дата";
            this.ReadyDate.Name = "ReadyDate";
            this.ReadyDate.ReadOnly = true;
            // 
            // WeekDay
            // 
            this.WeekDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WeekDay.DataPropertyName = "День недели";
            this.WeekDay.HeaderText = "День недели";
            this.WeekDay.Name = "WeekDay";
            this.WeekDay.ReadOnly = true;
            // 
            // Cnt
            // 
            this.Cnt.DataPropertyName = "Всего изделий";
            this.Cnt.HeaderText = "Всего изделий";
            this.Cnt.Name = "Cnt";
            this.Cnt.ReadOnly = true;
            // 
            // IsFree
            // 
            this.IsFree.DataPropertyName = "Свободно";
            this.IsFree.HeaderText = "Свободно";
            this.IsFree.Name = "IsFree";
            this.IsFree.ReadOnly = true;
            this.IsFree.Visible = false;
            // 
            // IsNotFree
            // 
            this.IsNotFree.DataPropertyName = "Занято";
            this.IsNotFree.HeaderText = "Занято";
            this.IsNotFree.Name = "IsNotFree";
            this.IsNotFree.ReadOnly = true;
            this.IsNotFree.Visible = false;
            // 
            // tbPlanBindingSource
            // 
            this.tbPlanBindingSource.DataMember = "tbPlan";
            this.tbPlanBindingSource.DataSource = this.dsOrders;
            this.tbPlanBindingSource.Sort = "";
            // 
            // dsOrders
            // 
            this.dsOrders.DataSetName = "dsOrders";
            this.dsOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlDifCat
            // 
            this.pnlDifCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDifCat.Controls.Add(this.cbJalType);
            this.pnlDifCat.Controls.Add(this.label1);
            this.pnlDifCat.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDifCat.Location = new System.Drawing.Point(0, 0);
            this.pnlDifCat.Name = "pnlDifCat";
            this.pnlDifCat.Size = new System.Drawing.Size(411, 41);
            this.pnlDifCat.TabIndex = 2;
            // 
            // cbJalType
            // 
            this.cbJalType.DataSource = this.tbTypesBindingSource;
            this.cbJalType.DisplayMember = "Название";
            this.cbJalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJalType.FormattingEnabled = true;
            this.cbJalType.Location = new System.Drawing.Point(147, 9);
            this.cbJalType.Name = "cbJalType";
            this.cbJalType.Size = new System.Drawing.Size(251, 21);
            this.cbJalType.TabIndex = 22;
            this.cbJalType.ValueMember = "Код";
            // 
            // tbTypesBindingSource
            // 
            this.tbTypesBindingSource.DataMember = "tbTypes";
            this.tbTypesBindingSource.DataSource = this.dsBlanks;
            this.tbTypesBindingSource.Sort = "[Код] asc";
            this.tbTypesBindingSource.CurrentChanged += new System.EventHandler(this.tbTypesBindingSource_CurrentChanged);
            // 
            // dsBlanks
            // 
            this.dsBlanks.DataSetName = "dsBlanks";
            this.dsBlanks.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Тип изделий";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dbg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 320);
            this.panel2.TabIndex = 3;
            // 
            // TfTimeTableInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 406);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDifCat);
            this.Controls.Add(this.pnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfTimeTableInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дата изготовления";
            this.Load += new System.EventHandler(this.FTimeTableInstall_Load);
            this.Shown += new System.EventHandler(this.TfTimeTableInstall_Shown);
            this.pnSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).EndInit();
            this.pnlDifCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dbg;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel pnlDifCat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbJalType;
        private System.Windows.Forms.BindingSource tbTypesBindingSource;
        private Datasets.dsBlanks dsBlanks;
        private Datasets.dsOrders dsOrders;
        private System.Windows.Forms.BindingSource tbPlanBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeekDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cnt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFree;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNotFree;
        public System.Windows.Forms.Panel pnSelect;
    }
}