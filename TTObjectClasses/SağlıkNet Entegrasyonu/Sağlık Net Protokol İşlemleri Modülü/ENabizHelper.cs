using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TTObjectClasses
{
    public class ENabizHelper
    {

        public static string XMLSerialize(object objToXml)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer;

            System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer = new System.Xml.Serialization.XmlSerializer(objToXml.GetType());
            System.IO.StringWriter sw = new Utf8StringWriter();

            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(sw, settings);

            xmlSerializer.Serialize(xmlWriter, objToXml, ns);
            // xmlSerializer.Serialize(xmlWriter, objToXml, ns);
            //buffer = Encoding.UTF8.GetString(ms.ToArray());
            return sw.ToString();
        }

        public static string GetNodeValue(XmlDocument xdoc, string nodeName)
        {
            XmlNodeList nl = xdoc.GetElementsByTagName(nodeName);
            if (nl.Count != 0)
                return nl[0].Attributes[0].Value;
            else
                return "";
        }

        public static string GetNodeListOuterXML(XmlDocument xdoc, string nodeName)
        {
            XmlNodeList nl = xdoc.GetElementsByTagName(nodeName);
            if (nl.Count != 0)
                return nl[0].OuterXml;

            return null;
        }

        public static bool IsDate(Object obj)
        {
            if (obj == null) { return false; }
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

    }

}
