using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace ImportExport
{
    public class CSVAnalytical
    {
        List<string> extendedCsvRlist = new List<string>();
        List<string> logCsvlist = new List<string>();
        List<string> waitParsedCsvList = new List<string>();
        private static string rootPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private static string strFilePath = rootPath + "log\\ImportDataCSVLog.txt";
  
        /// <summary>
        /// 取得要导入数据的索引文件列表
        /// </summary>
        /// <param name="csvFileUrl">csv数据文件的路径</param>
        public void GetCSV(string csvFileUrl)
        {
            if (Directory.Exists(csvFileUrl))
            {
                foreach (string item in Directory.GetFiles(csvFileUrl))
                {
                    string fileName = Path.GetFileName(item);
                    if (fileName.IndexOf("References") >= 0)  
                    {
                        extendedCsvRlist.Add(fileName);
                    }
                }
            }

        }
        /// <summary>
        /// 取得已经被导入数据库的索引文件的列表
        /// </summary>
        public void GetCsvByLog()
        {

            if (File.Exists(strFilePath))
            {
                FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                string str = sr.ReadToEnd();
                string[] fn = str.Split(',');
                fs.Flush();
                sr.Close();
                fs.Close();
                logCsvlist = new List<string>(fn);
            }
        }
        /// <summary>
        /// 取得没有被导入数据库的文件列表
        /// </summary>
        public void GetWaitParsedCSV()
        {
            if (File.Exists(strFilePath))
            {
                foreach (string item in extendedCsvRlist)
                {
                    if (!logCsvlist.Contains(item))
                    {
                        waitParsedCsvList.Add(item);
                    }
                }

            }
            else
            {
                waitParsedCsvList = extendedCsvRlist;
            }
        }

        public void ParseCsv(string csvFilesUrl)
        {
            GetCSV(csvFilesUrl);
            GetCsvByLog();
            GetWaitParsedCSV();
            XmlDocument doc = new XmlDocument();
            try
            {
                foreach (string item in waitParsedCsvList)
                {
                    string pf = csvFilesUrl + item;
                    doc.Load(pf);
                    XmlNamespaceManager nm = new XmlNamespaceManager(doc.NameTable);
                    XmlNode root = doc.SelectSingleNode("e:GetReferencesResult", nm);
                    XmlNodeList nodeList = root.ChildNodes;
                    if (nodeList.Count > 0)
                    {
                        ImportDatabase(item, csvFilesUrl);
                        WriteFiles(item + ",");
                    }
                    else
                    {
                        WriteFiles(item + ",");
                        //AddLog("");
                    }
                }
            }
            catch (Exception e)
            {
                //AddLog();
            }

        }

        protected void ImportDatabase(string References, string csvFilesUrl)
        {
            
        }

        private static void WriteFiles(string str)
        {
            try
            {
                using (FileStream fs = new FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    m_streamWriter.Write(str);
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                    fs.Close();
                }
            }
            catch { }
        }

        protected void AddLog(string content)
        {

        }
    }
}
