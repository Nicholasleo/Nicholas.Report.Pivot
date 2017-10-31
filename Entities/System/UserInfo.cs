/*==============================================
*CLR版本：4.0.30319.36388
*名称：UserInfo
*命名空间名称：Entities.System
*文件名称：UserInfo
*创建时间：2017/9/16 21:18:24
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.System
{
    public class UserInfo
    {
        public string ServerUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public bool Remember { get; set; }
    }
}
