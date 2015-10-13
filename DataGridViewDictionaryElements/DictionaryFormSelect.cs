using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewDictionaryElements
{
    public partial class DictionaryFormSelect : Form
    {
        public DictionaryFormSelect()
        {
            InitializeComponent();
        }

        public string Filter;

        private void DictionaryFormSelect_Shown(object sender, EventArgs e)
        {
            if (!Description.Visible)
                Display.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            edFilter.Focus();
        }

        private void edFilter_TextChanged(object sender, EventArgs e)
        {
            if (edFilter.Text == "")
                BindingSource.Filter = Filter;
            else
            {
                var text = edFilter.Text
                    .Replace("]", "")
                    .Replace("[", "")
                    .Replace("'", "");
                var format = "({0}) AND (1=0" +
                             (Display.Visible ? " OR CONVERT([{1}],'System.String') LIKE '%{3}%'" : "") +
                             (Description.Visible ? " OR CONVERT([{2}],'System.String') LIKE '%{3}%'" : "") +
                             ")";
                BindingSource.Filter = String.Format
                    (format, Filter, Display.DataPropertyName, Description.DataPropertyName, text);
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (BindingSource.Count>0)
                DialogResult = DialogResult.OK;
        }

        private void edFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.Cancel;
            if (e.KeyData == Keys.Return)
                GridView_DoubleClick(GridView, null);
            if (e.KeyData == Keys.Up ||
                e.KeyData == Keys.Down ||
                e.KeyData == Keys.PageUp ||
                e.KeyData == Keys.PageDown)
                GridView.Focus();
        }

        private void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                DialogResult = DialogResult.Cancel;
            if (e.KeyData == Keys.Return)
                GridView_DoubleClick(GridView, null);
        }

        private void GridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar>' ')
            {
                edFilter.Focus();
                edFilter.Text = e.KeyChar.ToString();
                edFilter.SelectionStart = edFilter.Text.Length;
            }
        }
    }
}
