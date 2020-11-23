using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// MultiBinding Converter on doubles values that multiply all values and return the result.
    /// </summary>
    public class DoubleValuesMultiplyMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        /// <summary>
        /// An additional double value to multiply with the result of the bindings values multiplication.
        /// By default = 1d
        /// </summary>
        public double AdditionalConstValueToMultiply { get; set; } = 1d;

        /// <summary>
        /// An additional double value to divide to the result of the bindings values multiplication.
        /// By default = 1d
        /// </summary>
        public double AdditionalConstValueToDivide { get; set; } = 1d;

        /// <summary>
        /// The default value to return if something goes wrong during the calculation.
        /// By default 0d;
        /// </summary>
        public double DefaultValue { get; set; }

        /// <summary>
        /// Specify how to use the ConverterParameter.
        /// </summary>
        public DoubleConvertersUseParameterTo UseParameterTo { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double firstFactor = AdditionalConstValueToMultiply * 1d / AdditionalConstValueToDivide;

                if (parameter != null)
                {
                    if (UseParameterTo == DoubleConvertersUseParameterTo.Multiply)
                    {
                        firstFactor *= System.Convert.ToDouble(parameter);
                    }
                    else if (UseParameterTo == DoubleConvertersUseParameterTo.Divide)
                    {
                        firstFactor /= System.Convert.ToDouble(parameter);
                    }
                }

                return values.Aggregate(firstFactor, (total, current) => total * System.Convert.ToDouble(current));
            }
            catch
            {
                return DefaultValue;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
