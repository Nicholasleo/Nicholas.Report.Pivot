/*==============================================
*CLR版本：4.0.30319.36388
*名称：Select
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Select
*创建时间：2017/9/5 17:23:09
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class Select<T> : ExpSelect<T> where T : class
    {
        public Select()
            : base()
        { }

        public override string ToString()
        {
            return "Select " + base.ToString();
        }
    }

    public class Select : ExpSelect
    {
        public Select(params string[] Columns)
            : base(Columns)
        {
        }

        public override string ToString()
        {
            return "Select " + base.ToString();
        }
    }
}
