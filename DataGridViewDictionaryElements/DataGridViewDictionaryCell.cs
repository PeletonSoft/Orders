using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataGridViewDictionaryElements
{

    internal class DataGridViewDictionaryCell:  DataGridViewTextBoxCell
    {
        public DataGridViewDictionaryCell() : base()
        {
            
        }

        public override void InitializeEditingControl(int rowIndex,
                                                      object initialFormattedValue,
                                                      DataGridViewCellStyle dataGridViewCellStyle)
        {

            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            var ec = DataGridView.EditingControl as DataGridViewDictionaryEditingControl;

            if (OwningColumn is DataGridViewDictionaryColumn)
            {
                var col = OwningColumn as DataGridViewDictionaryColumn;

                ec.DataSource = col.DataSource;
                ec.DisplayMember = col.DisplayMember;
                ec.ValueMember = col.ValueMember;
                ec.DescriptionMember = col.DescriptionMember;

                ec.MaxDropDownItems = col.MaxDropDownItems;
                ec.DropDownDisplayWidth = col.DropDownDisplayWidth;
                ec.DropDownDescriptionWidth = col.DropDownDescriptionWidth;

                ec.DisplayFormat = col.DisplayFormat;
                ec.DescriptionFormat = col.DescriptionFormat;
                ec.Format = col.Format;

                ec.ButtonVisible = col.ButtonVisible;
            }
            ec.SelectedValue = Value;
        }

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDictionaryEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return OwningColumn.ValueType;
            }
        }

        private int? CashedValue = null;
        private string CashedFormattedValue = null;

        protected override object GetFormattedValue(
            object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            if (value == null)
                return null;
            int iValue;
            if (Int32.TryParse(value.ToString(), out iValue))
                if (iValue == CashedValue)
                    return CashedFormattedValue;

            var col = OwningColumn as DataGridViewDictionaryColumn;
            var CurrBS = col.DataSource as BindingSource;
            if (CurrBS == null)
                return null;
            var bs = new BindingSource()
                         {
                             DataSource = CurrBS.DataSource,
                             DataMember = CurrBS.DataMember,
                             Sort = CurrBS.Sort,
                             Filter = CurrBS.Filter
                         };
            var iPos = bs.Find(col.ValueMember, value);
            if (iPos<0)
                return null;
            bs.Position = iPos;
            var row = (bs.Current as DataRowView).Row;
            var sValue = String.IsNullOrEmpty(col.DescriptionMember)
                             ? String.Format(col.Format, row[col.DisplayMember])
                             : String.Format(col.Format, row[col.DisplayMember], row[col.DescriptionMember]);
            if (Int32.TryParse(value.ToString(), out iValue))
            {
                CashedValue = iValue;
                CashedFormattedValue = sValue;
            }
            return sValue;

        }
    }
}
