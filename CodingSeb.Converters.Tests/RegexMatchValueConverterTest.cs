using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexMatchValueConverterTest
    {
        [Test]
        public void RegexMatchValue()
        {
            RegexMatchValueConverter converter = new RegexMatchValueConverter()
            {
                Pattern = @"\d+"
            };
            converter.Convert("dashlk 234 asd4 dads32sda das", null, null, null).ShouldBe("234");
        }
    }
}
