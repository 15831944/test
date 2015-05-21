using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ImportExport.PublicMethod
{
    public class XMLOperate
    {

        private XmlDocument xml = null;
        private string xmlPath = "";

        public XMLOperate(string xmlPath)
        {
            this.xml = new XmlDocument();
            xml.Load(xmlPath);
            this.xmlPath = xmlPath;
        }

        public XmlElement getElementById(string id)
        {
            return xml.GetElementById(id);
        }

        public string getElementInnerTextById(string id)
        {
            XmlElement ele = xml.GetElementById(id);
            if (ele != null)
                return xml.GetElementById(id).InnerText;
            return "";
        }

        public void setElementInnerTextById(string id, string value)
        {
            XmlElement ele = xml.GetElementById(id);
            if (ele != null)
                xml.GetElementById(id).InnerText = value;
        }

        public XmlNodeList getElementsByTagName(string name)
        {
            return xml.GetElementsByTagName(name);
        }

        public XmlNode getElementByTagName(string name)
        {
            XmlNodeList nl = xml.GetElementsByTagName(name);
            if (nl != null && nl.Count > 0)
                return nl[0];
            return null;
        }

        public string getElementByTagNameString(string name)
        {
            XmlNodeList nl = xml.GetElementsByTagName(name);
            if (nl != null && nl.Count > 0)
                return nl[0].InnerText;
            return null;
        }

        public void save()
        {
            this.xml.Save(this.xmlPath);
        }

        public void saveAsideXML(string xmlPath)
        {
            this.xml.Save(xmlPath);
        }


    }
}
