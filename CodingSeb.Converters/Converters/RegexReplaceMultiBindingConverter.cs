using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiBindingConverter Replace the text fund in first binding (input) with the second binding (Pattern Regex) by the third binding (Replacement)(Optional, if not provide is considered as empty string).
    /// RegexOptions can be defined by the Options property or by a forth binding.
    /// Only usable from source to target. (OneWay)
    /// </summary>
    public class RegexReplaceMultiBindingConverter : BaseConverter, IMultiValueConverter
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
                return Regex.Replace(values[0].ToString()
                    , values[1].ToString()
                    , values.Length >= 3 ? values[2].ToString() : ""
                    , values.Length >= 4 ? (RegexOptions)values[3] : Options);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
