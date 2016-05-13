namespace CamlBuilder
{
    using System;
    using System.Collections.Generic;
    using Internal.Operators;

    /// <summary>
    /// Defines a CAML operator. This is an abstract class. To instanciate an operator use public static methods.
    /// </summary>
    public abstract class ComparisonOperator : Statement
    {
        internal readonly string OperatorTypeString;

        /// <summary>
        /// Gets the operator type. 
        /// </summary>
        public ComparisonOperatorType OperatorType { get; } 

        /// <summary>
        /// Gets the name of the field on which this operator acts on.
        /// </summary>
        public FieldReference FieldReference { get; private set; }

        protected internal ComparisonOperator(
            ComparisonOperatorType comparisonOperatorType, 
            FieldReference fieldRef)
        {
            OperatorType = comparisonOperatorType;
            FieldReference = fieldRef;

            switch (comparisonOperatorType)
            {
                case ComparisonOperatorType.Equal:
                    OperatorTypeString = "Eq";
                    break;
                case ComparisonOperatorType.NotEqual:
                    OperatorTypeString = "Neq";
                    break;
                case ComparisonOperatorType.GreaterThan:
                    OperatorTypeString = "Gt";
                    break;
                case ComparisonOperatorType.GreaterThanOrEqualTo:
                    OperatorTypeString = "Geq";
                    break;
                case ComparisonOperatorType.LowerThan:
                    OperatorTypeString = "Lt";
                    break;
                case ComparisonOperatorType.LowerThanOrEqualTo:
                    OperatorTypeString = "Leq";
                    break;
                case ComparisonOperatorType.IsNull:
                case ComparisonOperatorType.IsNotNull:
                case ComparisonOperatorType.BeginsWith:
                case ComparisonOperatorType.Contains:
                case ComparisonOperatorType.DateRangesOverlap:
                case ComparisonOperatorType.Includes:
                case ComparisonOperatorType.NotIncludes:
                    OperatorTypeString = comparisonOperatorType.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperatorType), comparisonOperatorType, null);
            }
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <returns>IsNull operator instance.</returns>
        public static ComparisonOperator IsNull(FieldReference fieldRef)
        {
            return new SimpleComparisonOperator(ComparisonOperatorType.IsNull, fieldRef);
        }

        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <returns>IsNotNull operator instance.</returns>
        public static ComparisonOperator IsNotNull(FieldReference fieldRef)
        {
            return new SimpleComparisonOperator(ComparisonOperatorType.IsNotNull, fieldRef);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static ComparisonOperator Equal(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Equal, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static ComparisonOperator Equal(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Equal, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static ComparisonOperator NotEqual(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.NotEqual, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static ComparisonOperator NotEqual(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.NotEqual, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static ComparisonOperator BeginsWith(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.BeginsWith, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static ComparisonOperator BeginsWith(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.BeginsWith, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static ComparisonOperator Contains(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Contains, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static ComparisonOperator Contains(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Contains, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static ComparisonOperator DateRangesOverlap(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.DateRangesOverlap, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static ComparisonOperator DateRangesOverlap(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.DateRangesOverlap, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static ComparisonOperator GreaterThan(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.GreaterThan, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static ComparisonOperator GreaterThan(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.GreaterThan, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static ComparisonOperator GreaterThanOrEqualTo(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.GreaterThanOrEqualTo, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static ComparisonOperator GreaterThanOrEqualTo(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.GreaterThanOrEqualTo, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static ComparisonOperator LowerThan(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.LowerThan, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static ComparisonOperator LowerThan(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.LowerThan, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static ComparisonOperator LowerThanOrEqualTo(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.LowerThanOrEqualTo, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static ComparisonOperator LowerThanOrEqualTo(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.LowerThanOrEqualTo, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static ComparisonOperator Includes(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Includes, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static ComparisonOperator Includes(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.Includes, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static ComparisonOperator NotIncludes(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.NotIncludes, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static ComparisonOperator NotIncludes(FieldReference fieldRef, Value value)
        {
            return new ComplexComparisonOperator(ComparisonOperatorType.NotIncludes, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>In</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="values">Values against which the value returned by the field element is compared to.</param>
        /// <returns>In operator instance.</returns>
        public static ComparisonOperator In(FieldReference fieldRef, IEnumerable<Value> values)
        {
            return new InComparisonOperator(fieldRef, values);
        }
    }
}
