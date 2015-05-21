using System;
using System.Collections.Generic;
using System.Text;
using ImportExport.PublicMethod;
using System.Windows.Forms;
using System.IO;

namespace ImportExport.Entity
{
    class ConfigXml
    {
        private XMLOperate xml = null;

        private string xmlSavePath = string.Empty;
        public string XmlSavePath
        {
            get { return this.xmlSavePath; }
            set { this.xmlSavePath = value; }
        }

        private DateTime nextRunTime = DateTime.Now;
        public DateTime NextRunTime
        {
            get { return this.nextRunTime; }
            set { this.nextRunTime = value; }
        }

        private int previousRunInt = 2;
        public int PreviousRunInt
        {
            get { return this.previousRunInt; }
            set { this.previousRunInt = value; }
        }

        public ConfigXml()
        {
        }

        public ConfigXml(string path)
        {
            this.loadXmlByPath(path);
        }

        public void setXmlValueById(string id, string value)
        {
            this.xml.setElementInnerTextById(id, value);
        }

        public string getXmlValueById(string id)
        {
            return this.xml.getElementInnerTextById(id);
        }

        public int getXmlValueIntById(string id)
        {
            int num = 0;
            int.TryParse(this.xml.getElementInnerTextById(id), out num);
            return num;
        }

        public void aountNextRunTime()
        {
            try
            {
                DateTime dt = DateTime.Now;
      
                if (this.getXmlValueById("cycle") == EnumClass.Cycle.day.ToString())
                {
                    while (true)
                    {
                        if (this.nextRunTime.CompareTo(dt) < 0)
                            this.nextRunTime = this.nextRunTime.AddDays(1);
                        else
                            break;
                    }
                }
                else if (this.getXmlValueById("cycle") == EnumClass.Cycle.time.ToString())
                {
                    int num = 0;
                    int.TryParse(xml.getElementInnerTextById("hour"), out num);
                    if (num < 1)
                        num = 1;
                    while (true)
                    {
                        if (this.nextRunTime.CompareTo(dt) < 0)
                            this.nextRunTime = this.nextRunTime.AddHours(num);
                        else
                            break;
                    }
                }
                else
                {
                    //this.setXmlValueById("cycle", EnumClass.Cycle.year.ToString());
                    //this.setXmlValueById("year", DateTime.Now.Month.ToString());
                    //this.setXmlValueById("month", DateTime.Now.Day.ToString());
                    this.nextRunTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Out(ex.Message);
            }
        }

        public void aountRunTime()
        {
            try
            {
                DateTime dt = DateTime.Now;
               
                if (this.getXmlValueById("cycle") == EnumClass.Cycle.day.ToString())
                {
                    this.nextRunTime = DateTime.Parse(dt.ToShortDateString() + " " + xml.getElementInnerTextById("day"));
                }
                else if (this.getXmlValueById("cycle") == EnumClass.Cycle.time.ToString())
                {
                    this.nextRunTime = DateTime.Parse(dt.ToShortDateString() + " " + xml.getElementInnerTextById("time"));
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Out(ex.Message);
            }
        }

        public string getPreviousRunInt()
        {
            switch (this.previousRunInt)
            {
                case 0:
                    return "运行成功";
                case 1:
                    return "运行失败";
                case 2:
                    return "运行等待";
            }
            return "运行未知";
        }

        public void loadXmlByPath(string path)
        {
            this.xml = new XMLOperate(path);
            this.xmlSavePath = path;
            this.aountRunTime();
        }

        public void saveXmlByConfig()
        {
            this.xml.saveAsideXML(this.xmlSavePath);
        }

        public void deleteXmlByConfig()
        {
            if (File.Exists(this.xmlSavePath))
            {
                File.Delete(this.xmlSavePath);
            }
        }

        public ListViewItem listViewItemAddConfigXml()
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Tag = this;
            listViewItem.Text = this.getXmlValueById("name");
            return listViewItem;
        }

        public ListViewItem listViewItemRunConfigXml()
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Tag = this;
            listViewItem.Text = this.getXmlValueById("name");
            listViewItem.SubItems.Add(this.nextRunTime.ToShortDateString() + " " + this.nextRunTime.ToLongTimeString());
            listViewItem.SubItems.Add(this.getPreviousRunInt());
            return listViewItem;
        }
    }
}
