namespace CamlBuilder.Internal.Values
{
    internal class NowValue : Value
    {
        public NowValue(ValueType type, bool? includeTimeValue) 
            : base(type, includeTimeValue)
        {
        }

        protected override string GetCamlValue()
        {
            return "<Now/>";
        }
    }
}