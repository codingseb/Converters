using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

        /// <summary>
        /// By default = <c>false</c>.<para/>
        /// Set it to <c>true</c> to consider the first binding as the format of the string format in place of the <c>Format</c> Property
        /// </summary>
        public bool FirstBindingIsFormat { get; set; }

        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }

            string format = FirstBindingIsFormat ? values.FirstOrDefault()?.ToString() : Format;

            if (format == null)
            {
                format = string.Empty;

                for (int i = (FirstBindingIsFormat? 1 : 0); i < values.Length; i++)
                {
                    format += "{" + i.ToString(CultureInfo.InvariantCulture) + "}";
                }
            }

            return string.Format(CultureInfo.InvariantCulture,format.EscapeForXaml(), FirstBindingIsFormat ? values.Skip(1).ToArray() :values);
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
