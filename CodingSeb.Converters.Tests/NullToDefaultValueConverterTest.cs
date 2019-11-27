using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class NullToDefaultValueConverterTest
    {
        [Category("Convert")]
        [Test]
        public void NullToDefaultValueConverter_SomeDefaultValuesWithNullTest()
        {
            NullToDefaultValueConverter converter = new NullToDefaultValueConverter
            {
                ValueIfNull = true
            };

            converter.Convert(null, typeof(bool), null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(null, typeof(bool), null, null)).ShouldBeTrue();

            converter.ValueIfNull = 11;

            converter.Convert(null, typeof(bool), null, null).ShouldBeOfType<int>();
            ((int)converter.Convert(null, typeof(bool), null, null)).ShouldBe(11);

            converter.ValueIfNull = "Test";

            converter.Convert(null, typeof(bool), null, null).ShouldBeOfType<string>();
            ((string)converter.Convert(null, typeof(bool), null, null)).ShouldBe("Test");
        }

        [Category("Convert")]
        [Test]
        public void NullToDefaultValueConverter_SomeDefaultValuesWithNotNullTest()
        {
            NullToDefaultValueConverter converter = new NullToDefaultValueConverter
            {
                ValueIfNull = true
            };

            converter.Convert(false, typeof(bool), null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(false, typeof(bool), null, null)).ShouldBeFalse();

            converter.ValueIfNull = 11;

            converter.Convert(15, typeof(bool), null, null).ShouldBeOfType<int>();
            ((int)converter.Convert(15, typeof(bool), null, null)).ShouldBe(15);

            converter.ValueIfNull = "Test";

            converter.Convert("Hello", typeof(bool), null, null).ShouldBeOfType<string>();
            ((string)converter.Convert("Hello", typeof(bool), null, null)).ShouldBe("Hello");
        }

        [Category("ConvertBack")]
        [Test]
        public void NullToDefaultValueConverter_SomeDefaultValueConvertBackTest()
        {
            NullToDefaultValueConverter converter = new NullToDefaultValueConverter
            {
                ValueIfNull = true
            };

            converter.ConvertBack(false, typeof(bool), null, null).ShouldBeOfType<bool>();
            ((bool)converter.ConvertBack(false, typeof(bool), null, null)).ShouldBeFalse();

            converter.ValueIfNull = 11;

            converter.ConvertBack(15, typeof(bool), null, null).ShouldBeOfType<int>();
            ((int)converter.ConvertBack(15, typeof(bool), null, null)).ShouldBe(15);

            converter.ValueIfNull = "Test";

            converter.ConvertBack("Hello", typeof(bool), null, null).ShouldBeOfType<string>();
            ((string)converter.ConvertBack("Hello", typeof(bool), null, null)).ShouldBe("Hello");

            converter.ConvertBack(null, typeof(bool), null, null).ShouldBeNull();
        }
    }
}
