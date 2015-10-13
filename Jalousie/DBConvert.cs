using System;

namespace DBConverting
{

    public static class DBConvert
    {
        public static object ToDBObject(this int? Value)
        {
            return Value == null ? DBNull.Value : (object)Value;
        }

        public static object ToDBObject(this int Value)
        {
            return (object)Value;
        }

        public static object ToDBObject(this bool? Value)
        {
            return Value == null ? DBNull.Value : (object)Value;
        }

        public static object ToDBObject(this bool Value)
        {
            return (object)Value;
        }

        public static object ToDBObject(this double? Value)
        {
            return Value == null ? DBNull.Value : (object)Value;
        }

        public static object ToDBObject(this double Value)
        {
            return (object)Value;
        }

        public static object ToDBObject(this DateTime? Value)
        {
            return Value == null ? DBNull.Value : (object)Value;
        }

        public static object ToDBObject(this DateTime Value)
        {
            return (object)Value;
        }

        public static object ToDBObject(this string Value)
        {
            return Value == null ? DBNull.Value : (object)Value;
        }

        public static int ToInt(this object Value)
        {
            return Value == DBNull.Value ? 0 : (int)Value;
        }

        public static int? ToQInt(this object Value)
        {
            return Value == DBNull.Value ? null : (int?)Value;
        }

        public static bool ToBool(this object Value)
        {
            return Value == DBNull.Value ? false : (bool)Value;
        }

        public static bool? ToQBool(this object Value)
        {
            return Value == DBNull.Value ? null : (bool?)Value;
        }

        public static double ToDouble(this object Value)
        {
            return Value == DBNull.Value ? 0 : (double)Value;
        }

        public static double? ToQDouble(this object Value)
        {
            return Value == DBNull.Value ? null : (double?)Value;
        }

        public static DateTime ToDateTime(this object Value)
        {
            return (DateTime)Value;
        }

        public static DateTime? ToQDateTime(this object Value)
        {
            return Value == DBNull.Value ? null : (DateTime?)Value;
        }

        public static string ToString(object Value)
        {
            return Value == DBNull.Value ? null : (string)Value;
        }

        public static string ToQString(this object Value)
        {
            return Value == DBNull.Value ? null : (string)Value;
        }
    }
}