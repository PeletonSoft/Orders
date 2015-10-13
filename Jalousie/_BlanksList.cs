using System;
using System.Data;
using System.Windows.Forms;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfBlanksList : Form
    {
        public TfBlanksList()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new TfEditBlanksList
                        {
                            Tag = this.Tag,
                            Text = "Добавление нового бланка",
                            tbFirmsBindingSource =
                                {
                                    DataSource = tbFirmsBindingSource.DataSource,
                                    Filter = "[Активен]=1"
                                },
                            tbTypesBindingSource =
                                {
                                    DataSource = tbTypesBindingSource.DataSource,
                                    Filter = "[Активен]=1"
                                },
                            cbActive = {Checked = true}
                        };

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? BlankId=(int)f.edBlankId.Value;
            int? FirmId=(int)f.cbFirmId.SelectedValue;
            int? TypeId = (int)f.cbTypeId.SelectedValue;
            var Description=f.edDescription.Text;
            int? RowFirstPosition=(int)f.edRowFirstPosition.Value;
            int? RowPositionsMaximum=(int)f.edRowPositionsMaximum.Value;
	        var CellDraftBlank=f.edCellDraftBlank.Text;
            var CellOrderId=f.edCellOrderId.Text;
            var CellDate=f.edCellDate.Text;
	        var CellClientName=f.edCellClientName.Text;
            var CellClientTel=f.edCellClientTel.Text;
            var CellMounter= f.edCellMounter.Text;
            var CellOrderSum=f.edCellOrderSum.Text;
            var CellOrderPrepayment=f.edCellOrderPrepayment.Text;
            var CellMountingPeriod = f.edCellMountingPeriod.Text;
	        var ColumnPrice=f.edColumnPrice.Text; 
            var ColumnQuant=f.edColumnQuant.Text;
            var ColumnDiscount = f.edColumnDiscount.Text;
            var CellShopName = f.edCellShopName.Text;
            var CellShopTel = f.edCellShopTel.Text;
            var CellAppInfo = f.edCellAppendInfo.Text;
            var CellEssential = f.edCellEssential.Text;
            bool? Active = f.cbActive.Checked;

            LocalService.EditBlanksList(
                ref BlankId, ref FirmId, ref TypeId,
                ref Description, ref RowFirstPosition, ref RowPositionsMaximum,
                ref CellDraftBlank, ref CellOrderId, ref CellDate,
                ref CellClientName, ref CellClientTel, ref CellMounter,
                ref CellOrderSum, ref CellOrderPrepayment, ref CellMountingPeriod,
                ref ColumnPrice, ref ColumnQuant, ref ColumnDiscount, 
                ref CellShopName, ref CellShopTel, ref CellAppInfo, ref CellEssential, ref Active, 1);

            var tb = ((dsBlanks)tbBlanksBindingSource.DataSource).tbBlanks;
            var rw = (dsBlanks.tbBlanksRow)tb.NewRow();

            rw.Код = (int)BlankId;
            rw.Код_фирмы = (int)FirmId;
            rw.Код_типа = (int)TypeId;
            rw.Описание = Description;
            rw.Первая_позиция = (int)RowFirstPosition;
            rw.Максимум_позиций = (int)RowPositionsMaximum;
            rw.Предварительный_бланк = CellDraftBlank;
            rw.Номер_заказа = CellOrderId;
            rw.Дата = CellDate;
            rw.Клиент = CellClientName;
            rw.Телефон = CellClientTel;
            rw.Установщик = CellMounter;
            rw.Сумма = CellOrderSum;
            rw.Предоплата = CellOrderPrepayment;
            rw.Срок_исполнения = CellMountingPeriod;
            rw.Цена = ColumnPrice;
            rw.Количество = ColumnQuant;
            rw.Скидка = ColumnDiscount;
            rw.Название_магазина = CellShopName;
            rw.Телефон_магазина = CellShopTel;
            rw.Дополнительно = CellAppInfo;
            rw.Реквизиты = CellEssential;
            rw.Активен = (bool)Active;

            tb.Rows.Add(rw);
            tb.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbBlanksBindingSource.Count <= 0)
                return;

            var tb = ((dsBlanks)tbBlanksBindingSource.DataSource).tbBlanks;
            var rw = (dsBlanks.tbBlanksRow)
                ((DataRowView)dbg.SelectedRows[0].DataBoundItem).Row;

            var f = new TfEditBlanksList
                        {
                            Tag = this.Tag,
                            Text = "Редактирование бланка",
                            tbFirmsBindingSource = {DataSource = tbFirmsBindingSource.DataSource},
                            tbTypesBindingSource = {DataSource = tbTypesBindingSource.DataSource},
                            edBlankId =
                                {
                                    Enabled = false,
                                    Value = Convert.ToDecimal(rw.Код)
                                },
                            cbFirmId = {SelectedValue = rw.Код_фирмы},
                            cbTypeId = {SelectedValue = rw.Код_типа},
                            edDescription = {Text = rw.Описание},
                            edRowFirstPosition = {Value = Convert.ToDecimal(rw.Первая_позиция)},
                            edRowPositionsMaximum = {Value = Convert.ToDecimal(rw.Максимум_позиций)},
                            edCellDraftBlank = {Text = rw.Предварительный_бланк},
                            edCellOrderId = {Text = rw.Номер_заказа},
                            edCellDate = {Text = rw.Дата},
                            edCellClientName = {Text = rw.Клиент},
                            edCellClientTel = {Text = rw.Телефон},
                            edCellMounter = {Text = rw.Установщик},
                            edCellOrderSum = {Text = rw.Сумма},
                            edCellOrderPrepayment = {Text = rw.Предоплата},
                            edCellMountingPeriod = {Text = rw.Срок_исполнения},
                            edColumnPrice = {Text = rw.Цена},
                            edColumnQuant = {Text = rw.Количество},
                            cbActive = {Checked = rw.Активен},
                            edColumnDiscount = {Text = rw.Скидка},
                            edCellShopName = {Text = rw.Название_магазина},
                            edCellShopTel = {Text = rw.Телефон_магазина},
                            edCellAppendInfo = {Text = rw.Дополнительно},
                            edCellEssential = {Text = rw.Реквизиты}
                        };

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? BlankId = (int)f.edBlankId.Value;
            int? FirmId = (int)f.cbFirmId.SelectedValue;
            int? TypeId = (int)f.cbTypeId.SelectedValue;
            var Description = f.edDescription.Text;
            int? RowFirstPosition = (int)f.edRowFirstPosition.Value;
            int? RowPositionsMaximum = (int)f.edRowPositionsMaximum.Value;
            var CellDraftBlank = f.edCellDraftBlank.Text;
            var CellOrderId = f.edCellOrderId.Text;
            var CellDate = f.edCellDate.Text;
            var CellClientName = f.edCellClientName.Text;
            var CellClientTel = f.edCellClientTel.Text;
            var CellMounter = f.edCellMounter.Text;
            var CellOrderSum = f.edCellOrderSum.Text;
            var CellOrderPrepayment = f.edCellOrderPrepayment.Text;
            var CellMountingPeriod = f.edCellMountingPeriod.Text;
            var ColumnPrice = f.edColumnPrice.Text;
            var ColumnQuant = f.edColumnQuant.Text;
            var ColumnDiscount = f.edColumnDiscount.Text;
            var CellShopName = f.edCellShopName.Text;
            var CellShopTel = f.edCellShopTel.Text;
            var CellAppInfo = f.edCellAppendInfo.Text;
            var CellEssential = f.edCellEssential.Text;
            bool? Active = f.cbActive.Checked;

            LocalService.EditBlanksList(
                ref BlankId, ref FirmId, ref TypeId,
                ref Description, ref RowFirstPosition, ref RowPositionsMaximum,
                ref CellDraftBlank, ref CellOrderId, ref CellDate,
                ref CellClientName, ref CellClientTel, ref CellMounter,
                ref CellOrderSum, ref CellOrderPrepayment, ref CellMountingPeriod,
                ref ColumnPrice, ref ColumnQuant, ref ColumnDiscount,
                ref CellShopName, ref CellShopTel, ref CellAppInfo, 
                ref CellEssential, ref Active, 0);

            rw.Код = (int)BlankId;
            rw.Код_фирмы = (int)FirmId;
            rw.Код_типа = (int)TypeId;
            rw.Описание = Description;
            rw.Первая_позиция = (int)RowFirstPosition;
            rw.Максимум_позиций = (int)RowPositionsMaximum;
            rw.Предварительный_бланк = CellDraftBlank;
            rw.Номер_заказа = CellOrderId;
            rw.Дата = CellDate;
            rw.Клиент = CellClientName;
            rw.Телефон = CellClientTel;
            rw.Установщик = CellMounter;
            rw.Сумма = CellOrderSum;
            rw.Предоплата = CellOrderPrepayment;
            rw.Срок_исполнения = CellMountingPeriod;
            rw.Цена = ColumnPrice;
            rw.Количество = ColumnQuant;
            rw.Скидка = ColumnDiscount;
            rw.Название_магазина = CellShopName;
            rw.Телефон_магазина = CellShopTel;
            rw.Дополнительно = CellAppInfo;
            rw.Реквизиты = CellEssential;
            rw.Активен = (bool)Active;

            tb.AcceptChanges();

        }

        private void btStructure_Click(object sender, EventArgs e)
        {
            if (tbBlanksBindingSource.Count <= 0) return;
            var tb = tbBlanksBindingSource.DataSource as dsBlanks;
            var rw = (dsBlanks.tbBlanksRow)
                ((DataRowView)dbg.SelectedRows[0].DataBoundItem).Row;

            var f = new TfBlankStructure
                        {
                            Tag = this.Tag,
                            tbBlankStructureBindingSource = {DataSource = (Tag as TfMain).dsBlankStructure},
                            tbDataTypesBindingSource = {DataSource = (Tag as TfMain).dsBlankStructure},
                            tbAligmentBindingSource = {DataSource = (Tag as TfMain).dsBlankStructure},
                            lbBlankId = {Text = rw.Код.ToString(), Tag = rw.Код},
                            lbBlankDescription = {Text = rw.Описание},
                            lbBlankFirm = {Text = tb.tbFirms.FindByКод(rw.Код_фирмы).Название},
                            lbBlankType = {Text = tb.tbTypes.FindByКод(rw.Код_типа).Название},
                            cbBlankActive = {Checked = rw.Активен}
                        };


            f.tbBlankStructureBindingSource.Filter = "[Код бланка]=" + rw.Код.ToString();
            f.ShowDialog();
        }

        private void btConstraints_Click(object sender, EventArgs e)
        {
            if (tbBlanksBindingSource.Count <= 0) 
                return;

            var tb = tbBlanksBindingSource.DataSource as dsBlanks;
            var rw = (dsBlanks.tbBlanksRow)((DataRowView)dbg.SelectedRows[0].DataBoundItem).Row;

            (new TfConstraints
                 {
                     Tag = this.Tag,
                     tbExpressionTypeBindingSource = {DataSource = (Tag as TfMain).dsConstraints},
                     tbOperationsBindingSource = {DataSource = (Tag as TfMain).dsConstraints},
                     tbConstraintsBindingSource =
                         {
                             DataSource = (Tag as TfMain).dsConstraints,
                             Filter = String.Format("[Код бланка]={0:G}", rw.Код)
                         },
                     lbBlankId = {Text = rw.Код.ToString(), Tag = rw.Код},
                     lbBlankDescription = {Text = rw.Описание},
                     lbBlankFirm = {Text = tb.tbFirms.FindByКод(rw.Код_фирмы).Название},
                     lbBlankType = {Text = tb.tbTypes.FindByКод(rw.Код_типа).Название},
                     cbBlankActive = {Checked = rw.Активен}
                 }).ShowDialog();
        }

        private void btPrice_Click(object sender, EventArgs e)
        {
            if (tbBlanksBindingSource.Count <= 0) 
                return;

            var tb = tbBlanksBindingSource.DataSource as dsBlanks;
            var rw = (dsBlanks.tbBlanksRow)
                (dbg.SelectedRows[0].DataBoundItem as DataRowView).Row;

            (new TfAdvPrice
                 {
                     Tag = this.Tag,
                     lbBlankId = {Text = rw.Код.ToString(), Tag = rw.Код},
                     lbBlankDescription = {Text = rw.Описание},
                     lbBlankFirm = {Text = tb.tbFirms.FindByКод(rw.Код_фирмы).Название},
                     lbBlankType = {Text = tb.tbTypes.FindByКод(rw.Код_типа).Название},
                     cbBlankActive = {Checked = rw.Активен},
                     tbAdvPriceBindingSource =
                         {
                             DataSource = (Tag as TfMain).dsAdvPrice,
                             Filter = String.Format("[Код бланка]={0:G}", rw.Код)
                         }
                 }).ShowDialog();

        }
    }
}
