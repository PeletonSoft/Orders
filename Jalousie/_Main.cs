using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using Jalousie.Datasets;
using Microsoft.Win32;
using Jalousie.Properties;
using DBConverting;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.XPath;
using System.Configuration;

namespace Jalousie
{


    public partial class TfMain : Form
    {
        public TfMain()
        {
            InitializeComponent();
        }

        private void TfMain_Shown(object sender, EventArgs e)
        {
            DataRefresh();
            TreeViewInit();
            tv.Focus();
        }

        private void TreeViewInit()
        {
            tv.Nodes.Clear();

            var ndFirms = new TreeNode("Фирмы")
                              {
                                  ImageKey = "Firms",
                                  SelectedImageKey = "Firms"
                              };
            tv.Nodes.Add(ndFirms);

            var ndTypes = new TreeNode("Типы")
                              {
                                  ImageKey = "Types", 
                                  SelectedImageKey = "Types"
                              };
            tv.Nodes.Add(ndTypes);

            var fl = dsBlanks.tbFirms.AsEnumerable()
                .Where(x => x.Активен)
                .OrderBy(x => x.Название)
                .ToList();
            foreach (var frw in fl)
            {
                var fnd = new TreeNode(frw.Название)
                              {
                                  Tag = frw.Код,
                                  ImageKey = "CloseFolder",
                                  SelectedImageKey = "OpenFolder"
                              };
                ndFirms.Nodes.Add(fnd);

                var bl = dsBlanks.tbBlanks.AsEnumerable()
                    .Where(x => x.Активен && x.Код_фирмы == frw.Код)
                    .OrderBy(x => x.Описание)
                    .ToList();
                foreach (var brw in bl)
                {
                    var trw = dsBlanks.tbTypes.FindByКод(brw.Код_типа);
                    if (!trw.Активен) 
                        break;
                    var bnd = new TreeNode(trw.Название + " " + brw.Описание)
                                  {
                                      Tag = brw.Код,
                                      ImageKey = "Blank",
                                      SelectedImageKey = "Blank"
                                  };
                    fnd.Nodes.Add(bnd);
                }
            }

            var tl = dsBlanks.tbTypes.AsEnumerable()
                .Where(x => x.Активен)
                .OrderBy(x => x.Название)
                .ToList();
            foreach (var trw in tl)
            {
                var tnd = new TreeNode(trw.Название)
                              {
                                  Tag = trw.Код,
                                  ImageKey = "CloseFolder",
                                  SelectedImageKey = "OpenFolder"
                              };
                ndTypes.Nodes.Add(tnd);


                var bl = dsBlanks.tbBlanks.AsEnumerable()
                    .Where(x => x.Активен && x.Код_типа == trw.Код)
                    .ToList();
                foreach (var brw in bl)
                {
                    var frw = dsBlanks.tbFirms.FindByКод(brw.Код_фирмы);
                    if (!frw.Активен) break;

                    var bnd = new TreeNode(frw.Название + " " + brw.Описание)
                                  {
                                      Tag = brw.Код,
                                      ImageKey = "Blank",
                                      SelectedImageKey = "Blank"
                                  };
                    tnd.Nodes.Add(bnd);
                }
            }

            ndFirms.ExpandAll();
            ndTypes.ExpandAll();
            tv.Sort();
            tv.SelectedNode = ndFirms;
        }


        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            gbOrder.Visible = tv.SelectedNode.Level >= 2;
            gbType.Visible = tv.SelectedNode.Level == 1 &&
                             tv.SelectedNode.Parent.ImageKey == "Types";
            gbFirm.Visible = tv.SelectedNode.Level == 1 &&
                             tv.SelectedNode.Parent.ImageKey == "Firms";
            btAddOrder.Visible = tv.SelectedNode.Level >= 2;


