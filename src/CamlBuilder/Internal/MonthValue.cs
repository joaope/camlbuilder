namespace CamlBuilder.Internal
{
    internal class MonthValue : Value
    {
        public MonthValue(ValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<Month/>";
        }
    }
}