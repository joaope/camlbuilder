namespace CamlBuilder.Internal
{
    internal class AnyValue : Value
    {
        private readonly object anyValue;

        public AnyValue(ValueType type, bool? includeTimeValue, object anyValue)
            : base(type, includeTimeValue)
        {
            this.anyValue = anyValue;
        }

        internal override string GetCamlValue()
        {
            return anyValue.ToString();
        }
    }
}