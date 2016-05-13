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
    public class Query
    {
        private readonly List<FieldReference> orderByFields = new List<FieldReference>();

        private readonly List<string> groupByFields = new List<string>();

        /// <summary>
        /// Gets the statement holded by this query.
        /// </summary>
        public Statement Statement { get; }

        private Query(Statement statement)
        {
            Statement = statement;
        }

        /// <summary>
        /// Instanciates a new <i>Query</i> with the specified inner <paramref name="statement"/>
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        public static Query BuildQuery(Statement statement)
        {
            return new Query(statement);
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
        /// Adds a new query sort order relatively to a specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field where to perform the ordering on.</param>
        /// <returns>Returns the query itself.</returns>
        /// <remarks>Use <see cref="FieldReference.Ascending"/> with false value to specify descending order.</remarks>
        public Query OrderBy(FieldReference fieldRef)
        {
            orderByFields.Add(fieldRef);
            return this;
        }

        /// <summary>
        /// Adds a collection of sort orders relatively to specified <paramref name="fieldRefs"/>.
        /// </summary>
        /// <param name="fieldRefs">References to the fields where to perform the ordering on.</param>
        /// <returns>Returns the query itself.</returns>
        /// <remarks>Use <see cref="FieldReference.Ascending"/> with false value to specify descending order.</remarks>
        public Query OrderBy(IEnumerable<FieldReference> fieldRefs)
        {
            orderByFields.AddRange(fieldRefs);
            return this;
        }

        /// <summary>
        /// Specify the query's group-by options. Query will be grouped by
        /// the specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Field name to group by</param>
        /// <returns>Returns the query itself.</returns>
        public Query GroupBy(string fieldName)
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
            orderByFields.ForEach(o => sb.AppendLine(o.GetCaml()));

            return $@"
<OrderBy>
    {sb}
</OrderBy>
";
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
