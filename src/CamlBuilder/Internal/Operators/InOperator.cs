namespace CamlBuilder.Internal.Operators
{
    using System.Collections.Generic;
    using System.Linq;

    internal class InOperator : Operator
    {
        public Value[] Values { get; }

        internal InOperator(
            FieldReference fieldRef,
            IEnumerable<Value> values)
            : base(CamlBuilder.OperatorType.In, fieldRef)
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