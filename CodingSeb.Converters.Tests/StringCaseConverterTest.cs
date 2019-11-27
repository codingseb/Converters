using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringCaseConverterTest
    {
        [Category("Convert")]
        [Test]
        public void ConvertDefaultValueReturnStringAsThis()
        {
            StringCaseConverter converter = new StringCaseConverter();

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToNormalCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.Normal);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToNormalCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.Normal
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToLowerCaseCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.lowercase);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("hello this is a test");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToLowerCaseCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.lowercase
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("hello this is a test");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToUpperCaseCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.UPPERCASE);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HELLO THIS IS A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToUpperCaseCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.UPPERCASE
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HELLO THIS IS A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToSetFirstLetterUpperCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.Firstletterupper);

            converter.Convert("helLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToSetFirstLetterUpperCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.Firstletterupper
            };
            converter.Convert("helLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToSetFirstLetterLowerCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.firstLetterLower);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("helLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToSetFirstLetterLowerCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.firstLetterLower
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("helLo This is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToFirstLetterOfEachWordUpperCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.FirstLetterOfEachWordUpper);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This Is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToFirstLetterOfEachWordUpperCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.FirstLetterOfEachWordUpper
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This Is A TEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToFirstLetterOfEachWordLowerCasingModeSetByConstructor()
        {
            StringCaseConverter converter = new StringCaseConverter(StringCasingMode.firstletterofeachwordlower);

            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("helLo this is a tEST");
        }

        [Category("Convert")]
        [Test]
        public void ConvertToFirstLetterOfEachWordLowerCasingModeSetByProperty()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.firstletterofeachwordlower
            };
            converter.Convert("HelLo This is A TEST", null, null, null).ShouldBe("helLo this is a tEST");
        }

        [Category("ConvertBack")]
        [Test]
        public void ConvertBackStringAsThis()
        {
            StringCaseConverter converter = new StringCaseConverter()
            {
                CasingMode = StringCasingMode.Normal
            };
            converter.ConvertBack("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");

            converter.CasingMode = StringCasingMode.lowercase;
            converter.ConvertBack("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");

            converter.CasingMode = StringCasingMode.UPPERCASE;
            converter.ConvertBack("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");

            converter.CasingMode = StringCasingMode.firstLetterLower;
            converter.ConvertBack("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");

            converter.CasingMode = StringCasingMode.Firstletterupper;
            converter.ConvertBack("HelLo This is A TEST", null, null, null).ShouldBe("HelLo This is A TEST");
        }
    }
}
