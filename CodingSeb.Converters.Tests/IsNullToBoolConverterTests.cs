using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class IsNullToBoolConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ConvertNullToTrueValue()
        {
            IsNullToBoolConverter converter = new IsNullToBoolConverter();

            ((bool)converter.Convert(null, null, null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackTrueValueToNull()
        {
            IsNullToBoolConverter converter = new IsNullToBoolConverter();

            converter.ConvertBack(true, null, null, null).ShouldBeNull();
        }

        [Category("Convert")]
        [Test]
        public void ConvertInstanceToFalseValue()
        {
            IsNullToBoolConverter converter = new IsNullToBoolConverter();

            ((bool)converter.Convert(new object(), null, null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackFalseValueToProvidedConvertBackValueForFalse()
        {
            IsNullToBoolConverter converter = new IsNullToBoolConverter()
            {
                ConvertBackValueForFalse = "Test"
            };
            converter.ConvertBack(false, null, null, null).ShouldNotBeNull();
            converter.ConvertBack(false, null, null, null).ShouldBe("Test");
        }
    }
}
