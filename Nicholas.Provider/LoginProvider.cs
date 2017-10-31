/*==============================================
*CLR版本：4.0.30319.36388
*名称：LoginProvider
*命名空间名称：Nicholas.Provider
*文件名称：LoginProvider
*创建时间：2017/9/5 19:43:02
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
using Entities.System;

namespace Nicholas.Provider
{
    public class LoginProvider
    {
        private string _dbConnectionString = SystemConfig.GetDbConnectString();
        private DbProvider _provider;
        public LoginProvider()
        {
            _provider = new DbProvider(_dbConnectionString);
        }

        public LoginProvider(ProviderType providerType)
        {
            _provider = new DbProvider(_dbConnectionString, providerType);
        }

        public LoginProvider(ProviderType providerType, bool isSingleton)
        {
            _provider = new DbProvider(_dbConnectionString, providerType, isSingleton);
        }

        public DbProvider GetDbProvider(ProviderType providerType)
        {
            return DbProvider.CreateProvider(_dbConnectionString, providerType);
        }

        public ResultInfo<bool, string> Login(string userCode,string password)
        {
            ResultInfo<bool, string> resultInfo = new ResultInfo<bool, string>();
            try
            {
                
                resultInfo = _provider.Connect(_dbConnectionString);
                //if(resultInfo.Result)
                //{
                //    DbExecuteParameter dbExecuteParameter = new DbExecuteParameter(1800);
                //    dbExecuteParameter.IsStoredProcedure = true;
                //    dbExecuteParameter.CommandText = ProcedureName.LoginProcedure;
                //    DbProviderParameter[] dbProviderParameters = new DbProviderParameter[2];

                //    dbProviderParameters[0].DbType = DbType.String;
                //    dbProviderParameters[0].Value = userCode;
                //    dbProviderParameters[0].ParameterName = ColumnName.AccountName;

                //    dbProviderParameters[1].DbType = DbType.String;
                //    dbProviderParameters[1].Value = password;
                //    dbProviderParameters[1].ParameterName = ColumnName.Pwd;

                //    dbExecuteParameter.dbProviderParameters = dbProviderParameters;
                //    ResultInfo<DataTable, string> loginInfo = _provider.Query(dbExecuteParameter);
                //    if (loginInfo.Result != null && loginInfo.Result.Rows.Count > 0)
                //    {
                //        resultInfo.Info = "登陆成功";
                //    }
                //}
            }
            catch (Exception ex) 
            {
                resultInfo.Info = "登陆失败，请检查用户名和密码！";
                resultInfo.Result = false;
            }
            return resultInfo;
        }
    }
}
