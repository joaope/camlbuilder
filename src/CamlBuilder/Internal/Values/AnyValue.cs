namespace CamlBuilder.Internal.Values
{
    internal class AnyValue : Value
    {
        private readonly object _anyValue;

        public AnyValue(ValueType type, bool? includeTimeValue, object anyValue)
            : base(type, includeTimeValue)
        {
            this._anyValue = anyValue;
        }

        protected override string GetCamlValue()
        {
            return _anyValue.ToString();
        }
    }
}