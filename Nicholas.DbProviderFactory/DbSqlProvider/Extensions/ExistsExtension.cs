/*==============================================
*CLR版本：4.0.30319.36388
*名称：ExistsExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：ExistsExtension
*创建时间：2017/9/5 17:28:34
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
    public static class ExistsExtension
    {
        #region exists

        public static Exists Exists(this Where where, string values)
        {
            Exists _exists = new Exists(values);
            _exists.SqlString = where.SqlString + _exists.ToString();

            return _exists;
        }

        #endregion
    }
}
