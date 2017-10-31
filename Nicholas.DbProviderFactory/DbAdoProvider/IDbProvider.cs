/*==============================================
*CLR版本：4.0.30319.36388
*名称：IDbProvider
*命名空间名称：Nicholas.DbProviderFactory.DbAdoProvider
*文件名称：IDbProvider
*创建时间：2017/9/5 10:41:37
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nicholas.DbProviderFactory.DbAdoProvider;
using Nicholas.Entities;

namespace Nicholas.DbProviderFactory.DbAdoProvider
{
    interface IDbProvider
    {
        string DbConnectionString { get; set; }

        ProviderType DbType { get; set; }
        void Dispose();
        ResultInfo<bool, string> Connect(string connString);
        ResultInfo<DataTable, string> Query(DbExecuteParameter dbExecuteParameter);
        ResultInfo<List<T>, string> Query<T>(DbExecuteParameter dbExecuteParameter) where T : new();
        ResultInfo<DataSet, string> QueryToSet(DbExecuteParameter dbExecuteParameter);
        ResultInfo<int, string> QueryTo<T>(DbExecuteParameter dbExecuteParameter, Func<T, bool> rowAction) where T : new();
        ResultInfo<int, string> QueryToReader(DbExecuteParameter dbExecuteParameter, Func<IDataReader, bool> rowAction);
        ResultInfo<IDataReader, string> QueryToReader(DbExecuteParameter dbExecuteParameter);
        ResultInfo<int, string> QueryChanged(DbExecuteParameter dbExecuteParameter, Func<DataTable, bool> action);
        ResultInfo<int, string> QueryToTable(DbExecuteParameter dbExecuteParameter, DataTable dstTable);
        ResultInfo<int, string> ExecuteCmd(DbExecuteParameter dbExecuteParameter);

        ResultInfo<int, string> ExecuteTransaction(DbExecuteParameter dbExecuteParameter);

        ResultInfo<int, string> ExecuteTransaction(string[] CommandTexts, int timeout = 1800);

        ResultInfo<T, string> ExecuteScalar<T>(DbExecuteParameter dbExecuteParameter);

        ResultInfo<int, string> BulkCopy(DbExecuteBulkParameter dbExecuteParameter);
    }
}
