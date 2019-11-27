using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter to convert exclusive bool value (Example : IsChecked Property of RadioButtons) to the Enum value specified in ConverterParameter.
    /// Just Bind all (RadioButton) to the same enum property with the value to take in ConverterParameter
    /// </summary>
    public class ExclusiveBoolToEnumOrEquatableParameterConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return Equals(value, (value.GetType() == parameter.GetType()) ? parameter : TypeDescriptor.GetConverter(value).ConvertFrom(parameter));
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return parameter;
            else
                return DependencyProperty.UnsetValue;
        }
    }
}
