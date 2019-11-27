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
    /// This Converter Replace the text fund with the Pattern Regex by Replacement
    /// Only usable from source to target. (OneWay)
    /// </summary>
    [ContentProperty("Pattern")]
    public class RegexReplaceConverter : BaseConverter, IValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// The Regex pattern to replace
        /// </summary>
        public string Pattern { get; set; } = "";

        /// <summary>
        /// The text to put in place of the text found
        /// By default : an empty string
        /// </summary>
        public string Replacement { get; set; } = "";

        /// <summary>
        /// Options of the regex
        /// By Default : RegexOptions.None
        /// </summary>
        public RegexOptions Options { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;
            else
                return Regex.Replace(value.ToString(), Pattern.EscapeForXaml(), Replacement.EscapeForXaml(), Options);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
