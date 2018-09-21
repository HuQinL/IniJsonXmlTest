using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InitJsonXmlTest
{
   public class AppConfigXmlHelper
    {
        public static string AppConfig()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            string strDirectoryPath = Environment.CurrentDirectory + "\\IniJsonXmlTest.EXE.config";
            return strDirectoryPath;
        }
        public static string GetPath(string key)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(AppConfig());
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");　　　　//补充，需要在你的app.config 文件中增加一下，<appSetting> </appSetting>
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static void SetPath(string key, string path)
        {
            XmlElement xElem;
            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfig());
            XmlNode node = doc.SelectSingleNode(@"//appSettings");
            xElem = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
            xElem.SetAttribute("value", path);
            doc.Save(AppConfig());
        }
    }
}
