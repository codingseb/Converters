using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that inject a default string in place of a empty or null value
    /// The default value can be specified by the property DefaultValue or by passsing a parameter to the converter.
    /// The parameter has priority on the DefaultValue if both are define.
    /// </summary>
    public class StringNullOrEmptyToDefaultValueConverter : BaseConverter, IValueConverter
    {
        public StringNullOrEmptyToDefaultValueConverter()
        { }

        public StringNullOrEmptyToDefaultValueConverter(string defaultValue)
        {
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// The Default value to return when the given string value is null or empty
        /// </summary>
        [ConstructorArgument("defaultValue")]
        public string DefaultValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string) ? (parameter ?? DefaultValue.EscapeForXaml()) : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
