/*==============================================
*CLR版本：4.0.30319.36388
*名称：OrmProvider
*命名空间名称：Nicholas.DbProviderFactory
*文件名称：OrmProvider
*创建时间：2017/9/5 19:13:32
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.DbProviderFactory.DbEntityProvider;

namespace Nicholas.DbProviderFactory
{
    public class OrmProvider : EntityProvider, IOrmProvider
    {
        public static new OrmProvider CreateProvider(string DbConnection = null)
        {
            return new OrmProvider(DbConnection);
        }

        public OrmProvider(string DbConnection = null)
            : base(DbConnection)
        { }
    }
}
