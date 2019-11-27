using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringContainsMultiBindingConverterTest
    {
        [Test]
        public void StringContainsMultiBindingConvert()
        {
            StringContainsMultiBindingConverter converter = new StringContainsMultiBindingConverter();

            ((bool)converter.Convert(new object[] { "Hello World !!!", "Test" }, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(new object[] { "This is a Test !!!", "Test" }, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(new object[] { "This is a test !!!", "Test" }, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(new object[] { "This is a test !!!", "Test", true }, null, null, null)).ShouldBeTrue();
        }
    }
}
