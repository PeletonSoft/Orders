using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewDictionaryElements
{
    class DataGridViewDictionaryEditingControl : DictionaryComboBox, IDataGridViewEditingControl
    {

        public DataGridViewDictionaryEditingControl()
        {
        }
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
            //this.TextAlign = translateAlignment(dataGridViewCellStyle.Alignment);
        }

        public DataGridView EditingControlDataGridView { get; set; }


        public object EditingControlFormattedValue
        {
            set
            {
                SelectedValue = int.Parse(value.ToString());
            }
            get
            {
                return (SelectedValue ?? "").ToString();
            }

        }

        public int EditingControlRowIndex { get; set; }

        public bool EditingControlValueChanged { get; set; }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return !dataGridViewWantsInputKey;
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.IBeam;
            }

        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }

        }

        public override void OnSelectedIndexChanged(EventArgs e)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true); 
            base.OnSelectedIndexChanged(e);

        }

    }
}
