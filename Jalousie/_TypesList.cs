using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConverting;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfTypesList : Form
    {
        public TfTypesList()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            TfEditTypesList f = new TfEditTypesList() { Tag = this.Tag };
            f.Text="Добавление нового типа жалюзей";
            f.cbActive.Checked=true;
            if (f.ShowDialog()!=DialogResult.OK)
                return;

            int? TypeId=null;
            string TypeName = f.edName.Text;
            string Description = f.edDescription.Text;
            bool? Active=f.cbActive.Checked;

            LocalService.EditTypesList(ref TypeId, ref TypeName, ref Description, ref Active, 1);

            dsBlanks.tbTypesDataTable tb = ((dsBlanks)tbTypesBindingSource.DataSource).tbTypes;
            dsBlanks.tbTypesRow rw = (dsBlanks.tbTypesRow)tb.NewRow();

            rw.Код = (int)TypeId;
            rw.Название = TypeName;
            rw.Описание = Description;
            rw.Активен = (bool)Active;

            tb.Rows.Add(rw);
            tb.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            
            if (tbTypesBindingSource.Count <= 0)
                return;
            TfEditTypesList f = new TfEditTypesList() { Tag = this.Tag };
            f.Text = "Редактирование информации о типе жалюзей";

            dsBlanks.tbTypesDataTable tb = ((dsBlanks)tbTypesBindingSource.DataSource).tbTypes;
            dsBlanks.tbTypesRow rw = (dsBlanks.tbTypesRow)((DataRowView)dbg.SelectedRows[0].DataBoundItem).Row;

            f.edName.Text = rw.Название;
            f.edDescription.Text = rw.Описание;
            f.cbActive.Checked = rw.Активен;

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? TypeId = rw.Код;
            string TypeName = f.edName.Text;
            string Description = f.edDescription.Text;
            bool? Active = f.cbActive.Checked;

            LocalService.EditTypesList(ref TypeId, ref TypeName, ref Description, ref Active, 0);

            rw.Код = (int)TypeId;
            rw.Название = TypeName;
            rw.Описание = Description;
            rw.Активен = (bool)Active;

            tb.AcceptChanges();
            
        }
    }
}
