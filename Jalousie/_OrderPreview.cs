using System;
using System.Data;
using System.Windows.Forms;
using Jalousie.Datasets;
using Jalousie.Properties;
using System.Linq;
using DBConverting;

namespace Jalousie
{
    public partial class TfOrderPreview : Form
    {
        public bool ToEdit = false;

        public TfOrderPreview()
        {
            InitializeComponent();
        }

        public void UpdateDataset(int OrderId)
        {
            dsOrderContent.Clear();
            dsOrderContent.tbPositions.Load(LocalService.GetOrderPositions(OrderId).Tables[0].CreateDataReader());
            dsOrderContent.tbDetails.Load(LocalService.GetOrderContent(OrderId).Tables[0].CreateDataReader());

            int BlankId = (Tag as TfMain).dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;

            var rw = (dsOrders.tbOrdersRow)(tbOrdersBindingSource.Current as DataRowView).Row;

            btEdit.Enabled = (rw.Статус == 0);
            btMake.Enabled = (rw.Статус == 0);
            btDelete.Enabled = (rw.Статус == 0);


            btFile.Enabled = (Tag as TfMain)
                    .dsBlanks.tbLinked
                    .AsEnumerable()
                    .Where(x => x.Код_бланка == BlankId)
                    .ToList().Count > 0;

            btWriteOff.Enabled = (rw.Статус == 3);
            btEditTitle.Enabled = (rw.Статус >= 0) && (rw.Статус <= 3);

            UpdatePrePayment(OrderId);
        }

        public void UpdatePrePayment(int OrderId)
        {
            dsPrePayment.Clear();
            dsPrePayment.tbPrepayment.Load(LocalService.GetOrderPrePayment(OrderId).Tables[0].CreateDataReader());

            var Sum =
                dsOrderContent.tbPositions.AsEnumerable()
                    .Aggregate((double) 0, 
                        (f, s) => f +
                            (double) s["Цена"]*
                            (double) s["Количество"]*
                            (1 - (double) s["Скидка"]/100));
            
            lbSum.Text = Sum.ToString("N2");

            var PrePayment = dsPrePayment.tbPrepayment.AsEnumerable()
                .Aggregate((double) 0,
                           (f, s) => f + (s.Возврат ? -1 : 1)*s.Сумма);
            lbPrePayment.Text = PrePayment.ToString("N2");
            lbRest.Text = (Sum - PrePayment).ToString("N2");
        }

        public void ViewDataset(int OrderId)
        {
            var fMain = (TfMain)Tag;
            if (fMain.dsOrders.tbOrders.FindByКод(OrderId) == null)
                return;

            var BlankId = fMain.dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;

            var rwc = fMain.dsBlankStructure.tbBlankStructure
                .AsEnumerable()
                .Where(x => x.Краткий_обзор && x.Код_бланка == BlankId)
                .OrderBy(x => x.Номер)
                .ThenBy(x => x.Ячейка)
                .ToList();
            for (var i = 0; i < rwc.Count; i++)
            {
                var rw = rwc[i];
                var dc = dsOrderPreview.tbBlank.Columns.Add(rw.Поле);
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
                            .Where(x => x.Код_справочника==rw.Код_справочника && x.Код==rw.Справочник)
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
                var dbgcol = new DataGridViewTextBoxColumn
                                 {
                                     DataPropertyName = rw.Поле,
                                     HeaderText = rw.Надпись,
                                     Width = rw.Ширина,
                                     ReadOnly = true,
                                     DefaultCellStyle =
                                         {
                                             Format = rw.Формат,
                                             Alignment = (DataGridViewContentAlignment) rw.Код_выравнивания
                                         }
                                 };
                dbgBlank.Columns.Insert(i, dbgcol);
            }
            dsOrderPreview.AcceptChanges();
        }

