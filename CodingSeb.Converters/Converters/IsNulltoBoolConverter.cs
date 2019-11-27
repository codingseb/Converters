using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that check if the binding is null (return true) or not (return false)
    /// </summary>
    public class IsNullToBoolConverter : BaseConverter, IValueConverter
    {
        public bool? InDesigner { get; set; }

        /// <summary>
        /// Set this object for False value when the binding can go from target to source for ConvertBack
        /// </summary>
        public object ConvertBackValueForFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner.Value;
            else
                return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? null : ConvertBackValueForFalse;
        }
    }
}
