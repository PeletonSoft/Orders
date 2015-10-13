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
    public partial class TfFirmsList : Form
    {
        public TfFirmsList()
        {
            InitializeComponent();
        }

        private void TfFirmsList_Shown(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new TfEditFirmsList() { Tag = this.Tag };
            f.Text="Добавление новой фирмы";
            f.cbActive.Checked=true;
            if (f.ShowDialog()!=DialogResult.OK)
                return;

            int? FirmId=null;
            string FirmName = f.edName.Text;
            string Description = f.edDescription.Text;
            int? CodeSupplier= null;
            bool? Active=f.cbActive.Checked;

            LocalService.EditFirmsList(
                ref FirmId, ref FirmName, ref Description, 
                ref CodeSupplier, ref Active, 1);

            var tb = ((dsBlanks)tbFirmsBindingSource.DataSource).tbFirms;
            var rw = (dsBlanks.tbFirmsRow)tb.NewRow();

            rw.Код = (int)FirmId;
            rw.Название = FirmName;
            rw.Описание = Description;
            rw.Активен = (bool)Active;
            rw["Код поставщика"] = CodeSupplier.ToDBObject();

            tb.Rows.Add(rw);
            tb.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbFirmsBindingSource.Count <= 0)
                return;
            var f = new TfEditFirmsList
                        {
                            Tag = this.Tag, 
                            Text = "редактирование информации о фирме"
                        };

            var tb = ((dsBlanks)tbFirmsBindingSource.DataSource).tbFirms;
            var rw = (dsBlanks.tbFirmsRow)((DataRowView)dbg.SelectedRows[0].DataBoundItem).Row;

            f.edName.Text = rw.Название;
            f.edDescription.Text = rw.Описание;
            f.cbActive.Checked = rw.Активен;

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? FirmId = rw.Код;
            var FirmName = f.edName.Text;
            var Description = f.edDescription.Text;
            var CodeSupplier = DBConvert.ToQInt(rw["Код поставщика"]);
            bool? Active = f.cbActive.Checked;

            LocalService.EditFirmsList(
                ref FirmId, ref FirmName, ref Description,
                ref CodeSupplier, ref Active, 0);

            rw.Код = (int)FirmId;
            rw.Название = FirmName;
            rw.Описание = Description;
            rw.Активен = (bool)Active;
            rw["Код поставщика"] = CodeSupplier.ToDBObject();

            tb.AcceptChanges();

        }
    }
}
