using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CamlBuilder.Internal.Operators;

namespace CamlBuilder
{
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
        public FieldReference FieldReference { get; }

        protected internal Operator(
            OperatorType operatorType, 
            FieldReference fieldRef)
        {
            OperatorType = operatorType;
            FieldReference = fieldRef;

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
                case OperatorType.In:
                case OperatorType.Membership:
                    OperatorTypeString = operatorType.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorType), operatorType, null);
            }
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <returns>IsNull operator instance.</returns>
        public static Operator IsNull(FieldReference fieldRef)
        {
            return new SimpleOperator(OperatorType.IsNull, fieldRef);
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldRefProperty"/>.
        /// </summary>
        /// <param name="fieldRefProperty">
        /// Reference to the field to operate on. Name inferred from the specified field/property name.
        /// </param>
        /// <returns>IsNull operator instance.</returns>
        public static Operator IsNull<T, TProperty>(Expression<Func<T, TProperty>> fieldRefProperty)
        {
            return IsNull((FieldReference<T, TProperty>) fieldRefProperty);
        }   
        
        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <returns>IsNotNull operator instance.</returns>
        public static Operator IsNotNull(FieldReference fieldRef)
        {
            return new SimpleOperator(OperatorType.IsNotNull, fieldRef);
        }

        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldRefProperty"/>.
        /// </summary>
        /// <param name="fieldRefProperty">
        /// Reference to the field to operate on. Name inferred from the specified field/property name.
        /// </param>
        /// <returns>IsNotNull operator instance.</returns>
        public static Operator IsNotNull<T, TProperty>(Expression<Func<T, TProperty>> fieldRefProperty)
        {
            return IsNotNull((FieldReference<T, TProperty>) fieldRefProperty);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Equal, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.Equal, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return Equal((FieldReference<T, TProperty>) fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static Operator Equal<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return Equal((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.NotEqual, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return NotEqual((FieldReference<T, TProperty>) fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return NotEqual((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static Operator NotEqual(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.NotEqual, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.BeginsWith, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.BeginsWith, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return BeginsWith((FieldReference<T, TProperty>) fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static Operator BeginsWith<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return BeginsWith((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Contains, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.Contains, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return Contains((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static Operator Contains<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return Contains((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.DateRangesOverlap, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.DateRangesOverlap, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return DateRangesOverlap((FieldReference<T, TProperty>) fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static Operator DateRangesOverlap<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return DateRangesOverlap((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.GreaterThan, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.GreaterThan, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return GreaterThan((FieldReference<T, TProperty>) fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static Operator GreaterThan<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return GreaterThan((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.GreaterThanOrEqualTo, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.GreaterThanOrEqualTo, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return GreaterThanOrEqualTo((FieldReference<T, TProperty>) fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static Operator GreaterThanOrEqualTo<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return GreaterThanOrEqualTo((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.LowerThan, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.LowerThan, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return LowerThan((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static Operator LowerThan<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return LowerThan((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.LowerThanOrEqualTo, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.LowerThanOrEqualTo, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return LowerThanOrEqualTo((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static Operator LowerThanOrEqualTo<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return LowerThanOrEqualTo((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.Includes, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.Includes, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return Includes((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static Operator Includes<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return Includes((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes(FieldReference fieldRef, ValueType valueType, object value)
        {
            return new ComplexOperator(OperatorType.NotIncludes, fieldRef, Value.ObjectValue(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes(FieldReference fieldRef, Value value)
        {
            return new ComplexOperator(OperatorType.NotIncludes, fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, ValueType valueType, TProperty value)
        {
            return NotIncludes((FieldReference<T, TProperty>)fieldRef, valueType, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static Operator NotIncludes<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, Value value)
        {
            return NotIncludes((FieldReference<T, TProperty>)fieldRef, value);
        }

        /// <summary>
        /// Instanciates a new <i>In</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="values">Values against which the value returned by the field element is compared to.</param>
        /// <returns>In operator instance.</returns>
        public static Operator In(FieldReference fieldRef, IEnumerable<Value> values)
        {
            return new InOperator(fieldRef, values);
        }

        /// <summary>
        /// Instanciates a new <i>In</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="values">Values against which the value returned by the field element is compared to.</param>
        /// <returns>In operator instance.</returns>
        public static Operator In<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, IEnumerable<Value> values)
        {
            return In((FieldReference<T, TProperty>)fieldRef, values);
        }

        /// <summary>
        /// Instanciates a new <i>Membership</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="membershipType">Type of membership for the operator to use to filter for.</param>
        /// <returns>Membership operator instance.</returns>
        public static Operator Membership(FieldReference fieldRef, MembershipType membershipType)
        {
            return new MembershipOperator(fieldRef, membershipType);
        }

        /// <summary>
        /// Instanciates a new <i>Membership</i> operator which will perform on specified <paramref name="fieldRef"/>.
        /// </summary>
        /// <param name="fieldRef">Reference to the field to operate on.</param>
        /// <param name="membershipType">Type of membership for the operator to use to filter for.</param>
        /// <returns>Membership operator instance.</returns>
        public static Operator Membership<T, TProperty>(Expression<Func<T, TProperty>> fieldRef, MembershipType membershipType)
        {
            return Membership((FieldReference<T, TProperty>)fieldRef, membershipType);
        }
    }
}
