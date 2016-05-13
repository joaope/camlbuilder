namespace CamlBuilder.Internal.Operators
{
    internal class ComplexComparisonOperator : ComparisonOperator
    {
        public Value Value { get; }
        
        internal ComplexComparisonOperator(
            ComparisonOperatorType comparisonOperatorType, 
            FieldReference fieldRef, 
            Value value)
            : base(comparisonOperatorType, fieldRef)
        {
            Value = value;
        }

        public override string GetCaml()
        {
            return
                $@"
<{OperatorTypeString}>
    {FieldReference.GetCamlValue()}
    {Value.GetCaml()}
</{OperatorTypeString}>
";
        }
    }
}
