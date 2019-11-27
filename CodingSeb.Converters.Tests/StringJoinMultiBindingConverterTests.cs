using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringJoinMultiBindingConverterTests
    {
        [Category("Convert")]
        [Test]
        public void MultiBinding_StringJoinConvert()
        {
            StringJoinMultiBindingConverter converter = new StringJoinMultiBindingConverter();

            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test 12 True");
            converter.Separator = ",";
            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test,12,True");
            converter.Separator = "";
            converter.Convert(new object[] { "Test", 12, true }, null, null, null).ShouldBe("Test12True");
        }

        [Category("ConvertBack")]
        [Test]
        public void MultiBinding_StringJoinConvertBack()
        {
            StringJoinMultiBindingConverter converter = new StringJoinMultiBindingConverter();

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
