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
    public partial class TfOrderView : Form
    {
        public TfOrderPreview fOrderPreview;

        public TfOrderView()
        {
            InitializeComponent();
        }

        public void ViewDataset(int OrderId)
        {
            TfMain fMain = (TfMain)Tag;
            if (fMain.dsOrders.tbOrders.FindByКод(OrderId) == null)
                return;

            int BlankId = fMain.dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;

            DataRow[] rwc = fMain.dsBlankStructure.tbBlankStructure.
                Select(String.Format("[Код бланка]={0:G}", BlankId), "[Номер] ASC, [Ячейка] ASC");
            for (int i = 0; i < rwc.Length; i++)
            {
                dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)rwc[i];
                DataColumn dc = dsOrderPreview.tbBlank.Columns.Add(rw.Поле);
                dc.Caption = rw.Надпись;

                switch (rw.Код_типа_данных)
                {
                    case 1:
                        dc.DataType = typeof(int);
                        dc.DefaultValue = rw.Целое;
                        break;
                    case 2:
                        dc.DataType = typeof(double);
                        dc.DefaultValue = rw.Дробное;
                        break;
                    case 3:
                        dc.DataType = typeof(string);
                        dc.MaxLength = 150;
                        dc.DefaultValue = rw.Текстовое;
                        break;
                    case 4:
                            var rwDictionary = fMain.dsDictionary.tbDictionary
                                .AsEnumerable()
                                .Where(x => x.Код == rw.Код_справочника)
                                .ToList()[0];
                            var rwContent = fMain.dsDictionary.tbContent
                                .AsEnumerable()
                                .Where(x =>
                                       x.Код_справочника == rw.Код_справочника &&
                                       x.Код == rw.Справочник)
                                .ToList()[0];

                        switch (rwDictionary.Код_типа_данных)
                        {
                            case 1:
                                dc.DataType = typeof(int);
                                dc.DefaultValue = rwContent.Целое;
                                break;
                            case 2:
                                dc.DataType = typeof(double);
                                dc.DefaultValue = rwContent.Дробное;
                                break;
                            case 3:
                                dc.DataType = typeof(string);
                                dc.MaxLength = 150;
                                dc.DefaultValue = rwContent.Текстовое;
                                break;
                        }
                        break;
                }
                DataGridViewTextBoxColumn dbgcol = new DataGridViewTextBoxColumn();
                dbgcol.DataPropertyName = rw.Поле;
                dbgcol.HeaderText = rw.Надпись;
                dbgcol.Width = rw.Ширина;
                dbgcol.DefaultCellStyle.Format = rw.Формат;
                dbgcol.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)rw.Код_выравнивания;
                dbgcol.ReadOnly = true;
                dbgBlank.Columns.Insert(i, dbgcol);
            }
            dsOrderPreview.AcceptChanges();
        }

        public void FillDataset()
        {
            var fMain = (TfMain)Tag;

            dsOrderPreview.Clear();
            foreach (var rwPosition in fOrderPreview.dsOrderContent.tbPositions)
            {
                var rwBlank = (dsOrderPreview.tbBlankRow)
                    dsOrderPreview.tbBlank.NewRow();
                rwBlank.Код = rwPosition.Код;
                rwBlank.Количество = rwPosition.Количество;
                rwBlank.Цена = rwPosition.Цена;
                rwBlank["Дата отправки"] = rwPosition["Дата отправки"];
                rwBlank["Дата получения"] = rwPosition["Дата получения"];

                var rc = fOrderPreview.dsOrderContent.tbDetails
                    .AsEnumerable()
                    .Where(x => x.Код_позиции == rwPosition.Код)
                    .ToList();
                foreach (var rwDetail in rc)
                {
                    var rwStructure =
                        fMain.dsBlankStructure.tbBlankStructure.FindByКод(rwDetail.Код_структуры);
                    if (rwStructure == null) continue;
                    if (dsOrderPreview.tbBlank.Columns.IndexOf(rwStructure.Поле) < 0) continue;
                    int iCol = dsOrderPreview.tbBlank.Columns.IndexOf(rwStructure.Поле);

                    switch (rwStructure.Код_типа_данных)
                    {
                        case 1:
                            rwBlank[iCol] = rwDetail.Целое;
                            break;
                        case 2:
                            rwBlank[iCol] = rwDetail.Дробное;
                            break;
                        case 3:
                            rwBlank[iCol] = rwDetail.Текстовое;
                            break;
                        case 4:
                            var rwDictionary = fMain.dsDictionary.tbDictionary
                                .AsEnumerable()
                                .Where(x => x.Код == rwStructure.Код_справочника)
                                .ToList()[0];
                            var rwContent = fMain.dsDictionary.tbContent
                                .AsEnumerable()
                                .Where(x =>
                                       x.Код_справочника == rwStructure.Код_справочника &&
                                       x.Код == rwDetail.Справочник)
                                .ToList()[0];

                            switch (rwDictionary.Код_типа_данных)
                            {
                                case 1:
                                    rwBlank[iCol] = rwContent.Целое;
                                    break;
                                case 2:
                                    rwBlank[iCol] = rwContent.Дробное;
                                    break;
                                case 3:
                                    rwBlank[iCol] = rwContent.Текстовое;
                                    break;
                            }
                            break;
                    }
                }

                dsOrderPreview.tbBlank.Rows.Add(rwBlank);
            }
            dsOrderPreview.tbBlank.AcceptChanges();
        }

        private void tbBlankBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            double Sum = 0;
            foreach (DataRow rw in dsOrderPreview.tbBlank.Rows)
                Sum += (double)rw["Цена"] * (double)rw["Количество"] * (1 - (double)rw["Скидка"] / 100);
            lbSum.Text = Sum.ToString("N2");
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
