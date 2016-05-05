namespace CamlBuilder
{
    /// <summary>
    /// Specifies operator types.
    /// </summary>
    public enum CamlOperatorType
    {
        /// <summary>
        /// Indicates an Equal operator
        /// </summary>
        [CamlText("Eq")]
        Equal,

        /// <summary>
        /// Indicates a NotEqual operator
        /// </summary>
        [CamlText("Neq")]
        NotEqual,

        /// <summary>
        /// Indicates a GreaterThan operator
        /// </summary>
        [CamlText("Gt")]
        GreaterThan,

        /// <summary>
        /// Indicates a GreaterThanOrEqualTo operator
        /// </summary>
        [CamlText("Geq")]
        GreaterThanOrEqualTo,

        /// <summary>
        /// Indicates a LowerThan operator
        /// </summary>
        [CamlText("Lt")]
        LowerThan,

        /// <summary>
        /// Indicates a LowerThanOrEqualTo operator
        /// </summary>
        [CamlText("Leq")]
        LowerThanOrEqualTo,

        /// <summary>
        /// Indicates an IsNull operator
        /// </summary>
        [CamlText("IsNull")]
        IsNull,

        /// <summary>
        /// Indicates an IsNotNull operator
        /// </summary>
        [CamlText("IsNotNull")]
        IsNotNull,

        /// <summary>
        /// Indicates a BeginsWith operator
        /// </summary>
        [CamlText("BeginsWith")]
        BeginsWith,

        /// <summary>
        /// Indicates a Contains operator
        /// </summary>
        [CamlText("Contains")]
        Contains,

        /// <summary>
        /// Indicates a DateRangesOverlap operator
        /// </summary>
        [CamlText("DateRangesOverlap")]
        DateRangesOverlap
    }
}
