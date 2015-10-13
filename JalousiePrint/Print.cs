using System;
using System.Linq;
using System.Windows.Forms;
using JalousiePrint.Data;
using System.IO;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.util;

namespace JalousiePrint
{
    public class Print
    {
        public static string Database = "";
        public static string OutputPath = "";
        public static string TemplatePath = "";

        public static string TemplateFile(int BlankId)
        {
            return Path.Combine(TemplatePath, String.Format("Бланк №{0}.xls", BlankId));
        }

        public static string OutputFile(int OrderId)
        {
            return Path.Combine(OutputPath, String.Format("Заказ №{0}.xls", OrderId));
        }

        public static string JalousiePrint(int OrderId)
        {
            try
            {
                if (!Directory.Exists(TemplatePath))
                {
                    MessageBox.Show(
                        String.Format("Каталог с шаблонами не найден.\n Проверьте путь: {0}", TemplatePath),
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch
            {
                MessageBox.Show(
                    String.Format("Каталог с шаблонами не найден.\n Проверьте путь: {0}", TemplatePath),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                if (!Directory.Exists(OutputPath))
                {
                    MessageBox.Show(
                        String.Format("Каталог для вывода не найден.\n Проверьте путь: {0}", OutputPath),
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch
            {
                MessageBox.Show(
                    String.Format("Каталог для вывода не найден.\n Проверьте путь: {0}",
                                  OutputPath),
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int  BlankId;

            using (var dc = new JalousieLinqDataContext(Database))
            {
                if (dc.Отчеты_жалюзи_заголовок(OrderId).Count() != 1)
                    return null;
                BlankId = dc.Отчеты_жалюзи_заголовок(OrderId)
                    .Select(x => x.Код_бланка).ToList()[0];
            }

            return JalousiePrint(OrderId, TemplateFile(BlankId), OutputFile(OrderId));

        }

        public static string JalousiePrint(int OrderId, string Template, string Output)
        {
            var Result = DialogResult.Yes;

            if (File.Exists(Output))
            {
                Result = MessageBox.Show(
                    "Данный заказ уже имел сохраненный бланк.\nВы хотите перезаписать его?", "Печать заказа",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                switch (Result)
                {
                    case DialogResult.Yes:
                        File.Delete(Output);
                        break;
                    case DialogResult.Cancel:
                        return null;
                }
            }

            if (Result == DialogResult.Yes)
            {
                try
                {
                    File.Copy(Template, Output, true);
                    Fill(OrderId, Output);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(
                        "Данный заказ уже используется. Его нельзя перезаписать!", "Печать заказа",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(
                        ex.Message, "Печать заказа",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

            return Output;
        }

        public static void Fill(int OrderId, string FileName)
        {

            GC.Collect();

            //OOUtils.InitOO3Env();

            var localContext = uno.util.Bootstrap.bootstrap();
            var multiServiceFactory =
                (XMultiServiceFactory)localContext.getServiceManager();
            var xDesktop = (XDesktop)
                multiServiceFactory.createInstance("com.sun.star.frame.Desktop");
            
            try
            {
                #region xDesktop

                var componentLoader = (XComponentLoader)xDesktop;
                var xComponent = OOUtils.OpenFile(componentLoader, FileName, true, false);
                try
                {
                    #region xComponent

                    var xSpreadsheets = (xComponent as XSpreadsheetDocument).getSheets();
                    var xSpreadsheet = xSpreadsheets.getByName("Бланк").Value as XSpreadsheet;

                    using (var dc = new JalousieLinqDataContext(Database))
                    {
                        #region DataContext

                        var OrderTitle = dc.Отчеты_жалюзи_заголовок(OrderId).ToList()[0];
                        var Blank = dc.Жалюзи_бланкиs
                            .Where(x => x.Код == OrderTitle.Код_бланка)
                            .ToList()[0];
                        var BlankStructure = dc.Жалюзи_бланки_структураs
                            .Where(x => x.Код_бланка == OrderTitle.Код_бланка)
                            .ToList();
                        var OutputFormat = dc.Жалюзи_бланки_выводs
                            .ToList();

                        #region Title
                        xSpreadsheet.getCellRangeByName(Blank.Номер_заказа).
                            getCellByPosition(0, 0).setValue(OrderId);
                        xSpreadsheet.getCellRangeByName(Blank.Дата).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Дата.ToString("yyyy-MM-d"));
                        xSpreadsheet.getCellRangeByName(Blank.Клиент).
                            getCellByPosition(0, 0).setFormula(OrderTitle.ФИО);
                        xSpreadsheet.getCellRangeByName(Blank.Телефон).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Телефон);
                        if (OrderTitle.Установщик != null)
                        {
                            xSpreadsheet.getCellRangeByName(Blank.Установщик).
                                getCellByPosition(0, 0).setFormula(OrderTitle.Установщик);
                        }
                        xSpreadsheet.getCellRangeByName(Blank.Сумма).
                            getCellByPosition(0, 0).setValue((double)OrderTitle.Сумма);
                        xSpreadsheet.getCellRangeByName(Blank.Предоплата).
                            getCellByPosition(0, 0).setValue((double)OrderTitle.Предоплата);
                        if (OrderTitle.Дата_готовности != null)
                        {
                            var date = (System.DateTime) OrderTitle.Дата_готовности;
                            xSpreadsheet.getCellRangeByName(Blank.Срок_исполнения).
                                getCellByPosition(0, 0).setFormula(date.ToString("yyyy-MM-d"));
                        }
                        xSpreadsheet.getCellRangeByName(Blank.Название_магазина).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Магазин_название);
                        xSpreadsheet.getCellRangeByName(Blank.Телефон_магазина).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Магазин_телефон);
                        xSpreadsheet.getCellRangeByName(Blank.Дополнительно).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Дополнительно);
                        xSpreadsheet.getCellRangeByName(Blank.Реквизиты).
                            getCellByPosition(0, 0).setFormula(OrderTitle.Реквизиты);

                        if (OrderTitle.Статус == -1)
                            xSpreadsheet.getCellRangeByName(Blank.Предварительный_бланк).
                                getCellByPosition(0, 0).setFormula("Предварительный бланк");
                        #endregion

                        var OrderPositions = dc.Жалюзи_заказы_позицииs
                            .Where(x => x.Код_заказа == OrderId)
                            .ToList();


                        for (var i = 0; i < OrderPositions.Count; i++)
                        {
                            #region Positions
                            var OrderPosition = OrderPositions[i];
                            var CellIndex = (i + OrderTitle.Первая_позиция).ToString();

                            xSpreadsheet.getCellRangeByName(OrderTitle.Цена_столбец + CellIndex).
                                getCellByPosition(0, 0).setValue
                                (OrderPosition.Цена * (1 - OrderPosition.Скидка / 100));
                            xSpreadsheet.getCellRangeByName(OrderTitle.Количество_столбец + CellIndex).
                                getCellByPosition(0, 0).setValue((double)OrderPosition.Количество);

                            if (OrderTitle.Скидка_столбец.IndexOf("Z") == -1)
                                xSpreadsheet.getCellRangeByName(OrderTitle.Скидка_столбец + CellIndex).
                                    getCellByPosition(0, 0).setValue(OrderPosition.Скидка / 100);

                            var OrderPrositionStructures = dc.Жалюзи_заказы_позиции_структураs
                                .Where(x => x.Код_позиции == OrderPosition.Код).ToList();

                            #region Structure
                            foreach (var xBlankStructure in BlankStructure)
                            {
                                if (String.IsNullOrEmpty(xBlankStructure.Ячейка.Trim()) ||
                                    xBlankStructure.Ячейка.IndexOf("Z") >= 0)
                                    continue;
                                var Value = "";

                                #region Fill Value

                                var TargetOrderPrositionStructures = OrderPrositionStructures
                                    .Where(x => x.Код_структуры == xBlankStructure.Код).ToList();

                                if (TargetOrderPrositionStructures.Count>0)
                                {
                                    var TargetOrderPrositionStructure = TargetOrderPrositionStructures[0];
                                    switch (xBlankStructure.Код_типа_данных)
                                    {
                                        case 1:
                                            Value = TargetOrderPrositionStructure.Целое.ToString(xBlankStructure.Формат);
                                            break;
                                        case 2:
                                            Value = TargetOrderPrositionStructure.Дробное.ToString(xBlankStructure.Формат);
                                            break;
                                        case 3:
                                            Value = TargetOrderPrositionStructure.Текстовое;
                                            break;
                                        case 4:
                                            var xDictionary = dc.Жалюзи_все_справочникиs
                                                .Where(x => x.Код == xBlankStructure.Код_справочника)
                                                .ToList()[0];
                                            var xContent = dc.Жалюзи_все_справочники_содержаниеs
                                                .Where(x =>
                                                       x.Код_справочника == xBlankStructure.Код_справочника &&
                                                       x.Код == TargetOrderPrositionStructure.Справочник)
                                                .ToList()[0];


                                            switch (xDictionary.Код_типа_данных)
                                            {
                                                case 1:
                                                    Value = xContent.Целое.ToString(xBlankStructure.Формат);
                                                    break;
                                                case 2:
                                                    Value = xContent.Дробное.ToString(xBlankStructure.Формат);
                                                    break;
                                                case 3:
                                                    Value = xContent.Текстовое;
                                                    break;
                                            }
                                            break;
                                    }

                                }
                                else
                                    switch (xBlankStructure.Код_типа_данных)
                                    {
                                        case 1:
                                            Value = xBlankStructure.Целое.ToString(xBlankStructure.Формат);
                                            break;
                                        case 2:
                                            Value = xBlankStructure.Дробное.ToString(xBlankStructure.Формат);
                                            break;
                                        case 3:
                                            Value = xBlankStructure.Текстовое;
                                            break;
                                        case 4:
                                            var xDictionary = dc.Жалюзи_все_справочникиs
                                                .Where(x => x.Код == xBlankStructure.Код_справочника)
                                                .ToList()[0];
                                            var xContent = dc.Жалюзи_все_справочники_содержаниеs
                                                .Where(x => x.Код == xBlankStructure.Справочник)
                                                .ToList()[0];


                                            switch (xDictionary.Код_типа_данных)
                                            {
                                                case 1:
                                                    Value = xContent.Целое.ToString(xBlankStructure.Формат);
                                                    break;
                                                case 2:
                                                    Value = xContent.Дробное.ToString(xBlankStructure.Формат);
                                                    break;
                                                case 3:
                                                    Value = xContent.Текстовое;
                                                    break;
                                            }
                                            break;
                                    }
                                #endregion



                                var Replace = OutputFormat
                                    .Where(x =>
                                           x.Код_структуры == xBlankStructure.Код
                                           && x.Значение == Value)
                                    .ToList();
                                if (Replace.Count > 0)
                                    Value = Replace[0].Замена;

                                try
                                {
                                    xSpreadsheet.getCellRangeByName(xBlankStructure.Ячейка.Trim() + CellIndex).
                                        getCellByPosition(0, 0).setValue(Convert.ToDouble(Value));
                                }
                                catch
                                {

                                    xSpreadsheet.getCellRangeByName(xBlankStructure.Ячейка.Trim() + CellIndex).
                                        getCellByPosition(0, 0).setFormula(Value);
                                }
                            }
                            #endregion

                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                }
                finally
                {
                    OOUtils.SaveFile(xComponent as XStorable);
                    OOUtils.CloseFile(xComponent as XCloseable);
                    xComponent = null;
                }
                #endregion
            }
            finally
            {
                
                OOUtils.CloseDesktop(xDesktop);
                xDesktop = null;
                GC.Collect();
            }

        }

        public static void ViewFile(string FileName)
        {
            if (FileName!=null && File.Exists(FileName))
                    OOUtils.ViewFile(FileName);
        }
    }
}
