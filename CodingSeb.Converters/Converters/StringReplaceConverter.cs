using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that replace a oldString by a newString in the binding string (if OldString is empty the string is returned as this)
    /// The ConvertBack replace newString by oldString 
    /// (warning if newString is empty the string is returned as this and ConvertBack can have unexpected results).
    /// </summary>
    [ContentProperty("OldString")]
    public class StringReplaceConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The substring to replace
        /// </summary>
        public string OldString { get; set; } = "";

        /// <summary>
        /// The new string to put in place of the oldString
        /// </summary>
        public string NewString { get; set; } = "";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (OldString.Equals(string.Empty))
                return value.ToString();
            else
                return value.ToString().Replace(OldString.EscapeForXaml(), NewString.EscapeForXaml());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (NewString.Equals(string.Empty))
                return value.ToString();
            else
                return value.ToString().Replace(NewString.EscapeForXaml(), OldString.EscapeForXaml());
        }
    }
}
