using System.Xml;

namespace Ansira.Test.AutomationFramework.Helpers
{
    public class XMLHelpers
    {


        public XMLHelpers()
        {
        }

        /// <summary>
        /// Read an XML file and return the value of tagName as a XmlNodeList
        /// Example readXLMFile("C:\\Users\\ravi.peddi\\Downloads\\FileType2.xml","MsgId")
        /// </summary>
        public static XmlNodeList ReadXMLFile(string fileNameWithPath, string tagName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileNameWithPath);
            return doc.GetElementsByTagName(tagName);
        }


        /// <summary>
        /// Read an XML file and return the value of tagName as a XmlNodeList 
        /// </summary>
        public static XmlNodeList ReadXMLData(string xmlString, string tagName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("xmlString");
            return doc.GetElementsByTagName(tagName);
        }
    }
}
