using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringFormatConverterTests
    {
        [Category("Convert")]
        [Test]
        public void SimpleStringFormatConvert()
        {
            StringFormatConverter converter = new StringFormatConverter()
            {
                Format = "Hello {0} Test"
            };
            converter.Convert(23, null, null, null).ShouldBe("Hello 23 Test");
            converter.Convert("World", null, null, null).ShouldBe("Hello World Test");
        }

        [Category("ConvertBack")]
        [Test]
        public void SimpleStringFormatConvertBack()
        {
            StringFormatConverter converter = new StringFormatConverter()
            {
                Format = "Hello {0} Test"
            };
            converter.ConvertBack("Hello 23 Test", typeof(int), null, null).ShouldBe(23);
            converter.ConvertBack("Hello World Test", typeof(string), null, null).ShouldBe("World");
        }
    }
}
