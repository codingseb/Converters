using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexMatchValueMultiBindingConverterTest
    {
        [Test]
        public void RegexMatchValueMultiBindingConverter()
        {
            RegexMatchValueMultiBindingConverter converter = new RegexMatchValueMultiBindingConverter();

            converter.Convert(new object[] { "dashlk 234 asd4 dads32sda das", @"\d+" }, null, null, null).ShouldBe("234");
        }
    }
}
