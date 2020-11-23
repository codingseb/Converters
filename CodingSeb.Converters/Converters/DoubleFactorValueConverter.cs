using System;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return the value of the binding multiply and divide by the specified values
    /// </summary>
    public class DoubleFactorValueConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The value by which to multiply the binding
        /// </summary>
        public double MultiplyBy { get; set; } = 1d;

        /// <summary>
        /// The value by which to divide the binding
        /// </summary>
        public double DivideBy { get; set; } = 1d;

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

        /// <summary>
        /// Specify how to use the ConverterParameter.
        /// </summary>
        public DoubleConvertersUseParameterTo UseParameterTo { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double firstFactor = MultiplyBy * 1d / DivideBy;

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

                return System.Convert.ToDouble(value) * firstFactor;
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
                double firstFactor = MultiplyBy * 1d / DivideBy;

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

                return System.Convert.ToDouble(value) / firstFactor;
            }
            catch
            {
                return ConvertBackDefaultValue;
            }
        }
    }
}
