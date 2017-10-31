/*==============================================
*CLR版本：4.0.30319.36388
*名称：Extension
*命名空间名称：Nicholas.DbProviderFactory.DbEntityProvider
*文件名称：Extension
*创建时间：2017/9/5 16:24:46
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Nicholas.DbProviderFactory.DbEntityProvider
{
    internal static class Extension
    {
        public static void Detach<TEntity>(this DbContext dbContext, TEntity entity) where TEntity : class
        {
            ObjectContext context = ((IObjectContextAdapter)dbContext).ObjectContext;
            context.Detach(entity);
        }

        public static void Refresh<TEntity>(this EntityProvider dbProvider, TEntity entity) where TEntity : class
        {
            dbProvider.Refresh<TEntity>(entity);
        }
    }
}
