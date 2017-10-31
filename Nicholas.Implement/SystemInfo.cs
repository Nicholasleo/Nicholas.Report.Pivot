/*==============================================
*CLR版本：4.0.30319.36388
*名称：SystemInfo
*命名空间名称：Nicholas.Implement
*文件名称：SystemInfo
*创建时间：2017/9/19 18:35:52
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System.Data;
using Nicholas.DbProviderFactory.DbAdoProvider;
using Nicholas.Untilty;
using Nicholas.Entities;
using System;

namespace Nicholas.Implement
{
    public class SystemInfo : IDisposable
    {
        private string _dbConnectionString = SystemConfig.GetDbConnectString();
        private DbProvider _provider;

        public SystemInfo()
        {
            _provider = new DbProvider(_dbConnectionString);
        }

         public SystemInfo(ProviderType providerType)
        {
            _provider = new DbProvider(_dbConnectionString, providerType);
        }

         public SystemInfo(ProviderType providerType, bool isSingleton)
        {
            _provider = new DbProvider(_dbConnectionString, providerType, isSingleton);
        }

        public DbProvider GetDbProvider(ProviderType providerType)
        {
            return DbProvider.CreateProvider(_dbConnectionString, providerType);
        }

        public DataTable GetSystemFieldsMapping()
        {
            DataTable resultTable = new DataTable();
            try
            {
                DbExecuteParameter dbExecuteParameter = new DbExecuteParameter();
                dbExecuteParameter.CommandText = "SELECT NameSc,SysColumnName,SysTableName FROM dbo.TabColName";
                dbExecuteParameter.IgnoreCase = true;
                dbExecuteParameter.IsStoredProcedure = false;
                dbExecuteParameter.ExectueTimeout = 1800;
                ResultInfo<DataTable, string> resultInfo = GetDataTable(dbExecuteParameter);
                if (resultInfo.Result != null)
                {
                    resultTable = resultInfo.Result;
                }
                else
                {
                    throw new Exception(resultInfo.Info);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resultTable;
        }

        private ResultInfo<DataTable, string> GetDataTable(DbExecuteParameter dbExecuteParameter)
        {
            ResultInfo<DataTable, string> resultInfo = new ResultInfo<DataTable, string>();
            resultInfo = _provider.Query(dbExecuteParameter);
            return resultInfo;
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
