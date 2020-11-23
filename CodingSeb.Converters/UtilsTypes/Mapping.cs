using System;
using System.Windows;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    [ContentProperty("Value")]
    public class Mapping : MarkupExtension
    {
        public Mapping()
        {}

        public Mapping(object key)
        {
            Key = key;
        }

        public Mapping(object key, object value)
        {
            Key = key;
            Value = value;
        }

        [ConstructorArgument("key")]
        public object Key { get; set; }

        [ConstructorArgument("value")]
        public object Value { get; set; } = DependencyProperty.UnsetValue;

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}