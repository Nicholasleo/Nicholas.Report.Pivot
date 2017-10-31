/*==============================================
*CLR版本：4.0.30319.36388
*名称：ExpFrom
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：ExpFrom
*创建时间：2017/9/5 17:21:56
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class ExpFrom<T> : ExpTree
    {
        public string TableName { get; set; }
        public ExpFrom()
        {
            TableName = typeof(T).Name;
        }
    }

    public class ExpFrom : ExpTree
    {
        public string[] TableNames { get; set; }
        public ExpFrom(params string[] TableNames)
        {
            this.TableNames = TableNames;
        }
    }
}
