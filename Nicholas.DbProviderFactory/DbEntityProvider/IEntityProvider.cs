/*==============================================
*CLR版本：4.0.30319.36388
*名称：IEntityProvider
*命名空间名称：Nicholas.DbProviderFactory.DbEntityProvider
*文件名称：IEntityProvider
*创建时间：2017/9/5 16:25:06
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Nicholas.DbProviderFactory.DbEntityProvider
{
    public interface IEntityProvider
    {
        void DatabaseCreateOrMigrate();

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        IQueryable<TEntity> NoTrackQuery<TEntity>() where TEntity : class;

        IQueryable<TEntity> NoTrackQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;

        int Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        void Refresh<TEntity>(TEntity entity) where TEntity : class;

        TEntity GetById<TEntity>(object id) where TEntity : class;

        TEntity Insert<TEntity>(TEntity entity, bool isSaveChange = false) where TEntity : class;

        IEnumerable<TEntity> InsertRange<TEntity>(TEntity[] entities, bool isSaveChange = false) where TEntity : class;

        long BulkCopyWrite<TEntity>(IList<TEntity> collection, int batchSize = 10240) where TEntity : class;

        void Update<TEntity>(TEntity entity, bool isSaveChange = false) where TEntity : class;

        void Delete<TEntity>(TEntity entity, bool isSaveChange = false) where TEntity : class;

        IEnumerable<TEntity> Delete<TEntity>(Func<TEntity, bool> predicate, bool isSaveChange = false) where TEntity : class;

        int ExecuteCommand(string command, params object[] parameters);

        int ExecuteCommandTransaction(string command, System.Data.IsolationLevel IsolationLevel, params object[] parameters);

        List<T> ExecuteQuery<T>(string command, params object[] parameters);

        int SaveChanges();

        void Dispose();
    }
}
