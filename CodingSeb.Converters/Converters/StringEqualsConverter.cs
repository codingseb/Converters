using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters.Converters
{
    /// <summary>
    /// This Converter return <c>true</c> if binding string Equals Value, <c>false</c> otherwise.
    /// This converter has no ConvertBack. It is only usable source -> to target.
    /// </summary>
    public class StringEqualsConverter : BaseConverter, IValueConverter
    {
        public StringEqualsConverter()
        { }

        public StringEqualsConverter(string value)
        {
            Value = value;
        }

        public StringEqualsConverter(string value, StringComparison stringComparison)
        {
            Value = value;
            StringComparison = stringComparison;
        }

        public bool? InDesigner { get; set; }

        /// <summary>
        /// The string to test equality
        /// </summary>
        [ConstructorArgument("value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// To specify the culture and case of the equals
        /// </summary>
        [ConstructorArgument("stringComparison")]
        public StringComparison StringComparison { get; set; }

        /// <summary>
        /// Do the conversion here
        /// </summary>
        /// <param name="value">the input value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>the converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner.Value;
            }

            return value.ToString().Equals(Value.EscapeForXaml(), StringComparison);
        }

        /// <summary>
        /// No Convert back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
