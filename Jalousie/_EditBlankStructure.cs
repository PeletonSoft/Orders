using System;
using System.Data;
using System.Windows.Forms;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfEditBlankStructure : Form
    {
        public TfEditBlankStructure()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbDictionaryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (tbDictionaryBindingSource.Current == null)
                return;
            var rw = (dsDictionary.tbDictionaryRow)
                (tbDictionaryBindingSource.Current as DataRowView).Row;
            tbContentBindingSource.Filter = "[Активен]=1 AND [Код справочника]=" + rw.Код.ToString();
            switch (rw.Код_типа_данных)
            {
                case 1:
                    cbDictionaryContentId.DisplayMember = "Целое";
                    cbDictionaryContentId.FormatString = "N0";
                    cbDictionaryContentId.FormatString = "N0";
                    break;
                case 2:
                    cbDictionaryContentId.DisplayMember = "Дробное";
                    cbDictionaryContentId.FormatString = "N2";
                    break;
                case 3:
                    cbDictionaryContentId.DisplayMember = "Текстовое";
                    cbDictionaryContentId.FormatString = "";
                    break;
            }

        }

        private void rbInteger_CheckedChanged(object sender, EventArgs e)
        {
            edInteger.Enabled = rbInteger.Checked;
            edFloat.Enabled = rbFloat.Checked;
            edText.Enabled = rbText.Checked;
            cbDictionaryId.Enabled = rbDictionary.Checked;
            cbDictionaryContentId.Enabled = rbDictionary.Checked;

            lbfValue.Enabled = rbFloat.Checked;
            lbiValue.Enabled = rbInteger.Checked;
            lbtValue.Enabled = rbText.Checked;
            lbdValue.Enabled = rbDictionary.Checked;

            if (edInteger.Enabled)
            {
                if (Visible) 
                    edInteger.Focus();
            }
            else 
                edInteger.Value = 0;

            if (edFloat.Enabled)
            {
                if (Visible)
                    edFloat.Focus();
            }
            else
                edFloat.Value = 0;

            if (edText.Enabled)
            {
                if (Visible)
                    edText.Focus();
            }
            else
                edText.Text = "";

            if (cbDictionaryId.Enabled)
            {
                if (Visible) 
                    cbDictionaryId.Focus();
            }
        }
    }
}
