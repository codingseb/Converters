using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringNullOrEmptyToDefaultValueConverterTests
    {
        [Category("Convert")]
        [Test]
        public void NullStringToDefaultTextSettedByProperty()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter()
            {
                DefaultValue = "Not set"
            };
            converter.Convert(null, typeof(string), null, null).ShouldBe("Not set");
        }

        [Category("Convert")]
        [Test]
        public void EmptyStringToDefaultTextSettedByProperty()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter()
            {
                DefaultValue = "Not set"
            };
            converter.Convert("", typeof(string), null, null).ShouldBe("Not set");
        }

        [Category("Convert")]
        [Test]
        public void NormalStringUnchangedSettedByProperty()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter()
            {
                DefaultValue = "Not set"
            };
            converter.Convert("Test string", typeof(string), null, null).ShouldBe("Test string");
        }

        [Category("Convert")]
        [Test]
        public void NullStringToDefaultTextSettedByParameter()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter();

            converter.Convert(null, typeof(string), "Not set", null).ShouldBe("Not set");
        }

        [Category("Convert")]
        [Test]
        public void EmptyStringToDefaultTextSettedByParameter()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter();

            converter.Convert("", typeof(string), "Not set", null).ShouldBe("Not set");
        }

        [Category("Convert")]
        [Test]
        public void NormalStringUnchangedSettedByParameter()
        {
            StringNullOrEmptyToDefaultValueConverter converter = new StringNullOrEmptyToDefaultValueConverter();

            converter.Convert("Test string", typeof(string), "Not set", null).ShouldBe("Test string");
        }
    }
}
