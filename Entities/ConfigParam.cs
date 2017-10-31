/*==============================================
*CLR版本：4.0.30319.36388
*名称：ConfigParam
*命名空间名称：Entities
*文件名称：ConfigParam
*创建时间：2017/9/20 17:32:24
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ConfigParam
    {

        #region 最近操作文件夹

        /// <summary>
        /// 导出文件对应的文件夹
        /// </summary>
        public string DirectLastExport = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 打开文件对应的文件夹
        /// </summary>
        public string DirectLastOpen = AppDomain.CurrentDomain.BaseDirectory;


        #endregion        
    }
}