        public void FillDataset()
        {
            var fMain = (TfMain)Tag;

            dsOrderPreview.Clear();
            foreach (dsOrderContent.tbPositionsRow rwPosition in dsOrderContent.tbPositions.Rows)
            {
                var rwBlank = (dsOrderPreview.tbBlankRow)dsOrderPreview.tbBlank.NewRow();
                rwBlank.Код = rwPosition.Код;
                rwBlank.Количество = rwPosition.Количество;
                rwBlank.Цена = rwPosition.Цена;
                rwBlank.Скидка = rwPosition.Скидка;
                rwBlank["Дата отправки"] = rwPosition["Дата отправки"];
                rwBlank["Дата получения"] = rwPosition["Дата получения"];

                var rc = dsOrderContent.tbDetails.AsEnumerable()
                    .Where(x => x.Код_позиции == rwPosition.Код)
                    .ToList();

                foreach (var rwDetail in rc)
                {
                    var rwStructure = fMain.dsBlankStructure.tbBlankStructure.FindByКод(rwDetail.Код_структуры);
                    if (rwStructure == null) 
                        continue;
                    if (dsOrderPreview.tbBlank.Columns.IndexOf(rwStructure.Поле) < 0) 
                        continue;
                    var iCol = dsOrderPreview.tbBlank.Columns.IndexOf(rwStructure.Поле);

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

        private void btEdit_Click(object sender, EventArgs e)
        {
            var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
            var BlankId = (Tag as TfMain).dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;
            var rwBlank = (Tag as TfMain).dsBlanks.tbBlanks.FindByКод(BlankId);

            var f = new TfEditOrder
                        {
                            Tag = this.Tag,
                            lbSum = {Text = Convert.ToInt32(0).ToString("N2")},
                            lbBlankId =
                                {
                                    Tag = BlankId,
                                    Text = BlankId.ToString()
                                },
                            lbBlankDescription = {Text = rwBlank.Описание},
                            lbBlankFirm =
                                {Text = (Tag as TfMain).dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название},
                            lbBlankType = {Text = (Tag as TfMain).dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название},
                            tbMountersBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbUsersBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbStatesBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbOrdersBindingSource = {DataSource = (Tag as TfMain).dsOrders}
                        };


            f.tbOrdersBindingSource.Position = f.tbOrdersBindingSource.Find("Код", OrderId);

            f.UpdateDataset(OrderId);
            f.ViewDataset(BlankId);
            f.FillDataset();
            f.ShowDialog();
            
            UpdateDataset(OrderId);
            FillDataset();
        }

        private void tbBlankBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

            var Sum = dsOrderPreview.tbBlank.AsEnumerable()
                    .Aggregate((double)0,
                        (f, s) => f +
                            (double)s["Цена"] *
                            (double)s["Количество"] *
                            (1 - (double)s["Скидка"] / 100));
            lbSum.Text = Sum.ToString("N2");
        }

        private void btView_Click(object sender, EventArgs e)
        {
            var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
            var BlankId = (Tag as TfMain).dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;
            var rwBlank = (Tag as TfMain).dsBlanks.tbBlanks.FindByКод(BlankId);

            var f = new TfOrderView
                        {
                            Tag = this.Tag,
                            fOrderPreview = this,
                            lbSum = {Text = Convert.ToInt32(0).ToString("N2")},
                            lbBlankId =
                                {
                                    Tag = BlankId,
                                    Text = BlankId.ToString()
                                },
                            lbBlankDescription = {Text = rwBlank.Описание},
                            lbBlankFirm =
                                {Text = (Tag as TfMain).dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название},
                            lbBlankType = {Text = (Tag as TfMain).dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название},
                            tbMountersBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbUsersBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbStatesBindingSource = {DataSource = (Tag as TfMain).dsOrders},
                            tbOrdersBindingSource = {DataSource = (Tag as TfMain).dsOrders}
                        };

            f.tbOrdersBindingSource.Position = f.tbOrdersBindingSource.Find("Код", OrderId);

            f.ViewDataset(OrderId);
            f.FillDataset();
            f.ShowDialog();

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите удалить данный заказ?\n"+
                "После этой операции заказ нельзя будет уже ни изменить, ни оформить.",
                "Удаление заказа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3) != DialogResult.Yes) 
                return;
            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;

            var OrderId = rw.Код; // Код заказа
            string Message = null; // Сообщение
            bool? Error;

            LocalService.DeleteOrder(OrderId, out Error, out Message);

            if ((bool)Error)
            {
                MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rw.Статус = -1;
            (Tag as TfMain).dsOrders.AcceptChanges();

            btEdit.Enabled = (rw.Статус == 0);
            btMake.Enabled = (rw.Статус == 0);
            btDelete.Enabled = (rw.Статус == 0);
            btEditTitle.Enabled = (rw.Статус >= 0) && (rw.Статус <= 3);

            MessageBox.Show(
                "Заказ был успешно удален.\nНе забудьте вернуть предоплаты, если они есть.", 
                "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
        }

        private void btMake_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите оформить данный заказ?\n" +
                "После этой операции заказ будет уже заказ запущен в исполнение.",
                "Оформление заказа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;

            if (dsOrderPreview.tbBlank.Rows.Count <=0)
            {
                MessageBox.Show(
                    "В заказе нет ни одной позиции.\nТакой заказ нельзя оформить.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dsOrderPreview.tbBlank.Select("[Цена]*[Количество]<=0.005").Length > 0)
            {
                MessageBox.Show(
                    "В некоторых позициях не указана цена.\nТакой заказ нельзя оформить.", 
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rw.IsДата_готовностиNull())
            {
                // Добавление в график
                var inst = new TfTimeTableInstall {OrderId = rw.Код, TypeId = (int?) lbBlankType.Tag};
                inst.StartPosition = FormStartPosition.CenterScreen;
                if (inst.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Заказ не был добавлен в график. Дальнейшее оформление невозможно.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var fMain = (TfMain)Tag;
                var _OrderId = rw.Код;
                var Date = rw.Дата; // Дата
                var ClientId =rw.Код_клиента; // Код клиента
                var UserId = rw.Код_сотрудника; // Код установщика
                var MounterId = !rw.IsКод_установщикаNull() ? (int?)rw.Код_установщика : null; // Код установщика
                var InstallDate = inst.InstallDate; // Срок выполнения
                var AddInfo = rw.Дополнительно; // Дополнительная информация
                var Cashless = rw.Безнал;
                var Whole = rw.Опт;
                var IsOrdered = rw.Заказной;
                var Express = rw.Срочный;
                
                LocalService.UpdateOrdersList(
                    ref _OrderId, ref Date, ref ClientId, ref MounterId,
                    ref InstallDate, ref AddInfo, ref Cashless, ref Whole, ref IsOrdered, ref UserId,ref Express);

                rw["Дата готовности"] = InstallDate.ToDBObject();

                fMain.dsOrders.AcceptChanges();
            }

            int OrderId = rw.Код; // Код заказа
            string Message = null; // Сообщение
            bool? Error;

            LocalService.MakeOrder(OrderId, out Error, out Message);


            if ((bool)Error)
            {
                MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rw.Статус = 1;

            (Tag as TfMain).dsOrders.AcceptChanges();

            btEdit.Enabled = (rw.Статус == 0);
            btMake.Enabled = (rw.Статус == 0);
            btDelete.Enabled = (rw.Статус == 0);
            btWriteOff.Enabled = (rw.Статус == 3);
            btEditTitle.Enabled = (rw.Статус >= 0) && (rw.Статус <= 3);

            MessageBox.Show("Заказ был успешно оформлен.", "Успешное оформление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            var rwOrder = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;
            var OrderId = rwOrder.Код;

            JalousiePrint.Print.Database = Settings.Default.ShopConnectionString;
            JalousiePrint.Print.TemplatePath = Settings.Default.TemplatePath;
            JalousiePrint.Print.OutputPath = Settings.Default.OutputPath;
            JalousiePrint.Print.ViewFile(JalousiePrint.Print.JalousiePrint(OrderId));

        }

        private void btPrePayment_Click(object sender, EventArgs e)
        {
            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;

            var OrderId = rw.Код; // Код заказа
            UpdatePrePayment(OrderId);

            var f = new TfPrePayment
                        {
                            Tag = this.Tag,
                            tbPrepaymentBindingSource = {DataSource = dsPrePayment},
                            lbSum = {Text = lbPrePayment.Text}
                        };
            f.ShowDialog();
        }

        private void btCalculation_Click(object sender, EventArgs e)
        {
            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;

            var OrderId = rw.Код; // Код заказа

            var f = new TfOrderCalculation() { Tag = this.Tag };
            f.Calculation(OrderId);
            f.ShowDialog();
        }

        private void btWriteOff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите списать данный заказ?\n" +
                "После этой операции заказ уже нельзя будет возвратить.",
                "Списание заказа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;

            var OrderId = rw.Код; // Код заказа
            string Message = null; // Сообщение
            bool? Error;

            LocalService.WriteOffOrder(OrderId, out Error, out Message);

            if ((bool)Error)
            {
                MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rw.Статус = 4;
            (Tag as TfMain).dsOrders.AcceptChanges();

            btEdit.Enabled = (rw.Статус == 0);
            btMake.Enabled = (rw.Статус == 0);
            btDelete.Enabled = (rw.Статус == 0);
            btWriteOff.Enabled = (rw.Статус == 3);
            btEditTitle.Enabled = (rw.Статус >= 0) && (rw.Статус <= 3);

            MessageBox.Show(
                "Заказ был успешно списан.",
                "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
        }

        private void TfOrderPreview_Shown(object sender, EventArgs e)
        {
            if (ToEdit)
                btEdit_Click(btEdit, null);

        }

        private void btEditTitle_Click(object sender, EventArgs e)
        {

            var fMain = (TfMain) Tag;

            var OrderId = ((tbOrdersBindingSource.Current as DataRowView).Row as dsOrders.tbOrdersRow).Код;
            var BlankId = fMain.dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;

            var rwBlank = fMain.dsBlanks.tbBlanks.FindByКод(BlankId);
            var rwOrder = fMain.dsOrders.tbOrders.FindByКод(OrderId);

            var f =
                new TfEditOrderTitle
                    {
                        Tag = this.Tag,
                        lbBlankId = {Text = BlankId.ToString()},
                        lbBlankDescription = {Text = rwBlank.Описание},
                        lbBlankFirm = {Text = fMain.dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название},
                        lbBlankType =
                            {Text = fMain.dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название, Tag = rwBlank.Код_типа},
                        tbUsersBindingSource =
                            {
                                DataSource = fMain.dsOrders,
                                Filter = String.Format
                                    ("[Код магазина]={0:G}", rwOrder.Код_магазина)
                            },
                        tbMountersBindingSource =
                            {
                                DataSource = fMain.dsOrders,
                                Filter = String.Format
                                    ("[Активен]=1 AND [Уровень доступа]=1 AND [Код магазина]={0:G}",
                                     rwOrder.Код_магазина)
                            },

                        cbWhole = {Enabled = rwOrder.Статус == 0, Checked = rwOrder.Опт},
                        edAddInfo =
                            {
                                Enabled = rwOrder.Статус == 0,
                                Text = rwOrder.Дополнительно
                            },
                        cbUserId = {SelectedValue = rwOrder.Код_сотрудника},

                        cbCashless = {Checked = rwOrder.Безнал},
                        lbCode = {Text = rwOrder.Код.ToString(), Tag = rwOrder.Код},
                        edDate = {Value = rwOrder.Дата},
                        lbClientName =
                            {
                                Text = rwOrder.ФИО,
                                Tag = rwOrder.Код_клиента
                            },
                        lbClientTel = {Text = rwOrder.Телефон},
                        cbIsOrdered = {Enabled = rwOrder.Статус == 0, Checked = rwOrder.Заказной},
                        cbExpress = {Enabled = rwOrder.Статус == 0, Checked = rwOrder.Срочный},
                        btInstallDate = {Enabled = rwOrder.Статус == 0, Tag = rwOrder["Дата готовности"].ToQDateTime()}
                    };

            if(!rwOrder.IsКод_установщикаNull())
            {
                f.cbMounterId.SelectedValue = rwOrder.Код_установщика;
            }
            else
            {
                f.cbMounterId.SelectedIndex = -1;
            }

            f.ViewInstallDate();

            if (f.ShowDialog() != DialogResult.OK)
                return;

            var Date = f.edDate.Value; // Дата
            var ClientId = (int)f.lbClientName.Tag; // Код клиента
            var UserId = (int)f.cbUserId.SelectedValue; // Код установщика
            var MounterId = (int?)f.cbMounterId.SelectedValue; // Код установщика
            var InstallDate = (DateTime?)f.btInstallDate.Tag; // Срок выполнения
            var AddInfo = f.edAddInfo.Text; // Дополнительная информация
            var Cashless = f.cbCashless.Checked;
            var Whole = f.cbWhole.Checked;
            var IsOrdered = f.cbIsOrdered.Checked;
            var Express = f.cbExpress.Checked;
            //var InstallDate = (DateTime?)f.btInstallDate.Tag;

            LocalService.UpdateOrdersList(
                ref OrderId, ref Date, ref ClientId, ref MounterId, 
                ref InstallDate, ref AddInfo, ref Cashless, ref Whole, ref IsOrdered, ref UserId,ref Express);

            rwOrder.Дата = Date;
            rwOrder.Код_клиента = ClientId;
            rwOrder["Код установщика"] = (object)MounterId ?? DBNull.Value;
            rwOrder.Код_сотрудника = UserId;
            //rwOrder.Срок_выполнения = MountingPeriod;
            rwOrder.Дополнительно = AddInfo;
            rwOrder.Опт = Whole;
            rwOrder.Безнал = Cashless;
            rwOrder.Заказной = IsOrdered;
            rwOrder.ФИО = f.lbClientName.Text;
            rwOrder.Телефон = f.lbClientTel.Text;
            rwOrder["Дата готовности"] = InstallDate.ToDBObject();
            rwOrder.Срочный = Express;
            fMain.dsOrders.AcceptChanges();
            if (MounterId == null)
            {
                cbMounterId.SelectedIndex = -1;
                fMain.cbMounterId.SelectedIndex = -1;
            }

            
        }

        private void btFile_Click(object sender, EventArgs e)
        {
            var rwOrder = (dsOrders.tbOrdersRow)(tbOrdersBindingSource.Current as DataRowView).Row;
            var OrderId = rwOrder.Код;
            
            var BlankId = (Tag as TfMain).dsOrders.tbOrders.FindByКод(OrderId).Код_бланка;
            var OrderFile = new TfOrderFile()
                                {Tag = this, OrderId = OrderId, BlankId = BlankId, fMain = (Tag as TfMain)};
            OrderFile.ShowDialog();
        }
    }
}
