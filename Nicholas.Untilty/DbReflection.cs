/*==============================================
*CLR版本：4.0.30319.36388
*名称：DbReflection
*命名空间名称：Nicholas.Untilty
*文件名称：DbReflection
*创建时间：2017/9/5 11:07:21
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace Nicholas.Untilty
{
    public static class DbReflection
    {
        public static T GetGenericObjectValue<T>(this DbDataReader reader, bool ignoreCase = false) where T : new()
        {
            T value = new T();
            Type toType = typeof(T);
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var pi in pinfos)
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    if (NameEqual(pi.Name, reader.GetName(i), ignoreCase))
                    {
                        object attrValue = reader.GetValue(i);

                        if (attrValue == null || attrValue == DBNull.Value)
                            continue;

                        //转换类型
                        var dstPro = toType.GetProperty(pi.Name);
                        var dstType = dstPro.PropertyType;

                        object dstValue = null;

                        if (dstType.IsGenericType && dstType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            dstValue = Convert.ChangeType(attrValue, dstType.GetGenericArguments()[0]);
                        }
                        else if (dstType.IsEnum)
                        {
                            dstValue = Enum.ToObject(dstType, attrValue);
                        }
                        else
                        {
                            dstValue = Convert.ChangeType(attrValue, dstType);
                        }
                        pi.SetValue(value, dstValue, null);
                        break;
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// 根据DbDataReader映射到结构体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> GetGenericObjectValues<T>(this DbDataReader reader, bool ignoreCase = false) where T : new()
        {
            List<T> items = new List<T>(16);
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Type toType = typeof(T);

            while (reader.Read())
            {
                T value = new T();

                foreach (var pi in pinfos)
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        if (NameEqual(pi.Name, reader.GetName(i), ignoreCase))
                        {
                            object attrValue = reader.GetValue(i);

                            if (attrValue == null || attrValue == DBNull.Value)
                                continue;

                            //转换类型
                            var dstPro = toType.GetProperty(pi.Name);
                            var dstType = dstPro.PropertyType;

                            object dstValue = null;

                            if (dstType.IsGenericType && dstType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                dstValue = Convert.ChangeType(attrValue, dstType.GetGenericArguments()[0]);
                            }
                            else if (dstType.IsEnum)
                            {
                                dstValue = Enum.ToObject(dstType, attrValue);
                            }
                            else
                            {
                                dstValue = Convert.ChangeType(attrValue, dstType);
                            }
                            pi.SetValue(value, dstValue, null);
                            break;
                        }
                    }
                }
                items.Add(value);
            }
            return items;
        }

        private static bool NameEqual(string srcName, string dstName, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return srcName.ToLower().Equals(dstName.ToLower());
            }
            else
            {
                return srcName.Equals(dstName);
            }
        }
    }
}
