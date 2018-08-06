using Xunit;

namespace CamlBuilder.UnitTests
{
    public sealed class ValueTests : XmlTester
    {
        [Theory]
        [InlineData("CustomerSiteName", "CustomerSiteName")]
        [InlineData(@"
This is

a multi-line
test
", @"
This is

a multi-line
test
")]
        [InlineData("", "")]
        [InlineData("\n\r", "\n\r")]
        [InlineData("\r\n test \r", "\r\n test \r")]
        public void ObjectValueInnerTextShouldNotBeChangedFromTheInitialOne(
            string textValue,
            string expectedValue)
        {
            var value = Value.ObjectValue(ValueType.Text, null, textValue);

            var xmlDoc = GetXmlDocument(value.GetCaml(), true);

            Assert.Equal("Value", xmlDoc.FirstChild.Name);
            Assert.Equal(expectedValue, xmlDoc.FirstChild.InnerText);
        }

        [Fact]
        public void ValueTypesShouldBeEmptyString()
        {
            var nowValue = Value.Now();

            var xmlDoc = GetXmlDocument(nowValue.GetCaml(), true);

            Assert.Equal("Value", xmlDoc.FirstChild.Name);
            Assert.Equal(string.Empty, xmlDoc.FirstChild.InnerText);
        }
    }
}