/*==============================================
*CLR版本：4.0.30319.36388
*名称：NotExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：NotExtension
*创建时间：2017/9/5 17:31:40
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
    public static class NotExtension
    {
        #region notexists

        public static NotExists NotExists(this Where where, string values)
        {
            NotExists _notEists = new NotExists(values);
            _notEists.SqlString = where.SqlString + _notEists.ToString();

            return _notEists;
        }

        #endregion
    }
}
