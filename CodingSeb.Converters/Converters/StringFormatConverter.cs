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
    /// This converter Make a sting format on the binding
    /// </summary>
    public class StringFormatConverter : BaseConverter, IValueConverter
    {
        private static readonly Regex variableRegex = new Regex("[{][^}]+[}]");

        public StringFormatConverter()
        {}

        public StringFormatConverter(string format)
        {
            Format = format;
        }

        public string InDesigner { get; set; }

        /// <summary>
        /// The Format to use. By default = "{0}"
        /// </summary>
        [ConstructorArgument("format")]
        public string Format { get; set; } = "{0}";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(Format.EscapeForXaml(), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }

            MatchCollection variableMatch = variableRegex.Matches(Format);

            if (variableMatch.Count > 1)
            {
                throw new NotImplementedException();
            }
            else if (variableMatch.Count == 0)
            {
                return null;
            }
            else
            {
                string sValue = value.ToString()[variableMatch[0].Index..];
                sValue = sValue.Substring(0, sValue.Length - (Format.Length - (variableMatch[0].Index + variableMatch[0].Length)));

                return TypeDescriptor.GetConverter(targetType).ConvertFromString(sValue);
            }
        }
    }
}
