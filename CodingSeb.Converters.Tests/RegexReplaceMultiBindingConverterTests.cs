using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class RegexReplaceMultiBindingConverterTests
    {
        [Test]
        public void RegexReplaceMultiBindingConverter()
        {
            RegexReplaceMultiBindingConverter converter = new RegexReplaceMultiBindingConverter();

            converter.Convert(new object[] { "dashlk 234 asd4 dads32sda das", @"\d" }, null, null, null).ShouldBe("dashlk  asd dadssda das");
            converter.Convert(new object[] { "dashlk 234 asd4 dads32sda das", @"\d", "*" }, null, null, null).ShouldBe("dashlk *** asd* dads**sda das");
        }
    }
}
