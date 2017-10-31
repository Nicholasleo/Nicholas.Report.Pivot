/*==============================================
*CLR版本：4.0.30319.36388
*名称：From
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：From
*创建时间：2017/9/5 17:22:25
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class From<T> : ExpFrom<T> where T : class
    {
        public From()
            : base()
        { }

        public override string ToString()
        {
            return string.Format("From {0} ", TableName);
        }
    }

    public class From : ExpFrom
    {
        public From(params string[] TableName)
            : base(TableName)
        { }

        public override string ToString()
        {
            return string.Format("From {0} ", TableNames);
        }
    }
}
