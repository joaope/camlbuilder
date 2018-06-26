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

            Assert.Equal("IsNull", xmlDoc.FirstChild.Name);
            Assert.Equal(1, xmlDoc.ChildNodes.Count);
            Assert.Equal(1, xmlDoc.ChildNodes[0].ChildNodes.Count);
            Assert.True(xmlDoc.SelectSingleNode("/IsNull/FieldRef[@Name='testField']") != null);
        }

        [Fact]
        public void VerifySimpleOperatorIsNotNullFormat()
        {
            var op = Operator.IsNotNull("testField");

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(op.GetCaml());

            Assert.Equal("IsNotNull", xmlDoc.FirstChild.Name);
            Assert.Equal(1, xmlDoc.ChildNodes.Count);
            Assert.Equal(1, xmlDoc.ChildNodes[0].ChildNodes.Count);
            Assert.True(xmlDoc.SelectSingleNode("/IsNotNull/FieldRef[@Name='testField']") != null);
        }
    }
}
