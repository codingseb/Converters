using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiValueConverter return <c>true</c> if first binding string contains second binding string, <c>false</c> otherwise.
    /// A Third binging can be provided as a IgnoreCase boolean but is optional (By default is considered false)
    /// This converter has no ConvertBack. It is only usable source -> to target.
    /// </summary>
    public class StringContainsMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public bool? InDesigner { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner.Value;

            if (values.Length >= 3 && (bool)values[2])
            {
                return (values[0]?.ToString().IndexOf(values[1]?.ToString() ?? string.Empty, StringComparison.OrdinalIgnoreCase) ?? -1) > -1;
            }
            else
            {
                return values[0]?.ToString().Contains(values[1]?.ToString() ?? string.Empty) ?? false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
