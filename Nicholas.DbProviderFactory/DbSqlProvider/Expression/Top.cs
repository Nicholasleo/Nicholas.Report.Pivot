/*==============================================
*CLR版本：4.0.30319.36388
*名称：Top
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Top
*创建时间：2017/9/5 17:23:22
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class Top : ExpTree
    {
        int count = 0;
        public Top(int count = 30)
        { this.count = count; }

        public override string ToString()
        {
            return "Top " + count.ToString() + " ";
        }
    }
}
