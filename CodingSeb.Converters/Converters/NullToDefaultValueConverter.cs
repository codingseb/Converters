using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter to avoid null value. Provide a ValueIfNull Property to replace null values
    /// </summary>
    [ContentProperty(nameof(ValueIfNull))]
    public class NullToDefaultValueConverter : BaseConverter, IValueConverter
    {
        public NullToDefaultValueConverter()
        {}

        public NullToDefaultValueConverter(object valueIfNull)
        {
            ValueIfNull = valueIfNull;
        }

        /// <summary>
        /// The value to return if null
        /// </summary>
        [ConstructorArgument("valueIfNull")]
        public object ValueIfNull { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? ValueIfNull;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
