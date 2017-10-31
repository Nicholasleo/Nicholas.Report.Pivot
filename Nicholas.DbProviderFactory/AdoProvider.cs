/*==============================================
*CLR版本：4.0.30319.36388
*名称：AdoProvider
*命名空间名称：Nicholas.DbProviderFactory
*文件名称：AdoProvider
*创建时间：2017/9/5 17:37:15
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.DbProviderFactory.DbAdoProvider;
using Nicholas.Entities;

namespace Nicholas.DbProviderFactory
{
    public class AdoProvider : DbProvider, IAdoProvider
    {
        public AdoProvider(string ConnectionString,
            ProviderType ProviderType = ProviderType.SqlServer,
            bool IsSingleton = false)
            : base(ConnectionString, ProviderType, IsSingleton)
        {
        }

        public static AdoProvider CreateProvider(string ConnectionString,
            ProviderType providerType = ProviderType.SqlServer,
            bool IsSingleton = false)
        {
            return new AdoProvider(ConnectionString, providerType, IsSingleton);
        }
    }
}
