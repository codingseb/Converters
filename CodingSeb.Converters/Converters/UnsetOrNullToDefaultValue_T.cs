using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    public class UnsetOrNullToDefaultValue<T> : BaseConverter, IValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// The Value to return when value = DependencyProperty.UnsetValue
        /// By default : default(T)
        /// </summary>
        public T OnUnsetValue { get; set; }

        /// <summary>
        /// The Value to return when value is null
        /// By default : default(T)
        /// </summary>
        public T OnNullValue { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else if (value == DependencyProperty.UnsetValue)
            {
                return OnUnsetValue;
            }
            else if (value == null)
            {
                return OnNullValue;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class UnsetOrNullToBoolValue : UnsetOrNullToDefaultValue<bool> { };
    public class UnsetOrNullToStringValue : UnsetOrNullToDefaultValue<string>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else if (value == DependencyProperty.UnsetValue)
            {
                return OnUnsetValue.EscapeForXaml();
            }
            else if (value == null)
            {
                return OnNullValue.EscapeForXaml();
            }
            else
            {
                return value;
            }
        }
    };
    public class UnsetOrNullToObjectalue : UnsetOrNullToDefaultValue<object> { };
}
