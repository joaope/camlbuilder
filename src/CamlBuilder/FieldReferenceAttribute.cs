using System;

namespace CamlBuilder
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class FieldReferenceAttribute : Attribute
    {
        public string FieldName { get; }

        public FieldReferenceAttribute(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentException("Field name cannot be null or empty", nameof(fieldName));
            }

            FieldName = fieldName;
        }
    }
}
