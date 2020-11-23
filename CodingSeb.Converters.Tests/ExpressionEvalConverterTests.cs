using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class ExpressionEvalConverterTests
    {
        [Test]
        public void BooleanValuesExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "true"
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(null, null, null, null)).ShouldBeTrue();
            converter.Expression = "false";
            converter.Convert(null, null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void NullExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "null"
            };
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        public void NumbersIntFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45"
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<int>();
            converter.Expression = "-63";
            converter.Convert(null, null, null, null).ShouldBeOfType<int>();
        }

        [Test]
        public void NumbersDoubleFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "123.54"
            };

            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "-146.678";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "123.54e-12";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "-146.678e-12";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "45d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "-63d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "123.54d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "-146.678d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "123.54e-12d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
            converter.Expression = "-146.678e-12d";
            converter.Convert(null, null, null, null).ShouldBeOfType<double>();
        }

        [Test]
        public void NumbersFloatFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45f"
            };

            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
            converter.Expression = "-63f";
            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
            converter.Expression = "123.54f";
            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
            converter.Expression = "-146.678f";
            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
            converter.Expression = "123.54e-12f";
            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
            converter.Expression = "-146.678e-12f";
            converter.Convert(null, null, null, null).ShouldBeOfType<float>();
        }

        [Test]
        public void NumbersUIntFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45u"
            };

            converter.Expression = "45u";
            converter.Convert(null, null, null, null).ShouldBeOfType<uint>();
            converter.Expression = "123.54e6u";
            converter.Convert(null, null, null, null).ShouldBeOfType<uint>();
        }

        [Test]
        public void NumbersLongFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45l"
            };

            converter.Convert(null, null, null, null).ShouldBeOfType<long>();
            converter.Expression = "-63l";
            converter.Convert(null, null, null, null).ShouldBeOfType<long>();
            converter.Expression = "123.54e6l";
            converter.Convert(null, null, null, null).ShouldBeOfType<long>();
            converter.Expression = "-146.678e6l";
            converter.Convert(null, null, null, null).ShouldBeOfType<long>();
        }

        [Test]
        public void NumbersULongFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45ul"
            };

            converter.Convert(null, null, null, null).ShouldBeOfType<ulong>();
            converter.Expression = "123.54e6ul";
            converter.Convert(null, null, null, null).ShouldBeOfType<ulong>();
        }

        [Test]
        public void NumbersDecimalFormatsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "45m"
            };

            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
            converter.Expression = "-63m";
            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
            converter.Expression = "123.54m";
            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
            converter.Expression = "-146.678m";
            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
            converter.Expression = "123.54e-12m";
            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
            converter.Expression = "-146.678e-12m";
            converter.Convert(null, null, null, null).ShouldBeOfType<decimal>();
        }

        [Test]
        public void StringExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "\"Hello World\""
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello World");

            converter.Expression = "\"Hello\" + \"World\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("HelloWorld");
        }

        [Test]
        public void StringEscapedExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = $@"{'"'}\\\n{'"'}"
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("\\\n");

            converter.Expression = $@"@{'"'}\\n{'"'}";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe(@"\\n");
        }

        [Test]
        public void StringInterpolationExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "$\"Hello {1 + 2}\""
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello 3");

            converter.Expression = "$\"Test { binding } Test\"";
            converter.Convert(10, null, null, null).ShouldBeOfType<string>();
            converter.Convert(10, null, null, null).ShouldBe("Test 10 Test");

            converter.Expression = "$\"Test { binding + \" Test\" } Test\"";
            converter.Convert(10, null, null, null).ShouldBeOfType<string>();
            converter.Convert(10, null, null, null).ShouldBe("Test 10 Test Test");

            converter.Expression = "$\"Test { binding + \" Test{\" } Test\"";
            converter.Convert(10, null, null, null).ShouldBeOfType<string>();
            converter.Convert(10, null, null, null).ShouldBe("Test 10 Test{ Test");

            converter.Expression = "$\"Test { binding + \" Test{{ }\" } Test\"";
            converter.Convert(10, null, null, null).ShouldBeOfType<string>();
            converter.Convert(10, null, null, null).ShouldBe("Test 10 Test{{ } Test");
        }

        [Test]
        public void StringInterpolatedInCascadeExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "$\"Hello { $\"TS\"}\""
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello TS");

            converter.Expression = "$\"Hello { $\"T{{S\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T{S");

            converter.Expression = "$\"Hello { $\"T}}S\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T}S");

            converter.Expression = "$\"Hello { $\"T{1 + 2}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + \"S\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S{ 2 + 2 }\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S4");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S{ 2 + 2 } Test\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S4 Test");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S{ 2 + \" Test\" }\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S2 Test");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S{ 2 + $\" Test\" }\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S2 Test");

            converter.Expression = "$\"Hello { $\"T{1 + 2 + $\"S{ 2 + $\" Test{ 2 + 2 }\" }\"}\"}\"";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Hello T3S2 Test4");
        }

        [Test]
        public void StringWithParenthisBetweenParenthisExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "\"Hello\" + (\"Test\" + \"(\")"
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("HelloTest(");

            converter.Expression = "\"Hello\" + (\"Test\" + \")\")";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("HelloTest)");
        }

        [Test]
        public void StringWithParenthisOrComaInFunctionsArgsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "\"Hello\" + (\"Test\" + $\"{ Abs(int.Parse(\"-4\"))}\")"
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("HelloTest4");

            converter.Expression = "\"Text()\".Replace(\"(\", \"x\")";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Textx)");

            converter.Expression = "\"Text()\".Replace(\"x\", \",\")";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Te,t()");

            converter.Expression = "\"Text()\".Replace(\"(\", \",\")";
            converter.Convert(null, null, null, null).ShouldBeOfType<string>();
            converter.Convert(null, null, null, null).ShouldBe("Text,)");
        }

        [Test]
        public void StringWithSquareBracketInIndexing()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true
            };
            Dictionary<string, string> binding = new Dictionary<string, string>()
            {
                { "Test[", "Test1" },
                { "Test]", "Test2" },
                { "Test[]", "Test3" },
            };

            converter.Expression = "binding[\"Test[\"]";
            converter.Convert(binding, null, null, null).ShouldBe("Test1");

            converter.Expression = "binding[\"Test]\"]";
            converter.Convert(binding, null, null, null).ShouldBe("Test2");

            converter.Expression = "binding[\"Test[]\"]";
            converter.Convert(binding, null, null, null).ShouldBe("Test3");
        }

        [Test]
        public void SimpleAddExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding + 1"
            };
            converter.Convert(-60, null, null, null).ShouldBe(-59);
            converter.Convert(-1, null, null, null).ShouldBe(0);
            converter.Convert(1, null, null, null).ShouldBe(2);
            converter.Convert(3, null, null, null).ShouldBe(4);
            converter.Convert(10, null, null, null).ShouldBe(11);

            converter.Expression = "binding + 30";

            converter.Convert(-60, null, null, null).ShouldBe(-30);
            converter.Convert(-1, null, null, null).ShouldBe(29);
            converter.Convert(1, null, null, null).ShouldBe(31);
            converter.Convert(3, null, null, null).ShouldBe(33);
            converter.Convert(10, null, null, null).ShouldBe(40);

            converter.Expression = "binding + -10";

            converter.Convert(-60, null, null, null).ShouldBe(-70);
            converter.Convert(-1, null, null, null).ShouldBe(-11);
            converter.Convert(1, null, null, null).ShouldBe(-9);
            converter.Convert(3, null, null, null).ShouldBe(-7);
            converter.Convert(10, null, null, null).ShouldBe(0);
            converter.Convert(20, null, null, null).ShouldBe(10);
            converter.Convert(100, null, null, null).ShouldBe(90);
        }

        [Test]
        public void SimpleMinusExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding - 1"
            };
            converter.Convert(-60, null, null, null).ShouldBe(-61);
            converter.Convert(-1, null, null, null).ShouldBe(-2);
            converter.Convert(1, null, null, null).ShouldBe(0);
            converter.Convert(3, null, null, null).ShouldBe(2);
            converter.Convert(10, null, null, null).ShouldBe(9);

            converter.Expression = "binding - 30";

            converter.Convert(-60, null, null, null).ShouldBe(-90);
            converter.Convert(-1, null, null, null).ShouldBe(-31);
            converter.Convert(1, null, null, null).ShouldBe(-29);
            converter.Convert(100, null, null, null).ShouldBe(70);
            converter.Convert(40, null, null, null).ShouldBe(10);

            converter.Expression = "binding - -10";

            converter.Convert(-60, null, null, null).ShouldBe(-50);
            converter.Convert(-1, null, null, null).ShouldBe(9);
            converter.Convert(1, null, null, null).ShouldBe(11);
            converter.Convert(3, null, null, null).ShouldBe(13);
            converter.Convert(10, null, null, null).ShouldBe(20);
        }

        [Test]
        public void SimpleMultiplyExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding * 1"
            };
            converter.Convert(-60, null, null, null).ShouldBe(-60);
            converter.Convert(-1, null, null, null).ShouldBe(-1);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(1, null, null, null).ShouldBe(1);
            converter.Convert(10, null, null, null).ShouldBe(10);

            converter.Expression = "binding * 10";

            converter.Convert(-60, null, null, null).ShouldBe(-600);
            converter.Convert(-1, null, null, null).ShouldBe(-10);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(5.5, null, null, null).ShouldBe((double)55);
            converter.Convert(10, null, null, null).ShouldBe(100);

            converter.Expression = "binding * -10";

            converter.Convert(-60, null, null, null).ShouldBe(600);
            converter.Convert(-1, null, null, null).ShouldBe(10);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(1, null, null, null).ShouldBe(-10);
            converter.Convert(10, null, null, null).ShouldBe(-100);
            converter.Convert(5.5, null, null, null).ShouldBe((double)-55);
            converter.Convert(-6.12, null, null, null).ShouldBe(61.2);
        }

        [Test]
        public void SimpleDivideExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding / 1"
            };
            converter.Convert(-60, null, null, null).ShouldBe(-60);
            converter.Convert(-1, null, null, null).ShouldBe(-1);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(1, null, null, null).ShouldBe(1);
            converter.Convert(10, null, null, null).ShouldBe(10);

            converter.Expression = "binding / 10";

            converter.Convert(-60, null, null, null).ShouldBe(-6);
            converter.Convert(-1d, null, null, null).ShouldBe(-0.1);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(55d, null, null, null).ShouldBe(5.5);
            converter.Convert(10, null, null, null).ShouldBe(1);

            converter.Expression = "binding / -10";

            converter.Convert(-60, null, null, null).ShouldBe(6);
            converter.Convert(-1d, null, null, null).ShouldBe(0.1);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(10, null, null, null).ShouldBe(-1);
            converter.Convert(5.5, null, null, null).ShouldBe(-0.55);
        }

        [Test]
        public void DivAndMultiplyPriorityOverSubAndAddExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding - 10 / 2"
            };
            converter.Convert(5, null, null, null).ShouldBe(0);

            converter.Expression = "binding + 10 / 2";

            converter.Convert(5, null, null, null).ShouldBe(10);

            converter.Expression = "binding - 10 * 2";

            converter.Convert(5, null, null, null).ShouldBe(-15);

            converter.Expression = "binding + 10 * 2";

            converter.Convert(5, null, null, null).ShouldBe(25);
        }

        [Test]
        public void ParenthesisExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "(binding - 10) / 2"
            };
            converter.Convert(5d, null, null, null).ShouldBe(-2.5);

            converter.Expression = "(binding + 10) / 2";

            converter.Convert(5d, null, null, null).ShouldBe(7.5);

            converter.Expression = "(binding - 10) * 2";

            converter.Convert(5, null, null, null).ShouldBe(-10);

            converter.Expression = "(binding + 10) * 2";

            converter.Convert(5, null, null, null).ShouldBe(30);

            converter.Expression = "binding - (10 / 2)";

            converter.Convert(5, null, null, null).ShouldBe(0);

            converter.Expression = "binding + (10 / 2)";

            converter.Convert(5, null, null, null).ShouldBe(10);

            converter.Expression = "binding - (10 * 2)";

            converter.Convert(5, null, null, null).ShouldBe(-15);

            converter.Expression = "binding + (10 * 2)";

            converter.Convert(5, null, null, null).ShouldBe(25);
        }

        [Test]
        public void ModuloExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding % 2"
            };
            converter.Convert(-4, null, null, null).ShouldBe(0);
            converter.Convert(-3, null, null, null).ShouldBe(-1);
            converter.Convert(-2, null, null, null).ShouldBe(0);
            converter.Convert(-1, null, null, null).ShouldBe(-1);
            converter.Convert(0, null, null, null).ShouldBe(0);
            converter.Convert(1, null, null, null).ShouldBe(1);
            converter.Convert(2, null, null, null).ShouldBe(0);
            converter.Convert(3, null, null, null).ShouldBe(1);
            converter.Convert(4, null, null, null).ShouldBe(0);
            converter.Convert(5, null, null, null).ShouldBe(1);
            converter.Convert(6, null, null, null).ShouldBe(0);
            converter.Convert(7, null, null, null).ShouldBe(1);
            converter.Convert(8, null, null, null).ShouldBe(0);
        }

        [Test]
        public void LowerBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding < 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void GreaterBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding > 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void LowerOrEqualBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding <= 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void GreaterOrEqualBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding >= 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void IsOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding is string"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert("Test", null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(true, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void EqualBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding == 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void NotEqualBooleanOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding != 5"
            };
            ((bool)converter.Convert(1, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(5, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void NullCoalescingOperatorExpresionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding ?? \"Option2\""
            };
            ((string)converter.Convert("Option1", null, null, null)).ShouldBe("Option1");
            ((string)converter.Convert(null, null, null, null)).ShouldBe("Option2");

            converter.Expression = "\"Option1\" ?? \"Option2\"";
            ((string)converter.Convert(null, null, null, null)).ShouldBe("Option1");

            converter.Expression = "null ?? \"Option2\"";
            ((string)converter.Convert(null, null, null, null)).ShouldBe("Option2");
        }

        [Test]
        public void LogicalAndOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding & 8"
            };
            converter.Convert(2, null, null, null).ShouldBe(0);
            converter.Convert(10, null, null, null).ShouldBe(8);
        }

        [Test]
        public void LogicalXorOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding ^ 8"
            };
            converter.Convert(2, null, null, null).ShouldBe(10);
            converter.Convert(10, null, null, null).ShouldBe(2);
        }

        [Test]
        public void LogicalOrOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding | 8"
            };
            converter.Convert(2, null, null, null).ShouldBe(10);
            converter.Convert(10, null, null, null).ShouldBe(10);
        }

        [Test]
        public void BooleanAndOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding && true"
            };
            ((bool)converter.Convert(true, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeFalse();
            converter.Expression = "binding && false";
            ((bool)converter.Convert(true, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void BooleanOrOperatorExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding || true"
            };
            ((bool)converter.Convert(true, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeTrue();
            converter.Expression = "binding || false";
            ((bool)converter.Convert(true, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void BooleanLogicalNegationExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "!binding"
            };
            ((bool)converter.Convert(true, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void ShiftBitsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding << 2"
            };
            converter.Convert(1, null, null, null).ShouldBe(4);
            converter.Convert(2, null, null, null).ShouldBe(8);

            converter.Expression = "binding >> 2";
            converter.Convert(4, null, null, null).ShouldBe(1);
            converter.Convert(8, null, null, null).ShouldBe(2);
        }

        [Test]
        public void MathConstExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,
                OptionCaseSensitiveEvaluationActive = false,
                Expression = "pi"
            };
            converter.Convert(0, null, null, null).ShouldBeOfType<double>();
            converter.Convert(0, null, null, null).ToString().ShouldBe(Math.PI.ToString());

            converter.Expression = "e";

            converter.Convert(0, null, null, null).ShouldBeOfType<double>();
            converter.Convert(0, null, null, null).ToString().ShouldBe(Math.E.ToString());

            converter.Expression = "binding + PI";

            converter.Convert(1, null, null, null).ShouldBeOfType<double>();
            converter.Convert(1, null, null, null).ToString().ShouldStartWith("4.14159");
        }

        [Test]
        public void AbsFuncExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "Abs(binding)"
            };

            converter.Convert(-50, null, null, null).ShouldBe(50d);
            converter.Convert(-19, null, null, null).ShouldBe(19d);
            converter.Convert(-3.5, null, null, null).ShouldBe(3.5);
            converter.Convert(-1, null, null, null).ShouldBe(1d);
            converter.Convert(0, null, null, null).ShouldBe(0d);
            converter.Convert(1, null, null, null).ShouldBe(1d);
            converter.Convert(4.2, null, null, null).ShouldBe(4.2);
            converter.Convert(10, null, null, null).ShouldBe(10d);
            converter.Convert(60, null, null, null).ShouldBe(60d);

            converter.Expression = "binding + Abs(binding)";

            converter.Convert(-30, null, null, null).ShouldBe(0d);
            converter.Convert(-5.5, null, null, null).ShouldBe(0d);
            converter.Convert(-1, null, null, null).ShouldBe(0d);
            converter.Convert(0, null, null, null).ShouldBe(0d);
            converter.Convert(1, null, null, null).ShouldBe(2d);
            converter.Convert(5, null, null, null).ShouldBe(10d);
            converter.Convert(2.5, null, null, null).ShouldBe(5d);

            converter.Expression = "Abs(binding - 5)";

            converter.Convert(-10, null, null, null).ShouldBe(15d);
            converter.Convert(-5, null, null, null).ShouldBe(10d);
            converter.Convert(-2, null, null, null).ShouldBe(7d);
            converter.Convert(0, null, null, null).ShouldBe(5d);
            converter.Convert(2, null, null, null).ShouldBe(3d);
            converter.Convert(5, null, null, null).ShouldBe(0d);
            converter.Convert(6, null, null, null).ShouldBe(1d);
            converter.Convert(10, null, null, null).ShouldBe(5d);
        }

        [Test]
        public void MaxFuncExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "Max(binding, 2)"
            };
            converter.Convert(-2, null, null, null).ShouldBe(2d);
            converter.Convert(0, null, null, null).ShouldBe(2d);
            converter.Convert(1, null, null, null).ShouldBe(2d);
            converter.Convert(2, null, null, null).ShouldBe(2d);
            converter.Convert(3, null, null, null).ShouldBe(3d);

            converter.Expression = "Max(binding, 2, 4, 6)";

            converter.Convert(-7, null, null, null).ShouldBe(6d);
            converter.Convert(-6, null, null, null).ShouldBe(6d);
            converter.Convert(0, null, null, null).ShouldBe(6d);
            converter.Convert(4, null, null, null).ShouldBe(6d);
            converter.Convert(6, null, null, null).ShouldBe(6d);
            converter.Convert(7, null, null, null).ShouldBe(7d);
            converter.Convert(100, null, null, null).ShouldBe(100d);
        }

        [Test]
        public void InstancePropertyExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding.Length"
            };
            converter.Convert("Test", null, null, null).ShouldBe(4);
            converter.Convert("Test Test", null, null, null).ShouldBe(9);
        }

        [Test]
        public void InstancePropertyWithNullConditionalExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding?.Length"
            };
            converter.Convert("Test", null, null, null).ShouldBe(4);
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        public void InstanceMethodExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding.ToLower()"
            };
            converter.Convert("TEST", null, null, null).ShouldBe("test");

            converter.Expression = "binding.Replace(\"TEST\", \"Hello World\")";
            converter.Convert("TEST", null, null, null).ShouldBe("Hello World");
        }

        [Test]
        public void InstanceMethodWithNullConditionalExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding?.ToLower()"
            };
            converter.Convert("TEST", null, null, null).ShouldBe("test");
            converter.Convert(null, null, null, null).ShouldBeNull();

            converter.Expression = "binding?.Replace(\"TEST\", \"Hello World\")";
            converter.Convert("TEST", null, null, null).ShouldBe("Hello World");
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        public void StaticMethodExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "Math.Abs(binding)"
            };
            converter.Convert(-2, null, null, null).ShouldBe(2);

            converter.Expression = "Enumerable.Repeat(3,6).Cast().ToList().Count";
            converter.Convert(null, null, null, null).ShouldBe(6);

            converter.Expression = "Enumerable.Repeat(3,6).Cast().ToList()[binding]";
            converter.Convert(0, null, null, null).ShouldBe(3);
            converter.Convert(1, null, null, null).ShouldBe(3);
            converter.Convert(2, null, null, null).ShouldBe(3);
            converter.Convert(3, null, null, null).ShouldBe(3);
            converter.Convert(4, null, null, null).ShouldBe(3);
            converter.Convert(5, null, null, null).ShouldBe(3);

            converter.Expression = "string.IsNullOrEmpty(binding)";
            converter.Convert(null, null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(null, null, null, null)).ShouldBeTrue();
            converter.Convert("", null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("", null, null, null)).ShouldBeTrue();
            converter.Convert("hello", null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert("hello", null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void TypeObjectsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding.GetType().Name"
            };

            converter.Convert("Hello", null, null, null).ShouldBe("String");
            converter.Convert(3, null, null, null).ShouldBe("Int32");
            converter.Convert(new object[] { 2, "Hello" }, null, null, null).ShouldBe("Object[]");

            converter.Expression = "binding.GetType().ToString()";

            converter.Convert("Hello", null, null, null).ShouldBe("System.String");
            converter.Convert(3, null, null, null).ShouldBe("System.Int32");
            converter.Convert(new object[] { 2, "Hello" }, null, null, null).ShouldBe("System.Object[]");
        }

        [Test]
        public void CastingExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "(float)binding"
            };
            converter.Convert(13, null, null, null).ShouldBeOfType(typeof(float));
            converter.Convert(5.3, null, null, null).ShouldBeOfType(typeof(float));

            converter.Expression = "(decimal)binding";

            converter.Convert(13, null, null, null).ShouldBeOfType(typeof(decimal));
            converter.Convert(5.3, null, null, null).ShouldBeOfType(typeof(decimal));

            converter.Expression = "(int)binding";

            converter.Convert(13, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(5.3, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(5.3, null, null, null).ShouldBe(5);
            converter.Convert(true, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(true, null, null, null).ShouldBe(1);
            converter.Convert(false, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(false, null, null, null).ShouldBe(0);

            converter.Expression = "(bool)binding";

            converter.Convert(1, null, null, null).ShouldBeOfType(typeof(bool));
            converter.Convert(1, null, null, null).ShouldBe(true);
            converter.Convert(0, null, null, null).ShouldBeOfType(typeof(bool));
            converter.Convert(0, null, null, null).ShouldBe(false);
        }

        [Test]
        public void IndexingExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding[1]"
            };
            converter.Convert(new int[] { 3, 5, 2, 4 }, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(new int[] { 3, 5, 2, 4 }, null, null, null).ShouldBe(5);

            converter.Convert("Test", null, null, null).ShouldBe('e');

            converter.Expression = "binding[\"test\"]";

            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "hello", "world" },
                { "test", 5 },
                { "World", "Hello" }
            };

            converter.Convert(dict, null, null, null).ShouldBe(5);

            converter.Expression = "Array(1, 5, 3 ,7)[1]";

            converter.Convert(null, null, null, null).ShouldBe(5);
        }

        [Test]
        public void IndexingAndSubProperty()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding[1].IntProperty"
            };

            converter.Convert(new BasicClassForTests[] { new BasicClassForTests(), new BasicClassForTests() { IntProperty = 18 } }, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(new BasicClassForTests[] { new BasicClassForTests(), new BasicClassForTests() { IntProperty = 18 } }, null, null, null).ShouldBe(18);

            converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding[1].StringProperty.Replace(\"e\", \"a\").Equals(\"Tast\")"
            };

            converter.Convert(new BasicClassForTests[] { new BasicClassForTests(), new BasicClassForTests() { IntProperty = 18 } }, null, null, null).ShouldBeOfType(typeof(bool));
            ((bool)converter.Convert(new BasicClassForTests[] { new BasicClassForTests(), new BasicClassForTests() { IntProperty = 18 } }, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void IndexingWithNullConditionalExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "binding?[1]"
            };
            converter.Convert(new int[] { 3, 5, 2, 4 }, null, null, null).ShouldBeOfType(typeof(int));
            converter.Convert(new int[] { 3, 5, 2, 4 }, null, null, null).ShouldBe(5);
            converter.Convert("Test", null, null, null).ShouldBe('e');
            converter.Convert(null, null, null, null).ShouldBeNull();

            converter.Expression = "binding?[\"test\"]";

            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "hello", "world" },
                { "test", 5 },
                { "World", "Hello" }
            };

            converter.Convert(dict, null, null, null).ShouldBe(5);
            converter.Convert(null, null, null, null).ShouldBeNull();

            converter.Expression = "Array(1, 5, 3 ,7)?[1]";
            converter.Convert(null, null, null, null).ShouldBe(5);
            converter.Expression = "null?[1]";
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        public void LambdaExpressionDirectInvocationExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "(x => x + 1)(binding)"
            };
            converter.Convert(2, null, null, null).ShouldBe(3);

            converter.Expression = "((x, y) => x * y)(binding, 2)";
            converter.Convert(2, null, null, null).ShouldBe(4);

            converter.Expression = "(() => binding + 1)()";
            converter.Convert(2, null, null, null).ShouldBe(3);
        }

        [Test]
        public void LambdaExpressionAsPredicateExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "List(\"Hello\", \"Test\", \"Bye\", \"World !\").Find(x => x.Length == 3)"
            };
            converter.Convert(null, null, null, null).ShouldBe("Bye");

            converter.Expression = "List(\"Hello\", \"Test\", \"Bye\", \"World !\").Find(x => x.Length == binding)";
            converter.Convert(3, null, null, null).ShouldBe("Bye");
            converter.Convert(5, null, null, null).ShouldBe("Hello");
        }

        [Test]
        public void LambdaAsConverterExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "(List(1,2,3,4,5,6).ConvertAll(x => (float)x)[2]).GetType()"
            };
            converter.Convert(null, null, null, null).ShouldBe(typeof(float));
        }

        [Test]
        public void LambdaInLinqFuncBoolMethodsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "List(\"Hello\", \"Test\", \"Bye\", \"World !\").First(x => x.Length == 3)"
            };
            converter.Convert(null, null, null, null).ShouldBe("Bye");
        }

        [Test]
        public void MoreComplexLinqFuncExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "List(1,2,3,3,4,5).Where(x => x < binding).Count()"
            };
            converter.Convert(3, null, null, null).ShouldBe(2);
            converter.Convert(4, null, null, null).ShouldBe(4);
            converter.Convert(5, null, null, null).ShouldBe(5);

            converter.Expression = "List(1,2,3,3,4,5).Distinct().Where(x => x < binding).Count()";
            converter.Convert(3, null, null, null).ShouldBe(2);
            converter.Convert(4, null, null, null).ShouldBe(3);
            converter.Convert(5, null, null, null).ShouldBe(4);

            converter.Expression = "Enumerable.Range(binding,4).Cast().Sum(x =>(int)x)";
            converter.Convert(1, null, null, null).ShouldBe(10);
            converter.Convert(2, null, null, null).ShouldBe(14);
            converter.Convert(3, null, null, null).ShouldBe(18);
        }

        [Test]
        public void FluidFunctionsWithVoidFunctionsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "List(\"hello\", \"bye\").Select(x => x.ToUpper()).ToList().FluidAdd(\"test\").Count"
            };
            converter.Convert(null, null, null, null).ShouldBe(3);
            converter.Expression = "List(\"hello\", \"bye\").Select(x => x.ToUpper()).ToList().FluidAdd(\"test\")[binding]";
            converter.Convert(0, null, null, null).ShouldBe("HELLO");
            converter.Convert(1, null, null, null).ShouldBe("BYE");
            converter.Convert(2, null, null, null).ShouldBe("test");
            converter.Expression = "List(\"hello\", \"bye\").Select(x => x.ToUpper()).ToList().FluentAdd(\"test\").Count";
            converter.Convert(null, null, null, null).ShouldBe(3);
            converter.Expression = "List(\"hello\", \"bye\").Select(x => x.ToUpper()).ToList().FluentAdd(\"test\")[binding]";
            converter.Convert(0, null, null, null).ShouldBe("HELLO");
            converter.Convert(1, null, null, null).ShouldBe("BYE");
            converter.Convert(2, null, null, null).ShouldBe("test");
        }

        [Test]
        public void MoreComplexCalcsExpressionEval()
        {
            ExpressionEvalConverter converter = new ExpressionEvalConverter()
            {
                ThrowExceptions = true,

                Expression = "3 + (2 * (5-3-(Abs(-5)-6)))"
            };
            converter.Convert(1, null, null, null).ShouldBe(9d);

            converter.Expression = "!(!binding || false)";

            converter.Convert(false, null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeFalse();

            converter.Expression = "!(!binding || false) || !(!true && true)";

            converter.Convert(false, null, null, null).ShouldBeOfType<bool>();
            ((bool)converter.Convert(false, null, null, null)).ShouldBeTrue();
        }
    }
}
