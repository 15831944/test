using System;
using System.Collections.Generic;
using System.Text;
using ImportExport.Entity;
using System.IO;
using System.Windows.Forms;

namespace ImportExport.PublicMethod
{
    class LoadData
    {
        private static LoadData instance = null;
        /// <summary>
        /// 数据加载对象实例
        /// </summary>
        public static LoadData Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadData();
                return instance;
            }
        }

    

        private List<ConfigXml> configXmlList = null;
        public List<ConfigXml> ConfigXmlList
        {
            get { return this.configXmlList; }
            set { this.configXmlList = value; }
        }

        private string configFilePath = Application.StartupPath + "\\ConfigFile";
        public string ConfigFilePath
        {
            get { return this.configFilePath; }
        }

        private string configModelPath = Application.StartupPath + "\\ConfigModel";
        public string ConfigModelPath
        {
            get { return this.configModelPath; }
        }

        public void loadConfigXml()
        {
            this.configXmlList = new List<ConfigXml>();
            ConfigXml configXml = null;
            DirectoryInfo mydir = new DirectoryInfo(this.configFilePath);
            FileInfo[] myFiles = mydir.GetFiles();
            foreach (FileInfo myFile in myFiles)
            {
                if (myFile.Name.ToLower().EndsWith(".config"))
                {
                    try
                    {
                        configXml = new ConfigXml(myFile.FullName);
                        this.configXmlList.Add(configXml);
                    }
                    catch (Exception ex)
                    {
                        LogManager.Instance.Out(ex.Message);
                    }
                }
            }
        }

        public ListViewItem[] loadXmlAddListView()
        {
            List<ListViewItem> configXmlItemList = new List<ListViewItem>();
            foreach (ConfigXml configXml in this.configXmlList)
            {
                configXmlItemList.Add(configXml.listViewItemRunConfigXml());
            }
            return configXmlItemList.ToArray();
        }

        public ListViewItem[] loadRunListView()
        {
            List<ListViewItem> itemList = new List<ListViewItem>();
            foreach (ConfigXml configXml in this.configXmlList)
            {
                if (configXml.getXmlValueById("application") == EnumClass.Application.strat.ToString())
                {
                    configXml.aountRunTime();
                    itemList.Add(configXml.listViewItemRunConfigXml());
                }
            }
            return itemList.ToArray();
        }
    }
}
