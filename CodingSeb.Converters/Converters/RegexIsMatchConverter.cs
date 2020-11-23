using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter Return a boolean reflecting the Regex.IsMatch of the defined pattern
    /// Only usable from source to target. (OneWay)
    /// </summary>
    public class RegexIsMatchConverter : BaseConverter, IValueConverter
    {
        public RegexIsMatchConverter()
        { }

        public RegexIsMatchConverter(string pattern)
        {
            Pattern = pattern;
        }

        public RegexIsMatchConverter(string pattern, RegexOptions options)
        {
            Pattern = pattern;
            Options = options;
        }

        public string InDesigner { get; set; }

        /// <summary>
        /// The Regex pattern to find
        /// </summary>
        [ConstructorArgument("pattern")]
        public string Pattern { get; set; } = string.Empty;

        /// <summary>
        /// Options of the regex
        /// By Default : RegexOptions.None
        /// </summary>
        [ConstructorArgument("options")]
        public RegexOptions Options { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else
            {
                return Regex.IsMatch(value.ToString(), Pattern.EscapeForXaml(), Options);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
