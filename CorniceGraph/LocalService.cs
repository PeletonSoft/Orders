using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBConverting;
using System.Data;
using System.IO;
using System.Drawing;

namespace CorniceGraph
{
    class LocalService
    {
        static public string ConnectionString;

        static private SqlConnection Database()
        {
            SqlConnection db = new SqlConnection();
            db.ConnectionString = ConnectionString;
                
            return db;
        }

        static public DataSet GetLinesList(int OrderId)
        {
            var da = new SqlDataAdapter(
                "SELECT "+
                    "[Карнизы_заказы_линии].[Код], " +
	                "[Карнизы_заказы_линии].[Номер линии], "+
	                "[Карнизы_заказы_линии].[Отлет], "+
	                "[Карнизы_заказы_линии].[Код профиля], "+
	                "[Карнизы_профили].[Название] "+
                "FROM [Карнизы_заказы_линии] "+
	                "INNER JOIN [Карнизы_профили] "+
		                "ON [Карнизы_заказы_линии].[Код профиля]=[Карнизы_профили].[Код] "+
                "WHERE "+
	                "[Карнизы_заказы_линии].[Код заказа]=@OrderId "+
                "ORDER BY "+
	                "[Карнизы_заказы_линии].[Номер линии] ASC", Database());

            da.SelectCommand.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            da.SelectCommand.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }


        public static void EditLineSection(
           ref int? LineSectionId, // Код
           ref int? LineId, // Код линии
           ref int? Numer, // Номер
           ref double? Length, // Длина
           ref double? Alpha, // Угол
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {

            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_линии_секции_редактирование]";

            cmd.Parameters.Add("@LineSectionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Numer", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Length", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Alpha", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@LineSectionId"].Value = DBConvert.ToDBObject(LineSectionId);
            cmd.Parameters["@LineId"].Value = DBConvert.ToDBObject(LineId);
            cmd.Parameters["@Numer"].Value = DBConvert.ToDBObject(Numer);
            cmd.Parameters["@Length"].Value = DBConvert.ToDBObject(Length);
            cmd.Parameters["@Alpha"].Value = DBConvert.ToDBObject(Alpha);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            LineSectionId = DBConvert.ToQInt(cmd.Parameters["@LineSectionId"].Value);
            LineId = DBConvert.ToQInt(cmd.Parameters["@LineId"].Value);
            Numer = DBConvert.ToQInt(cmd.Parameters["@Numer"].Value);
            Length = DBConvert.ToQDouble(cmd.Parameters["@Length"].Value);
            Alpha = DBConvert.ToQDouble(cmd.Parameters["@Alpha"].Value);

        }

        public static void ClearCorniceGraphics(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_очистить_графику]";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static void SaveCornicePicture(
           int OrderId, // Код заказа
           Bitmap Bitmap
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = 
                "INSERT INTO [Карнизы_заказы_картинки]([Код заказа],[Картинка]) VALUES(@OrderId, @Image)";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@Image", SqlDbType.Image).Direction = ParameterDirection.Input;

            MemoryStream stream = new MemoryStream();
            Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            cmd.Parameters["@Image"].Value = stream.ToArray();

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static void EditWallList(
           ref int? WallId, // Код
           ref int? OrderId, // Код заказа
           ref int? Numer, // Номер
           ref double? Corner, // Угол
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_стены_редактирование]";

            cmd.Parameters.Add("@WallId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Numer", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Corner", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@WallId"].Value = DBConvert.ToDBObject(WallId);
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            cmd.Parameters["@Numer"].Value = DBConvert.ToDBObject(Numer);
            cmd.Parameters["@Corner"].Value = DBConvert.ToDBObject(Corner);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            WallId = DBConvert.ToQInt(cmd.Parameters["@WallId"].Value);
            OrderId = DBConvert.ToQInt(cmd.Parameters["@OrderId"].Value);
            Numer = DBConvert.ToQInt(cmd.Parameters["@Numer"].Value);
            Corner = DBConvert.ToQDouble(cmd.Parameters["@Corner"].Value);

        }

        public static void EditWallDetail(
           ref int? WallDetailId, // Код
           ref int? WallId, // Код стены
           ref int? Numer, // Номер
           ref double? Length, // Длина
           ref double? Alpha, // Угол
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_стены_детали_редактирование]";

