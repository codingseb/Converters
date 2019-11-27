using NUnit.Framework;
using Shouldly;
using System.Windows;
using System.Windows.Media;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ExclusiveBoolToEnumParameterConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ExclusiveBoolToStringParameterConverterTests_Convert()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.Convert("Test1", null, "Test1", null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("Test1", null, "Test1", null)).Equals(true);

            converter.Convert("Test2", null, "Test2", null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("Test2", null, "Test2", null)).Equals(true);

            converter.Convert("Test1", null, "Test2", null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("Test1", null, "Test2", null)).Equals(false);

            converter.Convert("Test2", null, "Test1", null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("Test2", null, "Test1", null)).Equals(false);
        }

        [Category("ConvertBack")]
        [Test]
        public void ExclusiveBoolToStringParameterConverterTests_ConvertBack()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.ConvertBack(true, null, "Test1", null).ShouldBeOfType<string>();
            ((string)converter.ConvertBack(true, null, "Test1", null)).Equals("Test1");

            converter.ConvertBack(true, null, "Test2", null).ShouldBeOfType<string>();
            ((string)converter.ConvertBack(true, null, "Test2", null)).Equals("Test2");

            converter.ConvertBack(false, null, "Test1", null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(false, null, "Test2", null).ShouldBe(DependencyProperty.UnsetValue);
        }

        [Category("Convert")]
        [Test]
        public void ExclusiveBoolToIntParameterConverterTests_Convert()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.Convert(1, null, 1, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(1, null, 1, null)).Equals(true);

            converter.Convert(2, null, 2, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(2, null, 2, null)).Equals(true);

            converter.Convert(1, null, 2, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(1, null, 2, null)).Equals(false);

            converter.Convert(2, null, 1, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(2, null, 1, null)).Equals(false);
        }

        [Category("ConvertBack")]
        [Test]
        public void ExclusiveBoolToIntParameterConverterTests_ConvertBack()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.ConvertBack(true, null, 1, null).ShouldBeOfType<int>();
            ((int)converter.ConvertBack(true, null, 1, null)).Equals(1);

            converter.ConvertBack(true, null, 2, null).ShouldBeOfType<int>();
            ((int)converter.ConvertBack(true, null, 2, null)).Equals(2);

            converter.ConvertBack(false, null, 1, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(false, null, 2, null).ShouldBe(DependencyProperty.UnsetValue);
        }

        [Category("Convert")]
        [Test]
        public void ExclusiveBoolToEnumParameterConverterTests_Convert()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.Convert(Colors.Black, null, Colors.Black, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Colors.Black, null, Colors.Black, null)).Equals(true);

            converter.Convert(Visibility.Collapsed, null, Visibility.Collapsed, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Visibility.Collapsed, null, Visibility.Collapsed, null)).Equals(true);

            converter.Convert(Colors.White, null, Colors.White, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Colors.White, null, Colors.White, null)).Equals(true);

            converter.Convert(Visibility.Visible, null, Visibility.Visible, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Visibility.Visible, null, Visibility.Visible, null)).Equals(true);

            converter.Convert(Colors.Black, null, Colors.White, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Colors.Black, null, Colors.White, null)).Equals(false);

            converter.Convert(Visibility.Collapsed, null, Visibility.Visible, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Visibility.Collapsed, null, Visibility.Visible, null)).Equals(false);

            converter.Convert(Colors.White, null, Colors.Black, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Colors.White, null, Colors.Black, null)).Equals(false);

            converter.Convert(Visibility.Visible, null, Visibility.Collapsed, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(Visibility.Visible, null, Visibility.Collapsed, null)).Equals(false);
        }

        [Category("ConvertBack")]
        [Test]
        public void ExclusiveBoolToEnumParameterConverterTests_ConvertBack()
        {
            ExclusiveBoolToEnumOrEquatableParameterConverter converter = new ExclusiveBoolToEnumOrEquatableParameterConverter();

            converter.ConvertBack(true, null, Colors.Black, null).ShouldBeOfType<Color>();
            ((Color)converter.ConvertBack(true, null, Colors.Black, null)).Equals(Colors.Black);

            converter.ConvertBack(true, null, Visibility.Collapsed, null).ShouldBeOfType<Visibility>();
            ((Visibility)converter.ConvertBack(true, null, Visibility.Collapsed, null)).Equals(Visibility.Collapsed);

            converter.ConvertBack(true, null, Colors.White, null).ShouldBeOfType<Color>();
            ((Color)converter.ConvertBack(true, null, Colors.White, null)).Equals(Colors.White);

            converter.ConvertBack(true, null, Visibility.Visible, null).ShouldBeOfType<Visibility>();
            ((Visibility)converter.ConvertBack(true, null, Visibility.Visible, null)).Equals(Visibility.Visible);

            converter.ConvertBack(false, null, Colors.Black, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(false, null, Visibility.Collapsed, null).ShouldBe(DependencyProperty.UnsetValue);

            converter.ConvertBack(false, null, Colors.White, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(false, null, Visibility.Visible, null).ShouldBe(DependencyProperty.UnsetValue);
        }
    }
}
