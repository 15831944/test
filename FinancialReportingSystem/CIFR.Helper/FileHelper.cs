using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFR.Helper
{
    public  class FileHelper
    {//用于文件上传
        private static string[] arrSpecialCharacter = new string[] { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };

        public static string GetValidDirectoryName(string dName)
        {
            //dName = "\\/:*?\"<>|abc";
            foreach (string cSc in arrSpecialCharacter)
            {
                dName = dName.Replace(cSc, string.Empty);
            }

            return dName.Replace("\\", "/");
        }

        public static void ClearDateOutImg(string path, int days)
        {
            try
            {
                string link = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                string pathtxt = string.Format("{0}{1}\\", link, path);
                string[] fileEntries = System.IO.Directory.GetFiles(pathtxt);
                foreach (string singFiles in fileEntries)
                {
                    if (
                        System.DateTime.Compare(System.IO.File.GetCreationTime(singFiles).Date,
                                                System.DateTime.Now.AddDays(-days).Date) <= 0)
                    {
                        System.IO.File.Delete(singFiles);
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

        public static DataSet GetExcelToDataTableBySheet(string FileFullPath)
        {
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'"; //此连接可以操作.xls与.xlsx文件,【HDR为YES表示首行为字段,为NO表示首行为数据】            
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            DataSet ds = new DataSet();
            OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [TestSite$]"), conn);
            odda.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        ///文件大小格式化
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static String FormatFileSize(Int64 fileSize)
        {
            if (fileSize < 0)
            {
                throw new ArgumentOutOfRangeException("fileSize");
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} bytes", fileSize);
            }
        }
    }
}
