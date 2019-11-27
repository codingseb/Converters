using System;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that return true if the Binding String value is null or empty and false otherwise
    /// </summary>
    public class StringIsNullOrEmptyToBoolConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// Set this string for False value when the binding can go from target to source for ConvertBack
        /// </summary>
        public string ConvertBackValueForFalse { get; set; }

        /// <summary>
        /// Set this to true for returning null in place of string.empty when Convert Back
        /// </summary>
        public bool ConvertBackReturnNullForTrue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? (ConvertBackReturnNullForTrue ? null : string.Empty).EscapeForXaml() : ConvertBackValueForFalse.EscapeForXaml() ?? "False";
        }
    }
}
