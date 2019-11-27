using NUnit.Framework;
using Shouldly;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class TypeCheckingConverterTests
    {
        [Test]
        public void DefaultTypeCheckingConverterConditionTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A)
            };

            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.Is
            };

            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsNotTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsNot
            };

            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(false);
        }

        [Test]
        public void InheritFromTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.InheritFrom
            };

            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(true);
        }

        [Test]
        public void InheritNotFromTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.InheritNotFrom
            };

            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(false);
        }

        [Test]
        public void IsAParentTypeOfTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsAParentTypeOf
            };

            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(true);
            converter.Convert(new B(), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsNotAParentTypeOfTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsNotAParentTypeOf
            };

            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(new A(), null, null, null).ShouldBe(false);
            converter.Convert(new B(), null, null, null).ShouldBe(false);
        }

        [Test]
        public void IsATypeDefaultTypeCheckingConverterConditionTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A)
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsATypeIsTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.Is
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsAtypeIsNotTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsNot
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);
        }

        [Test]
        public void IsATypeInheritFromTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.InheritFrom
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsATypeInheritNotFromTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.InheritNotFrom
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);
        }

        [Test]
        public void IsATypeIsAParentTypeOfTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsAParentTypeOf
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(true);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);
        }

        [Test]
        public void IsATypeIsNotAParentTypeOfTypeCheck()
        {
            TypeCheckingConverter converter = new TypeCheckingConverter
            {
                IsAType = true,
                TypeToCheck = typeof(A),
                TypeCheckingConverterCondition = TypeCheckingConverterCondition.IsNotAParentTypeOf
            };

            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(true);

            converter.TypeToCheck = typeof(B);
            converter.Convert(typeof(A), null, null, null).ShouldBe(false);
            converter.Convert(typeof(B), null, null, null).ShouldBe(false);
        }
    }
}
