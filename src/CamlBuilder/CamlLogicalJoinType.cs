namespace CamlBuilder
{
    /// <summary>
    /// Specifies logical join types.
    /// </summary>
    public enum CamlLogicalJoinType
    {
        /// <summary>
        /// Indicates an Or logical join.
        /// </summary>
        [CamlText("Or")]
        Or,
        /// <summary>
        /// Indicates an And logical join.
        /// </summary>
        [CamlText("And")]
        And
    }
}
