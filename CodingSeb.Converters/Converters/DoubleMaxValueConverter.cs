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
    /// This converter returns the max value between <see cref="MaxValue"/> and the value.
    /// </summary>
    public class DoubleMaxValueConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// Default constructor for <see cref="DoubleMaxValueConverter"/>
        /// </summary>
        public DoubleMaxValueConverter()
        {
        }

        /// <summary>
        /// Constructor for <see cref="DoubleMaxValueConverter"/>
        /// </summary>
        /// <param name="max">The max value to compare</param>
        public DoubleMaxValueConverter(double max)
        {
            MaxValue = max;
        }

        /// <summary>
        /// The max value for comparison
        /// By default : 0d
        /// </summary>
        [ConstructorArgument("max")]
        public double MaxValue { get; set; } = 0d;

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
                return Math.Max(MaxValue, System.Convert.ToDouble(value));
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
