using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DBConverting;
using Jalousie.Properties;

namespace Jalousie
{

    class LocalService
    {
        static public int ShopId = 3;
        static public int UserId = 0;
        public static int DocumentTypeId = 13;

        public class FileCollectionItem
        {
            public int ProgramId;
            public string FileName;
            public string Path;
        }

        public class JalousieInstall
        {
            public double MinimalSum { get; private set; }
            public double PercentOfCost { get; private set; }
            public JalousieInstall(double minimalSum, double percentOfCost)
            {
                MinimalSum = minimalSum;
                PercentOfCost = percentOfCost;
            }
        }

        public static List<FileCollectionItem> FileCollection;
        static private SqlConnection Database()
        {
            return
                new SqlConnection
                    {
                        ConnectionString = Settings.Default.ShopConnectionString
                    };
        }

        static public DataSet GetFirmsList()
        {
            var da = new SqlDataAdapter(
                @"SELECT 
                    [Код], [Название], [Описание], [Код поставщика], [Активен]
                    FROM [Жалюзи_фирмы] 
                ORDER BY [Название] ASC", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;


        }

        public static DataSet GetShops()
        {
            var da1 = new SqlDataAdapter(
                "SELECT [Код], [Название], " +
                "[Касса-название] AS [Название магазина], " +
                "[Телефон] AS [Телефон магазина] " +
                "FROM [Магазины] ORDER BY [Название] ASC", Database());
            var ds = new DataSet();
            da1.Fill(ds);
            return ds;

        }

        static public DataSet GetBlanksList()
        {
            var da = new SqlDataAdapter(
                "SELECT " +
                "[Код], " +
                "[Код фирмы], " +
                "[Код типа], " +
                "[Описание], " +
                "[Первая позиция], " +
                "[Максимум позиций], " +
                "[Предварительный бланк], " +
                "[Номер заказа], " +
                "[Дата], " +
                "[Клиент], " +
                "[Телефон], " +
                "[Установщик], " +
                "[Сумма], " +
                "[Предоплата], " +
                "[Срок исполнения], " +
                "[Цена], " +
                "[Количество], " +
                "[Скидка], " +
                "[Название магазина], " +
                "[Телефон магазина], " +
                "[Дополнительно], " +
                "[Реквизиты], " +
                "[Активен]" +
                "FROM [Жалюзи_бланки]", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        static public DataSet GetTypesList()
        {
            var da = new SqlDataAdapter(
                "SELECT [Код],[Название],[Описание],[Активен] " + 
                "FROM [Жалюзи_типы] ORDER BY [Название] ASC", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetDataTypesList()
        {
            var da = new SqlDataAdapter(
                "SELECT " + "[Код], " + "[Тип], " + "[Справочник]" + 
                "FROM [Жалюзи_типы_данных] ", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetDictionaryList()
        {
            var da = new SqlDataAdapter(
                "SELECT [Код], [Название], [Описание], [Код типа данных], [Внешний]" +
                "FROM [Жалюзи_все_справочники] " +
                "ORDER BY [Название] ASC ", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetDictionaryContent()
        {
            var da = new SqlDataAdapter(
                "SELECT " +
                    "[Код], [Код справочника], [Активен], [Целое], " +
                    "[Дробное], [Текстовое], [Внешний] " +
                "FROM [Жалюзи_все_справочники_содержание] ", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetAlignment()
        {
            var da = new SqlDataAdapter(
                @"SELECT [Код],[Выравнивание] FROM [Жалюзи_выравнивание]", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetBlankStructure()
        {
            var da = new SqlDataAdapter(
                "SELECT " +
                "[Код], " +
                "[Код бланка], " +
                "[Краткий обзор], " +
                "[Поле], " +
                "[Код типа данных], " +
                "[Надпись], " +
                "[Ячейка], " +
                "[Формат], " +
                "[Код выравнивания], " +
                "[Целое], " +
                "[Дробное], " +
                "[Текстовое], " +
                "[Код справочника], " +
                "[Справочник], " +
                "[Ширина], " +
                "[Только чтение], " +
                "[Невидим], " +
                "[Номер]" +
                "FROM [Жалюзи_бланки_структура]", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetExpressionTypeList()
        {
            var da = new SqlDataAdapter(
                    "SELECT [Код],[Название] FROM [Документы_типы_выражений]",
                    Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetOperationList()
        {
            var da =
                new SqlDataAdapter(
                    @"
                    SELECT [Код],[Название]
                    FROM [Документы_операции]
                    WHERE [Код] IN (
	                    SELECT [Операция] 
	                    FROM [Документы_операции_типы]
	                    WHERE [Тип документа]=@DocumentTypeId)",
                    Database());
            da.SelectCommand.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@DocumentTypeId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = DocumentTypeId
                            }
                    }
                );
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetUsersList()
        {
            var da = new SqlDataAdapter(@"
                    SELECT 
                        [Код сотрудника] AS [Код], 
                        [dbo].[Короткий_ФИО]([Код сотрудника]) AS [Инициалы], 
                        [dbo].[Полный_ФИО]([Код сотрудника]) AS [ФИО], 
                        [Код магазина], 
                        [Уровень доступа], 
                        [Активен]
                    FROM [Программы_доступ]
                    WHERE [Код программы]=4
                    ORDER BY [ФИО]", 
                Database());

            da.SelectCommand.Parameters.Add("@ShopId", SqlDbType.Int).Direction = ParameterDirection.Input;
            da.SelectCommand.Parameters["@ShopId"].Value = ShopId;

            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        
        static public DataSet GetStates()
        {
            var da = new SqlDataAdapter(
                "SELECT [Состояние],[Название],[Конечный] FROM [Жалюзи_статус]", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetOrdersList(DateTime dtFrom, DateTime dtTo)
        {
            var da = new SqlDataAdapter(@"
                 SELECT
                   [Жалюзи_заказы].[Код], 
                   [Жалюзи_заказы].[Дата],
                   [Жалюзи_заказы].[Код бланка], 
                   [Жалюзи_заказы].[Код клиента],
                   [Жалюзи_заказы].[Код установщика], 
                   [Жалюзи_заказы].[Статус],
                   [Жалюзи_заказы].[Срок выполнения], 
                   [Жалюзи_заказы].[Безнал], 
                   [Жалюзи_заказы].[Опт], 
                   [Жалюзи_заказы].[Срочный],         
                   [Жалюзи_заказы].[Дополнительно],
                   [Жалюзи_заказы].[Заказной],
                   [Жалюзи_заказы].[Код сотрудника], 
                   [Заказы_покупатель].[ФИО], 
                   [Заказы_покупатель].[Телефон], 
                   [Жалюзи_статус].[Название] AS [Состояние], 
                   [Жалюзи_бланки].[Описание] AS [Бланк],
                   [Жалюзи_фирмы].[Название] AS [Фирма], 
                   [Жалюзи_заказы].[Дата готовности], 
                   [Жалюзи_типы].[Название] AS [Тип], 
                   [Жалюзи_заказы].[Код магазина], 
                   [Магазины].[Название] AS [Магазин] 
                FROM [Жалюзи_заказы] 
                    INNER JOIN [Заказы_покупатель] 
                        ON [Жалюзи_заказы].[Код клиента]=[Заказы_покупатель].[Код] 
                    INNER JOIN [Жалюзи_статус] 
                        ON [Жалюзи_заказы].[Статус]=[Жалюзи_статус].[Состояние] 
                    INNER JOIN [Жалюзи_бланки] 
                        ON [Жалюзи_заказы].[Код бланка]=[Жалюзи_бланки].[Код] 
                    INNER JOIN [Жалюзи_фирмы] 
                        ON [Жалюзи_бланки].[Код фирмы]=[Жалюзи_фирмы].[Код] 
                    INNER JOIN [Жалюзи_типы] 
                        ON [Жалюзи_бланки].[Код типа]=[Жалюзи_типы].[Код] 
                    INNER JOIN [Магазины] 
                        ON [Магазины].[Код]=[Жалюзи_заказы].[Код магазина] 
                WHERE  
                   [Жалюзи_заказы].[Дата]>=@From AND [Жалюзи_заказы].[Дата]<@To OR 
                   [Жалюзи_статус].[Конечный]=0 
                ORDER BY [Дата] DESC", 
                Database());
            da.SelectCommand.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@From", SqlDbType.DateTime)
                            {
                                Direction = ParameterDirection.Input,
                                Value = dtFrom
                            },
                        new SqlParameter("@To", SqlDbType.DateTime)
                            {
                                Direction = ParameterDirection.Input,
                                Value = dtTo
                            }
                    }
                );


            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetOrderPositions(int OrderId)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = "SELECT " +
                                            "[Код], " +
                                            "[Код заказа], " +
                                            "[Количество], " +
                                            "[Цена], " +
                                            "[Дата отправки], " +
                                            "[Дата получения], " +
                                            "[Скидка]" +
                                            "FROM [Жалюзи_заказы_позиции] " +
                                            "WHERE [Код заказа]=@OrderId " +
                                            "ORDER BY [Код] ASC " +
                                            "FOR XML AUTO, XMLDATA"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();

            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        static public DataSet GetOrderContent(int OrderId)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = @"
                                SELECT 
                                    [Код],
                                    [Код позиции], 
                                    [Код структуры],
                                    [Целое], 
                                    [Дробное], 
                                    [Текстовое], 
                                    [Справочник]
                                FROM [Жалюзи_заказы_позиции_структура] 
                                WHERE [Код позиции] IN (
                                    SELECT [Код] 
                                    FROM [Жалюзи_заказы_позиции] 
                                    WHERE [Код заказа]=@OrderId) 
                                FOR XML AUTO, XMLDATA"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();

            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }


        static public DataSet GetConstraints()
        {
            var da = new SqlDataAdapter(@"
                    SELECT 
                        [Код],[Код бланка],[Ограничение],
                        [Сообщение],[Описание],[Приоритет],
                        [Тип выражения],[Операция],[Активен]
                    FROM [Жалюзи_бланки_ограничения] ", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        static public DataSet GetBlankOutput()
        {
            var da = new SqlDataAdapter(@"
                SELECT           
                    [Код], [Значение], [Замена], [Код структуры]
                FROM [Жалюзи_бланки_вывод]", Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetOrderPrePayment(int OrderId)
        {
            var da = new SqlDataAdapter(@"
                SELECT 
                    [Код], [Дата], [Сумма], [Карта],[Безнал],[Возврат]
                FROM [Жалюзи_платежи]
                WHERE [Код заказа]=@OrderId
                ORDER BY [Дата] DESC",
                    Database());

            da.SelectCommand.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@OrderId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = OrderId.ToDBObject()
                            }
                    }
                );


            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public void EditFirmsList(
            ref int? FirmId, ref string FirmName, ref string Description,
            ref int? CodeSupplier, ref bool? Active, int Edit)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_фирмы_редактирование]"
                          };

            cmd.Parameters.Add("@FirmId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FirmName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@CodeSupplier", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@FirmId"].Value = FirmId.ToDBObject();
            cmd.Parameters["@FirmName"].Value = FirmName.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@CodeSupplier"].Value = CodeSupplier.ToDBObject();
            cmd.Parameters["@Active"].Value = Active.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            FirmId = cmd.Parameters["@FirmId"].Value.ToQInt();
            FirmName = cmd.Parameters["@FirmName"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            CodeSupplier = cmd.Parameters["@CodeSupplier"].Value.ToQInt();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
        }

        static public void EditBlanksList(
           ref int? BlankId, // Код
           ref int? FirmId, // Код фирмы
           ref int? TypeId, // Код типа
           ref string Description, // Описание
           ref int? RowFirstPosition, // Первая позиция
           ref int? RowPositionsMaximum, // Максимум позиций
           ref string CellDraftBlank, // Предварительный бланк
           ref string CellOrderId, // Номер заказа
           ref string CellDate, // Дата
           ref string CellClientName, // Клиент
           ref string CellClientTel, // Телефон
           ref string CellMounter, // Установщик
           ref string CellOrderSum, // Сумма
           ref string CellOrderPrepayment, // Предоплата
           ref string CellMountingPeriod, // Срок исполнения
           ref string ColumnPrice, // Цена
           ref string ColumnQuant, // Количество
           ref string ColumtDiscount, // Скидка
           ref string CellShopName, // Срок исполнения
           ref string CellShopTel, // Срок исполнения
           ref string CellAppInfo, // Дополнительно
           ref string CellEssential, // Дополнительно
           ref bool? Active, // Активен
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var cmd = new SqlCommand
                          {
                              Connection = Database(),
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_бланки_редактирование]"
                          };

            cmd.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@BlankId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = BlankId.ToDBObject()
                            },
                        new SqlParameter("@TypeId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = TypeId.ToDBObject()
                            },
                        new SqlParameter("@FirmId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = FirmId.ToDBObject()
                            },
                        new SqlParameter("@Description", SqlDbType.NVarChar, 200)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Description.ToDBObject()
                            },
                        new SqlParameter("@RowFirstPosition", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = RowFirstPosition.ToDBObject()
                            },
                        new SqlParameter("@RowPositionsMaximum", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = RowPositionsMaximum.ToDBObject()
                            },
                        new SqlParameter("@CellDraftBlank", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellDraftBlank.ToDBObject()
                            },
                        new SqlParameter("@CellOrderId", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellOrderId.ToDBObject()
                            },
                        new SqlParameter("@CellDate", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellDate.ToDBObject()
                            },
                        new SqlParameter("@CellClientName", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellClientName.ToDBObject()
                            },
                        new SqlParameter("@CellClientTel", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellClientTel.ToDBObject()
                            },
                        new SqlParameter("@CellMounter", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellMounter.ToDBObject()
                            },
                        new SqlParameter("@CellOrderSum", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellOrderSum.ToDBObject()
                            },
                        new SqlParameter("@CellOrderPrepayment", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellOrderPrepayment.ToDBObject()
                            },
                        new SqlParameter("@CellMountingPeriod", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellMountingPeriod.ToDBObject()
                            },
                        new SqlParameter("@ColumnPrice", SqlDbType.NVarChar, 5)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = ColumnPrice.ToDBObject()
                            },
                        new SqlParameter("@ColumnQuant", SqlDbType.NVarChar, 5)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = ColumnQuant.ToDBObject()
                            },
                        new SqlParameter("@ColumtDiscount", SqlDbType.NVarChar, 5)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = ColumtDiscount.ToDBObject()
                            },
                        new SqlParameter("@CellShopName", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellShopName.ToDBObject()
                            },
                        new SqlParameter("@CellAppInfo", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellShopTel.ToDBObject()
                            },
                        new SqlParameter("@CellShopTel", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellAppInfo.ToDBObject()
                            },
                        new SqlParameter("@CellEssential", SqlDbType.NVarChar, 10)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = CellEssential.ToDBObject()
                            },
                        new SqlParameter("@Active", SqlDbType.Bit)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Active.ToDBObject()
                            },
                        new SqlParameter("@Edit", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = Edit.ToDBObject()
                            }
                    }
                );

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            BlankId = cmd.Parameters["@BlankId"].Value.ToQInt();
            FirmId = cmd.Parameters["@FirmId"].Value.ToQInt();
            TypeId = cmd.Parameters["@TypeId"].Value.ToQInt();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            RowFirstPosition = cmd.Parameters["@RowFirstPosition"].Value.ToQInt();
            RowPositionsMaximum = cmd.Parameters["@RowPositionsMaximum"].Value.ToQInt();
            CellDraftBlank = cmd.Parameters["@CellDraftBlank"].Value.ToQString();
            CellOrderId = cmd.Parameters["@CellOrderId"].Value.ToQString();
            CellDate = cmd.Parameters["@CellDate"].Value.ToQString();
            CellClientName = cmd.Parameters["@CellClientName"].Value.ToQString();
            CellClientTel = cmd.Parameters["@CellClientTel"].Value.ToQString();
            CellMounter = cmd.Parameters["@CellMounter"].Value.ToQString();
            CellOrderSum = cmd.Parameters["@CellOrderSum"].Value.ToQString();
            CellOrderPrepayment = cmd.Parameters["@CellOrderPrepayment"].Value.ToQString();
            CellMountingPeriod = cmd.Parameters["@CellMountingPeriod"].Value.ToQString();
            ColumnPrice = cmd.Parameters["@ColumnPrice"].Value.ToQString();
            ColumnQuant = cmd.Parameters["@ColumnQuant"].Value.ToQString();
            ColumtDiscount = cmd.Parameters["@ColumtDiscount"].Value.ToQString();
            CellShopName = cmd.Parameters["@CellShopName"].Value.ToQString();
            CellShopTel = cmd.Parameters["@CellShopTel"].Value.ToQString();
            CellAppInfo = cmd.Parameters["@CellAppInfo"].Value.ToQString();
            CellEssential = cmd.Parameters["@CellEssential"].Value.ToQString();
            Active = cmd.Parameters["@Active"].Value.ToQBool();

        }



        static public void EditTypesList(
            ref int? TypeId, ref string TypeName,
            ref string Description, ref bool? Active, int Edit)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_типы_редактирование]"
                          };

            cmd.Parameters.Add("@TypeId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@TypeName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@TypeId"].Value = TypeId.ToDBObject();
            cmd.Parameters["@TypeName"].Value = TypeName.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@Active"].Value = Active.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            TypeId = cmd.Parameters["@TypeId"].Value.ToQInt();
            TypeName = cmd.Parameters["@TypeName"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
        }

        static public void InsertDictionary(
           out int? DictionaryId, // Код справочника
           ref string DictionaryName, // Название справочника
           ref string Description, // Описание
           ref int DataTypeId, // Код типа данных
           out int? DictionaryContentId, // Код содержания справочника
           out bool? Active, // Активен
           ref int IntegerValue, // Целое
           ref double FloatValue, // Дробное
           ref string TextValue // Текстовое
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_справочники_добавление]"
                          };

            cmd.Parameters.Add("@DictionaryId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DataTypeId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IntegerValue", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FloatValue", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@TextValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@DictionaryId"].Value = DBNull.Value;
            cmd.Parameters["@DictionaryName"].Value = DictionaryName.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@DataTypeId"].Value = DataTypeId.ToDBObject();
            cmd.Parameters["@DictionaryContentId"].Value = DBNull.Value;
            cmd.Parameters["@Active"].Value = DBNull.Value;
            cmd.Parameters["@IntegerValue"].Value = IntegerValue.ToDBObject();
            cmd.Parameters["@FloatValue"].Value = FloatValue.ToDBObject();
            cmd.Parameters["@TextValue"].Value = TextValue.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            DictionaryId = cmd.Parameters["@DictionaryId"].Value.ToQInt();
            DictionaryName = cmd.Parameters["@DictionaryName"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            DataTypeId = cmd.Parameters["@DataTypeId"].Value.ToInt();
            DictionaryContentId = cmd.Parameters["@DictionaryContentId"].Value.ToQInt();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
            IntegerValue = cmd.Parameters["@IntegerValue"].Value.ToInt();
            FloatValue = cmd.Parameters["@FloatValue"].Value.ToDouble();
            TextValue = cmd.Parameters["@TextValue"].Value.ToQString();

        }

        static public void UpdateDictionary(
           ref int DictionaryId, // Код стравочника
           ref string DictionaryName, // Название справочника
           ref string Description, // Описание
           out int DataTypeId // Код типа данных
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_справочники_изменение]"
                          };

            cmd.Parameters.Add("@DictionaryId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DataTypeId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@DictionaryId"].Value = DictionaryId.ToDBObject();
            cmd.Parameters["@DictionaryName"].Value = DictionaryName.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@DataTypeId"].Value = DBNull.Value;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            DictionaryId = cmd.Parameters["@DictionaryId"].Value.ToInt();
            DictionaryName = cmd.Parameters["@DictionaryName"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            DataTypeId = cmd.Parameters["@DataTypeId"].Value.ToInt();

        }

        static public void EditDictionaryContent(
           ref int? DictionaryContentId, // Код
           ref int? DictionaryId, // Код справочника
           ref bool? Active, // Активен
           ref int? IntegerValue, // Целое
           ref double? FloatValue, // Дробное
           ref string TextValue, // Текстовое
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_справочники_содержание_редактирование]"
                          };

            cmd.Parameters.Add("@DictionaryContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IntegerValue", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FloatValue", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@TextValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@DictionaryContentId"].Value = DictionaryContentId.ToDBObject();
            cmd.Parameters["@DictionaryId"].Value = DictionaryId.ToDBObject();
            cmd.Parameters["@Active"].Value = Active.ToDBObject();
            cmd.Parameters["@IntegerValue"].Value = IntegerValue.ToDBObject();
            cmd.Parameters["@FloatValue"].Value = FloatValue.ToDBObject();
            cmd.Parameters["@TextValue"].Value = TextValue.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            DictionaryContentId = cmd.Parameters["@DictionaryContentId"].Value.ToQInt();
            DictionaryId = cmd.Parameters["@DictionaryId"].Value.ToQInt();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
            IntegerValue = cmd.Parameters["@IntegerValue"].Value.ToQInt();
            FloatValue = cmd.Parameters["@FloatValue"].Value.ToQDouble();
            TextValue = cmd.Parameters["@TextValue"].Value.ToQString();

        }

        static public void EditBlankStructure(
           ref int? BlankStructureId, // Код
           ref int? BlankId, // Код бланка
           ref bool? Preview, // Краткий обзор
           ref string FieldName, // Поле
           ref int? DataTypeId, // Код типа данных
           ref string FieldLabel, // Надпись
           ref string ColumnField, // Ячейка
           ref string FormatField, // Формат
           ref int? AlignmentId, // Код выравнивания
           ref int? DefaultIntegerValue, // Целое
           ref double? DefaultFloatValue, // Дробное
           ref string DefaultTextValue, // Текстовое
           ref int? DictionaryId, // Код справочника
           ref int? DefaultDictionaryContentId, // Справочник
           ref int? Width, // Ширина
           ref bool? ReadOnly, // Только чтение
           ref bool? Invisible, // Невидим
           ref int? Numer, // Номер
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_бланки_структура_редактирование]"
                          };

