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

            [FieldReference("CustomNameFromAttribute")]
            public bool BooleanProp { get; set; }

            [FieldReference("CustomDoubleFieldName")]
            public double FieldDouble;

            public string ThisIsAMethod()
            {
                return null;
            }
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

        [Fact]
        public void FieldNameShouldBeInferedFromAttribute()
        {
            var fieldRef = new FieldReference<TestsDto, bool>(t => t.BooleanProp);

            Assert.Equal("CustomNameFromAttribute", fieldRef.Name);
        }

        [Fact]
        public void ShouldGetNameFromFieldExpression()
        {
            var name = FieldReference.GetName<TestsDto, int>(t => t.PropNameInteger);

            Assert.Equal("PropNameInteger", name);
        }

        [Fact]
        public void ShouldGetNameFromFieldExpressionWithPreferenceToReadFromAttrribute()
        {
            var name = FieldReference.GetName<TestsDto, bool>(t => t.BooleanProp);
            var nameFromField = FieldReference.GetName<TestsDto, double>(t => t.FieldDouble);

            Assert.Equal("CustomNameFromAttribute", name);
            Assert.Equal("CustomDoubleFieldName", nameFromField);
        }

        [Fact]
        public void ShouldThrowWhenReadingAnExpressionNotAFieldOrProperty()
        {
            Assert.Throws<InvalidOperationException>(() =>
                FieldReference.GetName<TestsDto, string>(t => t.ThisIsAMethod()));
        }
    }
}
