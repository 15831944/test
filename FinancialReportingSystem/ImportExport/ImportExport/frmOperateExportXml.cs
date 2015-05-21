using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImportExport.PublicMethod;
using System.Data.OleDb;
using System.IO;
using ImportExport.Entity;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace ImportExport
{
    public partial class frmOperateExportXml : Form
    {
        public frmOperateExportXml()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择Xml文件保存路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = fbd.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {//保存配置

            try
            {
                this.txtMessage.Text = "";
                DateTime dtStartTime = this.dtpUa.Value;
                DateTime dtEndTime = this.dtpUb.Value;

                if (dtStartTime > dtEndTime)
                {
                    showMessage("请正确选择起止时间");
                    return;
                }
                showMessage(string.Empty);
                OperateExportXml();
            }
            catch (Exception ex)
            {
                //WriteLog(ex.ToString());
                showMessageAppend("导出失败:"+ex.ToString());
            }
        }

        private frmLoading frmload = null;
        private delegate void closeWindow();

        private void OperateExportXml()
        {
            IsCancel = false;
            frmload = new frmLoading(setOut);
            frmload.start();
            frmload.setMessage("导出数据");
            frmload.ShowDialog();
            if (frmload.Exception != null)
                throw frmload.Exception;
        }

        /// <summary>
        /// 弹出等待框，开始导出数据
        /// </summary>
        private void setOut() 
        {
            try
            {
                this.outXml();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeWindow closeWindow = new closeWindow(close);
                frmload.Invoke(closeWindow);
            }
        }

        private static bool IsCancel = false;
        public static void CancellationBackgroundWorker()
        {//设置取消导出
            IsCancel = true;
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        private void outXml()
        {
            try
            {
                this.txtMessage.Text = "";
                DateTime dtStartTime = this.dtpUa.Value;
                DateTime dtEndTime = this.dtpUb.Value;

                TimeSpan ts1 = new TimeSpan(dtStartTime.Ticks);
                TimeSpan ts2 = new TimeSpan(dtEndTime.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                int days = ts.Days;
                int startTime = 0;
                string urlInfo = string.Empty;
                for (int i = 0; i <= days; i++)
                {
                    if (IsCancel)
                        break;
                    startTime = Convert.ToInt32(dtStartTime.AddDays(i).ToString("yyyyMMdd"));
                    showMessage("正在导出：" + dtStartTime.AddDays(i).ToString("yyyy-MM-dd"));
                    urlInfo = this.GetUrl(startTime);
                    exportXml(urlInfo, dtStartTime.AddDays(i).ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-ss"));
                    Thread.Sleep(5000);
                }
                if(IsCancel)
                   showMessage("已取消导出");
                else
                   showMessage("导出成功");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                showMessageAppend("导出失败:" + ex.ToString());
            }
        }

        /// <summary>
        /// 关闭等待对话框
        /// </summary>
        private void close()
        {
            while (true)
            {
                if (frmload.Visible == false)
                    System.Threading.Thread.Sleep(10);
                else
                    break;
            }
            frmload.Close();
            System.GC.Collect();
        }

        /// <summary>
        /// 保存日志文件（按天为目录，每小时保存1个txt文件）
        /// </summary>
        /// <param name="LogMsg"></param>
        public static void WriteLog(string LogMsg)
        {
            try
            {
                string CurrentDate = DateTime.Now.ToString("yyyyMMdd");
                string DirectoryPath = Application.StartupPath + @"\" + "Log";
                string logPath = Application.StartupPath + @"\" + "Log" + "\\" + CurrentDate + ".txt";

                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                if (!File.Exists(logPath))
                {
                    File.Create(logPath);
                }
                StreamWriter sw = new StreamWriter(logPath, true);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + LogMsg);
                sw.Close();
            }
            catch
            {
            }
        }

        private string GetUrl(int startTime)
        {
            StringBuilder strUrl = new StringBuilder();
            string strPt = string.Empty;
            #region 添加 20130813

            string strUser = "CN00256";
            CheckIsNullOrEmpty(strUrl, "u", strUser);

            string strPasskey = "fe05d7ef2fd2379d241732ada96524dd";
            CheckIsNullOrEmpty(strUrl, "p", strPasskey);

            #endregion
            strPt = this.txtPt.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "pt", strPt);
            string strDc = string.Empty;
            strDc = this.txtDc.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "dc", strDc);

            //CheckIsNullOrEmpty(strUrl, "ua", startTime.ToString() + "000000");
            //CheckIsNullOrEmpty(strUrl, "ub", startTime.ToString() + "235959");

            CheckIsNullOrEmpty(strUrl, "ua", startTime.ToString() + "000000000");
            CheckIsNullOrEmpty(strUrl, "ub", startTime.ToString() + "235959000");

            string strO = string.Empty;
            strO = this.txtO.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "o", strO);

            string strOc = string.Empty;
            strOc = this.txtOc.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "oc", strOc);

            string strC = string.Empty;
            strC = this.txtC.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "ci", strC);

            string strPi = string.Empty;
            strPi = this.txtPi.Text.Trim();
            CheckIsNullOrEmpty(strUrl, "pi", strPi);

            return strUrl.ToString();
        }

        private void exportXml(string urlInfo, string fileName)
        {
            //string url = "http://www.enterprise-europe-network.ec.europa.eu/ws/pod/html/PodService.mvc";//?pt=TR&oc=FR&sa=20121101093000000&sb=20121110093000000";
            //string url = "http://een.ec.europa.eu/tools/services/podv5/QueryService.svc/GetProfiles";
            string url = "http://een.ec.europa.eu/tools/services/podv6/QueryService.svc/GetProfiles";
            url += urlInfo;

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

            if (this.txtFilePath.Text.Trim().EndsWith("\\"))
                this.txtFilePath.Text = this.txtFilePath.Text.Trim().Substring(0, this.txtFilePath.Text.Trim().Length - 1);
            if (this.txtFilePath.Text.Trim().EndsWith("/"))
                this.txtFilePath.Text = this.txtFilePath.Text.Trim().Substring(0, this.txtFilePath.Text.Trim().Length - 1);
            string strPath = this.txtFilePath.Text.Trim();

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
            /////

        }

        private void CheckIsNullOrEmpty(StringBuilder strUrl, string name, string strInfo)
        {
            if (!string.IsNullOrEmpty(strInfo))
            {
                if (strUrl.ToString().Length == 0)
                    strUrl.Append("?" + name + "=" + strInfo);
                else
                    strUrl.Append("&" + name + "=" + strInfo);
            }
        }

        #region 显示消息

        private void showMessage(string message)
        {
            this.txtMessage.Text = message;
            LogManager.Instance.Out(message);
        }

        private void showMessageAppend(string message)
        {
            this.txtMessage.Text += message;
            LogManager.Instance.Out(message);
        }

        #endregion 

        public void ImportDB()
        {
            try{
            string filsPath = txtFilePath.Text.Trim() + "\\";
            //XmlAnalytical xa = new XmlAnalytical();
            //xa.ParseXml(filsPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportDB();
                showMessage("数据导入成功！");
            }
            catch (Exception ex)
            {
                showMessage("数据导入失败：" + ex.Message);
            }

        }
    }
}