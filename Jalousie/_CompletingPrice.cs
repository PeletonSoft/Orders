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
    public partial class TfCompletingPrice : Form
    {
        public TfCompletingPrice()
        {
            InitializeComponent();
        }

        public void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedValue != null)
                tbDetailBindingSource.Filter = "[Код комплектующей]=" + cb.SelectedValue.ToString();
            else
                tbDetailBindingSource.Filter = "";
        }

        private void dbg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tbDetailBindingSource.Current == null) return;
            var rw = (dsCompleting.tbDetailRow)
                (tbDetailBindingSource.Current as DataRowView).Row;

            int? CompletingDetailId = rw.Код;
            int? CompletingId = rw.Код_комплектующей;
            int? ColorId = rw.Код_цвета;
            int? InformationId = rw["Код информации"].ToInt();
            double? Price = rw["Цена"].ToDouble();
            double? WholePrice = rw["Оптовая цена"].ToDouble();

            LocalService.EditCompletingDetail(
                ref CompletingDetailId, ref CompletingId, ref ColorId,
                ref InformationId, ref Price, ref WholePrice, 0);

            rw.Код = (int)CompletingDetailId;
            rw.Код_комплектующей = (int)CompletingId;
            rw.Код_цвета = (int)ColorId;
            rw["Цена"] = Price.ToDBObject();
            rw["Оптовая цена"] = WholePrice.ToDBObject();

            dbg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dsCompleting.AcceptChanges();
        }
    }
}
