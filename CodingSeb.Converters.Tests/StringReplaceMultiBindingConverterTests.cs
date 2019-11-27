using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringReplaceMultiBindingConverterTests
    {
        [Test]
        public void StringReplaceMultiBindingConverter()
        {
            StringReplaceMultiBindingConverter converter = new StringReplaceMultiBindingConverter();

            converter.Convert(new object[] { "23 asl Hello World 29" }, null, null, null).ShouldBe("23 asl Hello World 29");
            converter.Convert(new object[] { "23 asl Hello World 29", "" }, null, null, null).ShouldBe("23 asl Hello World 29");
            converter.Convert(new object[] { "23 asl Hello World 29", "Hello" }, null, null, null).ShouldBe("23 asl  World 29");
            converter.Convert(new object[] { "23 asl Hello World 29", "Hello", "Test" }, null, null, null).ShouldBe("23 asl Test World 29");
        }
    }
}
