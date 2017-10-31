/*==============================================
*CLR版本：4.0.30319.36388
*名称：Update
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Update
*创建时间：2017/9/5 17:23:29
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class Update : ExpTree
    {
        string tableName = string.Empty;
        public Update(string tableName)
        { this.tableName = tableName; }

        public override string ToString()
        {
            return "Update " + tableName;
        }
    }

    public class Update<T> : ExpTree
    {
        string tableName = string.Empty;

        public Update()
        {
            tableName = typeof(T).Name;
        }

        public override string ToString()
        {
            return "Update " + tableName;
        }
    }
}
