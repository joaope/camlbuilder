namespace CamlBuilder.Internal.Values
{
    internal class MonthValue : Value
    {
        public MonthValue(ValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        protected override string GetCamlValue()
        {
            return "<Month/>";
        }
    }
}