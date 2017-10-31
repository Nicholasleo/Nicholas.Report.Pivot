/*==============================================
*CLR版本：4.0.30319.36388
*名称：Exists
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Exists
*创建时间：2017/9/5 17:21:49
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class Exists : ExpTree
    {
        string value = string.Empty;
        public Exists(string value)
        { this.value = value; }

        public override string ToString()
        {
            return "Exists (" + this.value + ") ";
        }
    }
}
