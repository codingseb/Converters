using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ExpressionEvalMultiBindingConverterTests
    {
        [Test]
        public void SimpleMultiBindingExpressionEval()
        {
            ExpressionEvalMultiBindingConverter converter = new ExpressionEvalMultiBindingConverter();

            ((object[])converter.Convert(new object[] { 5, 3, "test", 4.3f }, null, null, null)).Length.ShouldBe(4);

            converter.Expression = "bindings[0] + bindings[1]";

            converter.Convert(new object[] { 5, 3 }, null, null, null).ShouldBe(8);
        }
    }
}
