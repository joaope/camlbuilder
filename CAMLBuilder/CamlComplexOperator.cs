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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class CamlComplexOperator : CamlOperator
    {
        private string FieldTypeString
        {
            get
            {
                return typeof(CamlFieldType)
                    .GetMember(FieldType.ToString())
                    .First()
                    .GetCustomAttributes(typeof(CamlTextAttribute), false)
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

        public override string GetCAML()
        {
            return string.Format(@"
<{0}>
    <FieldRef Name='{1}'{4} />
    <Value Type='{2}'>{3}</Value>
</{0}>
",
 OperatorTypeString,
 FieldName,
 FieldTypeString,
 Value.ToString(),
 GetFormattedOtherAttributes());
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
