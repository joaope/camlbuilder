namespace CamlBuilder.Internal.Operators
{
    using System.Collections.Generic;
    using System.Linq;

    internal class InComparisonOperator : ComparisonOperator
    {
        public Value[] Values { get; }

        internal InComparisonOperator(
            FieldReference fieldRef,
            IEnumerable<Value> values)
            : base(ComparisonOperatorType.In, fieldRef)
        {
            Values = values.ToArray();
        }

        public override string GetCaml()
        {
            return $@"
<In>
    <Values>
        {string.Join("\n", Values.Select(v => v.GetCaml()))}
    </Values>
</In>
";
        }
    }
}