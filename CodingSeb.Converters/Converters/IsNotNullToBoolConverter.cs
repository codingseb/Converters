using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that check if the binding is null (return false) or not (return true)
    /// </summary>
    public class IsNotNullToBoolConverter : BaseConverter, IValueConverter
    {
        public bool? InDesigner { get; set; }

        /// <summary>
        /// Set this object for True value when the binding can go from target to source for ConvertBack
        /// </summary>
        public object ConvertBackValueForTrue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner.Value;
            else
                return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ConvertBackValueForTrue : null;
        }
    }
}
