using System;
using Xunit;

namespace CamlBuilder.UnitTests
{
    public class FieldReferenceAttributeTests
    {
        [Fact]
        public void ShouldKeepProvidedName()
        {
            var attr = new FieldReferenceAttribute("FieldName");

            Assert.Equal("FieldName", attr.FieldName);
        }

        [Fact]
        public void ShouldThrowIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new FieldReferenceAttribute(null));
            Assert.Throws<ArgumentException>(() => new FieldReferenceAttribute(""));
        }
    }
}