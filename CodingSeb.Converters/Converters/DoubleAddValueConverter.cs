using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return the value of the binding + the value in Add Property and/or in parameter.
    /// Work with double values
    /// </summary>
    public class DoubleAddValueConverter : BaseConverter, IValueConverter
    {
        public DoubleAddValueConverter()
        {}

        public DoubleAddValueConverter(double add)
        {
            Add = add;
        }

        /// <summary>
        /// The value to add
        /// By default : 0d
        /// </summary>
        [ConstructorArgument("add")]
        public double Add { get; set; }

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
                return System.Convert.ToDouble(value) + Add + (parameter == null ? 0d : System.Convert.ToDouble(parameter));
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
                return System.Convert.ToDouble(value) - Add - (parameter == null ? 0d : System.Convert.ToDouble(parameter));
            }
            catch
            {
                return DefaultValue;
            }
        }
    }
}
