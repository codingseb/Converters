using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ReverseBoolConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ConvertTrueToFalse()
        {
            ReverseBoolConverter converter = new ReverseBoolConverter();

            ((bool)converter.Convert(true, typeof(bool), null, null)).ShouldBeFalse();
        }

        [Category("Convert")]
        [Test]
        public void ConvertFalseToTrue()
        {
            ReverseBoolConverter converter = new ReverseBoolConverter();

            ((bool)converter.Convert(false, typeof(bool), null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackTrueToFalse()
        {
            ReverseBoolConverter converter = new ReverseBoolConverter();

            ((bool)converter.ConvertBack(true, typeof(bool), null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackFalseToTrue()
        {
            ReverseBoolConverter converter = new ReverseBoolConverter();

            ((bool)converter.ConvertBack(false, typeof(bool), null, null)).ShouldBeTrue();
        }
    }
}
