/*==============================================
*CLR版本：4.0.30319.36388
*名称：Configure
*命名空间名称：Nicholas.Business
*文件名称：Configure
*创建时间：2017/9/20 17:31:28
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Entities;
using System.Reflection;
using System.IO;

namespace Nicholas.Business
{
    public class Configure
    {
        private XmlDocument xDoc = new XmlDocument();
        private XmlNode xNode = null;
        private string _filepath;
        private string _fileDirect = AppDomain.CurrentDomain.BaseDirectory + "\\Temp\\";
        private ConfigParam _param;


        private readonly static Configure _instance = new Configure();
        /// <summary>
        /// 单件实体
        /// </summary>
        public static Configure Instance
        {
            get { return _instance; }
        }
        #region 参数类
        /// <summary>
        /// 此属性为内部属性
        /// </summary>
        public ConfigParam Param
        {
            get { return _param; }
        }
        #endregion

        /// <summary>
        /// 初始化(默认配置文件为 sales.config)
        /// </summary>
        private Configure()
        {
            _filepath = _fileDirect + "Nicholas.cfg";
            _param = new ConfigParam();
            bool isExistFile;
            if (File.Exists(_filepath))
            {
                xDoc.Load(_filepath);
                isExistFile = true;
            }
            else
            {
                xDoc.AppendChild(xDoc.CreateElement("Config"));
                isExistFile = false;
            }
            xNode = xDoc.SelectSingleNode("//Config");
            if (isExistFile)
            {
                ReadConfig();
            }
            else
            {
                SaveConfig();
            }
        }

        #region 内部方法
        // 取得AppKey里的值
        private string GetConfiguration(string appKey)
        {
            try
            {
                XmlElement xElem;
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        // 设置AppKey的值
        private void SetConfiguration(string appKey, string appValue)
        {
            XmlElement xElem1;
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("value", appValue);
            }
            else
            {
                xElem1 = xDoc.CreateElement("add");
                xElem1.SetAttribute("key", appKey);
                xElem1.SetAttribute("value", appValue);
                xNode.AppendChild(xElem1);
            }
        }

        // 从配置文件中读取配置
        private void ReadConfig()
        {
            //            Type type = t.GetType();
            FieldInfo[] finfo = _param.GetType().GetFields();
            foreach (FieldInfo var in finfo)
            {
                if (var.FieldType.Equals(typeof(bool)))
                {
                    string tmpValue = GetConfiguration(var.Name);
                    var.SetValue(_param, string.IsNullOrEmpty(tmpValue) ? false : bool.Parse(tmpValue));
                }
                else
                {
                    var.SetValue(_param, GetConfiguration(var.Name));
                }
            }

        }

        #endregion


        /// <summary>
        /// 将新的配置写到配置文件中
        /// </summary>
        /// <returns></returns>
        public bool SaveConfig()
        {
            if (!Directory.Exists(_fileDirect))
            {
                Directory.CreateDirectory(_fileDirect);
            }
            FieldInfo[] finfo = _param.GetType().GetFields();
            foreach (FieldInfo var in finfo)
            {
                SetConfiguration(var.Name, Convert.ToString(var.GetValue(_param)));
            }
            try
            {

                xDoc.Save(_filepath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
