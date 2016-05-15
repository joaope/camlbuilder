namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Text;
    using Internal.Values;

    public abstract class Value
    {
        private readonly ValueType type;

        private readonly bool? includeTimeValue;

        protected internal Value(ValueType type)
            : this(type, null)
        {
        }

        protected internal Value(ValueType type, bool? includeTimeValue)
        {
            this.type = type;
            this.includeTimeValue = includeTimeValue;
        }

        internal string GetCaml()
        {
            var sb = new StringBuilder();

            if (includeTimeValue.HasValue)
            {
                sb.AppendLine($"<Value Type='{type}' IncludeTimeValue='{(includeTimeValue.Value ? "TRUE" : "FALSE")}'>");
            }

            sb.AppendLine(GetCamlValue());
            sb.AppendLine("</Value>");

            return sb.ToString();
        }

        protected abstract string GetCamlValue();

        public static Value Now()
        {
            return new NowValue(null);
        }

        public static Value Now(bool includeTimeValue)
        {
            return new NowValue(includeTimeValue);
        }

        public static Value Month()
        {
            return new MonthValue(null);
        }

        public static Value Month(bool includeTimeValue)
        {
            return new MonthValue(includeTimeValue);
        }

        public static Value Today()
        {
            return new TodayValue(null, null);
        }

        public static Value Today(int offset)
        {
            return new TodayValue(null, offset);
        }

        public static Value Today(bool includeTimeValue)
        {
            return new TodayValue(includeTimeValue, null);
        }

        public static Value Today(bool includeTimeValue, int offset)
        {
            return new TodayValue(includeTimeValue, offset);
        }

        public static Value ObjectValue(ValueType type, object value)
        {
            return new AnyValue(type, null, value);
        }

        public static Value ObjectValue(ValueType type, bool? includeTimeValue, object value)
        {
            return new AnyValue(type, includeTimeValue, value);
        }

        public static Value UserId()
        {
            return new UserIdValue();
        }

        public static Value ListProperties(
            ValueType type, 
            IEnumerable<ListPropertyValueItem> listProperties)
        {
            return new ListPropertyValue(type, null, listProperties);
        }

        public static Value ListProperties(
            ValueType type,
            bool? includeTimeValue,
            IEnumerable<ListPropertyValueItem> listProperties)
        {
            return new ListPropertyValue(type, includeTimeValue, listProperties);
        }
    }
}
