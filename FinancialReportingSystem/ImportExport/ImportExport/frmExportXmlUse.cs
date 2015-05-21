using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ImportExport.PublicMethod;
using System.Data.OleDb;
using ImportExport.Entity;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections;

namespace ImportExport
{
    class frmExportXmlUse
    {

        private ConfigXml configXml = null;
        public ConfigXml ConfigXml
        {
            get { return this.configXml; }
            set
            {
                this.configXml = value;
                string type = this.configXml.getXmlValueById("type");
                int.TryParse(type, out typeNum);
            }
        }

        private int typeNum = 0;
        public int TypeNum
        {
            get { return this.typeNum; }
            set { this.typeNum = value; }
        }

        private string fileName = string.Empty;

        public void newXml()
        {
            this.ConfigXml = new ConfigXml(LoadData.Instance.ConfigModelPath + "\\ExportXmlModel.config");
        }

        public void saveXml()
        {
            this.configXml.saveXmlByConfig();
        }

        public void saveXmlNew()
        {
            this.configXml.XmlSavePath = LoadData.Instance.ConfigFilePath + "\\" + this.configXml.getXmlValueById("name") + ".config";
            this.configXml.saveXmlByConfig();
        }

        public void runExportXml(ConfigXml configXml)
        {//手动导出
            this.ConfigXml = configXml;
            string strStart = configXml.getXmlValueById("ua");
            string strEnd=configXml.getXmlValueById("ub");
            DateTime  dtStartTime =Convert.ToDateTime(strStart.Substring(0,10));
            DateTime dtEndTime = Convert.ToDateTime(strEnd.Substring(0, 10));
           
            TimeSpan ts1 = new TimeSpan(dtStartTime.Ticks);
            TimeSpan ts2 = new TimeSpan(dtEndTime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int days=ts.Days;
            int startTime = 0;
            string urlInfo = string.Empty;
            for (int i = 0; i <= days; i++)
            {  
                startTime=Convert.ToInt32(dtStartTime.AddDays(i).ToString("yyyyMMdd"));
                urlInfo = this.GetUrl(this.ConfigXml,startTime);
                exportXml(configXml, urlInfo, dtStartTime.AddDays(i).ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-ss"));
                Thread.Sleep(3000);
            }
        }

        public void autoRunExportXml(ConfigXml configXml)
        {//自动导出
            string urlInfo = string.Empty;
            urlInfo = this.GetUrl(configXml);
            DateTime dt = DateTime.Now.AddDays(-1);
            string fileName = dt.ToString("yyyy-MM-dd")+"_"+DateTime.Now.ToString("HH-mm-ss");
            exportXml(configXml, urlInfo,fileName);
        }


        private void exportXml(ConfigXml configXml, string urlInfo, string fileName)
        {
            //string url = "http://www.enterprise-europe-network.ec.europa.eu/ws/pod/html/PodService.mvc";//?pt=TR&oc=FR&sa=20121101093000000&sb=20121110093000000";
            //string url = "http://een.ec.europa.eu/tools/services/podv5/QueryService.svc/GetProfiles";
            string url = "http://een.ec.europa.eu/tools/services/podv6/QueryService.svc/GetProfiles";
            url += urlInfo;
            this.ConfigXml = configXml;
            string strxml = string.Empty;
            WebClient _client = new WebClient();
            _client.BaseAddress = url;
            _client.Headers.Add("Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*");
            _client.Headers.Add("Accept-Language", "zh-cn");
            _client.Headers.Add("UA-CPU", "x86");
            _client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            System.IO.Stream objStream = _client.OpenRead(url);
            System.IO.StreamReader _read = new System.IO.StreamReader(objStream, System.Text.Encoding.UTF8);
            strxml = _read.ReadToEnd();


            bool isEmpty = false;
            string fileNameEmpty = string.Empty;
            fileNameEmpty = fileName + "_References";

            if (strxml.Substring(0, 5) != "<pod>")
            {
                isEmpty = true;
            }
            else
            {
                fileName += "_Profiles_00000-00000";
            }
            string strPath = configXml.getXmlValueById("path");

            int countProfile = 0; //含reference的个数

            if (!isEmpty)
            {//有数据需要保存的文件
                countProfile = Regex.Matches(strxml, "</profile>").Count;
                strxml = strxml.Replace("<profile xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">", "<profile xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.enterprise-europe-network.ec.europa.eu/schema/pod/pod-profiles-definition/2012/03/21\">"); //替换节点新程序无xmlns="" add by jerry 2014-09-18
                string xmlPath = strPath + "/" + fileName + ".xml";
                if (File.Exists(xmlPath))
                    File.Delete(xmlPath);
                File.WriteAllText(xmlPath, strxml);//保存到本地 
            }

            StringBuilder strProfile = new StringBuilder(); //存放reference字符串
            for (int i = 0; i < countProfile; i++)
            {
                strProfile.AppendLine("<reference>");
                strProfile.AppendLine("</reference>");
            }

            //此处是有数据和没有数据都需要保存的空文件
            string xmlPathEmpty = strPath + "/" + fileNameEmpty + ".xml";
            string strEmptyXml = "<GetReferencesResult xmlns:a=\"http://www.enterprise-europe-network.ec.europa.eu/schema/pod/pod-profiles-query/2011/04/22\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.enterprise-europe-network.ec.europa.eu/services/pod-profile/2011/04/22\">";
            strEmptyXml += strProfile.ToString() + "</GetReferencesResult>";
            if (File.Exists(xmlPathEmpty))
                File.Delete(xmlPathEmpty);
            File.WriteAllText(xmlPathEmpty, strEmptyXml);//保存到本地 

            
            #region SFTP方法

            SshConnectionInfo objInfo = new SshConnectionInfo();
            objInfo.User = "username";
            objInfo.Host = "host";
            objInfo.IdentityFile = "key"; //有2中认证，一种基于PrivateKey,一种基于password
            //objInfo.Pass = "password"; 基于密码
            SFTPHelper objSFTPHelper = new SFTPHelper(objInfo);
            objSFTPHelper.Upload("localFile", "remoteFile"); //上传文件
            objSFTPHelper.Download("remoteFile", "localFile");//下载文件
            ArrayList fileList = objSFTPHelper.GetFileList("remotePath");//遍历远程文件夹

            #endregion 
        }

        private string GetUrl(ConfigXml configXml, int startTime)
        {
            StringBuilder strUrl = new StringBuilder();
            

             #region 添加 20130813

            string strUser = "CN00256";
            CheckIsNullOrEmpty(strUrl, "u", strUser);

            string strPasskey = "fe05d7ef2fd2379d241732ada96524dd";
            CheckIsNullOrEmpty(strUrl, "p", strPasskey);

            #endregion

            string strPt = string.Empty;
            strPt = configXml.getXmlValueById("pt");
            CheckIsNullOrEmpty(strUrl, "pt", strPt);
            string strDc = string.Empty;
            strDc = configXml.getXmlValueById("dc");
            CheckIsNullOrEmpty(strUrl, "dc", strDc);

            CheckIsNullOrEmpty(strUrl, "ua", startTime.ToString() + "000000000");
            CheckIsNullOrEmpty(strUrl, "ub", startTime.ToString() + "235959000");

            //CheckIsNullOrEmpty(strUrl, "ua", startTime.ToString() + "000000");
            //CheckIsNullOrEmpty(strUrl, "ub", startTime.ToString() + "235959");

            string strO = string.Empty;
            strO = configXml.getXmlValueById("o");
            CheckIsNullOrEmpty(strUrl, "o", strO);

            string strOc = string.Empty;
            strOc = configXml.getXmlValueById("oc");
            CheckIsNullOrEmpty(strUrl, "oc", strOc);

            string strC = string.Empty;
            strC = configXml.getXmlValueById("ci");
            CheckIsNullOrEmpty(strUrl, "ci", strC);

            string strPi = string.Empty;
            strPi = configXml.getXmlValueById("pi");
            CheckIsNullOrEmpty(strUrl, "pi", strPi);

            return strUrl.ToString();

        }

        private string GetUrl(ConfigXml configXml)
        {
            string strStartTime = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "000000000";
            string strEndTime = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "235959000";

            //string strStartTime = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "000000";
            //string strEndTime = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "235959";

            StringBuilder strUrl = new StringBuilder();

            #region 添加 20130813

            string strUser = "CN00256";
            CheckIsNullOrEmpty(strUrl, "u", strUser);

            string strPasskey = "fe05d7ef2fd2379d241732ada96524dd";
            CheckIsNullOrEmpty(strUrl, "p", strPasskey);

            #endregion 

            string strPt = string.Empty;
            strPt=configXml.getXmlValueById("pt");
            CheckIsNullOrEmpty(strUrl, "pt", strPt);
            string strDc = string.Empty;
            strDc= configXml.getXmlValueById("dc");
            CheckIsNullOrEmpty(strUrl, "dc", strDc);

            CheckIsNullOrEmpty(strUrl, "ua", strStartTime);

            CheckIsNullOrEmpty(strUrl, "ub", strEndTime);

            string strO = string.Empty;
            strO = configXml.getXmlValueById("o");
            CheckIsNullOrEmpty(strUrl, "o", strO);

            string strOc = string.Empty;
            strOc = configXml.getXmlValueById("oc");
            CheckIsNullOrEmpty(strUrl, "oc", strOc);

            string strC = string.Empty;
            strC = configXml.getXmlValueById("ci");
            CheckIsNullOrEmpty(strUrl, "ci", strC);

            string strPi = string.Empty;
            strPi = configXml.getXmlValueById("pi");
            CheckIsNullOrEmpty(strUrl, "pi", strPi);

            return strUrl.ToString();

        }

        private string GetDateTime(ConfigXml configXml,string name)
        {
            return configXml.getXmlValueById(name).Replace("-", "").Replace(" ", "").Replace(":", "") + "000";
        }

        private void CheckIsNullOrEmpty(StringBuilder strUrl,string name,string strInfo)
        {
            if (!string.IsNullOrEmpty(strInfo))
            {
                if (strUrl.ToString().Length == 0)
                    strUrl.Append("?"+name+"=" + strInfo);
                else
                    strUrl.Append("&"+name+"=" + strInfo);
            }
        }
    }
}
