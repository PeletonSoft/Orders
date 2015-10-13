using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfDictionary : Form
    {
        public TfDictionary()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new TfInsertDictionary() { Tag = this.Tag };
            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? DictionaryId;
            int? DictionaryContentId;
            bool? Active;

            var DictionaryName = f.edName.Text;
            var Description = f.edDescription.Text;
            var DataTypeId = 0;
            var IntegerValue =0;
            double FloatValue = 0;
            var TextValue = "";

            if (f.rbInteger.Checked)
            {
                DataTypeId = 1;
                IntegerValue = Convert.ToInt32(f.edInteger.Value);
            }
            else
            if (f.rbFloat.Checked)
            {
                DataTypeId = 2;
                FloatValue = Convert.ToDouble(f.edFloat.Value);
            }
            else
            {
                DataTypeId = 3;
                TextValue = f.edText.Text;
            }

            LocalService.InsertDictionary(out DictionaryId,
                ref DictionaryName, ref Description, ref DataTypeId, 
                out DictionaryContentId, out Active, ref IntegerValue,
                ref FloatValue, ref TextValue);

            
            var drw = (dsDictionary.tbDictionaryRow)
                (tbDictionaryBindingSource.DataSource as dsDictionary).tbDictionary.NewRow();
            drw.Код = (int)DictionaryId;
            drw.Код_типа_данных = DataTypeId;
            drw.Название = DictionaryName;
            drw.Описание = Description;
            (tbDictionaryBindingSource.DataSource as dsDictionary).tbDictionary.Rows.Add(drw);

            var crw = (dsDictionary.tbContentRow)
                (tbDictionaryBindingSource.DataSource as dsDictionary).tbContent.NewRow();
            crw.Код = (int)DictionaryContentId;
            crw.Код_справочника = (int)DictionaryId;
            crw.Целое = IntegerValue;
            crw.Дробное = FloatValue;
            crw.Текстовое = TextValue;
            crw.Активен = (bool)Active;
            (tbDictionaryBindingSource.DataSource as dsDictionary).tbContent.Rows.Add(crw);

            (tbDictionaryBindingSource.DataSource as dsDictionary).tbContent.AcceptChanges();

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbDictionaryBindingSource.Current==null)
                return;
            var rw = (dsDictionary.tbDictionaryRow)
                (tbDictionaryBindingSource.Current as DataRowView).Row;

            if (rw.Внешний)
            {
                MessageBox.Show("Внешний справочник нельзя редактировать.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tbTypes = (tbDictionaryBindingSource.DataSource as dsDictionary).tbTypes;

            var f = new TfUpdateDictionary
                        {
                            Tag = this.Tag,
                            edName = {Text = rw.Название},
                            edDescription = {Text = rw.Описание},
                            lbDataType = {Text = tbTypes.FindByКод(rw.Код_типа_данных).Тип}
                        };

            if (f.ShowDialog() != DialogResult.OK)
                return;
            var DictionaryId=rw.Код;
            var DictionaryName = f.edName.Text;
            var Description = f.edDescription.Text;
            int DataTypeId;

            LocalService.UpdateDictionary(ref DictionaryId, ref DictionaryName, ref Description, out DataTypeId);

            rw.Код = DictionaryId;
            rw.Код_типа_данных = DataTypeId;
            rw.Название = DictionaryName;
            rw.Описание = Description;

            (tbDictionaryBindingSource.DataSource as dsDictionary).AcceptChanges();
        }

        private void btContent_Click(object sender, EventArgs e)
        {
            if (tbDictionaryBindingSource.Current == null)
                return;

            var rw = (dsDictionary.tbDictionaryRow)
                (tbDictionaryBindingSource.Current as DataRowView).Row;

            var tbTypes =
                (tbDictionaryBindingSource.DataSource as dsDictionary).tbTypes;

            var f = new TfDictionaryContent
                        {
                            Tag = this.Tag,
                            tbContentBindingSource =
                                {
                                    Filter = "[Код справочника]=" + rw.Код.ToString(),
                                    DataSource = tbDictionaryBindingSource.DataSource
                                },
                            lbDataType =
                                {
                                    Text = tbTypes.FindByКод(rw.Код_типа_данных).Тип,
                                    Tag = rw.Код_типа_данных
                                },
                            lbDescription = {Text = rw.Описание},
                            lbName = {Text = rw.Название, Tag = rw.Код}
                        };

            foreach (DataGridViewColumn col in f.dbg.Columns)
            {
                if (col.DataPropertyName == "Целое") col.Visible = (rw.Код_типа_данных == 1);
                if (col.DataPropertyName == "Дробное") col.Visible = (rw.Код_типа_данных == 2);
                if (col.DataPropertyName == "Текстовое") col.Visible = (rw.Код_типа_данных == 3);
            }

            f.ShowDialog();
        }

        private void btCompleting_Click(object sender, EventArgs e)
        {
            var f = new TfCompletingPrice
                        {
                            Tag = this.Tag,
                            tbDetailBindingSource = {DataSource = (Tag as TfMain).dsCompleting},
                            tbCompletingBindingSource = {DataSource = (Tag as TfMain).dsCompleting},
                            tbColorBindingSource = {DataSource = (Tag as TfMain).dsCompleting}
                        };
            f.cb_SelectedIndexChanged(f.cb, null);
            f.ShowDialog();
        }
    }
}
