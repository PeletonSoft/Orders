using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewDictionaryElements
{
    [ToolboxBitmap(typeof(ComboBox), "ComboBox.bmp")]
    partial class DictionaryComboBox : UserControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionaryComboBox));
            this.ComboBoxValue = new System.Windows.Forms.ComboBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.Hinter = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ComboBoxValue
            // 
            this.ComboBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxValue.FormattingEnabled = true;
            this.ComboBoxValue.Location = new System.Drawing.Point(0, 0);
            this.ComboBoxValue.Margin = new System.Windows.Forms.Padding(0);
            this.ComboBoxValue.MaxDropDownItems = 30;
            this.ComboBoxValue.Name = "ComboBoxValue";
            this.ComboBoxValue.Size = new System.Drawing.Size(293, 21);
            this.ComboBoxValue.TabIndex = 0;
            this.ComboBoxValue.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxValue_DrawItem);
            this.ComboBoxValue.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValue_SelectedIndexChanged);
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectButton.Image")));
            this.SelectButton.Location = new System.Drawing.Point(293, 0);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(0);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(21, 21);
            this.SelectButton.TabIndex = 1;
            this.Hinter.SetToolTip(this.SelectButton, "Поиск...");
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // DictionaryComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComboBoxValue);
            this.Controls.Add(this.SelectButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DictionaryComboBox";
            this.Size = new System.Drawing.Size(314, 21);
            this.SizeChanged += new System.EventHandler(this.DictionaryComboBox_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox ComboBoxValue;
        public System.Windows.Forms.Button SelectButton;
        private ToolTip Hinter;
    }
}
