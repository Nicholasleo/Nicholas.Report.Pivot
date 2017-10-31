/*==============================================
*CLR版本：4.0.30319.36388
*名称：Models
*命名空间名称：Nicholas.DbProviderFactory.DbSqlProvider
*文件名称：Models
*创建时间：2017/9/5 17:21:19
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Nicholas.DbProviderFactory.DbSqlProvider
{
    /// <summary>
    /// 排序方式
    /// </summary>
    [Flags]
    public enum Ordering
    {
        /// <summary>
        /// 降序
        /// </summary>
        Desc = 0,
        /// <summary>
        /// 升序
        /// </summary>
        Asc = 2
    }

    [Flags]
    public enum AndOr
    {
        /// <summary>
        /// 与
        /// </summary>
        And = 0,
        /// <summary>
        /// 或
        /// </summary>
        Or
    }

    [StructLayout(LayoutKind.Sequential)]
    public class KeyValue
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}