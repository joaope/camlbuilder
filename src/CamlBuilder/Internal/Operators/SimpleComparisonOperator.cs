namespace CamlBuilder.Internal.Operators
{
    internal class SimpleComparisonOperator : ComparisonOperator
    {
        internal SimpleComparisonOperator(
            ComparisonOperatorType comparisonOperatorType, 
            FieldReference fieldRef)
            : base(comparisonOperatorType, fieldRef)
        {
        }

        public override string GetCaml() => $@"
<{OperatorTypeString}>
    {FieldReference.GetCamlValue()}
</{OperatorTypeString}>
";
    }
}
