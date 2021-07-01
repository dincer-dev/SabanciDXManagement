using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabanciDxManagement.Helper
{
    public static class ExtensionHelper
    {
        public static IEnumerable<T> Select<T>(this DbDataReader dataReader, Func<DbDataReader, T> projection)
        {
            while (dataReader.Read())
                yield return projection(dataReader);
        }
    }
}
