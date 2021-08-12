using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter is a master converter that chain 2 sub converters and convert through the chain.
    /// It can also chain an other ChainingConverter or two.
    /// Or it can take a list of converters to chain as Content of the converter
    /// </summary>
    [ContentProperty(nameof(Converters))]
    [ContentWrapper(typeof(IValueConverter))]
    public class ChainingConverter : BaseConverter, IValueConverter
    {
        #region Constructors

        public ChainingConverter()
        { }

        public ChainingConverter(IValueConverter converter1) => Converter1 = converter1;

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2) : this(converter1) => Converter2 = converter2;

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3) : this(converter1, converter2)
            => Converters.Add(converter3);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4)
            : this(converter1, converter2, converter3) => Converters.Add(converter4);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5)
            : this(converter1, converter2, converter3, converter4) => Converters.Add(converter5);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6)
            : this(converter1, converter2, converter3, converter4, converter5) => Converters.Add(converter6);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7)
            : this(converter1, converter2, converter3, converter4, converter5, converter6) => Converters.Add(converter7);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8)
            : this(converter1, converter2, converter3, converter4, converter5, converter6, converter7) => Converters.Add(converter8);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8, IValueConverter converter9)
            : this(converter1, converter2, converter3, converter4, converter5, converter6, converter7, converter8) => Converters.Add(converter9);

        public ChainingConverter(IValueConverter converter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8, IValueConverter converter9, IValueConverter converter10)
            : this(converter1, converter2, converter3, converter4, converter5, converter6, converter7, converter8, converter9) => Converters.Add(converter10);

        #endregion

        /// <summary>
        /// First Converter to chain (input converter)
        /// </summary>
        [ConstructorArgument("converter1")]
        public IValueConverter Converter1 { get; set; }

        /// <summary>
        /// Second Converter to chain (output converter)
        /// </summary>
        [ConstructorArgument("converter2")]
        public IValueConverter Converter2 { get; set; }

        /// <summary>
        /// To use more than 2 converters
        /// </summary>
        public Collection<IValueConverter> Converters { get; } = new Collection<IValueConverter>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == Binding.DoNothing)
                return Binding.DoNothing;

            if (value == DependencyProperty.UnsetValue)
                return value;

            var converters = Converters.ToList();

            if (Converter2 != null)
                converters.Insert(0, Converter2);
            if (Converter1 != null)
                converters.Insert(0, Converter1);

            foreach (var converter in converters)
            {
                value = converter.Convert(value, targetType, parameter, culture);

                if (value == Binding.DoNothing)
                    return Binding.DoNothing;

                if (value == DependencyProperty.UnsetValue)
                    return value;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue)
                return value;

            var converters = Converters.ToList();

            if (Converter2 != null)
                converters.Insert(0, Converter2);
            if (Converter1 != null)
                converters.Insert(0, Converter1);

            foreach (var converter in Enumerable.Reverse(converters))
            {
                value = converter.ConvertBack(value, targetType, parameter, culture);
                if (value == Binding.DoNothing)
                {
                    return Binding.DoNothing;
                }

                if (value == DependencyProperty.UnsetValue)
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            return value;
        }
    }
}
