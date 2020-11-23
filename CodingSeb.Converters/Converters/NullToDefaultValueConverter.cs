using System;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter to avoid null value. Provide a ValueIfNull Property to replace null values
    /// </summary>
    public class NullToDefaultValueConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The value to return if null
        /// </summary>
        public object ValueIfNull { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? ValueIfNull;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
