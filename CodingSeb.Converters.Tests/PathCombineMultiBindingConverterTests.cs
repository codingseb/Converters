using Shouldly;

namespace CodingSeb.Converters.Tests
{
    public class PathCombineMultiBindingConverterTests
    {
        public void SimplePathCombineTest()
        {
            var converter = new PathCombineMultiBindingConverter();

            converter.Convert(new object[] { @"C:\MyDirectory", "SubFolder", "MyFile.txt" }, null, null, null).ShouldBe(@"C:\MyDirectory\SubFolder\MyFile.txt");
        }
    }
}