            cmd.Parameters.Add("@BlankStructureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Preview", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FieldName", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DataTypeId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FieldLabel", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ColumnField", SqlDbType.NVarChar, 5).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FormatField", SqlDbType.NVarChar, 20).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@AlignmentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DefaultIntegerValue", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DefaultFloatValue", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DefaultTextValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DefaultDictionaryContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Width", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ReadOnly", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Invisible", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Numer", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@BlankStructureId"].Value = DBConvert.ToDBObject(BlankStructureId);
            cmd.Parameters["@BlankId"].Value = DBConvert.ToDBObject(BlankId);
            cmd.Parameters["@Preview"].Value = DBConvert.ToDBObject(Preview);
            cmd.Parameters["@FieldName"].Value = DBConvert.ToDBObject(FieldName);
            cmd.Parameters["@DataTypeId"].Value = DBConvert.ToDBObject(DataTypeId);
            cmd.Parameters["@FieldLabel"].Value = DBConvert.ToDBObject(FieldLabel);
            cmd.Parameters["@ColumnField"].Value = DBConvert.ToDBObject(ColumnField);
            cmd.Parameters["@FormatField"].Value = DBConvert.ToDBObject(FormatField);
            cmd.Parameters["@AlignmentId"].Value = DBConvert.ToDBObject(AlignmentId);
            cmd.Parameters["@DefaultIntegerValue"].Value = DBConvert.ToDBObject(DefaultIntegerValue);
            cmd.Parameters["@DefaultFloatValue"].Value = DBConvert.ToDBObject(DefaultFloatValue);
            cmd.Parameters["@DefaultTextValue"].Value = DBConvert.ToDBObject(DefaultTextValue);
            cmd.Parameters["@DictionaryId"].Value = DBConvert.ToDBObject(DictionaryId);
            cmd.Parameters["@DefaultDictionaryContentId"].Value = DBConvert.ToDBObject(DefaultDictionaryContentId);
            cmd.Parameters["@Width"].Value = DBConvert.ToDBObject(Width);
            cmd.Parameters["@ReadOnly"].Value = DBConvert.ToDBObject(ReadOnly);
            cmd.Parameters["@Invisible"].Value = DBConvert.ToDBObject(Invisible);
            cmd.Parameters["@Numer"].Value = DBConvert.ToDBObject(Numer);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            BlankStructureId = DBConvert.ToQInt(cmd.Parameters["@BlankStructureId"].Value);
            BlankId = DBConvert.ToQInt(cmd.Parameters["@BlankId"].Value);
            Preview = DBConvert.ToQBool(cmd.Parameters["@Preview"].Value);
            FieldName = DBConvert.ToQString(cmd.Parameters["@FieldName"].Value);
            DataTypeId = DBConvert.ToQInt(cmd.Parameters["@DataTypeId"].Value);
            FieldLabel = DBConvert.ToQString(cmd.Parameters["@FieldLabel"].Value);
            ColumnField = DBConvert.ToQString(cmd.Parameters["@ColumnField"].Value);
            FormatField = DBConvert.ToQString(cmd.Parameters["@FormatField"].Value);
            AlignmentId = DBConvert.ToQInt(cmd.Parameters["@AlignmentId"].Value);
            DefaultIntegerValue = DBConvert.ToQInt(cmd.Parameters["@DefaultIntegerValue"].Value);
            DefaultFloatValue = DBConvert.ToQDouble(cmd.Parameters["@DefaultFloatValue"].Value);
            DefaultTextValue = DBConvert.ToQString(cmd.Parameters["@DefaultTextValue"].Value);
            DictionaryId = DBConvert.ToQInt(cmd.Parameters["@DictionaryId"].Value);
            DefaultDictionaryContentId = DBConvert.ToQInt(cmd.Parameters["@DefaultDictionaryContentId"].Value);
            Width = DBConvert.ToQInt(cmd.Parameters["@Width"].Value);
            ReadOnly = DBConvert.ToQBool(cmd.Parameters["@ReadOnly"].Value);
            Invisible = DBConvert.ToQBool(cmd.Parameters["@Invisible"].Value);
            Numer = DBConvert.ToQInt(cmd.Parameters["@Numer"].Value);

        }

