namespace CamlBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

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
                    .GetTypeInfo()
                    .DeclaredMembers
                    .Single(m => m.Name == OperatorType.ToString())
                    .CustomAttributes
                    .Cast<CamlTextAttribute>()
                    .First()
                    .StringValue;
            }
        }

        /// <summary>
        /// Gets the operator type. 
        /// </summary>
        public CamlOperatorType OperatorType { get; } 

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
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
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
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
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

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static CamlOperator Includes(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Includes, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>Includes operator instance.</returns>
        public static CamlOperator Includes(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.Includes, fieldName, fieldType, value, otherAttributes);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static CamlOperator NotIncludes(string fieldName, CamlFieldType fieldType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotIncludes, fieldName, fieldType, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <param name="otherAttributes">Other attributes to be added to FieldRef CAML element.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static CamlOperator NotIncludes(string fieldName, CamlFieldType fieldType, object value, params KeyValuePair<string, string>[] otherAttributes)
        {
            return new CamlComplexOperator(CamlOperatorType.NotIncludes, fieldName, fieldType, value, otherAttributes);
        }
    }
}
