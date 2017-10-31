/*==============================================
*CLR版本：4.0.30319.36388
*名称：IDbBulkCopy
*命名空间名称：Nicholas.DbProviderFactory.DbAdoProvider
*文件名称：IDbBulkCopy
*创建时间：2017/9/5 10:41:13
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nicholas.DbProviderFactory.DbAdoProvider
{
    interface IDbBulkCopy
    {
        void WriteToServer(DataTable dataTable);

        void WriteToServer(DataTable dataTable, DataRowState state);
    }
}
