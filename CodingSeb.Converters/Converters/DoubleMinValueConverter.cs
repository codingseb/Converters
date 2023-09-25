using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter returns the min value between <see cref="MinValue"/> and the value.
    /// </summary>
    public class DoubleMinValueConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// Default constructor for <see cref="DoubleMinValueConverter"/>
        /// </summary>
        public DoubleMinValueConverter()
        { }

        /// <summary>
        /// Constructor for <see cref="DoubleMinValueConverter"/>
        /// </summary>
        /// <param name="min">The min value to compare</param>
        public DoubleMinValueConverter(double min)
        {
            MinValue = min;
        }

        /// <summary>
        /// The min value for comparison
        /// By default : 0d
        /// </summary>
        [ConstructorArgument("min")]
        public double MinValue { get; set; } = 0d;

        /// <summary>
        /// The default value to return if something goes wrong during the calculation.
        /// By default 0d;
        /// </summary>
        public double DefaultValue { get; set; } = 0d;

        ///<inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Math.Min(MinValue, System.Convert.ToDouble(value));
            }
            catch
            {
                return DefaultValue;
            }
        }

        ///<inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
