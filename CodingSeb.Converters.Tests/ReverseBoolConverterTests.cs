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
            BoolReverseConverter converter = new BoolReverseConverter();

            ((bool)converter.Convert(true, typeof(bool), null, null)).ShouldBeFalse();
        }

        [Category("Convert")]
        [Test]
        public void ConvertFalseToTrue()
        {
            BoolReverseConverter converter = new BoolReverseConverter();

            ((bool)converter.Convert(false, typeof(bool), null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackTrueToFalse()
        {
            BoolReverseConverter converter = new BoolReverseConverter();

            ((bool)converter.ConvertBack(true, typeof(bool), null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackFalseToTrue()
        {
            BoolReverseConverter converter = new BoolReverseConverter();

            ((bool)converter.ConvertBack(false, typeof(bool), null, null)).ShouldBeTrue();
        }
    }
}
