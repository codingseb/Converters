using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class IsNotNullToBoolConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ConvertNullToFalseValue()
        {
            IsNotNullToBoolConverter converter = new IsNotNullToBoolConverter();

            ((bool)converter.Convert(null, null, null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackFalseValueToNull()
        {
            IsNotNullToBoolConverter converter = new IsNotNullToBoolConverter();

            converter.ConvertBack(false, null, null, null).ShouldBeNull();
        }

        [Category("Convert")]
        [Test]
        public void ConvertInstanceToTrueValue()
        {
            IsNotNullToBoolConverter converter = new IsNotNullToBoolConverter();

            ((bool)converter.Convert(new object(), null, null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackFalseValueToProvidedConvertBackValueForFalse()
        {
            IsNotNullToBoolConverter converter = new IsNotNullToBoolConverter()
            {
                ConvertBackValueForTrue = "Test"
            };
            converter.ConvertBack(true, null, null, null).ShouldNotBeNull();
            converter.ConvertBack(true, null, null, null).ShouldBe("Test");
        }
    }
}
