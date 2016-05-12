namespace CamlBuilder.Internal
{
    internal class OrderByField
    {
        public string FieldName { get; }

        public OrderByFieldOrder Order { get; }

        public OrderByField(string fieldName)
            : this(fieldName, OrderByFieldOrder.Ascending)
        {
        }

        public OrderByField(string fieldName, OrderByFieldOrder order)
        {
            FieldName = fieldName;
            Order = order;
        }

        public string GetCaml()
        {
            return $"<FieldRef Name='{FieldName}'{(Order == OrderByFieldOrder.Ascending ? string.Empty : " Ascending='False'")}/>";
        }
    }
}
