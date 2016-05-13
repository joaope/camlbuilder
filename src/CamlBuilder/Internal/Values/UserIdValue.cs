namespace CamlBuilder.Internal.Values
{
    internal class UserIdValue : Value
    {
        public UserIdValue(ValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        protected override string GetCamlValue()
        {
            return "<UserID/>";
        }
    }
}