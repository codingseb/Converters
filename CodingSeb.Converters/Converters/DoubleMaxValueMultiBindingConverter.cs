using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// MultiBinding Converter that return the maximum value of all double binding values.
    /// </summary>
    public class DoubleMaxValueMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        /// <summary>
        /// The default value to return if something goes wrong during the calculation.
        /// By default 0d;
        /// </summary>
        public double DefaultValue { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values.Max(current => System.Convert.ToDouble(current));
            }
            catch
            {
                return DefaultValue;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
