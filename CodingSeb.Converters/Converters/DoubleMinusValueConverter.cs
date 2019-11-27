using System;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return the minus of the binding value (must be a double).
    /// Equivalent to [binding * -1] or [-binding]
    /// </summary>
    public class DoubleMinusValueConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The default value to return if something goes wrong during the calculation.
        /// By default 0d;
        /// </summary>
        public double DefaultValue { get; set; }

        /// <summary>
        /// The default value to return if something goes wrong during the calculation. In convertBack
        /// By default 0d;
        /// </summary>
        public double ConvertBackDefaultValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return -System.Convert.ToDouble(value);
            }
            catch
            {
                return DefaultValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return -System.Convert.ToDouble(value);
            }
            catch
            {
                return ConvertBackDefaultValue;
            }
        }
    }
}
