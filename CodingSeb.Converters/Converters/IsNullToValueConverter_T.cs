using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter convert the fact that the dependencyproperty is null or not to the oject of the desired type
    /// This Class Must Be Override
    /// </summary>
    /// <typeparam name="T">Type of values FalseValue and TrueValue</typeparam>
    public class IsNullToValueConverters<T> : BaseConverter, IValueConverter
    {
        public T InDesigner { get; set; }

        /// <summary>
        /// The value if the dependencyproperty is null
        /// </summary>
        public T IsNullValue { get; set; }

        /// <summary>
        /// The value if the dependencyproperty is not null
        /// </summary>
        public T IsNotNullValue { get; set; }

        #region IValueConverter Membres

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else
            {
                return value == null ? IsNullValue : IsNotNullValue;
            }
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class IsNullToStringConverter : IsNullToValueConverters<string>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else
            {
                return value == null ? IsNullValue.EscapeForXaml() : IsNotNullValue.EscapeForXaml();
            }
        }
    }
    public class IsNullToObjectConverter : IsNullToValueConverters<object> { }
}
