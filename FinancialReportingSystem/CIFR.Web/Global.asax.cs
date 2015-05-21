using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CIFR.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
            Uri url = System.Web.HttpContext.Current.Request.Url;
            string message = string.Empty;
            message += "***出现错误：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  Message：" + error.Message;
            if (error.InnerException != null)
            {
                message += "  InnerException:" + error.InnerException.Message;
            }

            WriteFileLog(message);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void WriteFileLog(string strContent)
        {
            string upload_failure = @"errorlog\" + DateTime.Today.ToString("yyyyMM") + ".txt";
            String strFile, strDir;
            StreamWriter sw;
            DateTime now = DateTime.Now;
            strDir = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
            //创建多级目录
            string[] parts = upload_failure.Replace("/", "\\").Split('\\');
            if (parts.Length > 1)
            {
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    string part = parts[i];
                    strDir += part + @"\";
                    if (!Directory.Exists(strDir))
                        Directory.CreateDirectory(strDir);
                }
                strFile = strDir + parts[parts.Length - 1];
            }
            else
                strFile = strDir + upload_failure;

            //文件
            if (System.IO.File.Exists(strFile))
            {
                sw = System.IO.File.AppendText(strFile);
            }
            else
            {
                sw = System.IO.File.CreateText(strFile);
            }
            sw.WriteLine(strContent + "||");
            sw.Close();
        }
    }
}