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
    [ContentProperty(nameof(Mappings))]
    [ContentWrapper(typeof(Mapping))]
    [ValueConversion(typeof(object), typeof(object))]
    public class MappingConverter : BaseConverter, IValueConverter
    {
        #region Constructors

        public MappingConverter()
        {}
        public MappingConverter(Mapping mapping1) => Mappings.Add(mapping1);
        public MappingConverter(Mapping mapping1, Mapping mapping2) : this(mapping1) => Mappings.Add(mapping2);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3)
            : this(mapping1, mapping2) => Mappings.Add(mapping3);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4)
            : this(mapping1, mapping2, mapping3) => Mappings.Add(mapping4);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5)
            : this(mapping1, mapping2, mapping3, mapping4) => Mappings.Add(mapping5);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5, Mapping mapping6)
            : this(mapping1, mapping2, mapping3, mapping4, mapping5) => Mappings.Add(mapping6);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5, Mapping mapping6, Mapping mapping7)
            : this(mapping1, mapping2, mapping3, mapping4, mapping5, mapping6) => Mappings.Add(mapping7);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5, Mapping mapping6, Mapping mapping7, Mapping mapping8)
            : this(mapping1, mapping2, mapping3, mapping4, mapping5, mapping6, mapping7) => Mappings.Add(mapping8);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5, Mapping mapping6, Mapping mapping7, Mapping mapping8, Mapping mapping9)
            : this(mapping1, mapping2, mapping3, mapping4, mapping5, mapping6, mapping7, mapping8) => Mappings.Add(mapping9);
        public MappingConverter(Mapping mapping1, Mapping mapping2, Mapping mapping3, Mapping mapping4, Mapping mapping5, Mapping mapping6, Mapping mapping7, Mapping mapping8, Mapping mapping9, Mapping mapping10)
            : this(mapping1, mapping2, mapping3, mapping4, mapping5, mapping6, mapping7, mapping8, mapping9) => Mappings.Add(mapping10);

        #endregion

        public Collection<Mapping> Mappings { get; } = new Collection<Mapping>();

        public object DefaultValue { get; set; } = DependencyProperty.UnsetValue;
        public object DefaultValueForConvertBack { get; set; } = DependencyProperty.UnsetValue;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new List<Mapping>(Mappings).Find(m => m.Key.Equals(value))?.Value ?? DefaultValue;
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
                return new List<Mapping>(Mappings).Find(m => m.Value.Equals(value))?.Key ?? DefaultValueForConvertBack;
            }
            catch
            {
                return DefaultValueForConvertBack;
            }
        }
    }
}
