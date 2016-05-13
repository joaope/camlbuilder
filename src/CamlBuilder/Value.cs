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

        public static Value Now(ValueType type)
        {
            return new NowValue(type, null);
        }

        public static Value Now(ValueType type, bool? includeTimeValue)
        {
            return new NowValue(type, includeTimeValue);
        }

        public static Value Month(ValueType type)
        {
            return new MonthValue(type, null);
        }

        public static Value Month(ValueType type, bool? includeTimeValue)
        {
            return new MonthValue(type, includeTimeValue);
        }

        public static Value Today(ValueType type)
        {
            return new TodayValue(type, null, null);
        }

        public static Value Today(ValueType type, int? offset)
        {
            return new TodayValue(type, null, offset);
        }

        public static Value Today(ValueType type, bool? includeTimeValue)
        {
            return new TodayValue(type, includeTimeValue, null);
        }

        public static Value Today(ValueType type, bool? includeTimeValue, int? offset)
        {
            return new TodayValue(type, includeTimeValue, offset);
        }

        public static Value ObjectValue(ValueType type, object value)
        {
            return new AnyValue(type, null, value);
        }

        public static Value ObjectValue(ValueType type, bool? includeTimeValue, object value)
        {
            return new AnyValue(type, includeTimeValue, value);
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