        static public void EditClientsList(
           ref int? ClientId, // Код
           ref string ClientName, // ФИО
           ref string ClientTel, // Телефон
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Заказы_покупатель_редактирование]";

            cmd.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ClientName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ClientTel", SqlDbType.NVarChar, 50).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@ClientId"].Value = DBConvert.ToDBObject(ClientId);
            cmd.Parameters["@ClientName"].Value = DBConvert.ToDBObject(ClientName);
            cmd.Parameters["@ClientTel"].Value = DBConvert.ToDBObject(ClientTel);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            ClientId = DBConvert.ToQInt(cmd.Parameters["@ClientId"].Value);
            ClientName = DBConvert.ToQString(cmd.Parameters["@ClientName"].Value);
            ClientTel = DBConvert.ToQString(cmd.Parameters["@ClientTel"].Value);

        }

        static public void UpdateOrdersList(
           ref int OrderId, // Код
           ref DateTime Date, // Дата
           ref int ClientId, // Код клиента
           ref int? MounterId, // Код установщика
           ref DateTime? InstallDate, // Срок выполнения
           ref string AddInfo, // Дополнительная информация
           ref bool Cashless, // Безнал
           ref bool Whole, // Мелкий опт
           ref bool IsOrdered, // Заказная ткань
           ref int userId,
           ref bool express// Код сотрудника
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_изменение]"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@MounterId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@InstallDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@AddInfo", SqlDbType.NVarChar, 500).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Cashless", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Whole", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IsOrdered", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Express", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@Date"].Value = Date.ToDBObject();
            cmd.Parameters["@ClientId"].Value = ClientId.ToDBObject();
            cmd.Parameters["@MounterId"].Value = MounterId.ToDBObject();
            cmd.Parameters["@InstallDate"].Value = InstallDate.ToDBObject();
            cmd.Parameters["@AddInfo"].Value = AddInfo.ToDBObject();
            cmd.Parameters["@Cashless"].Value = Cashless.ToDBObject();
            cmd.Parameters["@Whole"].Value = Whole.ToDBObject();
            cmd.Parameters["@IsOrdered"].Value = IsOrdered.ToDBObject();
            cmd.Parameters["@UserId"].Value = userId.ToDBObject();
            cmd.Parameters["@Express"].Value = express.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            OrderId = cmd.Parameters["@OrderId"].Value.ToInt();
            Date = cmd.Parameters["@Date"].Value.ToDateTime();
            ClientId = cmd.Parameters["@ClientId"].Value.ToInt();
            MounterId = cmd.Parameters["@MounterId"].Value.ToQInt();
            InstallDate = cmd.Parameters["@InstallDate"].Value.ToQDateTime();
            AddInfo = cmd.Parameters["@AddInfo"].Value.ToQString();
            Cashless = cmd.Parameters["@Cashless"].Value.ToBool();
            Whole = cmd.Parameters["@Whole"].Value.ToBool();
            IsOrdered = cmd.Parameters["@IsOrdered"].Value.ToBool();
            userId = cmd.Parameters["@UserId"].Value.ToInt();
            express = cmd.Parameters["@Express"].Value.ToBool();

        }

        static public void InsertOrder(
           out int? OrderId, // Код заказа
           out DateTime? Date, // Дата
           ref int BlankId, // Код бланка
           ref int ClientId, // Код клиента
           ref int? MounterId, // Код установщика
           out int? State, // Статус
           ref DateTime? InstallDate, // Срок выполнения
           ref string AddInfo, // Дополнительная информация
           ref bool Cashless, // Безнал
           ref bool Whole, // Опт
           ref bool IsOrdered, // Заказная ткань
           ref int userId, // Код сотрудника
           ref bool express
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_добавление]"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@MounterId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@State", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@InstallDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@AddInfo", SqlDbType.NVarChar, 500).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Cashless", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Whole", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IsOrdered", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ShopId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Express", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@OrderId"].Value = DBNull.Value;
            cmd.Parameters["@Date"].Value = DBNull.Value;
            cmd.Parameters["@BlankId"].Value = DBConvert.ToDBObject(BlankId);
            cmd.Parameters["@ClientId"].Value = DBConvert.ToDBObject(ClientId);
            cmd.Parameters["@MounterId"].Value = DBConvert.ToDBObject(MounterId);
            cmd.Parameters["@State"].Value = DBNull.Value;
            cmd.Parameters["@InstallDate"].Value = DBConvert.ToDBObject(InstallDate);
            cmd.Parameters["@AddInfo"].Value = DBConvert.ToDBObject(AddInfo);
            cmd.Parameters["@Cashless"].Value = DBConvert.ToDBObject(Cashless);
            cmd.Parameters["@Whole"].Value = DBConvert.ToDBObject(Whole);
            cmd.Parameters["@IsOrdered"].Value = DBConvert.ToDBObject(IsOrdered);
            cmd.Parameters["@UserId"].Value = DBConvert.ToDBObject(userId);
            cmd.Parameters["@ShopId"].Value = DBConvert.ToDBObject(ShopId);
            cmd.Parameters["@Express"].Value = DBConvert.ToDBObject(express);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            OrderId = DBConvert.ToQInt(cmd.Parameters["@OrderId"].Value);
            Date = DBConvert.ToQDateTime(cmd.Parameters["@Date"].Value);
            BlankId = DBConvert.ToInt(cmd.Parameters["@BlankId"].Value);
            ClientId = DBConvert.ToInt(cmd.Parameters["@ClientId"].Value);
            MounterId = DBConvert.ToInt(cmd.Parameters["@MounterId"].Value);
            State = DBConvert.ToQInt(cmd.Parameters["@State"].Value);
            InstallDate = DBConvert.ToQDateTime(cmd.Parameters["@InstallDate"].Value);
            AddInfo = DBConvert.ToQString(cmd.Parameters["@AddInfo"].Value);
            Cashless = DBConvert.ToBool(cmd.Parameters["@Cashless"].Value);
            Whole = DBConvert.ToBool(cmd.Parameters["@Whole"].Value);
            IsOrdered = DBConvert.ToBool(cmd.Parameters["@IsOrdered"].Value);
            userId = DBConvert.ToInt(cmd.Parameters["@UserId"].Value);
            express = DBConvert.ToBool(cmd.Parameters["@Express"].Value);


        }


        static public void SaveOrder(
            int OrderId, // Код заказа
            DataSet dsOrderSave,
            out bool Ordered
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();

            var cmdState = new SqlCommand
                               {
                                   Connection = db,
                                   CommandType = CommandType.Text,
                                   CommandText = "SELECT [Статус] FROM [Жалюзи_заказы] WHERE [Код]=@OrderId"
                               };
            cmdState.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmdState.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            var cmdClear = new SqlCommand
                               {
                                   Connection = db,
                                   CommandType = CommandType.StoredProcedure,
                                   CommandText = "[Жалюзи_заказы_очищение_заказа]"
                               };

            cmdClear.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmdClear.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            var cmdAddPos = new SqlCommand
                                {
                                    Connection = db,
                                    CommandType = CommandType.StoredProcedure,
                                    CommandText = "[Жалюзи_заказы_позиции_редактирование]"
                                };

            cmdAddPos.Parameters.Add("@PositionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@Quantity", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@Price", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@SendDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@ReceiptDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@Discount", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmdAddPos.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            var cmdAddContent = new SqlCommand
                                    {
                                        Connection = db,
                                        CommandType = CommandType.StoredProcedure,
                                        CommandText = "[Жалюзи_заказы_позиции_структура_редактирование]"
                                    };

            cmdAddContent.Parameters.Add("@OrderContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@PositionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@BlankStructureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@IntegerValue", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@FloatValue", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@TextValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@DictionaryContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmdAddContent.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            var cmdHistory = new SqlCommand
                                 {
                                     Connection = db,
                                     CommandType = CommandType.StoredProcedure,
                                     CommandText = "[Жалюзи_заказы_добавить_в_историю]"
                                 };

            cmdHistory.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmdHistory.Parameters.Add("@OperationId", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmdHistory.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            cmdHistory.Parameters["@OperationId"].Value = 1;

            var cmdOrdered = new SqlCommand
                                 {
                                     Connection = db,
                                     CommandType = CommandType.Text,
                                     CommandText = "SELECT [dbo].[Жалюзи_заказной_заказ](@OrderId) AS [Заказной]"
                                 };

            cmdOrdered.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmdOrdered.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            db.Open();

            var State = (int)cmdState.ExecuteScalar();
            if (State != 0)
            {
                db.Close();
                Ordered = false;
                return;
            }

            cmdClear.ExecuteNonQuery();

            foreach (DataRow rw in dsOrderSave.Tables["tbPositions"].Rows)
            {
                cmdAddPos.Parameters["@PositionId"].Value = DBNull.Value;
                cmdAddPos.Parameters["@OrderId"].Value = OrderId;
                cmdAddPos.Parameters["@Quantity"].Value = rw["Количество"];
                cmdAddPos.Parameters["@Price"].Value = rw["Цена"];
                cmdAddPos.Parameters["@SendDate"].Value = DBNull.Value;
                cmdAddPos.Parameters["@ReceiptDate"].Value = DBNull.Value;
                cmdAddPos.Parameters["@Discount"].Value = rw["Скидка"];
                cmdAddPos.Parameters["@Edit"].Value = 1;

                cmdAddPos.ExecuteNonQuery();

                var PositionId = (int)cmdAddPos.Parameters["@PositionId"].Value;

                DataRow[] rc = dsOrderSave.Tables["tbContent"].Select
                    (String.Format("[Код позиции]={0:G}", rw["Код"]));

                foreach (DataRow rwc in rc)
                {
                    cmdAddContent.Parameters["@OrderContentId"].Value = DBNull.Value;
                    cmdAddContent.Parameters["@PositionId"].Value = PositionId;
                    cmdAddContent.Parameters["@BlankStructureId"].Value = rwc["Код структуры"];
                    cmdAddContent.Parameters["@IntegerValue"].Value = rwc["Целое"];
                    cmdAddContent.Parameters["@FloatValue"].Value = rwc["Дробное"];
                    cmdAddContent.Parameters["@TextValue"].Value = rwc["Текстовое"];
                    cmdAddContent.Parameters["@DictionaryContentId"].Value = rwc["Справочник"];
                    cmdAddContent.Parameters["@Edit"].Value = 1;

                    cmdAddContent.ExecuteNonQuery();
                }
            }

            cmdHistory.ExecuteNonQuery();
            Ordered = Convert.ToBoolean(cmdOrdered.ExecuteScalar());

            db.Close();

        }

        static public void EditOrderContent(
           ref int? OrderContentId, // Код
           ref int? PositionId, // Код позиции
           ref int? BlankStructureId, // Код структуры
           ref int? IntegerValue, // Целое
           ref double? FloatValue, // Дробное
           ref string TextValue, // Текстовое
           ref int? DictionaryContentId, // Справочник
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Жалюзи_заказы_позиции_структура_редактирование]";

            cmd.Parameters.Add("@OrderContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@PositionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankStructureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IntegerValue", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@FloatValue", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@TextValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@DictionaryContentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@OrderContentId"].Value = DBConvert.ToDBObject(OrderContentId);
            cmd.Parameters["@PositionId"].Value = DBConvert.ToDBObject(PositionId);
            cmd.Parameters["@BlankStructureId"].Value = DBConvert.ToDBObject(BlankStructureId);
            cmd.Parameters["@IntegerValue"].Value = DBConvert.ToDBObject(IntegerValue);
            cmd.Parameters["@FloatValue"].Value = DBConvert.ToDBObject(FloatValue);
            cmd.Parameters["@TextValue"].Value = DBConvert.ToDBObject(TextValue);
            cmd.Parameters["@DictionaryContentId"].Value = DBConvert.ToDBObject(DictionaryContentId);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            OrderContentId = DBConvert.ToQInt(cmd.Parameters["@OrderContentId"].Value);
            PositionId = DBConvert.ToQInt(cmd.Parameters["@PositionId"].Value);
            BlankStructureId = DBConvert.ToQInt(cmd.Parameters["@BlankStructureId"].Value);
            IntegerValue = DBConvert.ToQInt(cmd.Parameters["@IntegerValue"].Value);
            FloatValue = DBConvert.ToQDouble(cmd.Parameters["@FloatValue"].Value);
            TextValue = DBConvert.ToQString(cmd.Parameters["@TextValue"].Value);
            DictionaryContentId = DBConvert.ToQInt(cmd.Parameters["@DictionaryContentId"].Value);

        }

        static public void EditOrderPositions(
           ref int? PositionId, // Код
           ref int? OrderId, // Код заказа
           ref double? Quantity, // Количество
           ref double? Price, // Цена
           ref DateTime? SendDate, // Дата отправки
           ref DateTime? ReceiptDate, // Дата получения
           ref double? Discount, // Скидка
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_позиции_редактирование]"
                          };

            cmd.Parameters.Add("@PositionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Quantity", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Price", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Discount", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Bit).Direction = ParameterDirection.Input;

            cmd.Parameters["@PositionId"].Value = PositionId.ToDBObject();
            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@Quantity"].Value = Quantity.ToDBObject();
            cmd.Parameters["@Price"].Value = Price.ToDBObject();
            cmd.Parameters["@SendDate"].Value = SendDate.ToDBObject();
            cmd.Parameters["@ReceiptDate"].Value = ReceiptDate.ToDBObject();
            cmd.Parameters["@Discount"].Value = Discount.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            PositionId = cmd.Parameters["@PositionId"].Value.ToQInt();
            OrderId = cmd.Parameters["@OrderId"].Value.ToQInt();
            Quantity = cmd.Parameters["@Quantity"].Value.ToQDouble();
            Price = cmd.Parameters["@Price"].Value.ToQDouble();
            SendDate = cmd.Parameters["@SendDate"].Value.ToQDateTime();
            ReceiptDate = cmd.Parameters["@ReceiptDate"].Value.ToQDateTime();
            Discount = cmd.Parameters["@Discount"].Value.ToQDouble();

        }

        static public void EditConstraints(
           ref int? ConstraintId, // Код
           ref int? BlankId, // Код бланка
           ref string Constraint, // Ограничение
           ref string Message, // Сообщение
           ref string Description, // Описание
           ref int? Priority, // Приоритет
           ref int? ExpressionTypeId, // 
           ref int? OperationId, //
           ref bool? Active, // Активен
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var cmd = new SqlCommand
                          {
                              Connection = Database(),
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_бланки_ограничения_редактирование]"
                          };

            cmd.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@ConstraintId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = ConstraintId.ToDBObject()
                            },
                        new SqlParameter("@BlankId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = BlankId.ToDBObject()
                            },
                        new SqlParameter("@Constraint", SqlDbType.NVarChar, 4000)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Constraint.ToDBObject()
                            },
                        new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Message.ToDBObject()
                            },
                        new SqlParameter("@Description", SqlDbType.NVarChar, 200)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Description.ToDBObject()
                            },
                        new SqlParameter("@Priority", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Priority.ToDBObject()
                            },
                        new SqlParameter("@OperationId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = OperationId.ToDBObject()
                            },
                        new SqlParameter("@ExpressionTypeId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = ExpressionTypeId.ToDBObject()
                            },
                        new SqlParameter("@Active", SqlDbType.Bit)
                            {
                                Direction = ParameterDirection.InputOutput,
                                Value = Active.ToDBObject()
                            },
                        new SqlParameter("@Edit", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = Edit
                            }
                    }
                );

            
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            ConstraintId = cmd.Parameters["@ConstraintId"].Value.ToQInt();
            BlankId = cmd.Parameters["@BlankId"].Value.ToQInt();
            Constraint = cmd.Parameters["@Constraint"].Value.ToQString();
            Message = cmd.Parameters["@Message"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            Priority = cmd.Parameters["@Priority"].Value.ToQInt();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
            ExpressionTypeId = cmd.Parameters["@ExpressionTypeId"].Value.ToQInt();

        }

        static public void InsertOrdetIntoHistory(
           int OrderId, // Код заказа
           int OperationId // Код операции
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_добавить_в_историю]"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@OperationId", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@OperationId"].Value = OperationId.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();


        }

        static public void DeleteOrder(
           int OrderId, // Код заказа
           out bool? Error, // Ошибка
           out string Message // Сообщение
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_удаление]"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Error", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@Error"].Value = DBNull.Value;
            cmd.Parameters["@Message"].Value = DBNull.Value;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            Error = cmd.Parameters["@Error"].Value.ToQBool();
            Message = cmd.Parameters["@Message"].Value.ToQString();

        }

        static public void MakeOrder(
           int OrderId, // Код заказа
           out bool? Error, // Ошибка
           out string Message // Сообщение
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandTimeout = 300,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_заказы_оформление]"
                          };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Error", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@Error"].Value = DBNull.Value;
            cmd.Parameters["@Message"].Value = DBNull.Value;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            Error = cmd.Parameters["@Error"].Value.ToQBool();
            Message = cmd.Parameters["@Message"].Value.ToQString();

        }

        static public void EditBlankOutput(
           ref int? BlankOutputId, // Код
           ref string BlankOutputValue, // Значение
           ref string BlankOutputReplace, // Замена
           ref int? StructureId, // Код структуры
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_бланки_вывод_редактирование]"
                          };

            cmd.Parameters.Add("@BlankOutputId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankOutputValue", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankOutputReplace", SqlDbType.NVarChar, 150).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@StructureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@BlankOutputId"].Value = BlankOutputId.ToDBObject();
            cmd.Parameters["@BlankOutputValue"].Value = BlankOutputValue.ToDBObject();
            cmd.Parameters["@BlankOutputReplace"].Value = BlankOutputReplace.ToDBObject();
            cmd.Parameters["@StructureId"].Value = StructureId.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            BlankOutputId = cmd.Parameters["@BlankOutputId"].Value.ToQInt();
            BlankOutputValue = cmd.Parameters["@BlankOutputValue"].Value.ToQString();
            BlankOutputReplace = cmd.Parameters["@BlankOutputReplace"].Value.ToQString();
            StructureId = cmd.Parameters["@StructureId"].Value.ToQInt();

        }

        static public DataSet GetOrderCalculation(int OrderId)
        {
            var da = new SqlDataAdapter(@"
                    SELECT 
                        [Код информации],[Код артикула],
                        [Артикул], [ПрИнфо],[Инфо],
                        [Требуется], [Имеется], [Заказная],[Расчетная цена]
                    FROM [Жалюзи_расчет_склад](@OrderId)
                    ORDER BY [Требуется]-[Имеется] DESC", 
                    Database()) {SelectCommand = {CommandTimeout = 300}};

            da.SelectCommand.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            da.SelectCommand.Parameters["@OrderId"].Value = OrderId.ToDBObject();

            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public DataSet GetAdvPriceList()
        {
            var da = new SqlDataAdapter(@"
                SELECT 
                    [Код],[Код бланка],[Условие],[Сумма],
                    [Выражение],[Описание],[Опт],[Приоритет] 
                FROM [Жалюзи_дополнительные_расценки]",
                Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        static public void EditAdvPriceList(
           ref int? AdvPriceId, // Код
           ref int? BlankId, // Код бланка
           ref string Expression, // Условие
           ref double? Price, // Сумма
           ref string TruePart, // Выражение
           ref string Description, // Описание
           ref bool? Whole, // Опт
           ref int? Priority, // Приоритет
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_дополнительные_расценки_редактирование]"
                          };

            cmd.Parameters.Add("@AdvPriceId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BlankId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Expression", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Price", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@TruePart", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Whole", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@AdvPriceId"].Value = AdvPriceId.ToDBObject();
            cmd.Parameters["@BlankId"].Value = BlankId.ToDBObject();
            cmd.Parameters["@Expression"].Value = Expression.ToDBObject();
            cmd.Parameters["@Price"].Value = Price.ToDBObject();
            cmd.Parameters["@TruePart"].Value = TruePart.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@Whole"].Value = Whole.ToDBObject();
            cmd.Parameters["@Priority"].Value = Priority.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            AdvPriceId = cmd.Parameters["@AdvPriceId"].Value.ToQInt();
            BlankId = cmd.Parameters["@BlankId"].Value.ToQInt();
            Expression = cmd.Parameters["@Expression"].Value.ToQString();
            Price = cmd.Parameters["@Price"].Value.ToQDouble();
            TruePart = cmd.Parameters["@TruePart"].Value.ToQString();
            Description = cmd.Parameters["@Description"].Value.ToQString();
            Whole = cmd.Parameters["@Whole"].Value.ToQBool();
            Priority = cmd.Parameters["@Priority"].Value.ToQInt();
        }


        static public DataSet GetCompleting()
        {
            var da =
                new SqlDataAdapter(
                    @"
                        SELECT [Код],[Название] 
                        FROM [Жалюзи_комплектующие] 
                        WHERE [Код] IN (
                            SELECT [Код комплектующей] 
                            FROM [Жалюзи_цвета_комплектующих_наши]) 
                        ORDER BY [Название] ASC",
                    Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        static public DataSet GetCompletingDetail()
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = @"
                                SELECT
                                    [Код],[Код комплектующей],[Код цвета],
                                    [Код информации],[Цена],[Оптовая цена]
                                FROM [Жалюзи_комплектующие_подробности]
                                WHERE [Код цвета] IS NOT NULL
                                FOR XML AUTO, XMLDATA"
                          };
            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetCompletingColor()
        {
            var da =
                new SqlDataAdapter(@"
                    SELECT [Код],[Код комплектующей],[Цвет],[Описание цвета] 
                    FROM [Жалюзи_цвета_комплектующих_наши]",
                    Database());
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        static public void EditCompletingDetail(
           ref int? CompletingDetailId, // Код
           ref int? CompletingId, // Код комплектующей
           ref int? ColorId, // Код цвета
           ref int? InformationId, // Код информации
           ref double? Price, // Цена
           ref double? WholePrice, // Оптовая цена
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_комплектующие_подробности_редактирование]"
                          };

            cmd.Parameters.Add("@CompletingDetailId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@CompletingId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ColorId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@InformationId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Price", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@WholePrice", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Bit).Direction = ParameterDirection.Input;

            cmd.Parameters["@CompletingDetailId"].Value = CompletingDetailId.ToDBObject();
            cmd.Parameters["@CompletingId"].Value = CompletingId.ToDBObject();
            cmd.Parameters["@ColorId"].Value = ColorId.ToDBObject();
            cmd.Parameters["@InformationId"].Value = InformationId.ToDBObject();
            cmd.Parameters["@Price"].Value = Price.ToDBObject();
            cmd.Parameters["@WholePrice"].Value = WholePrice.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            CompletingDetailId = cmd.Parameters["@CompletingDetailId"].Value.ToQInt();
            CompletingId = cmd.Parameters["@CompletingId"].Value.ToQInt();
            ColorId = cmd.Parameters["@ColorId"].Value.ToQInt();
            InformationId = cmd.Parameters["@InformationId"].Value.ToQInt();
            Price = cmd.Parameters["@Price"].Value.ToQDouble();
            WholePrice = cmd.Parameters["@WholePrice"].Value.ToQDouble();
        }

        static public void WriteOffOrder(
           int OrderId, // Код заказа
           out bool? Error, // Ошибка
           out string Message // Сообщение
           ) // завершение декларации параметров
        {
            var db = Database();
            var cmd = new SqlCommand
                                 {
                                     Connection = db,
                                     CommandType = CommandType.StoredProcedure,
                                     CommandText = "[Жалюзи_заказы_списание]"
                                 };

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Error", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;

            cmd.Parameters["@OrderId"].Value = OrderId.ToDBObject();
            cmd.Parameters["@Error"].Value = DBNull.Value;
            cmd.Parameters["@Message"].Value = DBNull.Value;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            Error = cmd.Parameters["@Error"].Value.ToQBool();
            Message = cmd.Parameters["@Message"].Value.ToQString();

        }

        static public DataSet MakeStandartColor(int orderId, DataSet dsOrder)
        {
            DataSet ds = dsOrder.Copy();

            #region Информация о заказе
            var qOrder = new SqlCommand(
                    @"SELECT [Код бланка], [Срок выполнения], [Опт], [Срочный] 
                    FROM [Жалюзи_заказы] WHERE [Код]=@OrderId", 
                Database());
            qOrder.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            qOrder.Parameters["@OrderId"].Value = orderId;

            qOrder.Connection.Open();
            var drOrder = qOrder.ExecuteReader();
            if (!drOrder.Read())
            {
                qOrder.Connection.Close();
                return ds;
            }
            var blankId = drOrder.GetInt32(0);
            var period = drOrder.GetInt32(1);
            var whole = drOrder.GetBoolean(2);
            var express = drOrder.GetBoolean(3);

            qOrder.Connection.Close();
            #endregion

            var dsCopy = ds.Copy();
            var Number = 0;
            foreach (DataRow rwx in ds.Tables[0].Rows)
                rwx["Номер"] = ++Number;

            dsCopy.Tables[0].Columns.Add("Код заказа", typeof(int));
            dsCopy.Tables[0].Columns.Add("Код бланка", typeof(int));
            dsCopy.Tables[0].Columns.Add("Срок выполнения", typeof(int));
            dsCopy.Tables[0].Columns.Add("Опт", typeof(bool));
            dsCopy.Tables[0].Columns.Add("Срочный", typeof(bool));

            try
            {
                foreach (DataRow rw in dsCopy.Tables[0].Rows)
                {
                    rw["Код бланка"] = orderId;
                    rw["Код бланка"] = blankId;
                    rw["Срок выполнения"] = period;
                    rw["Опт"] = whole;
                    rw["Срочный"] = express;
                }
                var daCalcField = new SqlDataAdapter(
                    @"SELECT 
                        [Жалюзи_бланки_вычисления].[Условие],
                        [Жалюзи_бланки_вычисления].[Значение], 
                        [Жалюзи_бланки_вычисления].[Приоритет], 
                        [Жалюзи_бланки_вычисления].[Внутренний],
                        [Жалюзи_бланки_структура].[Поле]
                    FROM [Жалюзи_бланки_вычисления]
                        INNER JOIN [Жалюзи_бланки_структура]
                            ON [Жалюзи_бланки_вычисления].[Код структуры]=
                                [Жалюзи_бланки_структура].[Код] 
                    WHERE
                        [Жалюзи_бланки_вычисления].[Активен]=1 AND
                        [Жалюзи_бланки_структура].[Код бланка]=@BlankId
                    ORDER BY
                        [Жалюзи_бланки_вычисления].[Приоритет] DESC", Database());

                daCalcField.SelectCommand.Parameters.Add("@BlankId", SqlDbType.Int).Direction = ParameterDirection.Input;
                daCalcField.SelectCommand.Parameters["@BlankId"].Value = blankId;
                var dsCalcField = new DataSet();
                daCalcField.Fill(dsCalcField);

                foreach (DataRow rwCalcField in dsCalcField.Tables[0].Rows)
                {
                    var Expression = (string)rwCalcField["Условие"];
                    if (Expression == null || Expression.Trim() == "")
                        Expression = "1=1";

                    var rcPosCopy = dsCopy.Tables[0].Select(Expression);
                    var FieldName = (string)rwCalcField["Поле"];

                    if ((bool)rwCalcField["Внутренний"])
                    {
                        var cl = dsCopy.Tables[0].Columns.Add("Расчет",
                            ds.Tables[0].Columns[ds.Tables[0].Columns.IndexOf(FieldName)].DataType);
                        cl.Expression = rwCalcField["Значение"].ToQString();

                        foreach (var rwPosCopy in rcPosCopy)
                        {
                            var NewValue = rwPosCopy["Расчет"];
                            rwPosCopy[FieldName] = NewValue;

                            foreach (var rwPos in ds.Tables[0].Select("[Код]=" + rwPosCopy["Код"].ToString()))
                                rwPos[FieldName] = NewValue;
                        }
                        dsCopy.Tables[0].Columns.Remove(cl.ColumnName);
                        dsCopy.AcceptChanges();
                    }
                    else
                    {
                        var Query = rwCalcField["Значение"].ToQString();
                        var q = new SqlCommand(Query, Database());

                        foreach (DataColumn col in dsCopy.Tables[0].Columns)
                        {
                            var ParamName = "@" + col.ColumnName.Replace(" ", "_");
                            if (Query.IndexOf(ParamName) < 0) 
                                continue;

                            var Parameter = new SqlParameter()
                                                {
                                                    ParameterName = ParamName,
                                                    Direction = ParameterDirection.Input
                                                };
                            if (col.DataType == typeof (int))
                                Parameter.SqlDbType = SqlDbType.Int;
                            else if (col.DataType == typeof (double))
                                Parameter.SqlDbType = SqlDbType.Float;
                            else if (col.DataType == typeof (string))
                            {
                                Parameter.SqlDbType = SqlDbType.NVarChar;
                                Parameter.Size = 50;
                            }
                            q.Parameters.Add(Parameter);
                        }
                        foreach (var rwPosCopy in rcPosCopy)
                        {

                            foreach (DataColumn col in dsCopy.Tables[0].Columns)
                            {
                                var ParamName = "@" + col.ColumnName.Replace(" ", "_");
                                if (Query.IndexOf(ParamName) >= 0)
                                    q.Parameters[ParamName].Value = rwPosCopy[col.ColumnName];
                            }
                            q.Connection.Open();
                            var NewValue = q.ExecuteScalar();
                            if (NewValue != null)
                            {
                                rwPosCopy[FieldName] = NewValue;

                                foreach (var rwPos in ds.Tables[0].Select("[Код]=" + rwPosCopy["Код"].ToString()))
                                    rwPos[FieldName] = NewValue;
                            }
                            q.Connection.Close();
                        }
                    }
                }
            }
            finally
            {
                dsCopy.Tables[0].Columns.Remove("Код заказа");
                dsCopy.Tables[0].Columns.Remove("Код бланка");
                dsCopy.Tables[0].Columns.Remove("Срок выполнения");
                dsCopy.Tables[0].Columns.Remove("Опт");
                dsCopy.Tables[0].Columns.Remove("Срочный");
                ds.AcceptChanges();
            }
            return ds;
        }

        static public DataSet MakePrice(int OrderId, DataSet dsOrder)
        {
            var ds = dsOrder.Copy();
            var db = Database();

            var daAdvPrice = new SqlDataAdapter(
                "SELECT " +
                   "[Код], " +
                   "[Код бланка], " +
                   "[Условие], " +
                   "[Сумма], " +
                   "[Выражение]," +
                   "[Опт]," +
                   "[Приоритет]" +
                "FROM [Жалюзи_дополнительные_расценки] " +
                "ORDER BY [Приоритет] DESC", Database());

            var qOrder = new SqlCommand(
                "SELECT [Код бланка], [Срок выполнения], [Опт], [Срочный] FROM [Жалюзи_заказы] WHERE [Код]=@OrderId", Database());
            qOrder.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            qOrder.Parameters["@OrderId"].Value = OrderId;

            qOrder.Connection.Open();
            var drOrder = qOrder.ExecuteReader();
            if (!drOrder.Read())
            {
                qOrder.Connection.Close();
                return ds;
            }
            var BlankId = drOrder.GetInt32(0);
            var Period = drOrder.GetInt32(1);
            var Whole = drOrder.GetBoolean(2);
            var Express = drOrder.GetBoolean(3);

            qOrder.Connection.Close();

            var dsAdvPrice = new DataSet();
            daAdvPrice.Fill(dsAdvPrice);
            var rcAdvPrice = dsAdvPrice.Tables[0].Select
                (String.Format("[Код бланка]={0:G} AND [Опт]=0", BlankId), "[Приоритет] DESC");

            foreach (DataRow rw in ds.Tables[0].Rows)
                rw["Цена"] = 0;

            var dsCopy = ds.Copy();

            var cl = dsCopy.Tables[0].Columns.Add("Расчет", typeof(double));
            cl.DefaultValue = 0;

            dsCopy.Tables[0].Columns.Add("Код заказа", typeof(int));
            dsCopy.Tables[0].Columns.Add("Код бланка", typeof(int));
            dsCopy.Tables[0].Columns.Add("Срок выполнения", typeof(int));
            dsCopy.Tables[0].Columns.Add("Опт", typeof(bool));
            dsCopy.Tables[0].Columns.Add("Срочный", typeof(bool));

            foreach (DataRow rw in dsCopy.Tables[0].Rows)
            {
                rw["Код бланка"] = OrderId;
                rw["Код бланка"] = BlankId;
                rw["Срок выполнения"] = Period;
                rw["Опт"] = Whole;
                rw["Срочный"] = Express;
            }

            foreach (var rw in rcAdvPrice)
            {
                var Expression = (string)rw["Условие"];
                if (Expression == null || Expression.Trim() == "")
                    Expression = "1=1";

                //
                var rcPosCopy = dsCopy.Tables[0].Select(Expression);

                var IsTruePart =
                    rw["Выражение"].ToQString() != null &&
                    rw["Выражение"].ToQString().Trim() != "";
                if (IsTruePart)
                    cl.Expression = rw["Выражение"].ToQString();

                foreach (var rwPosCopy in rcPosCopy)
                {
                    var NewPrice = (double)rwPosCopy["Цена"] +
                        Math.Round(IsTruePart ? (double)rwPosCopy["Расчет"] : (double)rw["Сумма"], 2);
                    rwPosCopy["Цена"] = NewPrice;

                    foreach (var rwPos in ds.Tables[0].Select("[Код]=" + rwPosCopy["Код"].ToString()))
                        rwPos["Цена"] = NewPrice;
                }
            }

            foreach (DataRow rw in ds.Tables[0].Rows)
                rw["Цена"] = Math.Round((double)rw["Цена"], 0);

            dsCopy.Tables[0].Columns.Remove("Код заказа");
            dsCopy.Tables[0].Columns.Remove("Код бланка");
            dsCopy.Tables[0].Columns.Remove("Срок выполнения");
            dsCopy.Tables[0].Columns.Remove("Опт");
            dsCopy.Tables[0].Columns.Remove("Срочный");

            ds.AcceptChanges();
            return ds;
        }


        static public void EditCalcField(
           ref int? CalcFieldId, // Код
           ref int? StructureId, // Код структуры
           ref string Expression, // Условие
           ref string Value, // Значение
           ref int? Priority, // Приоритет
           ref bool? Inside, // Внутренний
           ref bool? Active, // Активен
           ref string Description, // Описание
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.StoredProcedure,
                              CommandText = "[Жалюзи_бланки_вычисления_редактирование]"
                          };

            cmd.Parameters.Add("@CalcFieldId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@StructureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Expression", SqlDbType.NVarChar, 500).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Value", SqlDbType.NVarChar, 500).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Inside", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@CalcFieldId"].Value = CalcFieldId.ToDBObject();
            cmd.Parameters["@StructureId"].Value = StructureId.ToDBObject();
            cmd.Parameters["@Expression"].Value = Expression.ToDBObject();
            cmd.Parameters["@Value"].Value = Value.ToDBObject();
            cmd.Parameters["@Priority"].Value = Priority.ToDBObject();
            cmd.Parameters["@Inside"].Value = Inside.ToDBObject();
            cmd.Parameters["@Active"].Value = Active.ToDBObject();
            cmd.Parameters["@Description"].Value = Description.ToDBObject();
            cmd.Parameters["@Edit"].Value = Edit.ToDBObject();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            CalcFieldId = cmd.Parameters["@CalcFieldId"].Value.ToQInt();
            StructureId = cmd.Parameters["@StructureId"].Value.ToQInt();
            Expression = cmd.Parameters["@Expression"].Value.ToQString();
            Value = cmd.Parameters["@Value"].Value.ToQString();
            Priority = cmd.Parameters["@Priority"].Value.ToQInt();
            Inside = cmd.Parameters["@Inside"].Value.ToQBool();
            Active = cmd.Parameters["@Active"].Value.ToQBool();
            Description = cmd.Parameters["@Description"].Value.ToQString();

        }

        static public DataSet GetCalcField()
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = "SELECT " +
                                            "[Код], " +
                                            "[Код структуры], " +
                                            "[Условие], " +
                                            "[Значение], " +
                                            "[Приоритет], " +
                                            "[Внутренний], " +
                                            "[Активен], " +
                                            "[Описание]" +
                                            "FROM [Жалюзи_бланки_вычисления] " +
                                            "FOR XML AUTO, XMLDATA"
                          };
            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        // проверка пароля
        static public bool CheckPassword(
           int UserId, // Код
           string Password)
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = @"
                                    SELECT 
                                        COUNT([Код]) FROM [Сотрудники]
                                    WHERE 
                                        [Код]=@UserId AND 
                                        ISNULL([Password],'')=@Password"
                          };

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Input;

            cmd.Parameters["@UserId"].Value = UserId;
            cmd.Parameters["@Password"].Value = Password;

            db.Open();
            var Result = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            db.Close();

            return Result;

        }


        static public DataSet GetLinkedProgramList()
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = @"
                                SELECT 
                                    [Код],[Код бланка],[Код программы] 
                                FROM [Жалюзи_бланки_связанные_программы] 
                                FOR XML AUTO, XMLDATA"
                          };
            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        static public DataSet GetProgramList()
        {
            var db = Database();
            var cmd = new SqlCommand
                          {
                              Connection = db,
                              CommandType = CommandType.Text,
                              CommandText = @"
                                    SELECT 
                                        [Код],[Название],[Описание],[Расширение] 
                                    FROM [Жалюзи_связанные_программы] 
                                    ORDER BY [Название] ASC 
                                    FOR XML AUTO, XMLDATA"
                          };
            var ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        static public byte[] GetLinkedFile(int OrderId, int ProgramId)
        {
            using (var cmd = new SqlCommand()
                                 {
                                     Connection = Database(),
                                     CommandType = CommandType.Text
                                 })
            {
                cmd.CommandText =
                    @"SELECT [dbo].[Жалюзи_получить_связанный_файл](@OrderId,@ProgramId)";
                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@ProgramId", SqlDbType.Int).Direction = ParameterDirection.Input;

                cmd.Parameters["@OrderId"].Value = OrderId;
                cmd.Parameters["@ProgramId"].Value = ProgramId;

                cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? null : (byte[]) result;

            }
        }

        static public byte[] GetPatternLinkedFile(int OrderId, int ProgramId)
        {
            using (var cmd = new SqlCommand()
                                 {
                                     Connection = Database(),
                                     CommandType = CommandType.Text
                                 })
            {
                cmd.CommandText =
                    @"SELECT [dbo].[Жалюзи_получить_связанный_шаблон](@OrderId,@ProgramId)";
                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@ProgramId", SqlDbType.Int).Direction = ParameterDirection.Input;

                cmd.Parameters["@OrderId"].Value = OrderId;
                cmd.Parameters["@ProgramId"].Value = ProgramId;

                cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? null : (byte[])result;
            }
        }

        static public void SetLinkedFile(
            int OrderId,
            int ProgramId,
            byte[] Value,
            out bool Error,
            out string Message
            ) 
        {

            using (var cmd = new SqlCommand()
                                 {
                                     Connection = Database(),
                                     CommandType = CommandType.StoredProcedure
                                 })
            {
                cmd.CommandText = "[Жалюзи_записать_файл]";

                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@ProgramId", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@Value", SqlDbType.VarBinary, 20000000).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@Error", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar,200).Direction = ParameterDirection.Output;

                cmd.Parameters["@OrderId"].Value = OrderId;
                cmd.Parameters["@ProgramId"].Value = ProgramId;
                cmd.Parameters["@Value"].Value = Value ?? (object)DBNull.Value;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                Error = (bool)cmd.Parameters["@Error"].Value;
                Message = cmd.Parameters["@Message"].Value.ToString().Trim();
            }

        }

        static public void SetPlanPosition(
            int OrderId,
            DateTime date,
            out bool Error,
            out bool Warning,
            out string Message
            )
        {

            using (var cmd = new SqlCommand()
            {
                Connection = Database(),
                CommandType = CommandType.StoredProcedure
            })
            {
                cmd.CommandText = "[Жалюзи_заказы_добавить_в_график]";

                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@DateInstall", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@Error", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Warning", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;

                cmd.Parameters["@OrderId"].Value = OrderId;
                cmd.Parameters["@DateInstall"].Value = date;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                Error = (bool)cmd.Parameters["@Error"].Value;
                Warning = (bool)cmd.Parameters["@Warning"].Value;
                Message = cmd.Parameters["@Message"].Value.ToString().Trim();
            }

        }

        static public DataSet GetPlan(int Type)
        {
            var da = new SqlDataAdapter(@"
                        SELECT     
                            [Код], [Дата], 
                            [День недели], [Всего изделий], 
                            [Код типа жалюзи], [Свободно], [Занято]
                        FROM Жалюзи_план(@Type)
                        ORDER BY [Дата] ASC",
                Database());

            da.SelectCommand.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@Type", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = Type
                            }
                    }
                );


            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static JalousieInstall GetJalousieInstall(int orderId)
        {
            var da = new SqlDataAdapter(@"
                SELECT 
	                DCH.[Код характеристики],
	                FCH.[Значение]
                FROM [Документы_характеристики] AS DCH
	                INNER JOIN Характеристики_значения_FLOAT as FCH
		                on
			                FCH.[Код]= DCH.[Код значения]
                WHERE
	                DCH.[Код типа документа] = 13 AND
	                DCH.[Код документа] = @OrderId AND
	                DCH.[Код характеристики] IN (42,43)",
                Database());

            da.SelectCommand.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter("@OrderId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = orderId
                            }
                    }
                );

            var ds = new DataSet();
            da.Fill(ds);
            var tb = ds.Tables[0];
            var minimalSum = (double)tb.Select("[Код характеристики]=43")[0]["Значение"];
            var precentOfCost = (double)tb.Select("[Код характеристики]=42")[0]["Значение"];
            return new JalousieInstall(minimalSum,precentOfCost);
        }
    }
}
