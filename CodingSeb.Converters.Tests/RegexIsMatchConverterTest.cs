using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexIsMatchConverterTest
    {
        [Test]
        public void RegexIsMatchConverter()
        {
            RegexIsMatchConverter converter = new RegexIsMatchConverter()
            {
                Pattern = @"\d"
            };
            ((bool)converter.Convert("dashlk 234 asd4 dads32sda das", null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert("dsafjkhl jsdahéf jlfkdsa gaksdj", null, null, null)).ShouldBeFalse();
        }
    }
}
