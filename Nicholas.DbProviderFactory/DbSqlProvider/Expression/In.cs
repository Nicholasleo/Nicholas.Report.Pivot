/*==============================================
*CLR版本：4.0.30319.36388
*名称：In
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：In
*创建时间：2017/9/5 17:22:39
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class In : ExpTree
    {
        string[] ins = null;
        public In(params string[] ins)
        { this.ins = ins; }

        public override string ToString()
        {
            return "In (" + string.Join(",", ins) + ") ";
        }
    }
}
