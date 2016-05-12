namespace CamlBuilder.Internal.Operators
{
    using System;
    using System.Collections.Generic;

    internal class ComplexOperator : Operator
    {
        private readonly Dictionary<string, string> otherAttributes = new Dictionary<string,string>();

        public Value Value { get; }
        
        internal ComplexOperator(
            OperatorType operatorType, 
            string fieldName, 
            Value value,
            params KeyValuePair<string,string>[] otherAttributes)
            : base(operatorType, fieldName)
        {
            Value = value;

            if (otherAttributes != null)
            {
                foreach (var pair in otherAttributes)
                {
                    this.otherAttributes.Add(pair.Key, pair.Value);
                }
            }
        }

        internal ComplexOperator(
            OperatorType operatorType,
            string fieldName,
            Value value)
            : this(operatorType, fieldName, value, null)
        {
        }

        public void AddOtherAttribute(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            otherAttributes.Add(name, value);
        }

        public bool ContainsOtherAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return otherAttributes.ContainsKey(name);
        }

        public void RemoveOtherAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            otherAttributes.Remove(name);
        }

        public override string GetCaml()
        {
            return
                $@"
<{OperatorTypeString}>
    <FieldRef Name='{FieldName}'{GetFormattedOtherAttributes()}/>
    {Value.GetCaml()}
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
		        attributes[i++] = $"{pair.Key}='{pair.Value}'";
	        }

            return string.Concat(" ", string.Join(" ", attributes));
        }
    }
}
