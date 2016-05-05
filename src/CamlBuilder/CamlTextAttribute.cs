namespace CamlBuilder
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    internal class CamlTextAttribute : Attribute
    {
        public string StringValue { get; private set; }

        public CamlTextAttribute(string stringValue)
        {
            StringValue = stringValue;
        }
    }
}
