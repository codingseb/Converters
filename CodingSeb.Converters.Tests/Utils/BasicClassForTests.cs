namespace CodingSeb.Converters.Tests
{
    internal class BasicClassForTests
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; } = "Test";
    }

    internal class A
    {
        public int IntProperty { get; set; }
    }

    internal class B : A
    {
        public string StringProperty { get; set; } = "Hye";
    }
}
