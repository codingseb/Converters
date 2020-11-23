using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter check if the binding type correspond to the specified condition.
    /// </summary>
    public class TypeCheckingConverter : BaseConverter, IValueConverter
    {
        public TypeCheckingConverter()
        {}
        public TypeCheckingConverter(Type typeToCheck)
        {
            TypeToCheck = typeToCheck;
        }

        public TypeCheckingConverter(Type typeToCheck, TypeCheckingConverterCondition typeCheckingConverterCondition)
        {
            TypeToCheck = typeToCheck;
            TypeCheckingConverterCondition = typeCheckingConverterCondition;
        }

        public TypeCheckingConverter(Type typeToCheck, TypeCheckingConverterCondition typeCheckingConverterCondition, bool isAType)
        {
            TypeToCheck = typeToCheck;
            TypeCheckingConverterCondition = typeCheckingConverterCondition;
            IsAType = isAType;
        }

        /// <summary>
        /// Type to Check with the Condition
        /// </summary>
        [ConstructorArgument("typeToCheck")]
        public Type TypeToCheck { get; set; }

        /// <summary>
        /// The condition to use to evaluate the type
        /// Default Value Is
        /// </summary>
        [ConstructorArgument("typeCheckingConverterCondition")]
        public TypeCheckingConverterCondition TypeCheckingConverterCondition { get; set; }

        /// <summary>
        /// Set to true to specify that the binding is the type to test. Set to false to specify that the binding is an instance of the type to test.
        /// By default : false
        /// </summary>
        [ConstructorArgument("isAType")]
        public bool IsAType { get; set; }

        /// <summary>
        /// The default value to return if the type is not checkable (binding is null or unset)
        /// By default : false
        /// </summary>
        public bool DefaultValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Type type = parameter as Type ?? TypeToCheck;
                Type valueType = IsAType ? (Type)value : value.GetType();

                if (value == null || type == null)
                {
                    return DefaultValue;
                }

                if (TypeCheckingConverterCondition == TypeCheckingConverterCondition.Is)
                {
                    return valueType.Equals(type);
                }
                else if (TypeCheckingConverterCondition == TypeCheckingConverterCondition.IsNot)
                {
                    return !valueType.Equals(type);
                }
                else if (TypeCheckingConverterCondition == TypeCheckingConverterCondition.InheritFrom)
                {
                    return type.IsAssignableFrom(valueType);
                }
                else if (TypeCheckingConverterCondition == TypeCheckingConverterCondition.InheritNotFrom)
                {
                    return !type.IsAssignableFrom(valueType);
                }
                else if (TypeCheckingConverterCondition == TypeCheckingConverterCondition.IsAParentTypeOf)
                {
                    return valueType.IsAssignableFrom(type);
                }
                else
                {
                    return !valueType.IsAssignableFrom(type);
                }
            }
            catch
            {
                return DefaultValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
