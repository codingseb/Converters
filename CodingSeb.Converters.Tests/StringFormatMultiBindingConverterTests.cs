using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringFormatMultiBindingConverterTests
    {
        [Category("Convert")]
        [Test]
        public void SimpleStringFormatMultiBindingConvert()
        {
            StringFormatMultiBindingConverter converter = new StringFormatMultiBindingConverter();

            converter.Convert(new object[] { "Hello ", 23, " Test" }, null, null, null).ShouldBe("Hello 23 Test");

            converter.Format = "{0:0.00}{1}";

            converter.Convert(new object[] { 10, " Hello" }, null, null, null).ShouldBe("10.00 Hello");
        }
    }
}
