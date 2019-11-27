using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter Convert a set of keys to their mapped value
    /// A DefaultValue can be defined for no found keys
    /// </summary>
    /// <example>
    /// <code lang="xml">
    /// <![CDATA[
    /// <TextBlock>>
    ///     <TextBlock.Text>
    ///         <Binding>
    ///             <Binding.Converter>
    ///                 <MappingConverter DefaultValue="DefaultValue">
    ///                     <Mapping Key="Test" Value="Hello"/>
    ///                     <Mapping Key="How" Value="How Are You ?"/>
    ///                     <Mapping Key="Hey" Value="Nice To meet you"/>
    ///                 </MapConverter>
    ///             </Binding.Converter>
    ///         </Binding>
    ///    </TextBlock.Text>
    /// </TextBlock>
    /// ]]>
    /// </code>
    /// </example>

    [ContentProperty("Mappings")]
    [ValueConversion(typeof(object), typeof(object))]
    public class MappingConverter : BaseConverter, IValueConverter
    {
        public Collection<Mapping> Mappings { get; set; } = new Collection<Mapping>();

        public object DefaultValue { get; set; } = DependencyProperty.UnsetValue;
        public object DefaultValueForConvertBack { get; set; } = DependencyProperty.UnsetValue;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (new List<Mapping>(Mappings)).Find(m => m.Key.Equals(value))?.Value ?? DefaultValue;
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
                return (new List<Mapping>(Mappings)).Find(m => m.Value.Equals(value))?.Key ?? DefaultValueForConvertBack;
            }
            catch
            {
                return DefaultValueForConvertBack;
            }
        }
    }
}
