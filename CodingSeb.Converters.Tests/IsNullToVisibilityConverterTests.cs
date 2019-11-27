using NUnit.Framework;
using System.Windows;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class IsNullToVisibilityConverterTests
    {
        [Test]
        public void IsNullToVisibilityConverterTests_Convert()
        {
            IsNullToVisibilityConverter converter = new IsNullToVisibilityConverter();

            converter.Convert(null, null, null, null).Equals(Visibility.Collapsed);
            converter.Convert(11, null, null, null).Equals(Visibility.Visible);

            converter.IsNullValue = Visibility.Visible;
            converter.IsNotNullValue = Visibility.Hidden;

            converter.Convert(null, null, null, null).Equals(Visibility.Visible);
            converter.Convert(11, null, null, null).Equals(Visibility.Hidden);
        }
    }
}
