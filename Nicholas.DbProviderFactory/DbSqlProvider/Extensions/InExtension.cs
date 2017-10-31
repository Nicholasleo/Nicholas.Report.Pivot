/*==============================================
*CLR版本：4.0.30319.36388
*名称：InExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：InExtension
*创建时间：2017/9/5 17:31:13
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
    public static class InExtension
    {
        #region  In
        public static In In(this Where where, params string[] values)
        {
            In _in = new In(values);
            _in.SqlString = where.SqlString + _in.ToString();

            return _in;
        }

        #endregion
    }
}
