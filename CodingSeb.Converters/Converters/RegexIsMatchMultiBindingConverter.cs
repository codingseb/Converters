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
    /// This MultiBindingConverter return a boolean reflecting the Regex.IsMatch on first binding (input) with the second binding (Pattern Regex).
    /// RegexOptions can be defined by the Options property or by a third binding.
    /// Only usable from source to target. (OneWay)
    /// </summary>
    public class RegexIsMatchMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// Options of the regex
        /// By Default : RegexOptions.None
        /// </summary>
        public RegexOptions Options { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;
            else
                return Regex.IsMatch(values[0].ToString()
                    , values[1].ToString()
                    , values.Length >= 3 ? (RegexOptions)values[2] : Options);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
