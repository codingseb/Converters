using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringJoinConverterTests
    {
        [Category("Convert")]
        [Test]
        public void StringJoinConvert()
        {
            StringJoinConverter converter = new StringJoinConverter();

            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test 12 True");
            converter.Separator = ",";
            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test,12,True");
            converter.Separator = "";
            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test12True");
        }

        [Category("ConvertBack")]
        [Test]
        public void StringJoinConvertBack()
        {
            StringJoinConverter converter = new StringJoinConverter();

            converter.ConvertBack("Test 12 True", null, null, null).ShouldBeOfType<string[]>();
            ((string[])converter.ConvertBack("Test 12 True", null, null, null))[0].ShouldBe("Test");
            ((string[])converter.ConvertBack("Test 12 True", null, null, null))[1].ShouldBe("12");
            ((string[])converter.ConvertBack("Test 12 True", null, null, null))[2].ShouldBe("True");
            converter.Separator = ",";
            converter.ConvertBack("Test,12,True", null, null, null).ShouldBeOfType<string[]>();
            ((string[])converter.ConvertBack("Test,12,True", null, null, null))[0].ShouldBe("Test");
            ((string[])converter.ConvertBack("Test,12,True", null, null, null))[1].ShouldBe("12");
            ((string[])converter.ConvertBack("Test,12,True", null, null, null))[2].ShouldBe("True");
            converter.Separator = "";
            converter.ConvertBack("Test,12,True", null, null, null).ShouldBeOfType<string[]>();
            ((string[])converter.ConvertBack("Test,12,True", null, null, null))[0].ShouldBe("Test,12,True");
        }
    }
}
