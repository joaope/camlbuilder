namespace CamlBuilder.Internal
{
    internal class CamlOrderByField
    {
        public string FieldName { get; }

        public OrderByFieldOrder Order { get; }

        public CamlOrderByField(string fieldName)
            : this(fieldName, OrderByFieldOrder.Ascending)
        {
        }

        public CamlOrderByField(string fieldName, OrderByFieldOrder order)
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
