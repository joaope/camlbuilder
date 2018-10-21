using System;
using System.Linq.Expressions;
using Xunit;

namespace CamlBuilder.UnitTests
{
    public class FieldReferenceTests
    {
        private sealed class TestsDto
        {
            public string PropName { get; set; }

            public int PropNameInteger { get; set; }
        }

        [Fact]
        public void FieldReferenceShouldInferNameFromExpression()
        {
            var fieldRef = new FieldReference<TestsDto, string>(t => t.PropName);
            var fieldRefInteger = new FieldReference<TestsDto, int>(t => t.PropNameInteger);

            Assert.Equal("PropName", fieldRef.Name);
            Assert.Equal("PropNameInteger", fieldRefInteger.Name);
        }

        [Fact]
        public void FieldReferenceCanBeCastedFromExpression()
        {
            Expression<Func<TestsDto, string>> expression = t => t.PropName;

            var fieldRef = (FieldReference<TestsDto, string>)expression;
            
            Assert.Equal("PropName", fieldRef.Name);
            Assert.IsAssignableFrom<FieldReference>(fieldRef);
        }
    }
}
