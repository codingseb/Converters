using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that convert a WPF System.Windows.Media.Color into the corresponding System.Windows.Media.SolidColorBrush and Back.
    /// </summary>
    public class ColorToSolidColorBrushConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
            {
                SolidColorBrush brush = new SolidColorBrush((Color)value);
                return brush;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                return (value as SolidColorBrush).Color;
            }
            return null;
        }
    }
}
