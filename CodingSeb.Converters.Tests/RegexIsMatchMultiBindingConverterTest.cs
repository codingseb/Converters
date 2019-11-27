using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexIsMatchMultiBindingConverterTest
    {
        [Test]
        public void RegexIsMatchMultiBindingConverter()
        {
            RegexIsMatchMultiBindingConverter converter = new RegexIsMatchMultiBindingConverter();

            ((bool)converter.Convert(new object[] { "dashlk 234 asd4 dads32sda das", @"\d" }, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(new object[] { "dsafjkhl jsdahéf jlfkdsa gaksdj", @"\d" }, null, null, null)).ShouldBeFalse();
        }
    }
}
