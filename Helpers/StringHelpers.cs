using System.Collections.Generic;
using System.Xml;

namespace WF.Test.AutomationFramework.Helpers
{
    public class StringHelpers
    {

        public StringHelpers()
        {

        }
        /// <summary>
        /// Method to Convert XMLNodeList To List of string
        /// </summary>
        public static List<string> ConvertXMLNodeListToList(XmlNodeList xmlNodeList)
        {
            List<string> nodes = new List<string>();
            foreach (XmlNode node in xmlNodeList)
            {
                nodes.Add(node.InnerText);
            }
            return nodes;
        }

    }
}
