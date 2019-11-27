using System.Windows;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    [ContentProperty("Value")]
    public class Mapping
    {
        public object Key { get; set; }
        public object Value { get; set; } = DependencyProperty.UnsetValue;
    }
}