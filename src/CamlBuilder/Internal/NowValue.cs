namespace CamlBuilder.Internal
{
    internal class NowValue : Value
    {
        public NowValue(ValueType type, bool? includeTimeValue) 
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<Now/>";
        }
    }
}