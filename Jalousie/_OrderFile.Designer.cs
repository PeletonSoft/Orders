namespace Jalousie
{
    partial class TfOrderFile
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
            this.btNew = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbProgram = new System.Windows.Forms.ComboBox();
            this.tbProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBlanks = new Jalousie.Datasets.dsBlanks();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).BeginInit();
            this.SuspendLayout();
            // 
            // btNew
            // 
            this.btNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btNew.ForeColor = System.Drawing.Color.Red;
            this.btNew.Location = new System.Drawing.Point(2, 2);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(171, 54);
            this.btNew.TabIndex = 1;
            this.btNew.Text = "Создать...";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEdit.ForeColor = System.Drawing.Color.Red;
            this.btEdit.Location = new System.Drawing.Point(2, 59);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(171, 54);
            this.btEdit.TabIndex = 3;
            this.btEdit.Text = "Редактировать...";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDelete
            // 
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(176, 59);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(171, 54);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btView
            // 
            this.btView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btView.Location = new System.Drawing.Point(176, 2);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(171, 54);
            this.btView.TabIndex = 2;
            this.btView.Text = "Просмотреть...";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btClose
            // 
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btClose.ForeColor = System.Drawing.Color.Green;
            this.btClose.Location = new System.Drawing.Point(176, 116);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(171, 54);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btLoad
            // 
            this.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btLoad.Location = new System.Drawing.Point(2, 116);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(171, 54);
            this.btLoad.TabIndex = 5;
            this.btLoad.Text = "Загрузить...";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btNew);
            this.panel1.Controls.Add(this.btEdit);
            this.panel1.Controls.Add(this.btView);
            this.panel1.Controls.Add(this.btDelete);
            this.panel1.Controls.Add(this.btLoad);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 175);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbProgram);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 30);
            this.panel2.TabIndex = 7;
            // 
            // cbProgram
            // 
            this.cbProgram.DataSource = this.tbProgramBindingSource;
            this.cbProgram.DisplayMember = "Название";
            this.cbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbProgram.FormattingEnabled = true;
            this.cbProgram.Location = new System.Drawing.Point(2, 3);
            this.cbProgram.MaxDropDownItems = 9;
            this.cbProgram.Name = "cbProgram";
            this.cbProgram.Size = new System.Drawing.Size(345, 21);
            this.cbProgram.TabIndex = 42;
            this.cbProgram.ValueMember = "Код";
            this.cbProgram.SelectedIndexChanged += new System.EventHandler(this.cbProgram_SelectedIndexChanged);
            // 
            // tbProgramBindingSource
            // 
            this.tbProgramBindingSource.DataMember = "tbProgram";
            this.tbProgramBindingSource.DataSource = this.dsBlanks;
            this.tbProgramBindingSource.Sort = "[Название] ASC";
            // 
            // dsBlanks
            // 
            this.dsBlanks.DataSetName = "dsBlanks";
            this.dsBlanks.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TfOrderFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 205);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TfOrderFile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Привязанный файл";
            this.Shown += new System.EventHandler(this.TfOrderFile_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBlanks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btNew;
        public System.Windows.Forms.Button btEdit;
        public System.Windows.Forms.Button btDelete;
        public System.Windows.Forms.Button btView;
        public System.Windows.Forms.Button btClose;
        public System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cbProgram;
        private System.Windows.Forms.BindingSource tbProgramBindingSource;
        private Datasets.dsBlanks dsBlanks;
    }
}