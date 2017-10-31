/*==============================================
*CLR版本：4.0.30319.36388
*名称：OrderByExtension
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider.Extensions
*文件名称：OrderByExtension
*创建时间：2017/9/5 17:32:05
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.DbProviderFactory.DbSqlProvider.Expression;
using SysLE = System.Linq.Expressions;

namespace Nicholas.DbProviderFactory.DbSqlProvider.Extensions
{
    public static class OrderByExtension
    {
        #region order by 关键字拼接
        /// <summary>
        /// 默认Asc(升序)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="Names"></param>
        /// <returns></returns>
        public static OrderBy OrderBy(this From from, params string[] Names)
        {
            OrderBy orderby = new OrderBy(Names);
            orderby.SqlString = from.SqlString + orderby.ToString();

            return orderby;
        }

        public static OrderBy OrderBy(this From from, Ordering[] orderings, params string[] Names)
        {
            OrderBy orderby = new OrderBy(Names);
            orderby.SqlString = from.SqlString + orderby.ToString(orderings);

            return orderby;
        }

        public static OrderBy OrderBy<T, TSource>(this From from, SysLE.Expression<Func<T, TSource>> exp)
        {
            OrderBy orderby = new OrderBy(SysExpression_Analyize<T, TSource>(exp));
            orderby.SqlString = from.SqlString + orderby.ToString();

            return orderby;
        }

        private static string SysExpression_Analyize<T, TSource>(SysLE.Expression<Func<T, TSource>> exp)
        {
            if (exp.Body.NodeType == SysLE.ExpressionType.Parameter) return exp.Name;
            else if (exp.Body.NodeType == SysLE.ExpressionType.MemberAccess)
            {
                SysLE.MemberExpression mexp = (SysLE.MemberExpression)exp.Body;
                if (mexp == null) return string.Empty;
                else return mexp.Member.Name;
            }
            else return string.Empty;
        }

        #endregion
    }
}
