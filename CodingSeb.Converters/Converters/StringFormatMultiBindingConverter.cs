using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter Make a sting format on the binding.
    /// </summary>
    public class StringFormatMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public StringFormatMultiBindingConverter()
        { }

        public StringFormatMultiBindingConverter(string format)
        {
            Format = format;
        }

        public string InDesigner { get; set; }

        /// <summary>
        /// The Format to use. By default = null --> Use as "{0}{1}{2}..." (Just cast all binding)
        /// </summary>
        [ConstructorArgument("format")]
        public string Format { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }

            string format = Format;

            if (format == null)
            {
                format = string.Empty;

                for (int i = 0; i < values.Length; i++)
                {
                    format += "{" + i.ToString() + "}";
                }
            }

            return string.Format(format.EscapeForXaml(), values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
