namespace CamlBuilder.Internal.Operators
{
    internal class SimpleOperator : Operator
    {
        internal SimpleOperator(OperatorType operatorType, string fieldName)
            : base(operatorType, fieldName)
        {
        }

        public override string GetCaml() => $@"
<{OperatorTypeString}>
    <FieldRef Name='{FieldName}'/>
</{OperatorTypeString}>
";
    }
}
