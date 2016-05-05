namespace CamlBuilder
{
    /// <summary>
    /// Defines a CAML statement. It can be a <see cref="CamlLogicalJoin"/> or a <see cref="CamlOperator"/>. 
    /// </summary>
    public abstract class CamlStatement
    {
        public abstract string GetCaml();
    }
}
