using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter make a string.Join on all bindings Converted to string with the ToString() method on into a string with the optional specified separator between each source objects. By default the Separator is considered as a a space character.
    /// </summary>
    public class StringJoinMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public StringJoinMultiBindingConverter()
        { }

        public StringJoinMultiBindingConverter(string separator)
        {
            Separator = separator;
        }

        /// <summary>
        /// This separator is added between each source object in the target string
        /// By Default : a space character
        /// </summary>
        [ConstructorArgument("separator")]
        public string Separator { get; set; } = " ";

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(Separator.EscapeForXaml(), values.ToList().ConvertAll(e => e.ToString()));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(new string[] { Separator.EscapeForXaml() }, StringSplitOptions.None);
        }
    }
}
