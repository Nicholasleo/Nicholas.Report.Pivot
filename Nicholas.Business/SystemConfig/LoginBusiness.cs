/*==============================================
*CLR版本：4.0.30319.36388
*名称：LoginBusiness
*命名空间名称：Nicholas.Business.SystemConfig
*文件名称：LoginBusiness
*创建时间：2017/9/5 19:39:49
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Entities;
using System.Data;
using Nicholas.Provider;

namespace Nicholas.Business.SystemConfig
{
    public class LoginBusiness
    {
        private LoginProvider _loginProvider;
        public LoginBusiness(ProviderType providerType)
        {
            if (_loginProvider == null)
                _loginProvider = new LoginProvider(providerType);
        }

        public LoginBusiness()
        {
            if (_loginProvider == null)
                _loginProvider = new LoginProvider();
        }

        public ResultInfo<bool, string> Login(string userCode, string password)
        {
            ResultInfo<bool, string> resultInfo = new ResultInfo<bool, string>();
            try
            {
                resultInfo = _loginProvider.Login(userCode, password);
            }
            catch (Exception ex)
            { 
            }
            return resultInfo;
        }
    }
}
