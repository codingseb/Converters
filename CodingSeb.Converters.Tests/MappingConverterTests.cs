using NUnit.Framework;
using Shouldly;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class MappingConverterTests
    {
        [Test]
        [Category("Convert")]
        public void MappingConverterTest_StringToString_Convert()
        {
            MappingConverter converter = new MappingConverter
            {
                Mappings = new Collection<Mapping>(new Mapping[]
                {
                    new Mapping()
                    {
                        Key = "Test 1",
                        Value = "Yes",
                    },
                    new Mapping()
                    {
                        Key = "Test 2",
                        Value = "No",
                    },
                })
            };

            converter.Convert("Test 1", null, null, null).ShouldBe("Yes");
            converter.Convert("Test 2", null, null, null).ShouldBe("No");
            converter.Convert("", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert("Try 40", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert(null, null, null, null).ShouldBe(DependencyProperty.UnsetValue);

            converter.DefaultValue = "Default";

            converter.Convert("", null, null, null).ShouldBe("Default");
            converter.Convert("Try 40", null, null, null).ShouldBe("Default");
            converter.Convert(null, null, null, null).ShouldBe("Default");
        }

        [Test]
        [Category("ConvertBack")]
        public void MappingConverterTest_StringToString_ConvertBack()
        {
            MappingConverter converter = new MappingConverter
            {
                Mappings = new Collection<Mapping>(new Mapping[]
            {
                new Mapping()
                {
                    Key = "Test 1",
                    Value = "Yes",
                },
                new Mapping()
                {
                    Key = "Test 2",
                    Value = "No",
                },
            })
            };

            converter.ConvertBack("Yes", null, null, null).ShouldBe("Test 1");
            converter.ConvertBack("No", null, null, null).ShouldBe("Test 2");
            converter.ConvertBack("", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack("Try 40", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(null, null, null, null).ShouldBe(DependencyProperty.UnsetValue);

            converter.DefaultValueForConvertBack = "Default";

            converter.ConvertBack("", null, null, null).ShouldBe("Default");
            converter.ConvertBack("Try 40", null, null, null).ShouldBe("Default");
            converter.ConvertBack(null, null, null, null).ShouldBe("Default");
        }

        [Test]
        [Category("Convert")]
        public void MappingConverterTest_ColorToVisibility_Convert()
        {
            MappingConverter converter = new MappingConverter
            {
                Mappings = new Collection<Mapping>(new Mapping[]
            {
                new Mapping()
                {
                    Key = Colors.Red,
                    Value = Visibility.Collapsed,
                },
                new Mapping()
                {
                    Key = Colors.Blue,
                    Value = Visibility.Visible,
                },
            })
            };

            converter.Convert(Colors.Red, null, null, null).ShouldBe(Visibility.Collapsed);
            converter.Convert(Colors.Blue, null, null, null).ShouldBe(Visibility.Visible);
            converter.Convert("", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert("Try 40", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert(Colors.Black, null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert(21, null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.Convert(null, null, null, null).ShouldBe(DependencyProperty.UnsetValue);

            converter.DefaultValue = Visibility.Hidden;

            converter.Convert("", null, null, null).ShouldBe(Visibility.Hidden);
            converter.Convert("Try 40", null, null, null).ShouldBe(Visibility.Hidden);
            converter.Convert(Colors.Black, null, null, null).ShouldBe(Visibility.Hidden);
            converter.Convert(21, null, null, null).ShouldBe(Visibility.Hidden);
            converter.Convert(null, null, null, null).ShouldBe(Visibility.Hidden);
        }

        [Test]
        [Category("ConvertBack")]
        public void MappingConverterTest_ColorToVisibility_ConvertBack()
        {
            MappingConverter converter = new MappingConverter
            {
                Mappings = new Collection<Mapping>(new Mapping[]
            {
                new Mapping()
                {
                    Key = Colors.Red,
                    Value = Visibility.Collapsed,
                },
                new Mapping()
                {
                    Key = Colors.Blue,
                    Value = Visibility.Visible,
                },
            })
            };

            converter.ConvertBack(Visibility.Collapsed, null, null, null).ShouldBe(Colors.Red);
            converter.ConvertBack(Visibility.Visible, null, null, null).ShouldBe(Colors.Blue);
            converter.ConvertBack("", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack("Try 40", null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(Visibility.Hidden, null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(Colors.Black, null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(21, null, null, null).ShouldBe(DependencyProperty.UnsetValue);
            converter.ConvertBack(null, null, null, null).ShouldBe(DependencyProperty.UnsetValue);

            converter.DefaultValueForConvertBack = Colors.Black;

            converter.ConvertBack("", null, null, null).ShouldBe(Colors.Black);
            converter.ConvertBack("Try 40", null, null, null).ShouldBe(Colors.Black);
            converter.ConvertBack(Visibility.Hidden, null, null, null).ShouldBe(Colors.Black);
            converter.ConvertBack(Colors.Black, null, null, null).ShouldBe(Colors.Black);
            converter.ConvertBack(21, null, null, null).ShouldBe(Colors.Black);
            converter.ConvertBack(null, null, null, null).ShouldBe(Colors.Black);
        }
    }
}
