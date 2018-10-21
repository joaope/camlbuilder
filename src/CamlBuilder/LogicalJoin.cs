namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a CAML logical join. This class has no constructors available. To instanciate a
    /// new logical join use public static methods.
    /// </summary>
    public class LogicalJoin : Statement
    {
        /// <summary>
        /// Gets the logical join type.
        /// </summary>
        public LogicalJoinType LogicalJoinType { get; }

        private readonly List<Statement> _internalStatements;

        private readonly string _logicalJoinTypeString;

        private LogicalJoin(LogicalJoinType logicalJoinType, IEnumerable<Statement> statements)
        {
            LogicalJoinType = logicalJoinType;
            _logicalJoinTypeString = logicalJoinType.ToString();
            _internalStatements = statements.ToList();
        }

        /// <summary>
        /// Adds a new statement to this logical join
        /// </summary>
        /// <param name="statement">Statement to be added.</param>
        public void AddStatement(Statement statement)
        {
            _internalStatements.Add(statement);
        }

        /// <summary>
        /// Adds new statements to this logical join.
        /// </summary>
        /// <param name="statements">Statements to be added to logical join.</param>
        public void AddStatements(IEnumerable<Statement> statements)
        {
            _internalStatements.AddRange(statements);
        }

        /// <summary>
        /// Returns CAML string representation of this
        /// logical join statement.
        /// </summary>
        /// <returns>CAML string.</returns>
        public override string GetCaml()
        {
            if (_internalStatements.Count == 0)
            {
                return string.Empty;
            }

            if (_internalStatements.Count == 1)
            {
                return _internalStatements[0].GetCaml();
            }

            var queue = new Queue<Statement>(_internalStatements);

            return BuildCamlRecursively(queue);
        }

        private string BuildCamlRecursively(Queue<Statement> statementsQueue)
        {
            if (statementsQueue.Count == 2)
            {
                return $@"
<{_logicalJoinTypeString}>
    {statementsQueue.Dequeue().GetCaml()}
    {statementsQueue.Dequeue().GetCaml()}
</{_logicalJoinTypeString}>
";
            }

            return $@"
<{_logicalJoinTypeString}>
    {statementsQueue.Dequeue().GetCaml()}
    {BuildCamlRecursively(statementsQueue)}
</{_logicalJoinTypeString}>
";
        }

        /// <summary>
        /// Instanciates a new <i>And</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">And statements.</param>
        /// <returns>And logical join instance.</returns>
        public static LogicalJoin And(params Statement[] statements)
        {
            return new LogicalJoin(LogicalJoinType.And, statements);
        }

        /// <summary>
        /// Instanciates a new <i>And</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">And statements.</param>
        /// <returns>And logical join instance.</returns>
        public static LogicalJoin And(IEnumerable<Statement> statements)
        {
            return new LogicalJoin(LogicalJoinType.And, statements);
        }

        /// <summary>
        /// Instanciates a new <i>Or</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">Or statements.</param>
        /// <returns>Or logical join instance.</returns>
        public static LogicalJoin Or(params Statement[] statements)
        {
            return new LogicalJoin(LogicalJoinType.Or, statements);
        }

        /// <summary>
        /// Instanciates a new <i>Or</i> logical join with specified inner <paramref name="statements"/>.
        /// </summary>
        /// <param name="statements">Or statements.</param>
        /// <returns>Or logical join instance.</returns>
        public static LogicalJoin Or(IEnumerable<Statement> statements)
        {
            return new LogicalJoin(LogicalJoinType.Or, statements);
        }
    }
}
