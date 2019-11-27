using NUnit.Framework;
using Shouldly;
using System.Windows;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class CustomBoolToVisibilityConverterTests
    {
        [Category("Convert")]
        [Test]
        public void DefaultTrueToVisibilityVisible()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter();

            converter.Convert(true, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Visible);
        }

        [Category("Convert")]
        [Test]
        public void DefaultFalseToVisibilityCollapsed()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter();

            converter.Convert(false, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Collapsed);
        }

        [Category("Convert")]
        [Test]
        public void SettedTrueToVisibilityCollapsed()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Collapsed,
                FalseValue = Visibility.Visible
            };
            converter.Convert(true, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Collapsed);
        }

        [Category("Convert")]
        [Test]
        public void SettedTrueToVisibilityHidden()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Hidden,
                FalseValue = Visibility.Visible
            };
            converter.Convert(true, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Hidden);
        }

        [Category("Convert")]
        [Test]
        public void SettedFalseToVisibilityVisible()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Collapsed,
                FalseValue = Visibility.Visible
            };
            converter.Convert(false, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Visible);
        }

        [Category("Convert")]
        [Test]
        public void SettedFalseToVisibilityHidden()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                FalseValue = Visibility.Hidden
            };
            converter.Convert(false, typeof(Visibility), null, null).ShouldBe<object>(Visibility.Hidden);
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertDefaultVisibilityVisibleToTrue()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter();

            ((bool)converter.ConvertBack(Visibility.Visible, typeof(Visibility), null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertDefaultVisibilityCollapsedToFalse()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter();

            ((bool)converter.ConvertBack(Visibility.Collapsed, typeof(Visibility), null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertSettedVisibilityCollapsedToTrue()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Collapsed,
                FalseValue = Visibility.Visible
            };
            ((bool)converter.ConvertBack(Visibility.Collapsed, typeof(Visibility), null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertSettedVisibilityHiddenToTrue()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Hidden,
                FalseValue = Visibility.Visible
            };
            ((bool)converter.ConvertBack(Visibility.Hidden, typeof(Visibility), null, null)).ShouldBeTrue();
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertSettedVisibilityVisibleToFalse()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                TrueValue = Visibility.Collapsed,
                FalseValue = Visibility.Visible
            };
            ((bool)converter.ConvertBack(Visibility.Visible, typeof(Visibility), null, null)).ShouldBeFalse();
        }

        [Category("ConvertBack")]
        [Test]
        public void RevertSettedVisibilityHiddenToFalse()
        {
            CustomBoolToVisibilityConverter converter = new CustomBoolToVisibilityConverter()
            {
                FalseValue = Visibility.Hidden
            };
            ((bool)converter.ConvertBack(Visibility.Hidden, typeof(Visibility), null, null)).ShouldBeFalse();
        }
    }
}
