/*==============================================
*CLR版本：4.0.30319.36388
*名称：GroupBy
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：GroupBy
*创建时间：2017/9/5 17:22:33
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class GroupBy : ExpTree
    {
        string[] groupNames = null;

        public GroupBy(params string[] groupNames)
        { this.groupNames = groupNames; }

        public override string ToString()
        {
            return "Group By " + string.Join(",", groupNames) + " ";
        }
    }
}
