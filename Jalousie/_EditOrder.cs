using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataGridViewDictionaryElements;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfEditOrder : Form
    {
        public TfEditOrder()
        {
            InitializeComponent();
        }

        public void UpdateDataset(int OrderId)
        {
            dsOrderContent.Clear();
            dsOrderContent.tbPositions.Load(LocalService.GetOrderPositions(OrderId).Tables[0].CreateDataReader());
            dsOrderContent.tbDetails.Load(LocalService.GetOrderContent(OrderId).Tables[0].CreateDataReader());
        }

        public void ViewDataset(int BlankId)
        {
            var fMain = (TfMain)Tag;
            var rwc = fMain.dsBlankStructure.tbBlankStructure.
                Select(String.Format("[Код бланка]={0:G}", BlankId), "[Номер] ASC, [Ячейка] ASC");

            var StartCount = dbgOrder.Columns.Count;

            foreach (dsBlankStructure.tbBlankStructureRow rw in rwc)
            {
                //dsBlankStructure.tbBlankStructureRow rw = (dsBlankStructure.tbBlankStructureRow)rwc[i];
                var dc = dsOrderEdit.tbBlank.Columns.Add(rw.Поле);
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
                        dc.DataType = typeof(int);
                        dc.DefaultValue = rw.Справочник;
                        break;
                }

                if (rw.Невидим) 
                    continue;

                if (rw.Код_типа_данных == 4)
                {
                    var rwDictionary = (Tag as TfMain).dsDictionary.tbDictionary.FindByКод(rw.Код_справочника);
                    var bs = new BindingSource
                                 {
                                     DataSource = (Tag as TfMain).dsDictionary,
                                     DataMember = "tbContent",
                                     Filter =
                                         String.Format("[Код справочника]={0:G} AND [Активен]=1", rw.Код_справочника)
                                 };

                    var dbgdbcol = new DataGridViewDictionaryColumn //DataGridViewComboBoxColumn();
                                       {
                                           DataPropertyName = rw.Поле,
                                           HeaderText = rw.Надпись,
                                           Width = rw.Ширина,
                                           DefaultCellStyle =
                                               {Alignment = (DataGridViewContentAlignment) rw.Код_выравнивания},
                                           DataSource = bs,
                                           ValueMember = "Код",
                                           ReadOnly = rw.Только_чтение,
                                           MaxDropDownItems = 30,
                                           DropDownDisplayWidth = Math.Min(rw.Ширина + 100, rw.Ширина*3/2),
                                           DisplayFormat = rw.Формат,
                                           ButtonVisible = bs.Count > 6,
                                           Format = "{0:" + (String.IsNullOrEmpty(rw.Формат) ? "G" : rw.Формат) + "}"
                                       };

                    switch (rwDictionary.Код_типа_данных)
                    {
                        case 1:
                            dbgdbcol.DisplayMember = "Целое";
                            break;
                        case 2:
                            dbgdbcol.DisplayMember = "Дробное";
                            break;
                        case 3:
                            dbgdbcol.DisplayMember = "Текстовое";
                            break;
                    }
                    bs.Sort = String.Format("{0} ASC", dbgdbcol.DisplayMember);
                    dbgOrder.Columns.Insert(dbgOrder.Columns.Count - StartCount, dbgdbcol);

                }
                else
                {

                    var dbgcol = new DataGridViewTextBoxColumn
                                     {
                                         DataPropertyName = rw.Поле,
                                         HeaderText = rw.Надпись,
                                         Width = rw.Ширина,
                                         ReadOnly = rw.Только_чтение,
                                         DefaultCellStyle =
                                             {
                                                 Format = rw.Формат,
                                                 Alignment = (DataGridViewContentAlignment)rw.Код_выравнивания
                                             }
                                     };

                    dbgOrder.Columns.Insert(dbgOrder.Columns.Count - StartCount, dbgcol);
                }
            }
            dsOrderEdit.tbBlank.AcceptChanges();
        }

        public void FillDataset()
        {
            dsOrderEdit.tbBlank.RowChanged -= tbBlank_RowChanged;
            var fMain = (TfMain)Tag;
            dsOrderEdit.Clear();
            foreach (var rwPosition in dsOrderContent.tbPositions)
            {
                var rwBlank = (dsOrderEdit.tbBlankRow) dsOrderEdit.tbBlank.NewRow();
                rwBlank.Количество = rwPosition.Количество;
                rwBlank.Цена = rwPosition.Цена;
                rwBlank.Скидка = rwPosition.Скидка;
                
                var rc = dsOrderContent.tbDetails.Select
                    (String.Format("[Код позиции]={0:G}",rwPosition.Код));
                foreach (dsOrderContent.tbDetailsRow rwDetail in rc)
                {
                    var rwStructure =
                        fMain.dsBlankStructure.tbBlankStructure.FindByКод(rwDetail.Код_структуры);
                    if (rwStructure == null) 
                        continue;
                    if (dsOrderEdit.tbBlank.Columns.IndexOf(rwStructure.Поле) < 0) 
                        continue;
                    var iCol = dsOrderEdit.tbBlank.Columns.IndexOf(rwStructure.Поле);

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
                            rwBlank[iCol] = rwDetail.Справочник;
                            break;
                    }
                }

                dsOrderEdit.tbBlank.Rows.Add(rwBlank);
            }
            dsOrderEdit.tbBlank.AcceptChanges();
            dsOrderEdit.tbBlank.RowChanged += tbBlank_RowChanged;
        }

        private bool Save()
        {
            var fMain = Tag as TfMain;
            var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
            var BlankId = fMain.dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;


            dsOrderEdit.AcceptChanges();
            CalcColor();
            CalcPrice();
            dsOrderEdit.AcceptChanges();
            
            // ограничение по количеству позиций
            if (dsOrderEdit.tbBlank.Rows.Count >
                fMain.dsBlanks.tbBlanks.FindByКод(BlankId).Максимум_позиций)
            {
                MessageBox.Show(
                    "В данном заказе позиций больше, чем может разместиться в бланке.\n"+
                    "Попробуйте перенести лишние позиции в новый заказ.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var lsFail = dsOrderEdit.tbBlank
                .AsEnumerable()
                .Where(x => x.Количество < 0.005)
                .ToList();
            if (lsFail.Count > 0)
            {
                tbBlankBindingSource.Position = tbBlankBindingSource.Find("Код", lsFail[0]["Код"]);
                MessageBox.Show(
                    "Количество заказанных изделий должно быть положительным.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            lsFail = dsOrderEdit.tbBlank
                .AsEnumerable()
                .Where(x => x.Цена < 0.005)
                .ToList();
            if (lsFail.Count > 0)
            {
                tbBlankBindingSource.Position = tbBlankBindingSource.Find("Код", lsFail[0]["Код"]);
                MessageBox.Show(
                    "Цена заказанного изделия не может быть отрицательной.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            lsFail = dsOrderEdit.tbBlank
                .AsEnumerable()
                .Where(x => x.Скидка < -0.005 || x.Скидка > 90.005)
                .ToList();
            if (lsFail.Count > 0)
            {
                tbBlankBindingSource.Position = tbBlankBindingSource.Find("Код", lsFail[0]["Код"]);
                MessageBox.Show(
                    "Скидка на товар должна быть в диапазоне от 0% до 90%.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // ограничения из таблицы ограничений
            var rcConstraints = fMain.dsConstraints.tbConstraints
                .AsEnumerable()
                .Where(x =>
                       x.Код_бланка == BlankId &&
                       x.Активен &&
                       x.Тип_выражения == 3 &&
                       x.Операция == 2)
                .OrderByDescending(x => x.Приоритет)
                .ThenBy(x => x.Код)
                .ToList();

            foreach (var rwConstraint in rcConstraints)
            {
                var rcFail = dsOrderEdit.tbBlank.Select(rwConstraint.Ограничение);
                if (rcFail.Length <= 0) continue;
                tbBlankBindingSource.Position = tbBlankBindingSource.Find("Код", rcFail[0]["Код"]);
                MessageBox.Show(rwConstraint.Сообщение, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // сохранение заказа
            dsOrderSave.Clear();
            foreach (dsOrderEdit.tbBlankRow rwBlank in dsOrderEdit.tbBlank.Rows)
            {
                var rwPosition = (dsOrderSave.tbPositionsRow)
                    dsOrderSave.tbPositions.NewRow();
                rwPosition.Код = rwBlank.Код;
                rwPosition.Количество = rwBlank.Количество;
                rwPosition.Цена = rwBlank.Цена;
                rwPosition.Скидка = rwBlank.Скидка;
                dsOrderSave.tbPositions.Rows.Add(rwPosition);
                dsOrderSave.tbPositions.AcceptChanges();

                foreach (DataColumn col in dsOrderEdit.tbBlank.Columns)
                {
                    if (col.ColumnName == "Цена") continue;
                    if (col.ColumnName == "Количество") continue;
                    if (col.ColumnName == "Код") continue;
                    if (col.ColumnName == "Скидка") continue;
                    if (col.ColumnName == "Номер") continue;

                    var rc = fMain.dsBlankStructure.tbBlankStructure
                        .AsEnumerable()
                        .Where(x => x.Код_бланка == BlankId && x.Поле == col.ColumnName)
                        .ToList();
                    if (rc.Count <= 0) continue;
                    var StructureId = rc[0].Код;
                    var DataTypeId = rc[0].Код_типа_данных;

                    var rwContent = (dsOrderSave.tbContentRow)
                        dsOrderSave.tbContent.NewRow();
                    rwContent.Код_позиции = rwPosition.Код;
                    rwContent.Код_структуры = StructureId;
                    switch (DataTypeId)
                    {
                        case 1:
                            rwContent["Целое"] = rwBlank[col.ColumnName];
                            break;
                        case 2:
                            rwContent["Дробное"] = rwBlank[col.ColumnName];
                            break;
                        case 3:
                            rwContent["Текстовое"] = rwBlank[col.ColumnName];
                            break;
                        case 4:
                            rwContent["Справочник"] = rwBlank[col.ColumnName];
                            break;
                    }
                    dsOrderSave.tbContent.Rows.Add(rwContent);
                    dsOrderSave.tbContent.AcceptChanges();
                }

            }
            dsOrderSave.AcceptChanges();
            bool Ordered;
            LocalService.SaveOrder(OrderId, dsOrderSave, out Ordered);
            MessageBox.Show("Заказ был успешно сохранен.", "Успешное сохранение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть форму не сохраняя заказ.\nПродлолжить действие?",
                "Закрытие без сохранения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                FormClosing -= TfEditOrder_FormClosing;
                DialogResult = DialogResult.Cancel;
            }
        }

        public void TfEditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(MessageBox.Show("Вы хотите закрыть форму.\nСделать сохранение заказа?",
                "Закрытие", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3))
            {
                case DialogResult.Yes:
                    if (Save())
                        DialogResult = DialogResult.OK;
                    else
                        e.Cancel = true;
                    break;
                case DialogResult.No:
                    DialogResult = DialogResult.Cancel;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить заказ и закрыть форму.\nПродлолжить действие?",
                "Закрытие с ссохранением", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes && Save())
            {
                FormClosing -= TfEditOrder_FormClosing;
                DialogResult = DialogResult.OK;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить заказ.\nПродлолжить действие?",
                "Сохранение заказа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes && Save())
            {
                var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
                UpdateDataset(OrderId);
                FillDataset();
            }
        }

        private void tbBlankBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            var Sum = dsOrderEdit.tbBlank
                .AsEnumerable()
                .Where(rw => 
                    rw.RowState != DataRowState.Deleted && 
                    rw.RowState != DataRowState.Detached)
                .Select(rw => 
                    (double) rw["Цена"]*
                    (double) rw["Количество"]*
                    (1 - (double) rw["Скидка"]/100))
                .Sum();
            lbSum.Text = Sum.ToString("N2");

        }

        private void dbgOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("Введены неправильные числовые данные.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false;
            }
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            FormClosing -= TfEditOrder_FormClosing;
            DialogResult = DialogResult.No;
        }

        private void btNext_Click(object sender, EventArgs e)
        {

        }

        private void CalcColor()
        {
            if (dsOrderEdit.tbBlank.Rows.Count <= 0) return;
            dsOrderEdit.tbBlank.RowChanged -= tbBlank_RowChanged;
            try
            {
                int SelectCol = dbgOrder.CurrentCell.ColumnIndex;
                int SelectRow = dbgOrder.CurrentCell.RowIndex;

                dsOrderEdit.AcceptChanges();

                //TfMain fMain = Tag as TfMain;
                int OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
                //int BlankId = fMain.dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;

                var ds = LocalService.MakeStandartColor(OrderId, dsOrderEdit);

                dsOrderEdit.Clear();
                dsOrderEdit.tbBlank.Load(ds.Tables[0].CreateDataReader());

                dbgOrder.CurrentCell = dbgOrder[SelectCol, SelectRow];
            }
            finally
            {
                dsOrderEdit.tbBlank.RowChanged += tbBlank_RowChanged;
            }
        }

        private void tbBlank_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            CalcColor();
            CalcPrice();
        }

        private void btComplete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить заказ и расчитать комплектование.\nПродлолжить действие?",
                "Комплектование заказа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes && Save())
            {
                int OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
                UpdateDataset(OrderId);
                FillDataset();
                var f = new TfOrderCalculation() { Tag = this.Tag };
                f.Calculation(OrderId);
                f.ShowDialog();
            }
        }

        private void CalcPrice()
        {
            if (dsOrderEdit.tbBlank.Rows.Count <= 0) return;
            dsOrderEdit.tbBlank.RowChanged -= tbBlank_RowChanged;
            try
            {
                var SelectCol = dbgOrder.CurrentCell.ColumnIndex;
                var SelectRow = dbgOrder.CurrentCell.RowIndex;

                dsOrderEdit.AcceptChanges();

                //var fMain = Tag as TfMain;
                var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
                var ds = LocalService.MakePrice(OrderId, dsOrderEdit);

                dsOrderEdit.Clear();
                dsOrderEdit.tbBlank.Load(ds.Tables[0].CreateDataReader());

                dbgOrder.CurrentCell = dbgOrder[SelectCol, SelectRow];
            }
            finally
            {
                dsOrderEdit.tbBlank.RowChanged += tbBlank_RowChanged;
            }
        }

        private void TfEditOrder_Load(object sender, EventArgs e)
        {

        }


    }
}
