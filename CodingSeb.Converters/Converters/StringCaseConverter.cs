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
    /// Converter that change the Casing of the binding string
    /// The ConvertBack always return the string as this
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class StringCaseConverter : BaseConverter, IValueConverter
    {
        private static Regex firstLetterRegex = new Regex("^.");
        private static Regex firstLetterEachWordRegex = new Regex(@"(?<=^|\s)\w");

        public string InDesigner { get; set; }

        /// <summary>
        /// The mode of casing to execute on the binding element
        /// </summary>
        [ConstructorArgument("casingMode")]
        public StringCasingMode CasingMode { get; set; }

        /// <summary>
        /// Some additionnal characters to consider as word boundaries for "each word" casing modes
        /// </summary>
        public string CharsToConsiderAsWordBoundary { get; set; } = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public StringCaseConverter()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="casingMode">The mode of casing to execute on the binding element</param>
        public StringCaseConverter(StringCasingMode casingMode)
        {
            CasingMode = casingMode;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;

            string result = value.ToString();

            if (!string.IsNullOrEmpty(CharsToConsiderAsWordBoundary))
            {
                firstLetterEachWordRegex = new Regex($@"(?<=^|\s|[{
                    CharsToConsiderAsWordBoundary
                    .Replace(@"\", @"\\")
                    .Replace("[", @"\[")
                    .Replace("]", @"\]")
                    }])\w");
            }

            switch (CasingMode)
            {
                case StringCasingMode.lowercase:
                    result = result.ToLower();
                    break;
                case StringCasingMode.UPPERCASE:
                    result = result.ToUpper();
                    break;
                case StringCasingMode.Firstletterupper:
                    result = firstLetterRegex.Replace(result, delegate (Match match)
                    {
                        return match.Value.ToUpper();
                    });
                    break;
                case StringCasingMode.firstLetterLower:
                    result = firstLetterRegex.Replace(result, delegate (Match match)
                    {
                        return match.Value.ToLower();
                    });
                    break;
                case StringCasingMode.FirstLetterOfEachWordUpper:
                    result = firstLetterEachWordRegex.Replace(result, delegate (Match match)
                    {
                        return match.Value.ToUpper();
                    });
                    break;
                case StringCasingMode.firstletterofeachwordlower:
                    result = firstLetterEachWordRegex.Replace(result, delegate (Match match)
                    {
                        return match.Value.ToLower();
                    });
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
