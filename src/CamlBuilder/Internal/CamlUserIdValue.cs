namespace CamlBuilder.Internal
{
    internal class CamlUserIdValue : CamlValue
    {
        public CamlUserIdValue(CamlValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<UserID/>";
        }
    }
}