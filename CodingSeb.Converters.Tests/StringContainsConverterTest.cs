﻿using NUnit.Framework;
using Shouldly;
using System;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class StringContainsConverterTest
    {
        [Test]
        public void SimpleStringContainsConvert()
        {
            StringContainsConverter converter = new StringContainsConverter()
            {
                ContainsString = "Test"
            };
            ((bool)converter.Convert("Hello World !!!", null, null, null)).ShouldBeFalse();
            ((bool)converter.Convert("This is a Test !!!", null, null, null)).ShouldBeTrue();
            ((bool)converter.Convert("This is a test !!!", null, null, null)).ShouldBeFalse();

            converter.StringComparison = StringComparison.OrdinalIgnoreCase;

            ((bool)converter.Convert("This is a test !!!", null, null, null)).ShouldBeTrue();
        }
    }
}
