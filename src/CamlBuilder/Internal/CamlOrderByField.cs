namespace CamlBuilder.Internal
{
    internal class CamlOrderByField
    {
        public string FieldName { get; }

        public CamlOrderByFieldOrder Order { get; }

        public CamlOrderByField(string fieldName)
            : this(fieldName, CamlOrderByFieldOrder.Ascending)
        {
        }

        public CamlOrderByField(string fieldName, CamlOrderByFieldOrder order)
        {
            FieldName = fieldName;
            Order = order;
        }

        public string GetCaml()
        {
            return $"<FieldRef Name='{FieldName}'{(Order == CamlOrderByFieldOrder.Ascending ? string.Empty : " Ascending='False'")}/>";
        }
    }
}
