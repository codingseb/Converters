using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringIsNullOrEmptyToBoolConverterTests
    {
        [Category("Convert")]
        [Test]
        public void StringIsNullOrEmptyToBool_IsEmpty_Convert()
        {
            StringIsNullOrEmptyToBoolConverter converter = new StringIsNullOrEmptyToBoolConverter();

            converter.Convert(string.Empty, null, null, null).ShouldBeOfType<bool>();
            converter.Convert(string.Empty, null, null, null).ShouldBe(true);
        }

        [Category("Convert")]
        [Test]
        public void StringIsNullOrEmptyToBool_IsNull_Convert()
        {
            StringIsNullOrEmptyToBoolConverter converter = new StringIsNullOrEmptyToBoolConverter();

            converter.Convert(null, null, null, null).ShouldBeOfType<bool>();
            converter.Convert(null, null, null, null).ShouldBe(true);
        }

        [Category("Convert")]
        [Test]
        public void StringIsNullOrEmptyToBool_HasText_Convert()
        {
            StringIsNullOrEmptyToBoolConverter converter = new StringIsNullOrEmptyToBoolConverter();

            converter.Convert("Hello", null, null, null).ShouldBeOfType<bool>();
            converter.Convert("Hello", null, null, null).ShouldBe(false);
        }

        [Category("ConvertBack")]
        [Test]
        public void StringIsNullOrEmptyToBool_False_ConvertBack()
        {
            StringIsNullOrEmptyToBoolConverter converter = new StringIsNullOrEmptyToBoolConverter();

            converter.ConvertBack(false, null, null, null).ShouldBe("False");

            converter.ConvertBackValueForFalse = "No Value";

            converter.ConvertBack(false, null, null, null).ShouldBe("No Value");
        }

        [Category("ConvertBack")]
        [Test]
        public void StringIsNullOrEmptyToBool_True_ConvertBack()
        {
            StringIsNullOrEmptyToBoolConverter converter = new StringIsNullOrEmptyToBoolConverter();

            converter.ConvertBack(true, null, null, null).ShouldBe(string.Empty);

            converter.ConvertBackReturnNullForTrue = true;

            converter.ConvertBack(true, null, null, null).ShouldBeNull();

            converter.ConvertBackReturnNullForTrue = false;

            converter.ConvertBack(true, null, null, null).ShouldBe(string.Empty);
        }
    }
}
