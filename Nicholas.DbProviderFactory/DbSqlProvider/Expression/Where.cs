/*==============================================
*CLR版本：4.0.30319.36388
*名称：Where
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Where
*创建时间：2017/9/5 17:23:36
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Expression
{
    public class Where<T> : ExpWhere
    {
        T value;
        public Where(T value)
            : base()
        {
            this.value = value;
        }

        public override string ToString()
        {
            if (this.value == null) return "Where ";

            return "Where " + base.ToExpression(value);
        }
    }

    public class Where : ExpWhere
    {
        KeyValue[] values = null;
        string whereStr = string.Empty;
        public Where(KeyValue[] values)
            : base()
        {
            this.values = values;
        }

        public Where(string whereStr)
        {
            this.whereStr = whereStr;
        }

        /// <summary>
        /// 默认“与”条件
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(whereStr))
                return "Where " + base.ToExpression(values);
            else return whereStr;
        }

        /// <summary>
        /// 定义“与或”条件
        /// </summary>
        /// <param name="andOrs"></param>
        /// <returns></returns>
        public string ToString(AndOr[] andOrs)
        {
            return "Where " + base.ToExpression(values, andOrs);
        }
    }
}
