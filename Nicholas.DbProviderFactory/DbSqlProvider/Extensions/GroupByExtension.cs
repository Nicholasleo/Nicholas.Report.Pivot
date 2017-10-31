/*==============================================
*CLR版本：4.0.30319.36388
*名称：GroupByExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：GroupByExtension
*创建时间：2017/9/5 17:30:40
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
    public static class GroupByExtension
    {
        #region group by 关键字拼接
        public static GroupBy GroupBy(this From from, params string[] groupNames)
        {
            GroupBy groupby = new GroupBy(groupNames);
            groupby.SqlString = from.SqlString + groupby.ToString();

            return groupby;
        }
        #endregion
    }
}
