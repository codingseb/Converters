using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    internal class StringReplaceConverterTests
    {
        [Category("Convert")]
        [Test]
        public void StringReplaceConvert()
        {
            StringReplaceConverter converter = new StringReplaceConverter();

            converter.Convert("23 asl Hello World 29", null, null, null).ShouldBe("23 asl Hello World 29");

            converter.OldString = "Hello";
            converter.Convert("23 asl Hello World 29", null, null, null).ShouldBe("23 asl  World 29");

            converter.NewString = "Test";
            converter.Convert("23 asl Hello World 29", null, null, null).ShouldBe("23 asl Test World 29");
        }

        [Category("ConvertBack")]
        [Test]
        public void StringReplaceConvertBackReturnStringAsThis()
        {
            StringReplaceConverter converter = new StringReplaceConverter();

            converter.ConvertBack("23 asl Test World 29", null, null, null).ShouldBe("23 asl Test World 29");

            converter.NewString = "Test";
            converter.ConvertBack("23 asl Test World 29", null, null, null).ShouldBe("23 asl  World 29");

            converter.OldString = "Hello";
            converter.ConvertBack("23 asl Test World 29", null, null, null).ShouldBe("23 asl Hello World 29");
        }
    }
}
