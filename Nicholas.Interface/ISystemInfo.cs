/*==============================================
*CLR版本：4.0.30319.36388
*名称：ISystemInfo
*命名空间名称：Nicholas.Interface
*文件名称：ISystemInfo
*创建时间：2017/9/19 18:37:32
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System.Data;
using System;

namespace Nicholas.Interface
{
    public interface ISystemInfo : IDisposable
    {
        DataTable GetSystemFieldsMapping();
    }
}
