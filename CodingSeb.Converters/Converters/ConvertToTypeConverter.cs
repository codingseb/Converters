using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter try to find a way to convert binding in the specified type.
    /// </summary>
    [ContentProperty(nameof(ConvertToType))]
    public class ConvertToTypeConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The type in which to convert the binding if possible.
        /// </summary>
        public Type ConvertToType { get; set; }

        /// <summary>
        /// The type in which to convertback the binding if possible.
        /// </summary>
        public Type ConvertBackToType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                try
                {
                    return TypeDescriptor.GetConverter(ConvertToType ?? targetType).ConvertFrom(value);
                }
                catch
                {
                    return TypeDescriptor.GetConverter(value).ConvertTo(value, ConvertToType ?? targetType);
                }
            }
            catch (NotSupportedException)
            {
                if ((ConvertToType ?? targetType) == typeof(string))
                {
                    return value.ToString();
                }
                else if (value.GetType() != typeof(string))
                {
                    ConvertToTypeConverter tempConverter = new ConvertToTypeConverter()
                    {
                        ConvertToType = typeof(string)
                    };

                    object tempValue = tempConverter.Convert(value, typeof(string), parameter, culture);

                    tempConverter.ConvertToType = ConvertToType ?? targetType;

                    return tempConverter.Convert(tempValue, tempConverter.ConvertToType, parameter, culture);
                }
                else
                {
                    throw;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                try
                {
                    return TypeDescriptor.GetConverter(ConvertBackToType ?? targetType).ConvertFrom(value);
                }
                catch
                {
                    return TypeDescriptor.GetConverter(value).ConvertTo(value, ConvertBackToType ?? targetType);
                }
            }
            catch (NotSupportedException)
            {
                if ((ConvertBackToType ?? targetType) == typeof(string))
                {
                    return value.ToString();
                }
                else if (value.GetType() != typeof(string))
                {
                    ConvertToTypeConverter tempConverter = new ConvertToTypeConverter()
                    {
                        ConvertToType = typeof(string)
                    };

                    object tempValue = tempConverter.Convert(value, typeof(string), parameter, culture);

                    tempConverter.ConvertToType = ConvertBackToType ?? targetType;

                    return tempConverter.Convert(tempValue, tempConverter.ConvertToType, parameter, culture);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
