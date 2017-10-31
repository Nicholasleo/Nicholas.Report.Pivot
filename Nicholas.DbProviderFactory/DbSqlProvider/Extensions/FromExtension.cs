/*==============================================
*CLR版本：4.0.30319.36388
*名称：FromExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：FromExtension
*创建时间：2017/9/5 17:29:38
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.DbProviderFactory.DbSqlProvider.Expression;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Extensions
{
    public static class FromExtension
    {
        #region From关键字拼接
        public static From From(this Select select, params string[] tableName)
        {
            From from = new From(tableName);
            from.SqlString = select.SqlString + from.ToString();

            return from;
        }

        public static From<T> From<T>(this Select<T> select) where T : class
        {
            From<T> from = new From<T>();
            from.SqlString = select.SqlString + from.ToString();

            return from;
        }

        public static From From(this Delete delete, string tableName)
        {
            From from = new Expression.From(tableName);
            from.SqlString = delete.ToString() + from.ToString();

            return from;
        }

        public static From<T> From<T>(this Delete<T> delete) where T : class
        {
            From<T> from = new Expression.From<T>();
            from.SqlString = delete.ToString() + from.ToString();

            return from;
        }
        #endregion
    }
}
