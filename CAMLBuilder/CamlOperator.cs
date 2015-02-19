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
    /// Defines a CAML operator. This is an abstract class. To instanciate an operator use public static methods.
    /// </summary>
    public abstract class CamlOperator : CamlStatement
    {
        internal string OperatorTypeString
        {
            get
            {
                return typeof(CamlOperatorType)
                    .GetMember(OperatorType.ToString())
                    .First()
                    .GetCustomAttributes(typeof(CamlTextAttribute), false)
                    .Cast<CamlTextAttribute>()
                    .First()
                    .StringValue;
            }
        }

        /// <summary>
        /// Gets the operator type. 
        /// </summary>
        public CamlOperatorType OperatorType { get; private set; } 

        /// <summary>
        /// Gets the name of the field on which this operator acts on.
        /// </summary>
        public string FieldName { get; private set; }

        protected internal CamlOperator(CamlOperatorType operatorType, string fieldName)
        {
            OperatorType = operatorType;
            FieldName = fieldName;
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNull operator instance.</returns>
        public static CamlOperator IsNull(string fieldName)
        {
            return new CamlSimpleOperator(CamlOperatorType.IsNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNotNull operator instance.</returns>
        public static CamlOperator IsNotNull(string fieldName)
        {
            return new CamlSimpleOperator(CamlOperatorType.IsNotNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static CamlOperator Equal(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Equal, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>Equal operator instance.</returns>
        public static CamlOperator Equal(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.Equal, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static CamlOperator NotEqual(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotEqual, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static CamlOperator NotEqual(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.NotEqual, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static CamlOperator BeginsWith(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.BeginsWith, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static CamlOperator BeginsWith(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.BeginsWith, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static CamlOperator Contains(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Contains, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>Contains operator instance.</returns>
        public static CamlOperator Contains(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.Contains, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static CamlOperator DateRangesOverlap(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.DateRangesOverlap, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static CamlOperator DateRangesOverlap(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.DateRangesOverlap, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static CamlOperator GreaterThan(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThan, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static CamlOperator GreaterThan(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThan, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static CamlOperator GreaterThanOrEqualTo(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThanOrEqualTo, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static CamlOperator GreaterThanOrEqualTo(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThanOrEqualTo, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static CamlOperator LowerThan(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThan, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static CamlOperator LowerThan(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThan, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static CamlOperator LowerThanOrEqualTo(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThanOrEqualTo, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldname"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static CamlOperator LowerThanOrEqualTo(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThanOrEqualTo, fieldName, fieldType, value, otherAttributes);
        }
    }
}
