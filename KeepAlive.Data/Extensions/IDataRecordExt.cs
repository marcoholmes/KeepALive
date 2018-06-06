using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Data.Extensions
{
    public static class IDataRecordExt
    {
        #region "GetInt32"

        public static int GetInteger(this IDataRecord record, string name)
        {
            
            return getItem(record, record.GetInt32, name, 0);
        }

        #endregion

        #region "GetValue"

        public static T GetValue<T>(this IDataRecord record, int ordinal)
        {
            return getItemValue<T>(record, ordinal, CultureInfo.CurrentCulture);
        }

        private static T getItemValue<T>(IDataRecord record, int i, IFormatProvider provider)
        {
            Type type = Nullable.GetUnderlyingType(typeof(T)) != null ? Nullable.GetUnderlyingType(typeof(T)) : typeof(T);
            if (record.IsDBNull(i))
                return default(T);

            object value = record.GetValue(i);

            if (value is IConvertible)
            {
                value = System.Convert.ChangeType(value, type, provider);
            }

            return (T)value;
        }


        #endregion

        #region "GetString"

        public static string GetString(this IDataRecord record, string name)
        {
            return getItem(record, record.GetString, name, string.Empty);
        }

        #endregion

        private static T getItem<T>(IDataRecord record,
                             Func<int, T> getter,
                             string name,
                             T defaultValue)
        {
            int index = record.GetOrdinal(name);

            if (record.IsDBNull(index))
            {
                return defaultValue;
            }
            else
            {
                return getter(index);
            }
        }
    }
}
