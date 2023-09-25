using NUnit.Framework;
using Shouldly;
using System;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class DoubleConvertersTests
    {
        [Test]
        public void DoubleAbsoluteValueConverter()
        {
            DoubleAbsoluteValueConverter converter = new DoubleAbsoluteValueConverter();

            ((double)converter.Convert(-100d, null, null, null)).ShouldBe(100d);
            ((double)converter.Convert(-48.5d, null, null, null)).ShouldBe(48.5d);
            ((double)converter.Convert(0d, null, null, null)).ShouldBe(0d);
            ((double)converter.Convert(48.5d, null, null, null)).ShouldBe(48.5d);
            ((double)converter.Convert(100d, null, null, null)).ShouldBe(100d);
        }

        [Test]
        public void DoubleMinusValueConverter()
        {
            DoubleMinusValueConverter converter = new DoubleMinusValueConverter();

            ((double)converter.Convert(-100d, null, null, null)).ShouldBe(100d);
            ((double)converter.Convert(-48.5d, null, null, null)).ShouldBe(48.5d);
            ((double)converter.Convert(0d, null, null, null)).ShouldBe(0d);
            ((double)converter.Convert(48.5d, null, null, null)).ShouldBe(-48.5d);
            ((double)converter.Convert(100d, null, null, null)).ShouldBe(-100d);
        }

        [Test]
        public void DoubleInverseValueConverter()
        {
            DoubleInverseValueConverter converter = new DoubleInverseValueConverter();

            ((double)converter.Convert(-5d, null, null, null)).ShouldBe(-0.2d);
            ((double)converter.Convert(-2d, null, null, null)).ShouldBe(-0.5d);
            ((double)converter.Convert(-1d, null, null, null)).ShouldBe(-1d);
            ((double)converter.Convert(-0.5d, null, null, null)).ShouldBe(-2d);
            ((double)converter.Convert(-0.25d, null, null, null)).ShouldBe(-4d);
            ((double)converter.Convert(0.25d, null, null, null)).ShouldBe(4d);
            ((double)converter.Convert(0.5d, null, null, null)).ShouldBe(2d);
            ((double)converter.Convert(1d, null, null, null)).ShouldBe(1);
            ((double)converter.Convert(2d, null, null, null)).ShouldBe(0.5);
            ((double)converter.Convert(5d, null, null, null)).ShouldBe(0.2);
        }

        [Test]
        public void DoubleValuesSumMultiBindingConverter()
        {
            DoubleValuesSumMultiBindingConverter converter = new DoubleValuesSumMultiBindingConverter();

            ((double)converter.Convert(new object[] { 5.5 }, null, null, null)).ShouldBe(5.5);
            ((double)converter.Convert(new object[] { 5.5, 4.5 }, null, null, null)).ShouldBe(10d);
            ((double)converter.Convert(new object[] { 1d, 2d, 3d, -4d }, null, null, null)).ShouldBe(2d);
            converter.AdditionalConstValueToAdd = 20d;
            ((double)converter.Convert(new object[] { 1d, 2d, 3d, -4d }, null, null, null)).ShouldBe(22d);
        }

        [Test]
        public void DoubleValuesMultiplyMultiBindingConverter()
        {
            DoubleValuesMultiplyMultiBindingConverter converter = new DoubleValuesMultiplyMultiBindingConverter();

            ((double)converter.Convert(new object[] { 5.5 }, null, null, null)).ShouldBe(5.5);
            ((double)converter.Convert(new object[] { 5.5, 2d }, null, null, null)).ShouldBe(11d);
            ((double)converter.Convert(new object[] { 2d, -8d, 0.5 }, null, null, null)).ShouldBe(-8d);
            converter.AdditionalConstValueToMultiply = -2d;
            ((double)converter.Convert(new object[] { 2d, -8d, 0.5 }, null, null, null)).ShouldBe(16d);
        }

        [Test]
        public void DoubleMaxValueConverter()
        {
            DoubleMaxValueConverter converter = new DoubleMaxValueConverter() { MaxValue = 10d };

            ((double)converter.Convert(-10d, null, null, null)).ShouldBe(10d);
            ((double)converter.Convert(10d, null, null, null)).ShouldBe(10d);
            ((double)converter.Convert(150d, null, null, null)).ShouldBe(150d);
            ((double)converter.Convert(11d, null, null, null)).ShouldBe(11d);
            ((double)converter.Convert(0d, null, null, null)).ShouldBe(10d);
        }

        [Test]
        public void DoubleMinValueConverter()
        {
            DoubleMinValueConverter converter = new DoubleMinValueConverter() { MinValue = 10d };

            ((double)converter.Convert(-10d, null, null, null)).ShouldBe(-10d);
            ((double)converter.Convert(10d, null, null, null)).ShouldBe(10d);
            ((double)converter.Convert(150d, null, null, null)).ShouldBe(10d);
            ((double)converter.Convert(9d, null, null, null)).ShouldBe(9d);
            ((double)converter.Convert(0d, null, null, null)).ShouldBe(0d);
        }
    }
}
