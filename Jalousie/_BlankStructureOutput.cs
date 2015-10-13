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
    public partial class TfBlankStructureOutput : Form
    {
        public TfBlankStructureOutput()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            TfEditBlankStructureOutput f = new TfEditBlankStructureOutput() { Tag = this.Tag };
            if (f.ShowDialog() != DialogResult.OK) return;

            dsBlankStructure.tbBlankStructureRow rwStructurte = (dsBlankStructure.tbBlankStructureRow)
                (tbBlankStructureBindingSource.Current as DataRowView).Row;

            int? BlankOutputId = null; // Код
            string BlankOutputValue = f.edValue.Text; // Значение
            string BlankOutputReplace = f.edReplace.Text; // Замена
            int? StructureId = rwStructurte.Код; // Код структуры

            LocalService.EditBlankOutput(
                ref BlankOutputId, ref BlankOutputValue,
                ref BlankOutputReplace, ref StructureId, 1);

            dsBlankStructure.tbOputputRow rw = (dsBlankStructure.tbOputputRow)
                (Tag as TfMain).dsBlankStructure.tbOputput.NewRow();

            rw.Код = (int)BlankOutputId;
            rw.Значение = BlankOutputValue;
            rw.Замена = BlankOutputReplace;
            rw.Код_структуры = (int)StructureId;

            (Tag as TfMain).dsBlankStructure.tbOputput.Rows.Add(rw);
            (Tag as TfMain).dsBlankStructure.AcceptChanges();

            tbOputputBindingSource.Position =
                tbOputputBindingSource.Find("Код", BlankOutputId);

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbOputputBindingSource.Current == null) return;

            if (MessageBox.Show(
                    "Вы действительно хотите удалить пункт автозамены?\n" +
                    "Если данный пункт будет удален, старые бланки могут быть недействительны.",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            dsBlankStructure.tbOputputRow rw = (dsBlankStructure.tbOputputRow)
                (tbOputputBindingSource.Current as DataRowView).Row;

            int? BlankOutputId = rw.Код; // Код
            string BlankOutputValue = null; // Значение
            string BlankOutputReplace = null; // Замена
            int? StructureId = null; // Код структуры

            LocalService.EditBlankOutput(
                ref BlankOutputId, ref BlankOutputValue,
                ref BlankOutputReplace, ref StructureId, -1);
            rw.Delete();
            (Tag as TfMain).dsBlankStructure.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbOputputBindingSource.Current == null) return;

            dsBlankStructure.tbOputputRow rw = (dsBlankStructure.tbOputputRow)
                (tbOputputBindingSource.Current as DataRowView).Row;

            TfEditBlankStructureOutput f = new TfEditBlankStructureOutput() { Tag = this.Tag };

            f.edValue.Text = rw.Значение; // Значение
            f.edReplace.Text = rw.Замена; // Замена

            if (f.ShowDialog() != DialogResult.OK) return;

            int? BlankOutputId = rw.Код; // Код
            string BlankOutputValue = f.edValue.Text; // Значение
            string BlankOutputReplace = f.edReplace.Text; // Замена
            int? StructureId = rw.Код_структуры; // Код структуры

            LocalService.EditBlankOutput(
                ref BlankOutputId, ref BlankOutputValue,
                ref BlankOutputReplace, ref StructureId, 0);

            rw.Код = (int)BlankOutputId;
            rw.Значение = BlankOutputValue;
            rw.Замена = BlankOutputReplace;
            rw.Код_структуры = (int)StructureId;

            (Tag as TfMain).dsBlankStructure.AcceptChanges();
        }
    }
}
