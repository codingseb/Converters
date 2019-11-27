using System;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return the inverse of the binding value (must be a double).
    /// Equivalent to [1 / binding]
    /// </summary>
    public class DoubleInverseValueConverter : BaseConverter, IValueConverter
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
                return 1d / System.Convert.ToDouble(value);
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
                return 1d / System.Convert.ToDouble(value);
            }
            catch
            {
                return ConvertBackDefaultValue;
            }
        }
    }
}
