using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiBindingConverter return the substring that match the specified Regex Pattern (Second Binding) in the input String (FirstBinding)
    /// RegexOptions can be defined by the Options property or by a third binding.
    /// Only usable from source to target. (OneWay)
    /// </summary>
    public class RegexMatchValueMultiBindingConverter : BaseConverter, IMultiValueConverter
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
                return Regex.Match(values[0].ToString()
                    , values[1].ToString()
                    , values.Length >= 3 ? (RegexOptions)values[2] : Options).Value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
