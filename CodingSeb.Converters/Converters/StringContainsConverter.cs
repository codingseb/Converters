using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return <c>true</c> if binding string contains ContainsString, <c>false</c> otherwise.
    /// This converter has no ConvertBack. It is only usable source -> to target.
    /// </summary>
    public class StringContainsConverter : BaseConverter, IValueConverter
    {
        public StringContainsConverter()
        { }

        public StringContainsConverter(string containsString)
        {
            ContainsString = containsString;
        }

        public StringContainsConverter(string containsString, StringComparison stringComparison)
        {
            ContainsString = containsString;
            StringComparison = stringComparison;
        }

        public bool? InDesigner { get; set; }

        /// <summary>
        /// The string to search
        /// </summary>
        [ConstructorArgument("containsString")]
        public string ContainsString { get; set; } = string.Empty;

        /// <summary>
        /// To specify the culture and case of the equals
        /// </summary>
        [ConstructorArgument("stringComparison")]
        public StringComparison StringComparison { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner.Value;
            }

            return value.ToString().IndexOf(ContainsString.EscapeForXaml(), StringComparison) > -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
