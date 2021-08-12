using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter make a string.Join on a collection of object (Array, list...) into a string with the optional specified separator between each source objects. By default the Separator is considered as a a space character.
    /// </summary>
    public class StringJoinConverter : BaseConverter, IValueConverter
    {
        public StringJoinConverter()
        { }

        public StringJoinConverter(string separator)
        {
            Separator = separator;
        }

        /// <summary>
        /// This separator is added between each source object in the target string
        /// By Default : a space character
        /// </summary>
        [ConstructorArgument("separator")]
        public string Separator { get; set; } = " ";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(Separator.EscapeForXaml(), ((ICollection<object>)value).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(new string[] { Separator.EscapeForXaml() }, StringSplitOptions.None);
        }
    }
}
