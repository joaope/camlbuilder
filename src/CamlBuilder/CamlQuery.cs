namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class which represents a CAML query.
    /// </summary>
    /// <summary>
    /// Defines a CAML query. This class has no constructors available. To instanciate a
    /// new query use public static methods.
    /// </summary>
    public class CamlQuery
    {
        private readonly List<CamlOrderByField> orderByFields = new List<CamlOrderByField>();

        private readonly List<string> groupByFields = new List<string>();

        /// <summary>
        /// Gets the statement holded by this query.
        /// </summary>
        public CamlStatement Statement { get; private set; }

        private CamlQuery(CamlStatement statement)
        {
            Statement = statement;
        }

        /// <summary>
        /// Instanciates a new <i>CamlQuery</i> with the specified inner <paramref name="statement"/>
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public static CamlQuery BuildQuery(CamlStatement statement)
        {
            return new CamlQuery(statement);
        }

        /// <summary>
        /// Returns query's CAML string representation surrounded by Query element
        /// </summary>
        /// <returns>Query CAML string surrounded by Query element.</returns>
        public string GetQueryClause()
        {
            return $@"
<Query>
    {GetWhereClause()}
</Query>
";
        }

        /// <summary>
        /// Returns query's CAML string representation surrounded by Where element only.
        /// </summary>
        /// <returns>Query CAMl string surrounded by Where element only.</returns>
        public string GetWhereClause()
        {
            return
                $@"
<Where>
    {Statement.GetCaml() ?? string.Empty}
    {GetGroupByCaml()}
</Where> 
{GetOrderByCaml()}";
        }

        /// <summary>
        /// Specify the query's order-by options through the specified <paramref name=" fieldName"/>
        /// and <paramref name="order"/>.
        /// </summary>
        /// <param name="fieldName">Field name to perform the ordering on.</param>
        /// <param name="order">Order direction.</param>
        /// <returns>Returns the query itself.</returns>
        public CamlQuery OrderBy(string fieldName, CamlOrderByFieldOrder order)
        {
            orderByFields.Add(new CamlOrderByField(fieldName, order));
            return this;
        }

        /// <summary>
        /// Specify the query's group-by options. Query will be grouped by
        /// the specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Field name to group by</param>
        /// <returns>Returns the query itself.</returns>
        public CamlQuery GroupBy(string fieldName)
        {
            groupByFields.Add(fieldName);
            return this;
        }

        private string GetOrderByCaml()
        {
            if (orderByFields.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.AppendLine("<OrderBy>");

            foreach (var orderBy in orderByFields)
            {
                sb.AppendLine(orderBy.GetCaml());
            }

            sb.AppendLine("</OrderBy>");

            return sb.ToString();
        }

        private string GetGroupByCaml()
        {
            if (groupByFields.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.AppendLine("<GroupBy>");

            foreach (var groupBy in groupByFields)
            {
                sb.AppendFormat("<FieldRef Name='{0}'/>", groupBy);
            }

            sb.AppendLine("</GroupBy>");

            return sb.ToString();
        }
    }
}
