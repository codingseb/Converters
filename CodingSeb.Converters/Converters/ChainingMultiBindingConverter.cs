using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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
        #region Constructors

        public ChainingMultiBindingConverter()
        { }

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1) => MultiValueConverter1 = multiValueConverter1;

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2) : this(multiValueConverter1) => Converter2 = converter2;

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3) : this(multiValueConverter1, converter2)
            => Converters.Add(converter3);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4)
            : this(multiValueConverter1, converter2, converter3) => Converters.Add(converter4);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5)
            : this(multiValueConverter1, converter2, converter3, converter4) => Converters.Add(converter5);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6)
            : this(multiValueConverter1, converter2, converter3, converter4, converter5) => Converters.Add(converter6);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7)
            : this(multiValueConverter1, converter2, converter3, converter4, converter5, converter6) => Converters.Add(converter7);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8)
            : this(multiValueConverter1, converter2, converter3, converter4, converter5, converter6, converter7) => Converters.Add(converter8);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8, IValueConverter converter9)
            : this(multiValueConverter1, converter2, converter3, converter4, converter5, converter6, converter7, converter8) => Converters.Add(converter9);

        public ChainingMultiBindingConverter(IMultiValueConverter multiValueConverter1, IValueConverter converter2, IValueConverter converter3, IValueConverter converter4, IValueConverter converter5, IValueConverter converter6, IValueConverter converter7, IValueConverter converter8, IValueConverter converter9, IValueConverter converter10)
            : this(multiValueConverter1, converter2, converter3, converter4, converter5, converter6, converter7, converter8, converter9) => Converters.Add(converter10);

        #endregion

        /// <summary>
        /// First Converter In the case of MultiBinding
        /// </summary>
        [ConstructorArgument("multiValueConverter1")]
        public IMultiValueConverter MultiValueConverter1 { get; set; }

        /// <summary>
        /// Second Converter to chain (output converter)
        /// </summary>
        [ConstructorArgument("converter2")]
        public IValueConverter Converter2 { get; set; }

        /// <summary>
        /// This converter if definded is execute on each binding of the MultiBinding before executing the MultiValueConverter1
        /// </summary>
        public IValueConverter ForEachBindingPreConverter { get; set; }

        /// <summary>
        /// The eventual parameter to give to the ForEachBindingPreConverter
        /// </summary>
        public object ForEachBindingPreConverterParameter { get; set; }
        /// <summary>
        /// The eventual CultureInfo to give to the ForEachBindingPreConverter
        /// </summary>
        public CultureInfo ForEachBindingPreConverterCultureInfo { get; set; }

        /// <summary>
        /// For a list of converters to chain (Use as content Property, Converter1 and Converter2 must be null)
        /// </summary>
        public Collection<IValueConverter> Converters { get; } = new Collection<IValueConverter>();

        private string[] parameters;
        private System.Collections.Generic.List<IValueConverter> converters;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            converters = Converters.ToList();

            if (Converter2 != null)
                converters.Insert(0, Converter2);

            if (parameter != null)
                parameters = Regex.Split(parameter.ToString(), @"(?<!\\),");

            object value = MultiValueConverter1
                .Convert(ForEachBindingPreConverter != null
                        ? values.Select(v => ForEachBindingPreConverter.Convert(v, null, ForEachBindingPreConverterParameter, ForEachBindingPreConverterCultureInfo)).ToArray()
                        : values,
                    targetType,
                    parameter,
                    culture);

            foreach (var converter in converters)
            {
                value = converter.Convert(value, targetType, GetParameter(converter), culture);

                if (value == Binding.DoNothing)
                    return Binding.DoNothing;

                if (value == DependencyProperty.UnsetValue)
                    return value;
            }

            return value;
        }

        private object GetParameter(IValueConverter converter)
        {
            if (parameters == null)
                return null;

            var index = converters.IndexOf(converter);
            string parameter;

            try
            {
                parameter = parameters[index];
            }
            catch (IndexOutOfRangeException)
            {
                parameter = null;
            }

            if (parameter != null)
                parameter = Regex.Unescape(parameter);

            return parameter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            converters = Converters.ToList();

            if (Converter2 != null)
                converters.Insert(0, Converter2);

            var convertersReverseList = new List<IValueConverter>(Converters);

            convertersReverseList.Reverse();

            foreach (var converter in Enumerable.Reverse(converters))
            {
                value = converter.ConvertBack(value, targetTypes[0], GetParameter(converter), culture);
            }

            return ForEachBindingPreConverter != null
                ? MultiValueConverter1.ConvertBack(value, targetTypes, parameter, culture).Select(v => ForEachBindingPreConverter.ConvertBack(v, null, ForEachBindingPreConverterParameter, ForEachBindingPreConverterCultureInfo)).ToArray()
                : MultiValueConverter1.ConvertBack(value, targetTypes, parameter, culture);
        }
    }
}
