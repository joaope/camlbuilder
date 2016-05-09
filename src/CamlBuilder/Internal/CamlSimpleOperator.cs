namespace CamlBuilder.Internal
{
    internal class CamlSimpleOperator : CamlOperator
    {
        internal CamlSimpleOperator(CamlOperatorType operatorType, string fieldName)
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
