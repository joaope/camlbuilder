namespace CamlBuilder.UnitTests
{
    using Xunit;
    using System.Xml;

    public class SimpleOperatorTests
    {
        [Fact]
        public void VerifySimpleOperatorIsNullformat()
        {
            var op = Operator.IsNull("testField");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(op.GetCaml());

            Assert.Equal(xmlDoc.FirstChild.Name, "IsNull");
            Assert.Equal(xmlDoc.ChildNodes.Count, 1);
            Assert.Equal(xmlDoc.ChildNodes[0].ChildNodes.Count, 1);
            Assert.True(xmlDoc.SelectSingleNode("/IsNull/FieldRef[@Name='testField']") != null);


        }

        [Fact]
        public void VerifySimpleOperatorIsNotNullFormat()
        {
            var op = Operator.IsNotNull("testField");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(op.GetCaml());

            Assert.Equal(xmlDoc.FirstChild.Name, "IsNotNull");
            Assert.Equal(xmlDoc.ChildNodes.Count, 1);
            Assert.Equal(xmlDoc.ChildNodes[0].ChildNodes.Count, 1);
            Assert.True(xmlDoc.SelectSingleNode("/IsNotNull/FieldRef[@Name='testField']") != null);
        }
    }
}
