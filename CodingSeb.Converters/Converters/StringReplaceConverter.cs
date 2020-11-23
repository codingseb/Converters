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
    public class StringReplaceConverter : BaseConverter, IValueConverter
    {
        public StringReplaceConverter()
        {}

        public StringReplaceConverter(string oldString)
        {
            OldString = oldString;
        }

        public StringReplaceConverter(string oldString, string newString)
        {
            OldString = oldString;
            NewString = newString;
        }

        /// <summary>
        /// The substring to replace
        /// </summary>
        [ConstructorArgument("oldString")]
        public string OldString { get; set; } = string.Empty;

        /// <summary>
        /// The new string to put in place of the oldString
        /// </summary>
        [ConstructorArgument("newString")]
        public string NewString { get; set; } = string.Empty;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (OldString.Equals(string.Empty))
            {
                return value.ToString();
            }
            else
            {
                return value.ToString().Replace(OldString.EscapeForXaml(), NewString.EscapeForXaml());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (NewString.Equals(string.Empty))
            {
                return value.ToString();
            }
            else
            {
                return value.ToString().Replace(NewString.EscapeForXaml(), OldString.EscapeForXaml());
            }
        }
    }
}
