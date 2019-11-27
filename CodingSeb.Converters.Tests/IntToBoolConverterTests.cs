using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class IntToBoolConverterTests
    {
        [Test]
        public void DefaultValueDefaultValueIsFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter();

            for (int i = -100; i <= 100; i++)
            {
                ((bool)converter.Convert(i, null, null, null)).ShouldBeFalse();
            }
        }

        [Test]
        public void DefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false
            };
            for (int i = -100; i <= 100; i++)
            {
                ((bool)converter.Convert(i, null, null, null)).ShouldBeFalse();
            }
        }

        [Test]
        public void DefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true
            };
            for (int i = -100; i <= 100; i++)
            {
                ((bool)converter.Convert(i, null, null, null)).ShouldBeTrue();
            }
        }

        [Test]
        public void IntToFalseDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                FalseValue = 0,
                DefaultValue = true
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.FalseValue = i;

                ((bool)converter.Convert(i, null, null, null)).ShouldBeFalse();

                for (int j = -100; j <= 100; j++)
                {
                    if (i != j)
                    {
                        ((bool)converter.Convert(j, null, null, null)).ShouldBeTrue();
                    }
                }
            }
        }

        [Test]
        public void IntToTrueValueDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.TrueValue = i;

                ((bool)converter.Convert(i, null, null, null)).ShouldBeTrue();

                for (int j = -100; j <= 100; j++)
                {
                    if (i != j)
                    {
                        ((bool)converter.Convert(j, null, null, null)).ShouldBeFalse();
                    }
                }
            }
        }

        [Test]
        public void IntToSmallerThanFalseValueDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.SmallerThanFalseValue = i;

                for (int j = -100; j < i; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeFalse();
                }

                for (int j = i; j <= 100; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeTrue();
                }
            }
        }

        [Test]
        public void IntToSmallerThanTrueValueDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.SmallerThanTrueValue = i;

                for (int j = -100; j < i; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeTrue();
                }

                for (int j = i; j <= 100; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeFalse();
                }
            }
        }

        [Test]
        public void IntToBiggerThanFalseValueDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.BiggerThanFalseValue = i;

                for (int j = -100; j <= i; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeTrue();
                }

                for (int j = i + 1; j < 100; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeFalse();
                }
            }
        }

        [Test]
        public void IntToBiggerThanTrueValueDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false
            };
            for (int i = -100; i <= 100; i++)
            {
                converter.BiggerThanTrueValue = i;

                for (int j = -100; j <= i; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeFalse();
                }

                for (int j = i + 1; j < 100; j++)
                {
                    ((bool)converter.Convert(j, null, null, null)).ShouldBeTrue();
                }
            }
        }

        [Test]
        public void IntToCustomRulesSimpleValuesDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false,
                UseDefaultValueOnException = false,

                CustomRules = "True=32;False=10"
            };
            ((bool)converter.Convert(32, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-3, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void IntToCustomRulesSimpleValuesDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true,
                UseDefaultValueOnException = false,

                CustomRules = "True=32;False=10"
            };
            ((bool)converter.Convert(32, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(-3, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void IntToCustomRulesRangesDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false,
                UseDefaultValueOnException = false,

                CustomRules = "True=[5;10];False=[-2;2]"
            };
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(6, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(8, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(9, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeTrue();

            ((bool)converter.Convert(-2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(2, null, null, null)).ShouldBeFalse();

            ((bool)converter.Convert(-3, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-10, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(3, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(100, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void IntToCustomRulesRangesDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true,
                UseDefaultValueOnException = false,

                CustomRules = "True=[5;10];False=[-2;2]"
            };
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(6, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(8, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(9, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeTrue();

            ((bool)converter.Convert(-2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(2, null, null, null)).ShouldBeFalse();

            ((bool)converter.Convert(-3, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(-10, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(3, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(100, null, null, null)).ShouldBeTrue();
        }

        [Test]
        public void IntToCustomRulesDiscontinuousDefaultValueDefinedToFalse()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = false,
                UseDefaultValueOnException = false,

                CustomRules = "True={[5;10];50; 60;[100;]};False={[;-20];[-2;2];20}"
            };
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(6, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(8, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(9, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(50, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(60, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(100, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(101, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(102, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(103, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(110, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(150, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(200, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(1000, null, null, null)).ShouldBeTrue();

            ((bool)converter.Convert(-1000, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-100, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-25, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-21, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-20, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(20, null, null, null)).ShouldBeFalse();

            ((bool)converter.Convert(-50, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-30, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-3, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-10, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(3, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(40, null, null, null)).ShouldBeFalse();
        }

        [Test]
        public void IntToCustomRulesDiscontinuousDefaultValueDefinedToTrue()
        {
            IntToBoolConverter converter = new IntToBoolConverter()
            {
                DefaultValue = true,
                UseDefaultValueOnException = false,

                CustomRules = "True={[5;10];50; 60;[100;]};False={[;-20];[-2;2];20}"
            };
            ((bool)converter.Convert(5, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(6, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(7, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(8, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(9, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(10, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(50, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(60, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(100, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(101, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(102, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(103, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(110, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(150, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(200, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(1000, null, null, null)).ShouldBeTrue();

            ((bool)converter.Convert(-1000, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-100, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-25, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-21, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-20, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(-1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(0, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(1, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(2, null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert(20, null, null, null)).ShouldBeFalse();

            ((bool)converter.Convert(-10, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(-15, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(-3, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(3, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(15, null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert(40, null, null, null)).ShouldBeTrue();
        }
    }
}
