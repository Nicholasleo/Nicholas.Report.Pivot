/*==============================================
*CLR版本：4.0.30319.36388
*名称：EntityMapper
*命名空间名称：Nicholas.DbProviderFactory.DbMapper
*文件名称：EntityMapper
*创建时间：2017/9/5 17:11:09
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Untilty;
using System.Reflection;

namespace Nicholas.DbProviderFactory.DbMapper
{
    public class EntityMapper
    {
        public static ToEntity MapToCreated<FromEntity, ToEntity>(FromEntity from)
        {
            ToEntity to = Activator.CreateInstance<ToEntity>();
            var tTo = typeof(ToEntity);
            var psFrom = typeof(FromEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var pFrom in psFrom)
            {
                var pTo = tTo.GetProperty(pFrom.Name);
                if (pTo == null) continue;

                var vFrom = pFrom.GetValue(from, new object[] { pFrom });
                if (vFrom == null) continue;

                var pToType = pTo.PropertyType;
                object vTo = null;

                if (pToType.IsGenericType && pToType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    vTo = Convert.ChangeType(vFrom, pToType.GetGenericArguments()[0]);
                }
                else if (pToType.IsEnum)
                {
                    vTo = Enum.ToObject(pToType, vFrom);
                }
                else
                {
                    vTo = Convert.ChangeType(vFrom, pTo.PropertyType);
                }
                pTo.SetValue(to, vTo, new object[] { pFrom });
            }
            return to;
        }

        public static ToEntity MapTo<FromEntity, ToEntity>(FromEntity from, ToEntity to)
        {
            var tTo = typeof(ToEntity);
            PropertyInfo[] psFrom = typeof(FromEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var pFrom in psFrom)
            {
                var vFrom = pFrom.GetValue(from, new object[] { pFrom });
                if (vFrom == null) continue;

                var pTo = tTo.GetProperty(pFrom.Name);
                if (pTo == null) continue;

                var pToType = pTo.PropertyType;
                object vTo = null;

                if (pToType.IsGenericType && pToType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    vTo = Convert.ChangeType(vFrom, pToType.GetGenericArguments()[0]);
                }
                else if (pToType.IsEnum)
                {
                    vTo = Enum.ToObject(pToType, vFrom);
                }
                else
                {
                    vTo = Convert.ChangeType(vFrom, pTo.PropertyType);
                }
                pTo.SetValue(to, vTo, new object[] { pFrom });
            }
            return to;
        }

        public static ToEntity MapTo<FromEntity, ToEntity>(FromEntity from, ToEntity to,
            FilterType filterType,
            params string[] FilterColumnNames)
        {
            var tTo = typeof(ToEntity);
            var psFrom = typeof(FromEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var pFrom in psFrom)
            {
                if (filterType != FilterType.Default
                    && FilterColumnNames.Length > 0)
                {
                    switch (filterType)
                    {
                        case FilterType.Ignore:
                            if (FilterColumnNames.Contains(pFrom.Name)) continue;
                            break;
                        case FilterType.Include:
                            if (!FilterColumnNames.Contains(pFrom.Name)) continue;
                            break;
                    }
                }

                object vFrom = pFrom.GetValue(from, new object[] { pFrom });
                if (vFrom == null) continue;

                PropertyInfo pTo = tTo.GetProperty(pFrom.Name);
                if (pTo == null) continue;

                Type pToType = pTo.PropertyType;
                object vTo = null;

                if (pToType.IsGenericType && pToType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    vTo = Convert.ChangeType(vFrom, pToType.GetGenericArguments()[0]);
                }
                else if (pToType.IsValueType)
                {
                    vTo = Convert.ChangeType(vFrom, pTo.PropertyType);
                }
                else if (pToType.IsEnum)
                {
                    vTo = Enum.ToObject(pToType, vFrom);
                }
                if (filterType == FilterType.NullIgnore
                    && vTo == null) continue;

                pTo.SetValue(to, vTo, new object[] { pFrom });
            }
            return to;
        }
    }

    public enum FilterType
    {
        Default = 0,
        Ignore = 1,
        Include = 2,
        NullIgnore = 4
    }
}