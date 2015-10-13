using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jalousie.Datasets;
using DBConverting;

namespace Jalousie
{
    public partial class TfDictionaryContent : Form
    {
        public TfDictionaryContent()
        {
            InitializeComponent();
        }

        private void dbg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cn = dbg.CurrentCell.OwningColumn.DataPropertyName;
            var drv = (DataRowView)dbg.CurrentCell.OwningRow.DataBoundItem;
            var rw = (dsDictionary.tbContentRow)drv.Row;
            var tbContent = (dsDictionary.tbContentDataTable)
                (tbContentBindingSource.DataSource as dsDictionary).tbContent;

            if (drv.IsNew && cn == "Активен")
            {
                MessageBox.Show("Вы еще не ввели значение!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                drv.Delete();
                tbContent.AcceptChanges();
                return;
            }

            if (!drv.IsNew && rw.Внешний)
            {
                MessageBox.Show("Внешние поля справочника нельзя редактировать.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbContentBindingSource.CancelEdit();
                return;
            }

            int? DictionaryContentId=0;
            var DictionaryId=(int?)lbName.Tag;
            bool? Active;
            int? IntegerValue;
            double? FloatValue; 
            string TextValue;

            if (drv.IsNew)
            {
                Active = rw.Активен;
                IntegerValue = rw.Целое;
                FloatValue = rw.Дробное;
                TextValue = rw.Текстовое;

                LocalService.EditDictionaryContent(
                    ref DictionaryContentId, ref DictionaryId, ref Active,
                    ref IntegerValue, ref FloatValue, ref TextValue, 1);

                rw.Код = (int)DictionaryContentId;
                rw.Код_справочника = (int)DictionaryId;
                rw.Активен = (bool)Active;
                rw.Целое = (int)IntegerValue;
                rw.Дробное = (double)FloatValue;
                rw.Текстовое = TextValue;
                rw.Внешний = false;

                dbg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                tbContent.AcceptChanges();
            }
            else
            {
                DictionaryContentId = rw.Код;
                DictionaryId = rw.Код_справочника;
                Active = rw.Активен;
                IntegerValue = rw.Целое;
                FloatValue = rw.Дробное;
                TextValue = rw.Текстовое;

                LocalService.EditDictionaryContent(
                    ref DictionaryContentId, ref DictionaryId, ref Active,
                    ref IntegerValue, ref FloatValue, ref TextValue, 0);

                rw.Код = (int)DictionaryContentId;
                rw.Код_справочника = (int)DictionaryId;
                rw.Активен = (bool)Active;
                rw.Целое = (int)IntegerValue;
                rw.Дробное = (double)FloatValue;
                rw.Текстовое = TextValue;

                dbg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                tbContent.AcceptChanges();
            }
        }
    }
}
