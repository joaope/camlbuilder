#region License
// Copyright (C) 2012 by João Pedro Correia (http://camlbuilder.codeplex.com/)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

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
        private string LogicalJoinTypeString
        {
            get
            {
                return typeof(CamlLogicalJoinType)
                    .GetMember(LogicalJoinType.ToString())
                    .First()
                    .GetCustomAttributes(typeof(CamlTextAttribute), false)
                    .Cast<CamlTextAttribute>()
                    .First()
                    .StringValue;
            }
        }

        /// <summary>
        /// Gets the logical join type.
        /// </summary>
        public CamlLogicalJoinType LogicalJoinType { get; private set; }

        private List<CamlStatement> statements;

        private CamlLogicalJoin(CamlLogicalJoinType logicalJoinType, IEnumerable<CamlStatement> statements)
        {
            LogicalJoinType = logicalJoinType;
            this.statements = statements.ToList();
        }

        private CamlLogicalJoin(CamlLogicalJoinType logicalJoinType)
            : this(logicalJoinType, new CamlStatement[] {})
        {
        }

        /// <summary>
        /// Adds a new statement to this logical join
        /// </summary>
        /// <param name="statement">Statement to be added.</param>
        public void AddStatement(CamlStatement statement)
        {
            statements.Add(statement);
        }

        /// <summary>
        /// Adds new statements to this logical join.
        /// </summary>
        /// <param name="statements">Statements to be added to logical join.</param>
        public void AddStatements(IEnumerable<CamlStatement> statements)
        {
            this.statements.AddRange(statements);
        }

        /// <summary>
        /// Returns CAML string representation of this
        /// logical join statement.
        /// </summary>
        /// <returns>CAML string.</returns>
        public override string GetCAML()
        {
            if (statements.Count == 0)
            {
                return string.Empty;
            }

            if (statements.Count == 1)
            {
                return statements[0].GetCAML();
            }

            var queue = new Queue<CamlStatement>(statements);

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
",
 LogicalJoinTypeString,
 statementsQueue.Dequeue().GetCAML(),
 statementsQueue.Dequeue().GetCAML());

            }
            else
            {
                return string.Format(@"
<{0}>
    {1}
    {2}
</{0}>
",
LogicalJoinTypeString,
statementsQueue.Dequeue().GetCAML(),
BuildCamlRecursively(statementsQueue));
            }
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
