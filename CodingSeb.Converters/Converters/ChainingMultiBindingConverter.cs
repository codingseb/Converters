using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiValueConverter is a master converter that chain 2 sub converters (A IMultiValueConverter and a IValueConverter) and convert through the chain.
    /// It can also chain an ChainingConverter as Converter2.
    /// Or it can take a list of IValueConverter to chain as Content of the converter. (The IMultiValueConverter is always provide by the MultiValueConverter1)
    /// </summary>
    [ContentProperty(nameof(Converters))]
    [ContentWrapper(typeof(IValueConverter))]
    public class ChainingMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        /// <summary>
        /// First Converter In the case of MultiBinding
        /// </summary>
        public IMultiValueConverter MultiValueConverter1 { get; set; }

        /// <summary>
        /// Second Converter to chain (output converter)
        /// </summary>
        public IValueConverter Converter2 { get; set; }

        /// <summary>
        /// For a list of converters to chain (Use as content Property, Converter1 and Converter2 must be null)
        /// </summary>
        public List<IValueConverter> Converters { get; } = new List<IValueConverter>();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (Converter2 == null)
            {
                object value = MultiValueConverter1.Convert(values, targetType, parameter, culture);

                foreach (var converter in Converters)
                {
                    value = converter.Convert(value, targetType, parameter, culture);
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
            else
            {
                return Converter2.Convert(MultiValueConverter1.Convert(values, targetType, parameter, culture), targetType, parameter, culture);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (Converter2 == null)
            {
                List<IValueConverter> convertersReverseList = new List<IValueConverter>(Converters);
                convertersReverseList.Reverse();

                foreach (var converter in convertersReverseList)
                {
                    value = converter.ConvertBack(value, targetTypes[0], parameter, culture);
                }

                return MultiValueConverter1.ConvertBack(value, targetTypes, parameter, culture);
            }
            else
            {
                return MultiValueConverter1.ConvertBack(Converter2.ConvertBack(value, targetTypes[0], parameter, culture), targetTypes, parameter, culture);
            }
        }
    }
}
