namespace CamlBuilder.Internal.Values
{
    internal class TodayValue : Value
    {
        private readonly int? offset;

        public TodayValue(ValueType type, bool? includeTimeValue, int? offset)
            : base(type, includeTimeValue)
        {
            this.offset = offset;
        }

        public TodayValue(ValueType type, bool? includeTimeValue)
            : this(type, includeTimeValue, null)
        {
        }

        protected override string GetCamlValue()
        {
            return offset.HasValue
                ? $"<Today Offset='{offset.Value}'/>"
                : "<Today/>";
        }
    }
}