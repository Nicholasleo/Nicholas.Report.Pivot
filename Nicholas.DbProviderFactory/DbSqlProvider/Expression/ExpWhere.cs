/*==============================================
*CLR版本：4.0.30319.36388
*名称：ExpWhere
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：ExpWhere
*创建时间：2017/9/5 17:22:16
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
    public class ExpWhere : ExpTree
    {
        public ExpWhere()
        { }

        public string ToExpression<T>(T value)
        {
            if (value is KeyValue[])
            {
                return ToAndExpression(value as KeyValue[]);
            }
            else
            {
                PropertyInfo[] infos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                StringBuilder builder = new StringBuilder();
                object temp = null;
                for (int i = 0; i < infos.Length; ++i)
                {
                    var item = infos[i];

                    temp = item.GetValue(value, null);
                    if (temp == null) continue;

                    if (temp is string) builder.AppendFormat("{0}='{1}' {2}", item.Name, temp, (i < infos.Length - 1 ? "And " : " "));
                    else builder.AppendFormat("{0}={1} {2}", item.Name, temp, (i < infos.Length - 1 ? "And " : " "));
                }
                return builder.ToString();
            }
        }

        public string ToExpression(KeyValue[] values, AndOr[] andOrs)
        {
            if ((values.Length - 1) != andOrs.Length)
                throw new Exception("键值对和条件对条数不匹配,");

            StringBuilder builder = new StringBuilder();
            int count = values.Length - 1;

            for (int i = 0; i < values.Length; ++i)
            {
                builder.AppendFormat("{0}='{1}' {2}", values[i].Name, values[i].Value, (i < count ? andOrs[i].ToString() + " " : " "));
            }
            return builder.ToString();
        }

        public string ToAndExpression(KeyValue[] values)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; ++i)
            {
                builder.AppendFormat("{0}='{1}' {2}", values[i].Name, values[i].Value, (i < values.Length - 1 ? "And " : " "));
            }
            return builder.ToString();
        }
    }
}
