using System.Windows;

namespace CodingSeb.Converters
{
    public class IsNullToVisibilityConverter : IsNullToValueConverters<Visibility>
    {
        public IsNullToVisibilityConverter()
        {
            IsNotNullValue = Visibility.Visible;
            IsNullValue = Visibility.Collapsed;
        }
    }
}
