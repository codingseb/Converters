using NUnit.Framework;
using Shouldly;
using System.Windows;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ChainingMultiBindingConverterTests
    {
        [Category("Convert")]
        [Test]
        public void ChainMultiValuesWithConverter2Converter()
        {
            ChainingMultiBindingConverter masterConverter = new ChainingMultiBindingConverter();

            ExpressionEvalMultiBindingConverter expressionEvalMultiBindingConverter = new ExpressionEvalMultiBindingConverter()
            {
                Expression = "bindings[0] && bindings[1]"
            };
            masterConverter.MultiValueConverter1 = expressionEvalMultiBindingConverter;
            masterConverter.Converter2 = new ReverseBoolConverter();

            ((bool)masterConverter.Convert(new object[] { true, true }, null, null, null)).ShouldBeFalse();
            ((bool)masterConverter.Convert(new object[] { true, false }, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.Convert(new object[] { false, true }, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.Convert(new object[] { false, false }, null, null, null)).ShouldBeTrue();
        }

        [Category("Convert")]
        [Test]
        public void ChainMultiValuesWithConvertersListConverter()
        {
            ChainingMultiBindingConverter masterConverter = new ChainingMultiBindingConverter();

            StringFormatMultiBindingConverter stringFormatMultiBindingConverter = new StringFormatMultiBindingConverter();
            ExpressionEvalConverter expressionEvalConverter = new ExpressionEvalConverter()
            {
                EvaluateBindingAsAnExpression = true,
                OptionCaseSensitiveEvaluationActive = false
            };
            stringFormatMultiBindingConverter.Format = "{0} && {1}";

            masterConverter.MultiValueConverter1 = stringFormatMultiBindingConverter;
            masterConverter.Converters.Add(expressionEvalConverter);
            masterConverter.Converters.Add(new ReverseBoolConverter());

            ((bool)masterConverter.Convert(new object[] { true, true }, null, null, null)).ShouldBeFalse();
            ((bool)masterConverter.Convert(new object[] { true, false }, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.Convert(new object[] { false, true }, null, null, null)).ShouldBeTrue();
            ((bool)masterConverter.Convert(new object[] { false, false }, null, null, null)).ShouldBeTrue();
        }
    }
}
