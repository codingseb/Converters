using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class CollectionCountOrArrayLengthConverterTests
    {
        [Test]
        public void CollectionCountOrArrayLengthConverter()
        {
            CollectionCountOrArrayLengthConverter converter = new CollectionCountOrArrayLengthConverter();

            converter.Convert(new object[] { 1, "Hello", true }, null, null, null).ShouldBe(3);
            converter.Convert(new int[] { 1, 2, 4, 5, 6, 1 }, null, null, null).ShouldBe(6);
            converter.Convert(new List<string>() { "Hello", "Bye" }, null, null, null).ShouldBe(2);
            converter.Convert(new ObservableCollection<string>() { "Hello", "Bye" }, null, null, null).ShouldBe(2);
        }
    }
}
