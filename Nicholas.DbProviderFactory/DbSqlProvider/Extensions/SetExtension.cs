/*==============================================
*CLR版本：4.0.30319.36388
*名称：SetExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：SetExtension
*创建时间：2017/9/5 17:34:18
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
    public static class SetExtension
    {
        public static Set Set(this Update update, string tableName, params KeyValue[] kvalue)
        {
            Set set = new Set(kvalue);
            set.SqlString = update.SqlString + set.ToString();

            return set;
        }

        public static Set<T> Set<T>(this Update<T> update, T Entity)
        {
            Set<T> set = new Expression.Set<T>(Entity);
            set.SqlString = update.SqlString + set.ToString();

            return set;
        }
    }
}
