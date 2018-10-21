namespace CamlBuilder.Internal.Values
{
    internal class TodayValue : Value
    {
        private readonly int? _offset;

        public TodayValue(bool? includeTimeValue, int? offset)
            : base(ValueType.DateTime, includeTimeValue)
        {
            this._offset = offset;
        }

        public TodayValue(bool? includeTimeValue)
            : this(includeTimeValue, null)
        {
        }

        protected override string GetCamlValue()
        {
            return _offset.HasValue
                ? $"<Today OffsetDays='{_offset.Value}'/>"
                : "<Today/>";
        }
    }
}