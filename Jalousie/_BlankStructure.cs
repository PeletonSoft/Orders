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
    public partial class TfBlankStructure : Form
    {
        public TfBlankStructure()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            TfEditBlankStructure f = new TfEditBlankStructure() { Tag = this.Tag };
            f.tbAligmentBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbDictionaryBindingSource.DataSource = (Tag as TfMain).dsDictionary;
            f.tbContentBindingSource.DataSource = (Tag as TfMain).dsDictionary;
            
            f.Text = "Добавление нового атрибута в бланк";

            int? BlankStructureId=null;
            int? BlankId = (int?)lbBlankId.Tag;
            int? DataTypeId=1;
            int? DefaultIntegerValue=0;
            double? DefaultFloatValue=0;
            string DefaultTextValue="";
            int? DictionaryId=null;
            int? DefaultDictionaryContentId=null;

            if (f.ShowDialog() != DialogResult.OK)
                return;

            bool? Preview = f.cbPreview.Checked;
            string FieldName = f.edFieldName.Text;
            string FieldLabel = f.edFieldLabel.Text;
            string ColumnField = f.edColumnField.Text;
            string FormatField = f.edFormatField.Text;
            int? AlignmentId = (int)f.cbAlignmentId.SelectedValue;
            int? Width = Convert.ToInt32(f.edWidth.Value);
            bool? ReadOnly = f.cbReadOnly.Checked;
            bool? Invisible = f.cbInvisible.Checked;
            int? Numer = Convert.ToInt32(f.edNumer.Value);

            if (f.rbInteger.Checked)
            {
                DataTypeId = 1;
                DefaultIntegerValue = Convert.ToInt32(f.edInteger.Value);
            }

            if (f.rbFloat.Checked)
            {
                DataTypeId = 2;
                DefaultFloatValue = Convert.ToDouble(f.edFloat.Value);
            }

            if (f.rbText.Checked)
            {
                DataTypeId = 3;
                DefaultTextValue = f.edText.Text;
            }

            if (f.rbDictionary.Checked)
            {
                DataTypeId = 4;
                DictionaryId = (int)f.cbDictionaryId.SelectedValue;
                DefaultDictionaryContentId = (int)f.cbDictionaryContentId.SelectedValue;
            }

            LocalService.EditBlankStructure(
                ref BlankStructureId, ref BlankId, ref Preview, ref FieldName, ref DataTypeId,
                ref FieldLabel, ref ColumnField, ref FormatField, ref AlignmentId,
                ref DefaultIntegerValue, ref DefaultFloatValue, ref DefaultTextValue,
                ref DictionaryId, ref DefaultDictionaryContentId, ref Width, 
                ref ReadOnly, ref Invisible, ref Numer, 1);

            dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)
                (Tag as TfMain).dsBlankStructure.tbBlankStructure.NewRow();
            rw.Код = (int)BlankStructureId;
            rw.Код_бланка = (int)BlankId;
            rw.Краткий_обзор = (bool)Preview;
            rw.Невидим = (bool)Invisible;
            rw.Только_чтение = (bool)ReadOnly;
            rw.Поле = FieldName;
            rw.Код_типа_данных = (int)DataTypeId;
            rw.Надпись = FieldLabel;
            rw.Ячейка = ColumnField;
            rw.Формат = FormatField;
            rw.Код_выравнивания = (int)AlignmentId;
            rw.Целое = (int)DefaultIntegerValue;
            rw.Дробное = (double)DefaultFloatValue;
            rw.Текстовое = DefaultTextValue;
            rw["Код справочника"] = DBConvert.ToDBObject(DictionaryId);
            rw["Справочник"] = DBConvert.ToDBObject(DefaultDictionaryContentId);
            rw.Ширина = (int)Width;
            rw.Номер = (int)Numer;

            (Tag as TfMain).dsBlankStructure.tbBlankStructure.Rows.Add(rw);
            (Tag as TfMain).dsBlankStructure.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbBlankStructureBindingSource.Current == null) return;
            TfEditBlankStructure f = new TfEditBlankStructure() { Tag = this.Tag };
            f.tbAligmentBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbDictionaryBindingSource.DataSource = (Tag as TfMain).dsDictionary;
            f.tbContentBindingSource.DataSource = (Tag as TfMain).dsDictionary;

            f.Text = "Редактирование атрибута в бланке";

            dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)
                (tbBlankStructureBindingSource.Current as DataRowView).Row;

            f.cbPreview.Checked = rw.Краткий_обзор;
            f.cbReadOnly.Checked = rw.Только_чтение;
            f.cbInvisible.Checked = rw.Невидим;
            f.edFieldName.Text = rw.Поле;
            f.edFieldLabel.Text = rw.Надпись;
            f.edColumnField.Text = rw.Ячейка;
            f.edFormatField.Text = rw.Формат;
            f.cbAlignmentId.SelectedValue = rw.Код_выравнивания;
            f.edWidth.Value = Convert.ToDecimal(rw.Ширина);
            f.edNumer.Value = Convert.ToDecimal(rw.Номер);

            switch (rw.Код_типа_данных)
            {
                case 1:
                    f.rbInteger.Checked = true;
                    f.edInteger.Value = Convert.ToDecimal(rw.Целое);
                    break;
                case 2:
                    f.rbFloat.Checked = true;
                    f.edFloat.Value = Convert.ToDecimal(rw.Дробное);
                    break;
                case 3:
                    f.rbText.Checked = true;
                    f.edText.Text = rw.Текстовое;
                    break;
                case 4:
                    f.rbDictionary.Checked = true;
                    f.cbDictionaryId.SelectedValue = rw.Код_справочника;
                    f.cbDictionaryContentId.SelectedValue = rw.Справочник;
                    break;
            }

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? BlankStructureId = rw.Код;
            int? BlankId = rw.Код_бланка;
            int? DataTypeId = 1;
            int? DefaultIntegerValue = 0;
            double? DefaultFloatValue = 0;
            string DefaultTextValue = "";
            int? DictionaryId = null;
            int? DefaultDictionaryContentId = null;

            bool? Preview = f.cbPreview.Checked;
            string FieldName = f.edFieldName.Text;
            string FieldLabel = f.edFieldLabel.Text;
            string ColumnField = f.edColumnField.Text;
            string FormatField = f.edFormatField.Text;
            int? AlignmentId = (int)f.cbAlignmentId.SelectedValue;
            int? Width = Convert.ToInt32(f.edWidth.Value);
            bool? ReadOnly = f.cbReadOnly.Checked;
            bool? Invisible = f.cbInvisible.Checked;
            int? Numer = Convert.ToInt32(f.edNumer.Value);

            if (f.rbInteger.Checked)
            {
                DataTypeId = 1;
                DefaultIntegerValue = Convert.ToInt32(f.edInteger.Value);
            }

            if (f.rbFloat.Checked)
            {
                DataTypeId = 2;
                DefaultFloatValue = Convert.ToDouble(f.edFloat.Value);
            }

            if (f.rbText.Checked)
            {
                DataTypeId = 3;
                DefaultTextValue = f.edText.Text;
            }

            if (f.rbDictionary.Checked)
            {
                DataTypeId = 4;
                DictionaryId = (int)f.cbDictionaryId.SelectedValue;
                DefaultDictionaryContentId = (int)f.cbDictionaryContentId.SelectedValue;
            }

            LocalService.EditBlankStructure(
                ref BlankStructureId, ref BlankId, ref Preview, ref FieldName, ref DataTypeId,
                ref FieldLabel, ref ColumnField, ref FormatField, ref AlignmentId,
                ref DefaultIntegerValue, ref DefaultFloatValue, ref DefaultTextValue,
                ref DictionaryId, ref DefaultDictionaryContentId, ref Width,
                ref ReadOnly, ref Invisible, ref Numer, 0);

            rw.Код = (int)BlankStructureId;
            rw.Код_бланка = (int)BlankId;
            rw.Краткий_обзор = (bool)Preview;
            rw.Невидим = (bool)Invisible;
            rw.Только_чтение = (bool)ReadOnly;
            rw.Поле = FieldName;
            rw.Код_типа_данных = (int)DataTypeId;
            rw.Надпись = FieldLabel;
            rw.Ячейка = ColumnField;
            rw.Формат = FormatField;
            rw.Код_выравнивания = (int)AlignmentId;
            rw.Целое = (int)DefaultIntegerValue;
            rw.Дробное = (double)DefaultFloatValue;
            rw.Текстовое = DefaultTextValue;
            rw["Код справочника"] = DBConvert.ToDBObject(DictionaryId);
            rw["Справочник"] = DBConvert.ToDBObject(DefaultDictionaryContentId);
            rw.Ширина = (int)Width;
            rw.Номер = (int)Numer;

            (Tag as TfMain).dsBlankStructure.AcceptChanges();

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbBlankStructureBindingSource.Current == null) return;

            if (MessageBox.Show(
                    "Вы действительно хотите удалить данный атрибут из структуры бланка?\n"+
                    "Если данный атрибут уже использовался, то операция может закончиться провалом.",
                    "Внимание",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3)!=DialogResult.Yes)
                return;
            dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)
                (tbBlankStructureBindingSource.Current as DataRowView).Row;

            int? BlankStructureId = rw.Код;
            int? BlankId = null;
            int? DataTypeId = null;
            int? DefaultIntegerValue = null;
            double? DefaultFloatValue = null;
            string DefaultTextValue = null;
            int? DictionaryId = null;
            int? DefaultDictionaryContentId = null;
            bool? Preview = null;
            string FieldName = null;
            string FieldLabel = null;
            string ColumnField = null;
            string FormatField = null;
            int? AlignmentId = null;
            int? Width = null;
            bool? ReadOnly = null;
            bool? Invisible = null;
            int? Numer = null;

            LocalService.EditBlankStructure(
                ref BlankStructureId, ref BlankId, ref Preview, ref FieldName, ref DataTypeId,
                ref FieldLabel, ref ColumnField, ref FormatField, ref AlignmentId,
                ref DefaultIntegerValue, ref DefaultFloatValue, ref DefaultTextValue,
                ref DictionaryId, ref DefaultDictionaryContentId, ref Width,
                ref ReadOnly, ref Invisible, ref Numer, -1);

            MessageBox.Show("Атрибут был успешно удален из бланка!", "Успешное удаление", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            rw.Delete();
            (Tag as TfMain).dsBlankStructure.AcceptChanges();

        }

        private void btOutput_Click(object sender, EventArgs e)
        {
            if (tbBlankStructureBindingSource.Current == null) return;
            dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)
                (tbBlankStructureBindingSource.Current as DataRowView).Row;

            TfBlankStructureOutput f = new TfBlankStructureOutput { Tag = this.Tag };

            f.tbBlankStructureBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbAligmentBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbOputputBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbBlankStructureBindingSource.Position =
                f.tbBlankStructureBindingSource.Find("Код", rw.Код);
            f.tbOputputBindingSource.Filter = String.Format("[Код структуры]={0:G}", rw.Код);
            f.lbBlankId.Text = lbBlankId.Text;
            f.lbBlankId.Tag = lbBlankId.Tag;
            f.lbBlankDescription.Text = lbBlankDescription.Text;
            f.lbBlankFirm.Text = lbBlankFirm.Text;
            f.lbBlankType.Text = lbBlankType.Text;
            f.cbBlankActive.Checked = cbBlankActive.Checked;

            f.ShowDialog();
        }

        private void btCalcField_Click(object sender, EventArgs e)
        {
            if (tbBlankStructureBindingSource.Current == null) return;
            dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)
                (tbBlankStructureBindingSource.Current as DataRowView).Row;

            TfBlankStructureCalcField f = new TfBlankStructureCalcField { Tag = this.Tag };

            f.tbBlankStructureBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbAligmentBindingSource.DataSource = (Tag as TfMain).dsBlankStructure;
            f.tbCalcFieldBindingSource.DataSource = (Tag as TfMain).dsCalcField;
            f.tbBlankStructureBindingSource.Position =
                f.tbBlankStructureBindingSource.Find("Код", rw.Код);
            f.tbCalcFieldBindingSource.Filter = "[Код структуры]=" + rw.Код;
            f.tbCalcFieldBindingSource.Sort = "[Приоритет] DESC";
            f.lbBlankId.Text = lbBlankId.Text;
            f.lbBlankId.Tag = lbBlankId.Tag;
            f.lbBlankDescription.Text = lbBlankDescription.Text;
            f.lbBlankFirm.Text = lbBlankFirm.Text;
            f.lbBlankType.Text = lbBlankType.Text;
            f.cbBlankActive.Checked = cbBlankActive.Checked;

            f.StructureId = rw.Код;

            f.ShowDialog();
        }
    }
}
