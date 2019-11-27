using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexReplaceConverterTest
    {
        [Test]
        public void RegexReplaceConverter()
        {
            RegexReplaceConverter converter = new RegexReplaceConverter()
            {
                Pattern = @"\d"
            };

            converter.Convert("dashlk 234 asd4 dads32sda das", null, null, null).ShouldBe("dashlk  asd dadssda das");

            converter.Replacement = "*";
            converter.Convert("dashlk 234 asd4 dads32sda das", null, null, null).ShouldBe("dashlk *** asd* dads**sda das");
        }
    }
}