            cmd.Parameters.Add("@WallDetailId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@WallId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Numer", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Length", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Alpha", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@WallDetailId"].Value = DBConvert.ToDBObject(WallDetailId);
            cmd.Parameters["@WallId"].Value = DBConvert.ToDBObject(WallId);
            cmd.Parameters["@Numer"].Value = DBConvert.ToDBObject(Numer);
            cmd.Parameters["@Length"].Value = DBConvert.ToDBObject(Length);
            cmd.Parameters["@Alpha"].Value = DBConvert.ToDBObject(Alpha);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            WallDetailId = DBConvert.ToQInt(cmd.Parameters["@WallDetailId"].Value);
            WallId = DBConvert.ToQInt(cmd.Parameters["@WallId"].Value);
            Numer = DBConvert.ToQInt(cmd.Parameters["@Numer"].Value);
            Length = DBConvert.ToQDouble(cmd.Parameters["@Length"].Value);
            Alpha = DBConvert.ToQDouble(cmd.Parameters["@Alpha"].Value);

        }


        public static void EditLineClearance(
           ref int? LineClearanceId, // Код
           ref int? LineId, // Код линии
           ref int? WallId, // Код стены
           ref double? Clearance, // Отлет
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_линии_отлеты_редактирование]";

            cmd.Parameters.Add("@LineClearanceId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@WallId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Clearance", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@LineClearanceId"].Value = DBConvert.ToDBObject(LineClearanceId);
            cmd.Parameters["@LineId"].Value = DBConvert.ToDBObject(LineId);
            cmd.Parameters["@WallId"].Value = DBConvert.ToDBObject(WallId);
            cmd.Parameters["@Clearance"].Value = DBConvert.ToDBObject(Clearance);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            LineClearanceId = DBConvert.ToQInt(cmd.Parameters["@LineClearanceId"].Value);
            LineId = DBConvert.ToQInt(cmd.Parameters["@LineId"].Value);
            WallId = DBConvert.ToQInt(cmd.Parameters["@WallId"].Value);
            Clearance = DBConvert.ToQDouble(cmd.Parameters["@Clearance"].Value);

        }

        public static void EditLineStartPosition(
           ref int? StartPositionId, // Код
           ref int? LineId, // Код линии
           ref double? X, // X
           ref double? Y, // Y
           ref double? Phi, // Phi
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_линии_положение_редактирование]";

            cmd.Parameters.Add("@StartPositionId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@X", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Y", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Phi", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@StartPositionId"].Value = DBConvert.ToDBObject(StartPositionId);
            cmd.Parameters["@LineId"].Value = DBConvert.ToDBObject(LineId);
            cmd.Parameters["@X"].Value = DBConvert.ToDBObject(X);
            cmd.Parameters["@Y"].Value = DBConvert.ToDBObject(Y);
            cmd.Parameters["@Phi"].Value = DBConvert.ToDBObject(Phi);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            StartPositionId = DBConvert.ToQInt(cmd.Parameters["@StartPositionId"].Value);
            LineId = DBConvert.ToQInt(cmd.Parameters["@LineId"].Value);
            X = DBConvert.ToQDouble(cmd.Parameters["@X"].Value);
            Y = DBConvert.ToQDouble(cmd.Parameters["@Y"].Value);
            Phi = DBConvert.ToQDouble(cmd.Parameters["@Phi"].Value);

        }

        public static void UpadteCorniceInfo(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_обновление]";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static bool IsWallExists(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [dbo].[Карнизы_заказы_линии_наличие](@OrderId)";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            db.Open();
            bool Result = DBConvert.ToBool(cmd.ExecuteScalar());
            db.Close();
            return Result;
        }

