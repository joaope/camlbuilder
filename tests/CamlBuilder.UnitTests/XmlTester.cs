using System.Xml;

namespace CamlBuilder.UnitTests
{
    public abstract class XmlTester
    {
        protected static XmlDocument GetXmlDocument(string xml, bool preserveWhitespace = false)
        {
            var xmlDoc = new XmlDocument
            {
                PreserveWhitespace = preserveWhitespace
            };
            xmlDoc.LoadXml(xml);

            return xmlDoc;
        }
    }
}