            if (tv.SelectedNode.Level >= 2)
            {
                var BlankId = (int) tv.SelectedNode.Tag;
                lbBlankId.Text = BlankId.ToString();
                var rwBlank = dsBlanks.tbBlanks.FindByКод(BlankId);
                lbBlankDescription.Text = rwBlank.Описание;
                lbBlankFirm.Text = dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название;
                lbBlankType.Text = dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название;
                tbOrdersBindingSource.Filter = String.Format("[Код бланка]={0:G}", BlankId);
                //btEdit.Enabled = (tbOrdersBindingSource.Count > 0);

            }
            else 
            if (tv.SelectedNode.Level == 0)
                tbOrdersBindingSource.Filter = "";
            else
                switch (tv.SelectedNode.Parent.ImageKey)
                {
                    case "Types":
                        var TypeId = (int) tv.SelectedNode.Tag;
                        lbTypeName.Text = dsBlanks.tbTypes.FindByКод(TypeId).Название;
                        tbOrdersBindingSource.Filter = String.Format(
                            "[Код бланка] IN ({0})",
                            dsBlanks.tbBlanks.AsEnumerable()
                                .Where(x => x.Код_типа == TypeId)
                                .Aggregate("0", (f, s) => f + "," + s.Код.ToString()));
                        break;
                    case "Firms":
                        var FirmId = (int) tv.SelectedNode.Tag;
                        lbFirmName.Text = dsBlanks.tbFirms.FindByКод(FirmId).Название;
                        tbOrdersBindingSource.Filter = String.Format(
                            "[Код бланка] IN ({0})",
                            dsBlanks.tbBlanks.AsEnumerable()
                                .Where(x => x.Код_типа == FirmId)
                                .Aggregate("0", (f, s) => f + "," + s.Код.ToString()));
                        break;
                }

        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode nd = ((TreeView)sender).GetNodeAt(e.Location);
                if (nd != null) ((TreeView)sender).SelectedNode = nd;
                ((TreeView)sender).Focus();
            }
        }

        private void TfMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Settings.Default.OutputPath) ||
                    !Directory.Exists(Settings.Default.TemplatePath))
                {
                    MessageBox.Show(
                        "Рабочий каталог программы не найден. Приложение будет закрыто." + Settings.Default.OutputPath,
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    {
                        Application.Exit();
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show(
                    "Рабочий каталог программы не найден. Приложение будет закрыто.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    Application.Exit();
                    return;
                }
            }

            var doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var settings = doc.XPathSelectElements("/configuration/userSettings//setting[@name=\"ProgramList\"]/value/item");

            LocalService.FileCollection = new List<LocalService.FileCollectionItem>();
            if (settings.Count() > 0)
                LocalService.FileCollection = settings
                    .Select(x => new LocalService.FileCollectionItem
                    {
                        ProgramId = (int)x.Element("program"),
                        FileName = (string)x.Element("filename"),
                        Path = (string)x.Element("path")
                    })
                    .ToList();

            foreach (var r in LocalService.FileCollection)
            {
                if (!Directory.Exists(r.Path))
                {
                    MessageBox.Show(
                        String.Format("Kаталог {0} не найден. Приложение будет закрыто.",r.Path),
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                if (!File.Exists(r.FileName))
                {
                    MessageBox.Show(
                        String.Format("Файл {0} не найден. Приложение будет закрыто.", r.FileName),
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

            }

            var fLogin = new TfLogin();

            dsOrders.Clear();
            dsOrders.tbShops.Load(LocalService.GetShops().Tables[0].CreateDataReader());
            dsOrders.tbUsers.Load(LocalService.GetUsersList().Tables[0].CreateDataReader());

            var rcShop = dsOrders.tbShops.AsEnumerable()
                .OrderBy(x => x.Название)
                .ToList();
            foreach (var rwShop in rcShop)
            {
                var rcUser = dsOrders.tbUsers.AsEnumerable()
                    .Where(x => x.Уровень_доступа == 0 && x.Код_магазина == rwShop.Код && x.Активен)
                    .OrderBy(x => x.ФИО)
                    .ToList();
                if (rcUser.Count <= 0)
                    continue;
                var ndShop = new TreeNode(rwShop.Название)
                                 {
                                     Tag = rwShop.Код,
                                     ImageKey = "Firms",
                                     SelectedImageKey = "Firms"
                                 };
                fLogin.tv.Nodes.Add(ndShop);
                foreach (var rwUser in rcUser)
                {
                    var ndUser = new TreeNode(rwUser.ФИО)
                                     {
                                         Tag = rwUser.Код,
                                         ImageKey = "Users",
                                         SelectedImageKey = "Users"
                                     };
                    ndShop.Nodes.Add(ndUser);
                }
            }
            fLogin.tv.ExpandAll();
            fLogin.tv.SelectedNode = fLogin.tv.Nodes[0];

            if (fLogin.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            LocalService.UserId = Convert.ToInt32(fLogin.tv.SelectedNode.Tag);
            LocalService.ShopId = Convert.ToInt32(fLogin.tv.SelectedNode.Parent.Tag);
            Text = String.Format("Жалюзи-заказы - {0:G} ({1:G})",
                fLogin.tv.SelectedNode.Text, fLogin.tv.SelectedNode.Parent.Text);

            edFrom.Value = DateTime.Now.AddMonths(-1);
            edTo.Value = DateTime.Now.AddDays(1);
            

        }

        private void sbFirms_Click(object sender, EventArgs e)
        {
            var f = new TfFirmsList {Tag = this, tbFirmsBindingSource = {DataSource = dsBlanks}};
            f.ShowDialog();
            TreeViewInit();
            tv.Focus();
        }

        private void tbBlanks_Click(object sender, EventArgs e)
        {
            var f = new TfBlanksList
                        {
                            Tag = this,
                            tbFirmsBindingSource = {DataSource = dsBlanks},
                            tbBlanksBindingSource = {DataSource = dsBlanks},
                            tbTypesBindingSource = {DataSource = dsBlanks}
                        };
            f.ShowDialog();
            TreeViewInit();
            tv.Focus();
        }

        private void tbDictionary_Click(object sender, EventArgs e)
        {
            var f = new TfDictionary
                        {
                            Tag = this,
                            tbDictionaryBindingSource = {DataSource = dsDictionary},
                            tbTypesBindingSource = {DataSource = dsDictionary}
                        };
            f.ShowDialog();       
        }

        private void tbTypes_Click(object sender, EventArgs e)
        {
            var f = new TfTypesList {Tag = this, tbTypesBindingSource = {DataSource = dsBlanks}};
            f.ShowDialog();
            TreeViewInit();
            tv.Focus();
        }

        private void btAddOrder_Click(object sender, EventArgs e)
        {
            var BlankId = (int)tv.SelectedNode.Tag;
            var rwBlank = dsBlanks.tbBlanks.FindByКод(BlankId);

            var f = new TfInsertOrder
                        {
                            Tag = this,
                            lbBlankId = {Text = BlankId.ToString()},
                            lbBlankDescription = {Text = rwBlank.Описание},
                            lbBlankFirm = {Text = dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название},
                            lbBlankType = { Text = dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название, Tag = rwBlank.Код_типа },
                            tbMountersBindingSource =
                                {
                                    DataSource = dsOrders,
                                    Filter = String.Format
                                        ("[Активен]=1 AND [Уровень доступа]=1 AND [Код магазина]={0:G}",
                                         LocalService.ShopId)
                                },
                            tbUsersBindingSource =
                                {
                                    DataSource = dsOrders,
                                    Filter = String.Format
                                        ("[Активен]=1 AND [Код магазина]={0:G}", LocalService.ShopId)
                                },
                            cbUserId = {SelectedValue = LocalService.UserId}
                        };

            f.cbMounterId.SelectedIndex = -1;

            if (f.ShowDialog() != DialogResult.OK)
                return;

            int? OrderId; // Код заказа
            DateTime? Date; // Дата
            int? State; // Статус
            var ClientId=(int)f.lbClientName.Tag; // Код клиента
            var MounterId=(int?)f.cbMounterId.SelectedValue; // Код установщика
            var UserId = (int)f.cbUserId.SelectedValue; // Код установщика
            //var MountingPeriod=Convert.ToInt32(f.edMountingPeriod.Value); // Срок выполнения
            var AddInfo=f.edAddInfo.Text; // Дополнительная информация
            var Cashless = f.cbCashless.Checked;
            var Whole = f.cbWhole.Checked;
            var IsOrdered = f.cbIsOrdered.Checked;
            var InstallDate = (DateTime?)f.btInstallDate.Tag;
            var express = f.cbExpress.Checked;

            LocalService.InsertOrder(out OrderId, out Date, ref BlankId, ref ClientId, ref MounterId,
                out State, ref InstallDate, ref AddInfo, ref Cashless, ref Whole, ref IsOrdered, ref UserId, ref express);

            try
            {
                var rwOrder = (dsOrders.tbOrdersRow)dsOrders.tbOrders.NewRow();
                rwOrder["Код"] = OrderId.ToDBObject();
                rwOrder["Код бланка"] = BlankId.ToDBObject();
                rwOrder["Код клиента"] = 200;
                rwOrder["Дата"] = Date.ToDBObject();
                rwOrder["Код установщика"] = MounterId.ToDBObject();
                rwOrder["Код сотрудника"] = UserId.ToDBObject();
                rwOrder["Статус"] = State.ToDBObject();
                rwOrder["Дополнительно"] = AddInfo.ToDBObject();
                rwOrder["Срок выполнения"] = 5;
                rwOrder["Опт"] = Whole.ToDBObject();
                rwOrder["Безнал"] = Cashless.ToDBObject();
                rwOrder["Заказной"] = IsOrdered.ToDBObject();
                rwOrder["Дата готовности"] = InstallDate.ToDBObject();
                rwOrder["Срочный"] = express;
                dsOrders.tbOrders.Rows.Add(rwOrder);

                rwOrder["Код"] = OrderId.ToDBObject();
                rwOrder["Код бланка"] = BlankId.ToDBObject();
                rwOrder["Код клиента"] = ClientId.ToDBObject();
                rwOrder["Дата"] = Date.ToDBObject();
                rwOrder["Код установщика"] = MounterId.ToDBObject();
                rwOrder["Код сотрудника"] = UserId.ToDBObject();
                rwOrder["Статус"] = State.ToDBObject();
                rwOrder["Дополнительно"] = AddInfo.ToDBObject();
                rwOrder["Срок выполнения"] = 5;
                rwOrder["Опт"] = Whole.ToDBObject();
                rwOrder["Безнал"] = Cashless.ToDBObject();
                rwOrder["Срочный"] = express;
                rwOrder["Дата готовности"] = InstallDate.ToDBObject();
                rwOrder.ФИО = f.lbClientName.Text;
                rwOrder.Телефон = f.lbClientTel.Text;
                rwOrder.Состояние = dsOrders.tbStates.FindByСостояние((int)State).Название;
                rwOrder.Бланк = dsBlanks.tbBlanks.FindByКод(BlankId).Описание;
                rwOrder.Фирма = dsBlanks.tbFirms.FindByКод
                    (dsBlanks.tbBlanks.FindByКод(BlankId).Код_фирмы).Название;
                rwOrder.Тип = dsBlanks.tbTypes.FindByКод
                    (dsBlanks.tbBlanks.FindByКод(BlankId).Код_типа).Название;
                rwOrder.Код_магазина = LocalService.ShopId;
                rwOrder.Магазин = dsOrders.tbShops.FindByКод(LocalService.ShopId).Название;
                dsOrders.AcceptChanges();
            }
            catch
            {
                DataRefresh();
            }

            
            tbOrdersBindingSource.Position = tbOrdersBindingSource.Find("Код", OrderId);
            MessageBox.Show(String.Format("Заказ был успешно создан и получил №{0:G}.", OrderId),
                "Успешная операция", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OrderView((int)OrderId, true);
            
            
                
        }

        public void OrderView(int OrderId, bool ToEdit)
        {
            if (dsOrders.tbOrders.FindByКод(OrderId) == null) 
                return;

            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;
            var BlankId = rw.Код_бланка;
            var rwBlank = dsBlanks.tbBlanks.FindByКод(BlankId);
            var f = new TfOrderPreview
                        {
                            Tag = this,
                            lbSum = {Text = Convert.ToInt32(0).ToString("N2")},
                            ToEdit = ToEdit,
                            lbBlankId = {Tag = BlankId, Text = BlankId.ToString()},
                            lbBlankDescription = {Text = rwBlank.Описание},
                            lbBlankFirm = {Text = dsBlanks.tbFirms.FindByКод(rwBlank.Код_фирмы).Название},
                            lbBlankType = { Text = dsBlanks.tbTypes.FindByКод(rwBlank.Код_типа).Название, Tag = rwBlank.Код_типа },
                            tbMountersBindingSource = {DataSource = dsOrders},
                            tbUsersBindingSource = {DataSource = dsOrders},
                            tbStatesBindingSource = {DataSource = dsOrders},
                            tbOrdersBindingSource = {DataSource = dsOrders}
                        };

/*
            f.btEdit.Enabled = (rw.Статус == 0);
            f.btMake.Enabled = (rw.Статус == 0);
            f.btDelete.Enabled = (rw.Статус == 0);
*/

            f.tbOrdersBindingSource.Position = f.tbOrdersBindingSource.Find("Код", OrderId);

            f.ViewDataset(OrderId);
            f.UpdateDataset(OrderId);
            f.FillDataset();
            f.ShowDialog();

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbOrdersBindingSource.Current == null)
                return;

            var rw = (dsOrders.tbOrdersRow)
                (tbOrdersBindingSource.Current as DataRowView).Row;
            //var x = LocalService.GetJalousieInstall(rw.Код);
            //MessageBox.Show(x.MinimalSum.ToString() + "-" + x.PercentOfCost.ToString());
            OrderView(rw.Код, false);
        }

        public string TemplateFile(int BlankId)
        {
            return Path.Combine(
                Settings.Default.TemplatePath, 
                String.Format("Бланк №{0:G}.xls", BlankId));
        }

        public string OrderFile(int OrderId)
        {
            return Path.Combine(
                Settings.Default.OutputPath,
                String.Format("Заказ №{0:G}.xls", OrderId));
        }

        public void DataRefresh()
        {
            dsBlanks.Clear();
            dsBlanks.tbFirms.Load(LocalService.GetFirmsList().Tables[0].CreateDataReader());
            dsBlanks.tbTypes.Load(LocalService.GetTypesList().Tables[0].CreateDataReader());
            dsBlanks.tbBlanks.Load(LocalService.GetBlanksList().Tables[0].CreateDataReader());
            dsBlanks.tbProgram.Load(LocalService.GetProgramList().Tables[0].CreateDataReader());
            dsBlanks.tbLinked.Load(LocalService.GetLinkedProgramList().Tables[0].CreateDataReader());

            dsDictionary.Clear();
            dsDictionary.tbTypes.Load(LocalService.GetDataTypesList().Tables[0].CreateDataReader());
            dsDictionary.tbDictionary.Load(LocalService.GetDictionaryList().Tables[0].CreateDataReader());
            dsDictionary.tbContent.Load(LocalService.GetDictionaryContent().Tables[0].CreateDataReader());

            dsBlankStructure.Clear();
            dsBlankStructure.tbAligment.Load(LocalService.GetAlignment().Tables[0].CreateDataReader());
            dsBlankStructure.tbDataTypes.Load(LocalService.GetDataTypesList().Tables[0].CreateDataReader());
            dsBlankStructure.tbBlankStructure.Load(LocalService.GetBlankStructure().Tables[0].CreateDataReader());
            dsBlankStructure.tbOputput.Load(LocalService.GetBlankOutput().Tables[0].CreateDataReader());
            dsBlankStructure.tbOputput.Load(LocalService.GetBlankOutput().Tables[0].CreateDataReader());

            dsOrders.Clear();
            dsOrders.tbShops.Load(LocalService.GetShops().Tables[0].CreateDataReader());
            //dsOrders.tbMounters.Load(LocalService.GetMountersList(3).Tables[0].CreateDataReader());
            dsOrders.tbUsers.Load(LocalService.GetUsersList().Tables[0].CreateDataReader());
            dsOrders.tbStates.Load(LocalService.GetStates().Tables[0].CreateDataReader());
            dsOrders.tbOrders.Load(LocalService.GetOrdersList(edFrom.Value, edTo.Value).Tables[0].CreateDataReader());

            dsConstraints.Clear();
            dsConstraints.tbExpressionType.Load(LocalService.GetExpressionTypeList().Tables[0].CreateDataReader());
            dsConstraints.tbOperations.Load(LocalService.GetOperationList().Tables[0].CreateDataReader());
            dsConstraints.tbConstraints.Load(LocalService.GetConstraints().Tables[0].CreateDataReader());

            dsAdvPrice.Clear();
            dsAdvPrice.tbAdvPrice.Load(LocalService.GetAdvPriceList().Tables[0].CreateDataReader());

            dsCalcField.Clear();
            dsCalcField.tbCalcField.Load(LocalService.GetCalcField().Tables[0].CreateDataReader());

            dsCompleting.Clear();
            dsCompleting.tbCompleting.Load(LocalService.GetCompleting().Tables[0].CreateDataReader());
            dsCompleting.tbColor.Load(LocalService.GetCompletingColor().Tables[0].CreateDataReader());
            dsCompleting.tbDetail.Load(LocalService.GetCompletingDetail().Tables[0].CreateDataReader());

        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

         private void dbgTypes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dbg = (DataGridView)sender;
            var drv = (DataRowView)dbg.Rows[e.RowIndex].DataBoundItem;
            var rw = (dsOrders.tbOrdersRow)drv.Row;
            var Color = e.CellStyle.BackColor;
            switch (rw.Статус)
            {
                case -4: Color = Color.Maroon; break;
                case -1: Color = Color.Black; break;
                case 0: Color = Color.Red; break;
                case 1: Color = Color.Green; break;
                case 2: Color = Color.GreenYellow; break;
                case 3: Color = Color.Gold; break;
                case 4: Color = Color.Maroon; break;
            }
            Color = Color.FromArgb(204 + Color.R / 5, 204 + Color.G / 5, 204 + Color.B / 5);
            e.CellStyle.BackColor = Color;
        }

         private void edTo_CloseUp(object sender, EventArgs e)
         {
             Date_CloseUp();
         }

         private void edFrom_CloseUp(object sender, EventArgs e)
         {
             Date_CloseUp();
         }


         private void Date_CloseUp()
         {

             dsOrders.tbOrders.Clear();
             dsOrders.tbOrders.Load(LocalService.GetOrdersList(edFrom.Value, edTo.Value).Tables[0].CreateDataReader());

         }

         private void edNumder_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyData == Keys.Return)
             {
                 var iFind = tbOrdersBindingSource.Find("Код", Convert.ToInt32(edNumder.Value));
                 if (iFind < 0)
                     MessageBox.Show(String.Format("Заказ №{0:G} не был найден.", Convert.ToInt32(edNumder.Value)),
                                     "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 else
                     tbOrdersBindingSource.Position = iFind;
             }
         }

         private void btExit_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Вы уверены, что хотите завершить работу с программой",
                 "Завершение работы", MessageBoxButtons.YesNoCancel, 
                 MessageBoxIcon.Question) != DialogResult.Yes)
                 return;
             this.Close();
         }

         private void btnPlan_Click(object sender, EventArgs e)
         {
             var inst = new TfTimeTableInstall();
             inst.StartPosition = FormStartPosition.CenterScreen;
             inst.ShowDialog();
         }

    }
}


