/*==============================================
*CLR版本：4.0.30319.36388
*名称：ExpSelect
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：ExpSelect
*创建时间：2017/9/5 17:22:02
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class ExpSelect<T> : ExpTree
    {
        public string[] Columns { get; set; }

        public ExpSelect()
        {
            PropertyInfo[] infos = typeof(T).GetProperties();
            Columns = new string[infos.Length];
            for (int i = 0; i < infos.Length; ++i)
            {
                Columns[i] = infos[i].Name;
            }
        }

        public override string ToString()
        {
            if (Columns == null
                || Columns.Length == 0) return string.Empty;

            return string.Join(",", Columns) + " ";
        }
    }

    public class ExpSelect : ExpTree
    {
        public string[] Columns { get; set; }

        public ExpSelect()
        { }

        public ExpSelect(string[] Columns)
        {
            this.Columns = Columns;
        }

        public override string ToString()
        {
            if (Columns == null
                || Columns.Length == 0) return string.Empty;

            return string.Join(",", Columns) + " ";
        }
    }
}
