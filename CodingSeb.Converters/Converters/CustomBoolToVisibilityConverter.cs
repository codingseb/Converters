using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that convert bool to Visibility the way you want.
    /// The two Properties VisibilityForTrueValue and VisibilityForFalseValue are use to know how to map Visibility and Boolean values.
    /// </summary>
    public class CustomBoolToVisibilityConverter : BaseConverter, IValueConverter
    {
        public CustomBoolToVisibilityConverter()
        {}

        public CustomBoolToVisibilityConverter(Visibility trueValue)
        {
            TrueValue = trueValue;
        }
        public CustomBoolToVisibilityConverter(Visibility trueValue, Visibility falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public Visibility? InDesigner { get; set; }

        /// <summary>
        /// The Value of the visibility when the source value is DependencyProperty.UnsetValue
        /// Default is Visibility.Collapsed
        /// </summary>
        public Visibility OnUnsetValue { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// The Value of the visibility when the source value is null
        /// Default is Visibility.Collapsed
        /// </summary>
        public Visibility OnNullValue { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// The Value of the visibility when the source value is true
        /// Default is Visibility.Visible
        /// </summary>
        [ConstructorArgument("trueValue")]
        public Visibility TrueValue { get; set; }

        /// <summary>
        /// The Value of the visibility when the source value is true
        /// Default is Visibility.Collapsed
        /// </summary>
        [ConstructorArgument("falseValue")]
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else if (value == null)
            {
                return OnNullValue;
            }
            else if (value == DependencyProperty.UnsetValue)
            {
                return OnUnsetValue;
            }

            return value is bool x && x ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == TrueValue;
        }
    }
}
