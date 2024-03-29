﻿using NUnit.Framework;
using Shouldly;
using System.Windows;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ChainingConverterTests
    {
        [Category("Convert")]
        [Test]
        public void Chain2ReverseBoolConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter()
            {
                Converter1 = new BoolReverseConverter(),
                Converter2 = new BoolReverseConverter()
            };
            ((bool)masterConverter.Convert(true, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.Convert(false, null, null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackChain2ReverseBoolConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter()
            {
                Converter1 = new BoolReverseConverter(),
                Converter2 = new BoolReverseConverter()
            };
            ((bool)masterConverter.ConvertBack(true, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.ConvertBack(false, null, null, null)).ShouldBeFalse();
        }

        [Category("Convert")]
        [Test]
        public void ChainReverseBoolAndCustomBoolToVisibilityConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter()
            {
                Converter1 = new BoolReverseConverter(),
                Converter2 = new CustomBoolToVisibilityConverter()
            };
            ((Visibility)masterConverter.Convert(true, null, null, null)).ShouldBe(Visibility.Collapsed);
            ((Visibility)masterConverter.Convert(false, null, null, null)).ShouldBe(Visibility.Visible);
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackChainReverseBoolAndCustomBoolToVisibilityConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter()
            {
                Converter1 = new BoolReverseConverter(),
                Converter2 = new CustomBoolToVisibilityConverter()
            };
            ((bool)masterConverter.ConvertBack(Visibility.Collapsed, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.ConvertBack(Visibility.Visible, null, null, null)).ShouldBeFalse();
        }

        [Category("Convert")]
        [Test]
        public void ChainMoreThanTwoConvertersConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter();

            IntToBoolConverter intToBoolConverter = new IntToBoolConverter()
            {
                BiggerThanTrueValue = 0,
                SmallerThanFalseValue = 1
            };
            masterConverter.Converters.Add(intToBoolConverter);
            masterConverter.Converters.Add(new BoolReverseConverter());
            masterConverter.Converters.Add(new CustomBoolToVisibilityConverter());

            ((Visibility)masterConverter.Convert(-3, null, null, null)).ShouldBe(Visibility.Visible);
            ((Visibility)masterConverter.Convert(-1, null, null, null)).ShouldBe(Visibility.Visible);
            ((Visibility)masterConverter.Convert(0, null, null, null)).ShouldBe(Visibility.Visible);
            ((Visibility)masterConverter.Convert(1, null, null, null)).ShouldBe(Visibility.Collapsed);
            ((Visibility)masterConverter.Convert(5, null, null, null)).ShouldBe(Visibility.Collapsed);
            ((Visibility)masterConverter.Convert(10, null, null, null)).ShouldBe(Visibility.Collapsed);
        }

        [Category("Convert")]
        [Test]
        public void ChainConvertersWithParametersConverter()
        {
            ChainingConverter masterConverter = new ChainingConverter();

            masterConverter.Converters.Add(new DoubleAddValueConverter());
            masterConverter.Converters.Add(new DoubleFactorValueConverter() { UseParameterTo = DoubleConvertersUseParameterTo.Multiply });

            ((double)masterConverter.Convert(1.0, null, "2,3", null)).ShouldBe(9.0);
            ((double)masterConverter.Convert(2.1, null, "1,2", null)).ShouldBe(6.2);
        }
    }
}
