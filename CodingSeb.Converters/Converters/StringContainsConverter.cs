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
    [ContentProperty("Format")]
    public class StringContainsConverter : BaseConverter, IValueConverter
    {
        public bool? InDesigner { get; set; }

        /// <summary>
        /// The string to search
        /// </summary>
        public string ContainsString { get; set; } = "";

        /// <summary>
        /// if <c>true</c>, ignore case of the string to find ContainsString, if <c>false</c> take care of the case. By default : false
        /// </summary>
        public bool IgnoreCase { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner.Value;

            if (IgnoreCase)
            {
                return value.ToString().ToLower().Contains(ContainsString.ToLower().EscapeForXaml());
            }
            else
            {
                return value.ToString().Contains(ContainsString.EscapeForXaml());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
