/*==============================================
*CLR版本：4.0.30319.36388
*名称：DataPool
*命名空间名称：Nicholas.Business
*文件名称：DataPool
*创建时间：2017/9/19 18:25:12
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nicholas.Implement;

namespace Nicholas.Business
{
    public class DataPool
    {
        private static readonly DataPool _instance = new DataPool();

        private readonly SystemInfo _systemInfo = new SystemInfo();
        public static DataPool Instance
        {
            get {
                return _instance;
            }
        }

        private DataTable _dtFieldMapping;

        public DataTable DtFieldMapping
        {
            get {
                if (_dtFieldMapping == null || _dtFieldMapping.Rows.Count <= 0)
                {
                    _dtFieldMapping = _systemInfo.GetSystemFieldsMapping();
                }
                return _dtFieldMapping;
            }
        }
    }   
}
