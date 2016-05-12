namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Text;
    using Internal;

    public abstract class CamlValue
    {
        protected CamlValueType Type { get; }

        protected bool? IncludeTimeValue { get; }

        internal CamlValue(CamlValueType type)
            : this(type, null)
        {
        }

        internal CamlValue(CamlValueType type, bool? includeTimeValue)
        {
            Type = type;
            IncludeTimeValue = includeTimeValue;
        }

        internal string GetCaml()
        {
            var sb = new StringBuilder();

            if (IncludeTimeValue.HasValue)
            {
                sb.AppendLine($"<Value Type='{Type}' IncludeTimeValue='{(IncludeTimeValue.Value ? "TRUE" : "FALSE")}'>");
            }

            sb.AppendLine(GetCamlValue());
            sb.AppendLine("</Value>");

            return sb.ToString();
        }

        internal abstract string GetCamlValue();

        public static CamlValue Now(CamlValueType type)
        {
            return new CamlNowValue(type, null);
        }

        public static CamlValue Now(CamlValueType type, bool? includeTimeValue)
        {
            return new CamlNowValue(type, includeTimeValue);
        }

        public static CamlValue Month(CamlValueType type)
        {
            return new CamlMonthValue(type, null);
        }

        public static CamlValue Month(CamlValueType type, bool? includeTimeValue)
        {
            return new CamlMonthValue(type, includeTimeValue);
        }

        public static CamlValue Today(CamlValueType type)
        {
            return new CamlTodayValue(type, null, null);
        }

        public static CamlValue Today(CamlValueType type, int? offset)
        {
            return new CamlTodayValue(type, null, offset);
        }

        public static CamlValue Today(CamlValueType type, bool? includeTimeValue)
        {
            return new CamlTodayValue(type, includeTimeValue, null);
        }

        public static CamlValue Today(CamlValueType type, bool? includeTimeValue, int? offset)
        {
            return new CamlTodayValue(type, includeTimeValue, offset);
        }

        public static CamlValue Value(CamlValueType type, object value)
        {
            return new CamlAnyValue(type, null, value);
        }

        public static CamlValue Value(CamlValueType type, bool? includeTimeValue, object value)
        {
            return new CamlAnyValue(type, includeTimeValue, value);
        }

        public static CamlValue ListProperties(
            CamlValueType type, 
            IEnumerable<CamlListPropertyValueItem> listProperties)
        {
            return new CamlListPropertyValue(type, null, listProperties);
        }

        public static CamlValue ListProperties(
            CamlValueType type,
            bool? includeTimeValue,
            IEnumerable<CamlListPropertyValueItem> listProperties)
        {
            return new CamlListPropertyValue(type, includeTimeValue, listProperties);
        }
    }
}
