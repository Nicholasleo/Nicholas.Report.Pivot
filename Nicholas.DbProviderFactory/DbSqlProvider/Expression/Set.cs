/*==============================================
*CLR版本：4.0.30319.36388
*名称：Set
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Expression
*文件名称：Set
*创建时间：2017/9/5 17:23:16
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
    public class Set : ExpTree
    {
        KeyValue[] keyvalues = null;

        public Set(params KeyValue[] keyvalues)
        { this.keyvalues = keyvalues; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Set ");
            for (int i = 0; i < keyvalues.Length; ++i)
            {
                builder.AppendFormat("{0}='{1}'{2}", keyvalues[i].Name, keyvalues[i].Value, (i < keyvalues.Length - 1 ? "," : " "));
            }
            return builder.ToString();
        }
    }

    public class Set<T> : ExpTree
    {
        T Entity = default(T);
        public Set(T Entity)
        {
            this.Entity = Entity;
        }

        public override string ToString()
        {
            PropertyInfo[] infos = typeof(T).GetProperties();
            object temp = null;
            StringBuilder builder = new StringBuilder(" Set ");
            for (int i = 0; i < infos.Length; ++i)
            {
                temp = infos[i].GetValue(Entity, null);
                if (temp == null) continue;

                if (temp is string) builder.AppendFormat("{0}='{1}'{2}", infos[i].Name, temp, (i < infos.Length - 1 ? "," : " "));
                else builder.AppendFormat("{0}={1}{2}", infos[i].Name, temp, (i < infos.Length - 1 ? "," : " "));
            }
            return builder.ToString();
        }
    }
}
