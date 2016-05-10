namespace CamlBuilder.Internal
{
    internal class CamlTodayValue : CamlValue
    {
        private readonly int? offset;

        public CamlTodayValue(CamlValueType type, bool? includeTimeValue, int? offset)
            : base(type, includeTimeValue)
        {
            this.offset = offset;
        }

        public CamlTodayValue(CamlValueType type, bool? includeTimeValue)
            : this(type, includeTimeValue, null)
        {
        }

        internal override string GetCamlValue()
        {
            return offset.HasValue
                ? $"<Today Offset='{offset.Value}'/>"
                : "<Today/>";
        }
    }
}