        public static DataSet GetWallList(
            int OrderId // Код заказа
            )
        {

            var da = new SqlDataAdapter(
                "SELECT " +
                "[Код], " +
                "[Код заказа], " +
                "[Номер], " +
                "[Угол]" +
                "FROM [Карнизы_заказы_стены] " +
                "WHERE [Код заказа]=@OrderId", Database());
            da.SelectCommand.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            da.SelectCommand.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static DataSet GetWallDetail(
            int OrderId // Код заказа
            )
        {
            var da = new SqlDataAdapter(
                "SELECT " +
                   "[Код], " +
                   "[Код стены], " +
                   "[Номер], " +
                   "[Длина], " +
                   "[Угол]" +
                "FROM [Карнизы_заказы_стены_детали] " +
                "WHERE [Код стены] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_стены] WHERE [Код заказа]=@OrderId)", Database());

            da.SelectCommand.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            da.SelectCommand.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public static DataSet GetLineClearance(
            int OrderId // Код заказа
            )
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код линии], " +
                   "[Код стены], " +
                   "[Отлет]" +
                "FROM [Карнизы_заказы_линии_отлеты] " +
                "WHERE [Код стены] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_стены] WHERE [Код заказа]=@OrderId) " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetCorniceLineSection(
            int OrderId // Код заказа
            )
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код линии], " +
                   "[Номер], " +
                   "[Длина], " +
                   "[Угол]" +
                "FROM [Карнизы_заказы_линии_секции] " +
                "WHERE [Код линии] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_линии] WHERE [Код заказа]=@OrderId) " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetLineStartPosition(
            int OrderId // Код заказа
            )
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код линии], " +
                   "[X], " +
                   "[Y], " +
                   "[Phi]" +
                "FROM [Карнизы_заказы_линии_положение] " +
                "WHERE [Код линии] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_линии] WHERE [Код заказа]=@OrderId) " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static void EditCorniceSide(
           ref int? SideId, // Код
           ref int? LineId, // Код линии
           ref bool? IsSide, // Боковина
           ref bool? Position, // Положение
           ref double? Step, // Отступ
           ref double? Side, // Угол
           ref double? Radius, // Радиус
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_линии_боковины_редактирование]";

            cmd.Parameters.Add("@SideId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IsSide", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Position", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Step", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Side", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Radius", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@SideId"].Value = DBConvert.ToDBObject(SideId);
            cmd.Parameters["@LineId"].Value = DBConvert.ToDBObject(LineId);
            cmd.Parameters["@IsSide"].Value = DBConvert.ToDBObject(IsSide);
            cmd.Parameters["@Position"].Value = DBConvert.ToDBObject(Position);
            cmd.Parameters["@Step"].Value = DBConvert.ToDBObject(Step);
            cmd.Parameters["@Side"].Value = DBConvert.ToDBObject(Side);
            cmd.Parameters["@Radius"].Value = DBConvert.ToDBObject(Radius);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            SideId = DBConvert.ToQInt(cmd.Parameters["@SideId"].Value);
            LineId = DBConvert.ToQInt(cmd.Parameters["@LineId"].Value);
            IsSide = DBConvert.ToQBool(cmd.Parameters["@IsSide"].Value);
            Position = DBConvert.ToQBool(cmd.Parameters["@Position"].Value);
            Step = DBConvert.ToQDouble(cmd.Parameters["@Step"].Value);
            Side = DBConvert.ToQDouble(cmd.Parameters["@Side"].Value);
            Radius = DBConvert.ToQDouble(cmd.Parameters["@Radius"].Value);

        }

        public static DataSet GetCorniceSide(
            int OrderId // Код заказа
            )
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код линии], " +
                   "[Боковина], " +
                   "[Положение], " +
                   "[Отступ], " +
                   "[Угол], " +
                   "[Радиус]" +
                "FROM [Карнизы_заказы_линии_боковины] " +
                "WHERE [Код линии] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_линии] WHERE [Код заказа]=@OrderId) " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetCorniceView(
            int OrderId // Код заказа
            )
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код заказа], " +
                   "[X], " +
                   "[Y], " +
                   "[Поворот], " +
                   "[Масштаб], " +
                   "[Отражение]" +
                "FROM [Карнизы_заказы_вид] " +
                "WHERE [Код заказа]=@OrderId " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static void EditCorniceView(
           ref int? ViewId, // Код
           int OrderId, // Код заказа
           ref double? StartX, // X
           ref double? StartY, // Y
           ref double? Rotate, // Поворот
           ref double? Zoom, // Масштаб
           ref bool? Mirrow, // Отражение
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_вид_редактирование]";

            cmd.Parameters.Add("@ViewId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@StartX", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@StartY", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Rotate", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Zoom", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Mirrow", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@ViewId"].Value = DBConvert.ToDBObject(ViewId);
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            cmd.Parameters["@StartX"].Value = DBConvert.ToDBObject(StartX);
            cmd.Parameters["@StartY"].Value = DBConvert.ToDBObject(StartY);
            cmd.Parameters["@Rotate"].Value = DBConvert.ToDBObject(Rotate);
            cmd.Parameters["@Zoom"].Value = DBConvert.ToDBObject(Zoom);
            cmd.Parameters["@Mirrow"].Value = DBConvert.ToDBObject(Mirrow);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            ViewId = DBConvert.ToQInt(cmd.Parameters["@ViewId"].Value);
            StartX = DBConvert.ToQDouble(cmd.Parameters["@StartX"].Value);
            StartY = DBConvert.ToQDouble(cmd.Parameters["@StartY"].Value);
            Rotate = DBConvert.ToQDouble(cmd.Parameters["@Rotate"].Value);
            Zoom = DBConvert.ToQDouble(cmd.Parameters["@Zoom"].Value);
            Mirrow = DBConvert.ToQBool(cmd.Parameters["@Mirrow"].Value);

        }

        public static int? OrderState(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [Статус] FROM [Карнизы_заказы] WHERE [Код]=@OrderId";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            db.Open();
            int? Result = DBConvert.ToQInt(cmd.ExecuteScalar());
            db.Close();
            return Result;
        }

        public static void EditAgregate(
           ref int? AgregateId, // Код
           int OrderId, // Код заказа
           ref string AgregateName, // Название
           ref double? Base, // Длина базы
           ref double? Height, // Высота прогиба
           ref double? Salience, // Выпуклость
           ref bool? IsDown, // Прогиб вниз
           ref int? Approximate, // Тип апроксимации
           ref double? BaseHeight, // Высота базы
           ref double? Interval, // Интеграл измерений
           ref bool? IsCenter, // Центрирование
           ref int? Part, // Часть арки
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_агрегаты_редактирование]";

            cmd.Parameters.Add("@AgregateId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@AgregateName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Base", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Height", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Salience", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IsDown", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Approximate", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@BaseHeight", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Interval", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@IsCenter", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Part", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@AgregateId"].Value = DBConvert.ToDBObject(AgregateId);
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            cmd.Parameters["@AgregateName"].Value = DBConvert.ToDBObject(AgregateName);
            cmd.Parameters["@Base"].Value = DBConvert.ToDBObject(Base);
            cmd.Parameters["@Height"].Value = DBConvert.ToDBObject(Height);
            cmd.Parameters["@Salience"].Value = DBConvert.ToDBObject(Salience);
            cmd.Parameters["@IsDown"].Value = DBConvert.ToDBObject(IsDown);
            cmd.Parameters["@Approximate"].Value = DBConvert.ToDBObject(Approximate);
            cmd.Parameters["@BaseHeight"].Value = DBConvert.ToDBObject(BaseHeight);
            cmd.Parameters["@Interval"].Value = DBConvert.ToDBObject(Interval);
            cmd.Parameters["@IsCenter"].Value = DBConvert.ToDBObject(IsCenter);
            cmd.Parameters["@Part"].Value = DBConvert.ToDBObject(Part);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            AgregateId = DBConvert.ToQInt(cmd.Parameters["@AgregateId"].Value);
            AgregateName = DBConvert.ToString(cmd.Parameters["@AgregateName"].Value);
            Base = DBConvert.ToQDouble(cmd.Parameters["@Base"].Value);
            Height = DBConvert.ToQDouble(cmd.Parameters["@Height"].Value);
            Salience = DBConvert.ToQDouble(cmd.Parameters["@Salience"].Value);
            IsDown = DBConvert.ToQBool(cmd.Parameters["@IsDown"].Value);
            Approximate = DBConvert.ToQInt(cmd.Parameters["@Approximate"].Value);
            BaseHeight = DBConvert.ToQDouble(cmd.Parameters["@BaseHeight"].Value);
            Interval = DBConvert.ToQDouble(cmd.Parameters["@Interval"].Value);
            IsCenter = DBConvert.ToQBool(cmd.Parameters["@IsCenter"].Value);
            Part = DBConvert.ToQInt(cmd.Parameters["@Part"].Value);

        }


        public static DataSet GetAgregate(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код заказа], " +
                   "[Название], " +
                   "[Длина базы], " +
                   "[Высота прогиба], " +
                   "[Выпуклость], " +
                   "[Прогиб вниз], " +
                   "[Тип апроксимации], " +
                   "[Высота базы], " +
                   "[Интервал измерений], " +
                   "[Центрирование], " +
                   "[Часть арки]" +
                "FROM [Карнизы_заказы_агрегаты] " +
                "WHERE [Код заказа]=@OrderId " +
                "FOR XML AUTO, XMLDATA";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }


        public static DataSet GetMeasure(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код агрегата], " +
                   "[Координата], " +
                   "[Измерение]" +
                "FROM [Карнизы_заказы_измерения] " +
                "WHERE [Код агрегата] IN " +
                "(SELECT [Код] FROM [Карнизы_заказы_агрегаты] WHERE [Код заказа]=@OrderId) " +
                "FOR XML AUTO, XMLDATA";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static void EditMeasure(
           ref int? MeasureId, // Код
           ref int? AgregateId, // Код агрегата
           ref double? X, // Координата
           ref double? Y, // Измерение
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_измерения_редактирование]";

            cmd.Parameters.Add("@MeasureId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@AgregateId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@X", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Y", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@MeasureId"].Value = DBConvert.ToDBObject(MeasureId);
            cmd.Parameters["@AgregateId"].Value = DBConvert.ToDBObject(AgregateId);
            cmd.Parameters["@X"].Value = DBConvert.ToDBObject(X);
            cmd.Parameters["@Y"].Value = DBConvert.ToDBObject(Y);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            MeasureId = DBConvert.ToQInt(cmd.Parameters["@MeasureId"].Value);
            AgregateId = DBConvert.ToQInt(cmd.Parameters["@AgregateId"].Value);
            X = DBConvert.ToQDouble(cmd.Parameters["@X"].Value);
            Y = DBConvert.ToQDouble(cmd.Parameters["@Y"].Value);

        }


        public static DataSet GetOrderInfo(
           int OrderId // Код заказа
           ) // завершение декларации параметров
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
	                "[Код],[Дата],[Установщик],[ФИО], " +
	                "[Телефон],[Сумма],[Предоплата],[Количество], " +
                    "[Остаток],[Статус],[Статус название],[Тип карниза],[Код типа карниза], " +
                    "[Безнал],[Опт],[Тип гнутия], [Код типа гнутия], " +
	                "[Код карты покупателя],[Код карты дизайнера], " +
                    "[Карта покупателя],[Карта дизайнера] " +
	                "FROM [Карнизы_выбор_заказов] " +
                "WHERE [Код]=@OrderId " +
                "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetSplintComponents()
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код профиля], " +
                   "[Название], " +
                   "[Вариация], " +
                   "[Параметр], " +
                   "[Минимум], " +
                   "[Максимум], " +
                   "[Мантиса], " +
                   "[Инкремент], " +
                   "[Значение]" + 
                "FROM [Карнизы_комплектующие_шины] " +
                "FOR XML AUTO, XMLDATA";
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static DataSet GetSplintContour()
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код компоненты], " +
                   "[Номер], " +
                   "[L0], " +
                   "[LK], " +
                   "[Phi0], " +
                   "[PhiK], " +
                   "[Угол], " +
                   "[Тип] " +
                "FROM [Карнизы_комплектующие_шины_контур] " +
                "FOR XML AUTO, XMLDATA";
            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }

        public static void EditLineSplint(
           ref int? LineSplintId, // Код
           ref int? LineId, // Код линии
           ref int? ComponentId, // Код компоненты
           ref int? Numer, // Номер
           ref double? Value, // Значение
           int Edit) // тип редактирования (-1 - DELETE, 0 - UPDATE, +1 - INSERT)
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[Карнизы_заказы_линии_шины_редактирование]";

            cmd.Parameters.Add("@LineSplintId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@ComponentId", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Numer", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Value", SqlDbType.Float).Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Edit", SqlDbType.Int).Direction = ParameterDirection.Input;

            cmd.Parameters["@LineSplintId"].Value = DBConvert.ToDBObject(LineSplintId);
            cmd.Parameters["@LineId"].Value = DBConvert.ToDBObject(LineId);
            cmd.Parameters["@ComponentId"].Value = DBConvert.ToDBObject(ComponentId);
            cmd.Parameters["@Numer"].Value = DBConvert.ToDBObject(Numer);
            cmd.Parameters["@Value"].Value = DBConvert.ToDBObject(Value);
            cmd.Parameters["@Edit"].Value = DBConvert.ToDBObject(Edit);

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            LineSplintId = DBConvert.ToQInt(cmd.Parameters["@LineSplintId"].Value);
            LineId = DBConvert.ToQInt(cmd.Parameters["@LineId"].Value);
            ComponentId = DBConvert.ToQInt(cmd.Parameters["@ComponentId"].Value);
            Numer = DBConvert.ToQInt(cmd.Parameters["@Numer"].Value);
            Value = DBConvert.ToQDouble(cmd.Parameters["@Value"].Value);

        }

        public static DataSet GetLineSplint(
           int OrderId // Код заказа
           ) // завершение декларации параметр
        {
            SqlConnection db = Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "SELECT " +
                   "[Код], " +
                   "[Код линии], " +
                   "[Код компоненты], " +
                   "[Номер], " +
                   "[Значение]" +
                "FROM [Карнизы_заказы_линии_шины] " +               
                "WHERE [Код линии] IN " +
                    "(SELECT [Код] FROM [Карнизы_заказы_линии] WHERE [Код заказа]=@OrderId) " +
                    "FOR XML AUTO, XMLDATA";
            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Input;
            cmd.Parameters["@OrderId"].Value = DBConvert.ToDBObject(OrderId);

            DataSet ds = new DataSet();
            db.Open();
            ds.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
            db.Close();
            return ds;
        }


    }
}
