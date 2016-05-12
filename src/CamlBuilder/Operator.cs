namespace CamlBuilder
{
    using System;
    using Internal;

    /// <summary>
    /// Defines a CAML operator. This is an abstract class. To instanciate an operator use public static methods.
    /// </summary>
    public abstract class Operator : Statement
    {
        internal readonly string OperatorTypeString;

        /// <summary>
        /// Gets the operator type. 
        /// </summary>
        public OperatorType OperatorType { get; } 

        /// <summary>
        /// Gets the name of the field on which this operator acts on.
        /// </summary>
        public string FieldName { get; private set; }

        protected internal Operator(OperatorType operatorType, string fieldName)
        {
            OperatorType = operatorType;
            FieldName = fieldName;

            switch (operatorType)
            {
                case OperatorType.Equal:
                    OperatorTypeString = "Eq";
                    break;
                case OperatorType.NotEqual:
                    OperatorTypeString = "Neq";
                    break;
                case OperatorType.GreaterThan:
                    OperatorTypeString = "Gt";
                    break;
                case OperatorType.GreaterThanOrEqualTo:
                    OperatorTypeString = "Geq";
                    break;
                case OperatorType.LowerThan:
                    OperatorTypeString = "Lt";
                    break;
                case OperatorType.LowerThanOrEqualTo:
                    OperatorTypeString = "Leq";
                    break;
                case OperatorType.IsNull:
                case OperatorType.IsNotNull:
                case OperatorType.BeginsWith:
                case OperatorType.Contains:
                case OperatorType.DateRangesOverlap:
                case OperatorType.Includes:
                case OperatorType.NotIncludes:
                    OperatorTypeString = operatorType.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorType), operatorType, null);
            }
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNull operator instance.</returns>
        public static Operator IsNull(string fieldName)
        {
            return new SimpleOperator(OperatorType.IsNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNotNull operator instance.</returns>
        public static Operator IsNotNull(string fieldName)
        {
            return new SimpleOperator(OperatorType.IsNotNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Equal, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.Equal, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.NotEqual, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.NotEqual, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.BeginsWith, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.BeginsWith, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Contains, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.Contains, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.DateRangesOverlap, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.DateRangesOverlap, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.GreaterThan, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.GreaterThan, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.GreaterThanOrEqualTo, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.GreaterThanOrEqualTo, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.LowerThan, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.LowerThan, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.LowerThanOrEqualTo, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.LowerThanOrEqualTo, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Includes, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.Includes, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes(string fieldName, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.NotIncludes, fieldName, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes(string fieldName, Value value)
        {
            return new ComplexOperator(OperatorType.NotIncludes, fieldName, value);
        }
    }
}
