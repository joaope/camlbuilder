namespace CamlBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    internal class CamlComplexOperator : CamlOperator
    {
        private string FieldTypeString
        {
            get
            {
                return typeof(CamlFieldType)
                    .GetTypeInfo()
                    .DeclaredMembers
                    .Single(m => m.Name == FieldType.ToString())
                    .CustomAttributes
                    .Cast<CamlTextAttribute>()
                    .First()
                    .StringValue;
            }
        }

        private readonly Dictionary<string, string> otherAttributes = new Dictionary<string,string>();

        public CamlFieldType FieldType { get; private set; }

        public object Value { get; private set; }

        internal CamlComplexOperator(
            CamlOperatorType operatorType, 
            string fieldName, 
            CamlFieldType fieldType, 
            object value,
            params KeyValuePair<string,string>[] otherAttributes)
            : base(operatorType, fieldName)
        {
            FieldType = fieldType;
            Value = value;

            if (otherAttributes != null)
            {
                foreach (var pair in otherAttributes)
                {
                    this.otherAttributes.Add(pair.Key, pair.Value);
                }
            }
        }

        internal CamlComplexOperator(
            CamlOperatorType operatorType,
            string fieldName,
            CamlFieldType fieldType,
            object value)
            : this(operatorType, fieldName, fieldType, value, null)
        {
        }

        public void AddOtherAttribute(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            otherAttributes.Add(name, value);
        }

        public bool ContainsOtherAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            return otherAttributes.ContainsKey(name);
        }

        public void RemoveOtherAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            otherAttributes.Remove(name);
        }

        public override string GetCaml()
        {
            return
                $@"
<{OperatorTypeString}>
    <FieldRef Name='{FieldName}'{GetFormattedOtherAttributes()} />
    <Value Type='{FieldTypeString}'>{Value}</Value>
</{OperatorTypeString}>
";
        }

        private string GetFormattedOtherAttributes()
        {
            if (otherAttributes == null || otherAttributes.Count == 0)
            {
                return string.Empty;
            }

            var attributes = new string[otherAttributes.Count];
            var i = 0;

            foreach (var pair in otherAttributes)
	        {
		        attributes[i++] = string.Format(
                    "{0}='{1}'",
                    pair.Key,
                    pair.Value);
	        }

            return string.Concat(" ", string.Join(" ", attributes));
        }
    }
}
