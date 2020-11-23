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
        private static readonly Regex firstLetterRegex = new Regex("^.");
        private static Regex firstLetterEachWordRegex = new Regex(@"(?<=^|\s)\w");

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="casingMode">The mode of casing to execute on the binding element</param>
        /// <param name="charsToConsiderAsWordBoundary">The mode of casing to execute on the binding element</param>
        public StringCaseConverter(StringCasingMode casingMode, string charsToConsiderAsWordBoundary)
        {
            CasingMode = casingMode;
            CharsToConsiderAsWordBoundary = charsToConsiderAsWordBoundary;
        }

        public string InDesigner { get; set; }

        /// <summary>
        /// The mode of casing to execute on the binding element
        /// </summary>
        [ConstructorArgument("casingMode")]
        public StringCasingMode CasingMode { get; set; }

        /// <summary>
        /// Some additionnal characters to consider as word boundaries for "each word" casing modes
        /// </summary>
        [ConstructorArgument("charsToConsiderAsWordBoundary")]
        public string CharsToConsiderAsWordBoundary { get; set; } = string.Empty;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }

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
                    result = firstLetterRegex.Replace(result, match => match.Value.ToUpper());
                    break;
                case StringCasingMode.firstLetterLower:
                    result = firstLetterRegex.Replace(result, match => match.Value.ToLower());
                    break;
                case StringCasingMode.FirstLetterOfEachWordUpper:
                    result = firstLetterEachWordRegex.Replace(result, match => match.Value.ToUpper());
                    break;
                case StringCasingMode.firstletterofeachwordlower:
                    result = firstLetterEachWordRegex.Replace(result, match => match.Value.ToLower());
                    break;
                case StringCasingMode.Normal:
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
