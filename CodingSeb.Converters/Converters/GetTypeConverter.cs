using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Return the type of the binding
    /// </summary>
    public class GetTypeConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Indicate if the converter must return the type as string with the namespace or not.
        /// </summary>
        public bool IsOnlyReturnClassName { get; set; } = false;

        /// <summary>
        /// Indicate if the type must be return as a string
        /// </summary>
        public bool AsString { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (AsString)
            {
                if (IsOnlyReturnClassName)
                {
                    return value.GetType().Name;
                }

                return value.GetType().FullName;
            }

            return value.GetType();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
