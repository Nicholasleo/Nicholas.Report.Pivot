/*==============================================
*CLR版本：4.0.30319.36388
*名称：PivotDataBusiness
*命名空间名称：Nicholas.Business.SystemConfig
*文件名称：PivotDataBusiness
*创建时间：2017/9/17 13:39:09
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Entities;
using Nicholas.Provider;
using System.Data;

namespace Nicholas.Business.SystemConfig
{
    public class PivotDataBusiness
    {
        private PivotDataProvider _pivotDataProvider;
        public PivotDataBusiness(ProviderType providerType)
        {
            if (_pivotDataProvider == null)
                _pivotDataProvider = new PivotDataProvider(providerType);
        }

        public PivotDataBusiness()
        {
            if (_pivotDataProvider == null)
                _pivotDataProvider = new PivotDataProvider();
        }

        public ResultInfo<DataTable, string> GetDataTable()
        {
            DbExecuteParameter dbExecuteParameter = new DbExecuteParameter();
            dbExecuteParameter.IsStoredProcedure = true;
            dbExecuteParameter.IgnoreCase = true;
            dbExecuteParameter.CommandText = "P_Test";
            ResultInfo<DataTable, string> resultInfo = new ResultInfo<DataTable, string>();
            resultInfo = _pivotDataProvider.GetDataTable(dbExecuteParameter);
            return resultInfo;
        }

        public ResultInfo<DataSet, string> GetDataSet(DbExecuteParameter dbExecuteParameter)
        {
            ResultInfo<DataSet, string> resultInfo = new ResultInfo<DataSet, string>();
            resultInfo = _pivotDataProvider.GetDataSet(dbExecuteParameter);
            return resultInfo;
        }
    }
}
