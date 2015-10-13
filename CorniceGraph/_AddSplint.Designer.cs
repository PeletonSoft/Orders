namespace CorniceGraph
{
    partial class TfAddSplint
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb = new System.Windows.Forms.TrackBar();
            this.edValue = new System.Windows.Forms.NumericUpDown();
            this.lbmin = new System.Windows.Forms.Label();
            this.lbmax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbParameters = new System.Windows.Forms.Label();
            this.tbComponentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSplints = new CorniceGraph.Datasets.dsSplints();
            this.lcb = new System.Windows.Forms.ComboBox();
            this.pn = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbComponentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSplints)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 42);
            this.panel1.TabIndex = 2;
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
            this.panel2.Controls.Add(this.tb);
            this.panel2.Controls.Add(this.edValue);
            this.panel2.Controls.Add(this.lbmin);
            this.panel2.Controls.Add(this.lbmax);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbParameters);
            this.panel2.Controls.Add(this.lcb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 127);
            this.panel2.TabIndex = 3;
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(7, 85);
            this.tb.Maximum = 100;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(285, 42);
            this.tb.SmallChange = 10;
            this.tb.TabIndex = 7;
            this.tb.TickFrequency = 5;
            this.tb.Scroll += new System.EventHandler(this.tb_Scroll);
            // 
            // edValue
            // 
            this.edValue.DecimalPlaces = 3;
            this.edValue.Location = new System.Drawing.Point(107, 59);
            this.edValue.Name = "edValue";
            this.edValue.Size = new System.Drawing.Size(90, 20);
            this.edValue.TabIndex = 6;
            this.edValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edValue.ValueChanged += new System.EventHandler(this.edValue_ValueChanged);
            // 
            // lbmin
            // 
            this.lbmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbmin.Location = new System.Drawing.Point(7, 60);
            this.lbmin.Name = "lbmin";
            this.lbmin.Size = new System.Drawing.Size(61, 20);
            this.lbmin.TabIndex = 5;
            this.lbmin.Text = "MIN";
            this.lbmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmax
            // 
            this.lbmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbmax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbmax.Location = new System.Drawing.Point(231, 60);
            this.lbmax.Name = "lbmax";
            this.lbmax.Size = new System.Drawing.Size(61, 20);
            this.lbmax.TabIndex = 4;
            this.lbmax.Text = "MAX";
            this.lbmax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "MIN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(231, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParameters
            // 
            this.lbParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbParameters.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbComponentsBindingSource, "Параметр", true));
            this.lbParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbParameters.Location = new System.Drawing.Point(107, 36);
            this.lbParameters.Name = "lbParameters";
            this.lbParameters.Size = new System.Drawing.Size(90, 20);
            this.lbParameters.TabIndex = 1;
            this.lbParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbComponentsBindingSource
            // 
            this.tbComponentsBindingSource.DataMember = "tbComponents";
            this.tbComponentsBindingSource.DataSource = this.dsSplints;
            this.tbComponentsBindingSource.Sort = "[Название] ASC";
            // 
            // dsSplints
            // 
            this.dsSplints.DataSetName = "dsSplints";
            this.dsSplints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lcb
            // 
            this.lcb.DataSource = this.tbComponentsBindingSource;
            this.lcb.DisplayMember = "Название";
            this.lcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lcb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lcb.FormattingEnabled = true;
            this.lcb.Location = new System.Drawing.Point(7, 7);
            this.lcb.MaxDropDownItems = 15;
            this.lcb.Name = "lcb";
            this.lcb.Size = new System.Drawing.Size(285, 21);
            this.lcb.TabIndex = 0;
            this.lcb.ValueMember = "Код";
            this.lcb.SelectedIndexChanged += new System.EventHandler(this.lcb_SelectedIndexChanged);
            // 
            // pn
            // 
            this.pn.BackColor = System.Drawing.Color.White;
            this.pn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn.Location = new System.Drawing.Point(0, 127);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(300, 112);
            this.pn.TabIndex = 4;
            this.pn.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_Paint);
            // 
            // TfAddSplint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 281);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfAddSplint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление шины";
            this.Shown += new System.EventHandler(this.TfAddSplint_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbComponentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSplints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.BindingSource tbComponentsBindingSource;
        private CorniceGraph.Datasets.dsSplints dsSplints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbParameters;
        private System.Windows.Forms.Label lbmin;
        private System.Windows.Forms.Label lbmax;
        private System.Windows.Forms.TrackBar tb;
        private System.Windows.Forms.Panel pn;
        public System.Windows.Forms.ComboBox lcb;
        public System.Windows.Forms.NumericUpDown edValue;
    }
}