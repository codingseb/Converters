using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// MultiBinding Converter on doubles values that sum (add) all values and return the result.
    /// </summary>
    public class DoubleValuesSumMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        /// <summary>
        /// The default value to return if something goes wrong during the calculation.
        /// By default 0d;
        /// </summary>
        public double DefaultValue { get; set; }

        /// <summary>
        /// An additional double value to add to the result of the bindings values sum.
        /// By default = 0d
        /// </summary>
        public double AdditionalConstValueToAdd { get; set; }

        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values.Sum(element => System.Convert.ToDouble(element)) + AdditionalConstValueToAdd + (parameter == null ? 0d : System.Convert.ToDouble(parameter));
            }
            catch
            {
                return DefaultValue;
            }
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
