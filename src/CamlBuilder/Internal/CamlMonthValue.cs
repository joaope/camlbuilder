namespace CamlBuilder.Internal
{
    internal class CamlMonthValue : CamlValue
    {
        public CamlMonthValue(CamlValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<Month/>";
        }
    }
}