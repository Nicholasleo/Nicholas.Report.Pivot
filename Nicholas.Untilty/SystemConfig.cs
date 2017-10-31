/*==============================================
*CLR版本：4.0.30319.36388
*名称：SystemConfig
*命名空间名称：Nicholas.Untilty
*文件名称：SystemConfig
*创建时间：2017/9/5 19:43:53
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.Untilty
{
    public class SystemConfig
    {
        private static string _dbConnectionString = string.Empty;

        public SystemConfig()
        {
        }

        public SystemConfig(string server, string user, string pwd, string databaseName)
        {
            _dbConnectionString = string.Format(@"Data Source={0};Initial Catalog={3};uid={1};pwd={2};MultipleActiveResultSets=True", server, user, pwd, databaseName);
        }

        public static string GetDbConnectString()
        {
            return _dbConnectionString;
        }
    }
}
