using System;
using System.Windows.Forms;
using Nicholas.Untilty;
using System.IO;
using System.Xml;
using System.Collections;
using Nicholas.Secret;
using Entities.System;
using Nicholas.Business.SystemConfig;
using Nicholas.Entities;

namespace Nicholas.Win
{
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// 记住信息
        /// </summary>
        private bool _rememberInfo = false;
        private readonly XmlHelper xml = new XmlHelper();
        private string _configPath = AppDomain.CurrentDomain.BaseDirectory ;
        private XmlNodeList _xmlNodeList = null;
        private string filename = AppDomain.CurrentDomain.BaseDirectory + "SystemConfig.xml";
        ResultInfo<bool, string> resultInfo = new ResultInfo<bool, string>();
        private UserInfo _userInfo = new UserInfo();
        public LoginBusiness MyLogin = null;

        public FrmLogin()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            _rememberInfo = cbRemember.Checked;
            InitInfo();
        }

        private void InitInfo()
        {
            if (File.Exists(filename))
            {
                _userInfo.ServerUrl = (string)GetConfig("ServerUrl");
                _userInfo.Password = (string)GetConfig("Password");
                _userInfo.UserName = (string)GetConfig("UserName");
                _userInfo.DatabaseName = (string)GetConfig("DatabaseName");
                string remember =  GetConfig("Remember").ToUpper();
                _userInfo.Remember = _rememberInfo = remember == "TRUE" ? true : false;
            }
            cbRemember.Checked = _rememberInfo;
            if (_rememberInfo)
            {
                this.txtLoginName.Text = SelfDecrypt(_userInfo.UserName);
                this.txtServerUrl.Text = SelfDecrypt(_userInfo.ServerUrl);
                this.txtPassword.Text = SelfDecrypt(_userInfo.Password);
                this.txtDatabase.Text = SelfDecrypt(_userInfo.DatabaseName);
            }
        }

        private string GetConfig(string name)
        {
            _xmlNodeList = xml.GetXmlNodeListByXpath(filename, "SystemInfo");
            if (_xmlNodeList == null)
                return "";
            foreach (XmlNode node in _xmlNodeList)
            {
                XmlElement element = (XmlElement)node;
                if (element.HasChildNodes)
                {
                    string ff = element.Value;
                    XmlNodeList iNode = element.ChildNodes;
                    foreach (XmlNode x in iNode)
                    {
                        XmlElement e = (XmlElement)x;
                        if (e.Name == "UserInfo")
                        {
                            XmlNodeList g = e.ChildNodes;
                            foreach (XmlNode t in g)
                            {
                                XmlElement u = (XmlElement)t;
                                if (u.Name == name)
                                {
                                    return u.InnerText;
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }

        private string SelfEncrtpt(string value)
        {
            return NicholasEncrypt.EncryptUTF8String(value, NicholasLeoKey.MyKey);
        }

        private string SelfDecrypt(string value)
        {
            return NicholasEncrypt.DecryptUTF8String(value, NicholasLeoKey.MyKey);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string serverUrl = string.Empty;
            string userName = string.Empty;
            string password = string.Empty;
            string databaseName = string.Empty;
            Hashtable htAtt = new Hashtable();
            Hashtable htSubNode = new Hashtable();
            if (_rememberInfo)
            {
                serverUrl = txtServerUrl.Text.Trim();
                userName = txtLoginName.Text.Trim();
                password = txtPassword.Text.Trim();
                databaseName = txtDatabase.Text.Trim();
                if (!File.Exists(filename))
                {
                    xml.CreateXmlDocument(filename, "SystemInfo", "UTF-8");
                    htSubNode.Add("ServerUrl", SelfEncrtpt(serverUrl));
                    htSubNode.Add("UserName", SelfEncrtpt(userName));
                    htSubNode.Add("Password", SelfEncrtpt(password));
                    htSubNode.Add("DatabaseName", SelfEncrtpt(databaseName));
                    htSubNode.Add("Remember",cbRemember.Checked);
                    xml.InsertNode(filename, "UserInfo", false, "SystemInfo", htAtt, htSubNode);
                }
                else
                {
                    _xmlNodeList = xml.GetXmlNodeListByXpath(filename, "SystemInfo");
                }
            }
            resultInfo.Result = false;
            if (_userInfo != null)
            {
                SystemConfig config = new SystemConfig(serverUrl, userName, password, databaseName);
                MyLogin = new LoginBusiness(ProviderType.SqlServer);
                resultInfo = MyLogin.Login(userName, password);
            }

            if (resultInfo.Result)
            {
                MessageBox.Show("系统登录成功！");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(resultInfo.Info);
                DialogResult = DialogResult.No;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRemember_CheckStateChanged(object sender, EventArgs e)
        {
            _rememberInfo = cbRemember.Checked;
        }
    }
}
