using NUnit.Framework;
using Shouldly;
using System.Windows.Media;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ColorToSolidColorBrushConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ConvertSomeColorsIntoCorrepondingSolidColorBrush()
        {
            ColorToSolidColorBrushConverter converter = new ColorToSolidColorBrushConverter();

            // ShouldBes sur le ToString() utiliser ici parce que dans le cas de SolidColorBrush le Equals test la référence et retourne false.
            converter.Convert(Colors.Black, typeof(SolidColorBrush), null, null).ToString().ShouldBe(Brushes.Black.ToString());
            converter.Convert(Colors.White, typeof(SolidColorBrush), null, null).ToString().ShouldBe(Brushes.White.ToString());
            converter.Convert(Colors.Red, typeof(SolidColorBrush), null, null).ToString().ShouldBe(Brushes.Red.ToString());
            converter.Convert(Colors.Blue, typeof(SolidColorBrush), null, null).ToString().ShouldBe(Brushes.Blue.ToString());
            converter.Convert(Colors.Yellow, typeof(SolidColorBrush), null, null).ToString().ShouldBe(Brushes.Yellow.ToString());
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackSomeSolidColorBrushIntoCorrepondingColors()
        {
            ColorToSolidColorBrushConverter converter = new ColorToSolidColorBrushConverter();

            converter.ConvertBack(Brushes.Black, typeof(SolidColorBrush), null, null).ShouldBe(Colors.Black);
            converter.ConvertBack(Brushes.White, typeof(SolidColorBrush), null, null).ShouldBe(Colors.White);
            converter.ConvertBack(Brushes.Red, typeof(SolidColorBrush), null, null).ShouldBe(Colors.Red);
            converter.ConvertBack(Brushes.Blue, typeof(SolidColorBrush), null, null).ShouldBe(Colors.Blue);
            converter.ConvertBack(Brushes.Yellow, typeof(SolidColorBrush), null, null).ShouldBe(Colors.Yellow);
        }
    }
}
