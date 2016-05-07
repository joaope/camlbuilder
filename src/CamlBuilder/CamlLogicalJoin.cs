namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a CAML logical join. This class has no constructors available. To instanciate a
    /// new logical join use public static methods.
    /// </summary>
    public class CamlLogicalJoin : CamlStatement
    {
        /// <summary>
        /// Gets the logical join type.
        /// </summary>
        public CamlLogicalJoinType LogicalJoinType { get; }

        private readonly List<CamlStatement> internalStatements;

        private readonly string logicalJoinTypeString;

        private CamlLogicalJoin(CamlLogicalJoinType logicalJoinType, IEnumerable<CamlStatement> statements)
        {
            LogicalJoinType = logicalJoinType;
            logicalJoinTypeString = logicalJoinType.ToString();
            internalStatements = statements.ToList();
        }

        /// <summary>
        /// Adds a new statement to this logical join
        /// </summary>
        /// <param name="statement">Statement to be added.</param>
        public void AddStatement(CamlStatement statement)
        {
            internalStatements.Add(statement);
        }

        /// <summary>
        /// Adds new statements to this logical join.
        /// </summary>
        /// <param name="statements">Statements to be added to logical join.</param>
        public void AddStatements(IEnumerable<CamlStatement> statements)
        {
            internalStatements.AddRange(statements);
        }

        /// <summary>
        /// Returns CAML string representation of this
        /// logical join statement.
        /// </summary>
        /// <returns>CAML string.</returns>
        public override string GetCaml()
        {
            if (internalStatements.Count == 0)
            {
                return string.Empty;
            }

            if (internalStatements.Count == 1)
            {
                return internalStatements[0].GetCaml();
            }

            var queue = new Queue<CamlStatement>(internalStatements);

            return BuildCamlRecursively(queue);
        }

        private string BuildCamlRecursively(Queue<CamlStatement> statementsQueue)
        {
            if (statementsQueue.Count == 2)
            {
                return string.Format(@"
<{0}>
    {1}
    {2}
</{0}>
", logicalJoinTypeString, statementsQueue.Dequeue().GetCaml(), statementsQueue.Dequeue().GetCaml());
            }

            return string.Format(@"
<{0}>
    {1}
    {2}
</{0}>
", logicalJoinTypeString, statementsQueue.Dequeue().GetCaml(), BuildCamlRecursively(statementsQueue));
        }

        /// <summary>
        /// Instanciates a new <i>And</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">And statements.</param>
        /// <returns>And logical join instance.</returns>
        public static CamlLogicalJoin And(params CamlStatement[] statements)
        {
            return new CamlLogicalJoin(CamlLogicalJoinType.And, statements);
        }

        /// <summary>
        /// Instanciates a new <i>And</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">And statements.</param>
        /// <returns>And logical join instance.</returns>
        public static CamlLogicalJoin And(IEnumerable<CamlStatement> statements)
        {
            return new CamlLogicalJoin(CamlLogicalJoinType.And, statements);
        }

        /// <summary>
        /// Instanciates a new <i>Or</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">Or statements.</param>
        /// <returns>Or logical join instance.</returns>
        public static CamlLogicalJoin Or(params CamlStatement[] statements)
        {
            return new CamlLogicalJoin(CamlLogicalJoinType.Or, statements);
        }

        /// <summary>
        /// Instanciates a new <i>Or</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">Or statements.</param>
        /// <returns>Or logical join instance.</returns>
        public static CamlLogicalJoin Or(IEnumerable<CamlStatement> statements)
        {
            return new CamlLogicalJoin(CamlLogicalJoinType.Or, statements);
        }
    }
}
