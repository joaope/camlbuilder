namespace CamlBuilder.Internal
{
    internal class CamlNowValue : CamlValue
    {
        public CamlNowValue(CamlValueType type, bool? includeTimeValue) 
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<Now/>";
        }
    }
}