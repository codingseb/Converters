using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;
using System.Windows;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ConvertToTypeConverterTest
    {
        [Category("Convert")]
        [Test]
        public void StringToIntConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(int)
            };

            converter.Convert("12", null, null, null).ShouldBeOfType<int>();
            converter.Convert("12", null, null, null).ShouldBe(12);
        }

        [Category("Convert")]
        [Test]
        public void StringToBoolConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(bool)
            };

            converter.Convert("true", null, null, null).ShouldBeOfType<bool>();
            converter.Convert("true", null, null, null).ShouldBe(true);
            converter.Convert("false", null, null, null).ShouldBeOfType<bool>();
            converter.Convert("false", null, null, null).ShouldBe(false);
        }

        [Category("Convert")]
        [Test]
        public void StringToFloatConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(float)
            };

            converter.Convert("12", null, null, null).ShouldBeOfType<float>();
            converter.Convert("12", null, null, null).ShouldBe(12f);
            converter.Convert("15.3", null, null, null).ShouldBeOfType<float>();
            converter.Convert("15.3", null, null, null).ShouldBe(15.3f);
        }

        [Test]
        public void StringToVisibilityEnumConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(Visibility)
            };
            converter.Convert("Collapsed", null, null, null).ShouldBeOfType<Visibility>();
            converter.Convert("Collapsed", null, null, null).ShouldBe(Visibility.Collapsed);
            converter.Convert("Visible", null, null, null).ShouldBeOfType<Visibility>();
            converter.Convert("Visible", null, null, null).ShouldBe(Visibility.Visible);
            converter.Convert("Hidden", null, null, null).ShouldBeOfType<Visibility>();
            converter.Convert("Hidden", null, null, null).ShouldBe(Visibility.Hidden);
        }

        [Test]
        public void VisibilityEnumToStrignConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(string)
            };
            converter.Convert(Visibility.Collapsed, null, null, null).ShouldBeOfType<string>();
            converter.Convert(Visibility.Collapsed, null, null, null).ShouldBe("Collapsed");
            converter.Convert(Visibility.Visible, null, null, null).ShouldBeOfType<string>();
            converter.Convert(Visibility.Visible, null, null, null).ShouldBe("Visible");
            converter.Convert(Visibility.Hidden, null, null, null).ShouldBeOfType<string>();
            converter.Convert(Visibility.Hidden, null, null, null).ShouldBe("Hidden");
        }

        [Test]
        public void StringToRegexOptionsEnumConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(RegexOptions)
            };
            converter.Convert("IgnoreCase", null, null, null).ShouldBeOfType<RegexOptions>();
            converter.Convert("IgnoreCase", null, null, null).ShouldBe(RegexOptions.IgnoreCase);
            converter.Convert("None", null, null, null).ShouldBeOfType<RegexOptions>();
            converter.Convert("None", null, null, null).ShouldBe(RegexOptions.None);
            converter.Convert("IgnoreCase, Multiline", null, null, null).ShouldBeOfType<RegexOptions>();
            converter.Convert("IgnoreCase, Multiline", null, null, null).ShouldBe(RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }

        [Category("Convert")]
        [Test]
        public void IntToStringConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(string)
            };
            converter.Convert(13, null, null, null).ShouldBeOfType<string>();
            converter.Convert(13, null, null, null).ShouldBe("13");
        }

        [Category("Convert")]
        [Test]
        public void BoolToStringConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(string)
            };
            converter.Convert(true, null, null, null).ShouldBeOfType<string>();
            converter.Convert(true, null, null, null).ShouldBe("True");
            converter.Convert(false, null, null, null).ShouldBeOfType<string>();
            converter.Convert(false, null, null, null).ShouldBe("False");
        }

        [Category("Convert")]
        [Test]
        public void IntToFloatConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(float)
            };
            converter.Convert(13, null, null, null).ShouldBeOfType<float>();
            converter.Convert(13, null, null, null).ShouldBe(13f);
        }

        [Category("Convert")]
        [Test]
        public void FloatToIntConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(int)
            };
            converter.Convert(13f, null, null, null).ShouldBeOfType<int>();
            converter.Convert(13f, null, null, null).ShouldBe(13);
            converter.Convert(15.3f, null, null, null).ShouldBeOfType<int>();
            converter.Convert(15.3f, null, null, null).ShouldBe(15);
        }

        [Category("Convert")]
        [Test]
        public void DecimalToFloatConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(float)
            };
            converter.Convert(13m, null, null, null).ShouldBeOfType<float>();
            converter.Convert(13m, null, null, null).ShouldBe(13f);
            converter.Convert(15.3m, null, null, null).ShouldBeOfType<float>();
            converter.Convert(15.3m, null, null, null).ShouldBe(15.3f);
        }

        [Category("Convert")]
        [Test]
        public void FloatToDecimalConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(decimal)
            };
            converter.Convert(13f, null, null, null).ShouldBeOfType<decimal>();
            converter.Convert(13f, null, null, null).ShouldBe(13m);
            converter.Convert(15.3f, null, null, null).ShouldBeOfType<decimal>();
            converter.Convert(15.3f, null, null, null).ShouldBe(15.3m);
        }

        [Category("Convert")]
        [Test]
        public void DecimalToIntConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(int)
            };
            converter.Convert(13m, null, null, null).ShouldBeOfType<int>();
            converter.Convert(13m, null, null, null).ShouldBe(13);
            converter.Convert(15.3m, null, null, null).ShouldBeOfType<int>();
            converter.Convert(15.3m, null, null, null).ShouldBe(15);
        }

        [Category("Convert")]
        [Test]
        public void IntToDecimalConvertToTypeConvert()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertToType = typeof(decimal)
            };
            converter.Convert(13, null, null, null).ShouldBeOfType<decimal>();
            converter.Convert(13, null, null, null).ShouldBe(13m);
        }

        [Category("ConvertBack")]
        [Test]
        public void StringToIntConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(int)
            };
            converter.ConvertBack("12", null, null, null).ShouldBeOfType<int>();
            converter.ConvertBack("12", null, null, null).ShouldBe(12);
        }

        [Category("ConvertBack")]
        [Test]
        public void StringToBoolConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(bool)
            };
            converter.ConvertBack("true", null, null, null).ShouldBeOfType<bool>();
            converter.ConvertBack("true", null, null, null).ShouldBe(true);
            converter.ConvertBack("false", null, null, null).ShouldBeOfType<bool>();
            converter.ConvertBack("false", null, null, null).ShouldBe(false);
        }

        [Category("ConvertBack")]
        [Test]
        public void StringToFloatConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(float)
            };
            converter.ConvertBack("12", null, null, null).ShouldBeOfType<float>();
            converter.ConvertBack("12", null, null, null).ShouldBe(12f);
            converter.ConvertBack("15.3", null, null, null).ShouldBeOfType<float>();
            converter.ConvertBack("15.3", null, null, null).ShouldBe(15.3f);
        }

        [Category("ConvertBack")]
        [Test]
        public void IntToStringConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(string)
            };
            converter.ConvertBack(13, null, null, null).ShouldBeOfType<string>();
            converter.ConvertBack(13, null, null, null).ShouldBe("13");
        }

        [Category("ConvertBack")]
        [Test]
        public void BoolToStringConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(string)
            };
            converter.ConvertBack(true, null, null, null).ShouldBeOfType<string>();
            converter.ConvertBack(true, null, null, null).ShouldBe("True");
            converter.ConvertBack(false, null, null, null).ShouldBeOfType<string>();
            converter.ConvertBack(false, null, null, null).ShouldBe("False");
        }

        [Category("ConvertBack")]
        [Test]
        public void IntToFloatConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(float)
            };
            converter.ConvertBack(13, null, null, null).ShouldBeOfType<float>();
            converter.ConvertBack(13, null, null, null).ShouldBe(13f);
        }

        [Category("ConvertBack")]
        [Test]
        public void FloatToIntConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(int)
            };
            converter.ConvertBack(13f, null, null, null).ShouldBeOfType<int>();
            converter.ConvertBack(13f, null, null, null).ShouldBe(13);
            converter.ConvertBack(15.3f, null, null, null).ShouldBeOfType<int>();
            converter.ConvertBack(15.3f, null, null, null).ShouldBe(15);
        }

        [Category("ConvertBack")]
        [Test]
        public void DecimalToFloatConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(float)
            };
            converter.ConvertBack(13m, null, null, null).ShouldBeOfType<float>();
            converter.ConvertBack(13m, null, null, null).ShouldBe(13f);
            converter.ConvertBack(15.3m, null, null, null).ShouldBeOfType<float>();
            converter.ConvertBack(15.3m, null, null, null).ShouldBe(15.3f);
        }

        [Category("ConvertBack")]
        [Test]
        public void FloatToDecimalConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(decimal)
            };
            converter.ConvertBack(13f, null, null, null).ShouldBeOfType<decimal>();
            converter.ConvertBack(13f, null, null, null).ShouldBe(13m);
            converter.ConvertBack(15.3f, null, null, null).ShouldBeOfType<decimal>();
            converter.ConvertBack(15.3f, null, null, null).ShouldBe(15.3m);
        }

        [Category("ConvertBack")]
        [Test]
        public void DecimalToIntConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(int)
            };
            converter.ConvertBack(13m, null, null, null).ShouldBeOfType<int>();
            converter.ConvertBack(13m, null, null, null).ShouldBe(13);
            converter.ConvertBack(15.3m, null, null, null).ShouldBeOfType<int>();
            converter.ConvertBack(15.3m, null, null, null).ShouldBe(15);
        }

        [Category("ConvertBack")]
        [Test]
        public void IntToDecimalConvertToTypeConvertBack()
        {
            ConvertToTypeConverter converter = new ConvertToTypeConverter()
            {
                ConvertBackToType = typeof(decimal)
            };
            converter.ConvertBack(13, null, null, null).ShouldBeOfType<decimal>();
            converter.ConvertBack(13, null, null, null).ShouldBe(13m);
        }
    }
}
