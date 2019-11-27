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
    [ContentProperty("Format")]
    public class StringFormatConverter : BaseConverter, IValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// The Format to use. By default = "{0}"
        /// </summary>
        public string Format { get; set; } = "{0}";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(Format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;

            Regex variableRegex = new Regex("[{][^}]+[}]");

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
                string sValue = value.ToString().Substring(variableMatch[0].Index);
                sValue = sValue.Substring(0, sValue.Length - (Format.Length - (variableMatch[0].Index + variableMatch[0].Length)));

                return TypeDescriptor.GetConverter(targetType).ConvertFromString(sValue);
            }
        }
    }
}
