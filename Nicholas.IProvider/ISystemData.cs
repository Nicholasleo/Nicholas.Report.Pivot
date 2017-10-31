/*==============================================
*CLR版本：4.0.30319.36388
*名称：ISystemData
*命名空间名称：Nicholas.IProvider
*文件名称：ISystemData
*创建时间：2017/9/19 18:33:26
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nicholas.IProvider
{
    interface ISystemData
    {
        public DataTable GetSystemMappingDataTable();
    }
}
