/*==============================================
*CLR版本：4.0.30319.36388
*名称：PivotDataProvider
*命名空间名称：Nicholas.Provider
*文件名称：PivotDataProvider
*创建时间：2017/9/17 13:39:45
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.DbProviderFactory.DbAdoProvider;
using Nicholas.Untilty;
using Nicholas.Entities;
using System.Data;

namespace Nicholas.Provider
{
    public class PivotDataProvider
    {
        private string _dbConnectionString = SystemConfig.GetDbConnectString();
        private DbProvider _provider;

        public PivotDataProvider()
        {
            _provider = new DbProvider(_dbConnectionString);
        }

         public PivotDataProvider(ProviderType providerType)
        {
            _provider = new DbProvider(_dbConnectionString, providerType);
        }

         public PivotDataProvider(ProviderType providerType, bool isSingleton)
        {
            _provider = new DbProvider(_dbConnectionString, providerType, isSingleton);
        }

        public DbProvider GetDbProvider(ProviderType providerType)
        {
            return DbProvider.CreateProvider(_dbConnectionString, providerType);
        }

        public ResultInfo<DataTable, string> GetDataTable(DbExecuteParameter dbExecuteParameter)
        {
            ResultInfo<DataTable, string> resultInfo = new ResultInfo<DataTable, string>();
            resultInfo = _provider.Query(dbExecuteParameter);
            return resultInfo;
        }

        public ResultInfo<DataSet, string> GetDataSet(DbExecuteParameter dbExecuteParameter)
        {
            ResultInfo<DataSet, string> resultInfo = new ResultInfo<DataSet, string>();
            return resultInfo;
        }
    }
}
