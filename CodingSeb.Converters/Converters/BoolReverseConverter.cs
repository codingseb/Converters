using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that just revert the given bool value in two way
    /// </summary>
    public class BoolReverseConverter : BaseConverter, IValueConverter
    {
        public bool? InDesigner { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
                return InDesigner.Value;

            if (value == Binding.DoNothing)
                return Binding.DoNothing;

            if (value == DependencyProperty.UnsetValue)
                return value;

            return !(bool)value;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
