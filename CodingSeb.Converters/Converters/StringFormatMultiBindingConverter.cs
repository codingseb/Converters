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
    [ContentProperty("Format")]
    public class StringFormatMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// The Format to use. By default = null --> Use as "{0}{1}{2}..." (Just cast all binding)
        /// </summary>
        public string Format { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;

            string format = Format;

            if (format == null)
            {
                format = string.Empty;

                for (int i = 0; i < values.Length; i++)
                {
                    format += "{" + i.ToString() + "}";
                }
            }

            return string.Format(format, values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
