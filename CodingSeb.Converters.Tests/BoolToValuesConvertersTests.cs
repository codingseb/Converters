using NUnit.Framework;
using Shouldly;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CodingSeb.Converters.Tests
{
    #region Classes utilitaires pour les tests

    public class ClassToTestBoolToObjectConverter1
    {
        public string Attribute1 { get; set; } = "att1";

        public override bool Equals(object obj)
        {
            return obj is ClassToTestBoolToObjectConverter1 classToTestBoolToObjectConverter1 && Attribute1.Equals((classToTestBoolToObjectConverter1).Attribute1);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Attribute1.GetHashCode();
        }
    }

    public class ClassToTestBoolToObjectConverter2
    {
        public int Attribute2 { get; set; } = 2;

        public override bool Equals(object obj)
        {
            return obj is ClassToTestBoolToObjectConverter2 classToTestBoolToObjectConverter2 && Attribute2.Equals((classToTestBoolToObjectConverter2).Attribute2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Attribute2.GetHashCode();
        }
    }

    public class ClassToTestBoolToObjectConverter3
    {
        public bool Attribute3 { get; set; } = true;

        public override bool Equals(object obj)
        {
            return obj is ClassToTestBoolToObjectConverter3 classToTestBoolToObjectConverter3 && Attribute3.Equals((classToTestBoolToObjectConverter3).Attribute3);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Attribute3.GetHashCode();
        }
    }

    #endregion

    [TestFixture]
    public class BoolToValueConvertersTests
    {
        #region Tests BoolToStringConverter

        #region Tests ConvertMethod

        [Test]
        [Category("ToStringConverter")]
        [Category("Convert")]
        public void BoolToStringConverter_ConvertTrue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            converter.Convert(true, null, null, null).ShouldBe("Yes");
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("Convert")]
        public void BoolToStringConverter_ConvertFalse()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            converter.Convert(false, null, null, null).ShouldBe("No");
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("Convert")]
        public void BoolToStringConverter_ConvertNull_DefaultOnNullValue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("Convert")]
        public void BoolToStringConverter_ConvertNull_WithOnNullValueFalse()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnNullValue = "No"
            };
            converter.Convert(null, null, null, null).ShouldBe("No");
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("Convert")]
        public void BoolToStringConverter_ConvertNull_WithOnNullValueTrue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnNullValue = "Yes"
            };
            converter.Convert(null, null, null, null).ShouldBe("Yes");
        }

        #endregion

        #region Test ConvertBack

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromTrueValue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            ((bool)converter.ConvertBack("Yes", null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromFalseValue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            ((bool)converter.ConvertBack("No", null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromNullValue_DefaultOnNullValue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromNullValue_WithOnNullValueFalse()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnReverseNullValue = false
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromNullValue_WithOnNullValueTrue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnReverseNullValue = true
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromOtherValue_DefaultOnOtherValue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No"
            };
            ((bool)converter.ConvertBack("Hello", null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromOtherValue_WithOnOtherValueFalse()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnReverseOtherValue = false
            };
            ((bool)converter.ConvertBack("Hello", null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToStringConverter")]
        [Category("ConvertBack")]
        public void BoolToStringConverter_ConvertBackFromOtherValue_WithOnOtherValueTrue()
        {
            BoolToStringConverter converter = new BoolToStringConverter()
            {
                TrueValue = "Yes",
                FalseValue = "No",
                OnReverseOtherValue = true
            };
            ((bool)converter.ConvertBack("Hello", null, null, null)).ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Tests BoolToBrushConverter

        #region Tests ConvertMethod

        [Test]
        [Category("ToBrushConverter")]
        [Category("Convert")]
        public void BoolToBrushConverter_ConvertTrue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            converter.Convert(true, null, null, null).ShouldBe(Brushes.Green);
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("Convert")]
        public void BoolToBrushConverter_ConvertFalse()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            converter.Convert(false, null, null, null).ShouldBe(Brushes.Red);
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("Convert")]
        public void BoolToBrushConverter_ConvertNull_DefaultOnNullValue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("Convert")]
        public void BoolToBrushConverter_ConvertNull_WithOnNullValueFalse()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnNullValue = Brushes.Red
            };
            converter.Convert(null, null, null, null).ShouldBe(Brushes.Red);
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("Convert")]
        public void BoolToBrushConverter_ConvertNull_WithOnNullValueTrue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnNullValue = Brushes.Green
            };
            converter.Convert(null, null, null, null).ShouldBe(Brushes.Green);
        }

        #endregion

        #region Test ConvertBack

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromTrueValue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            ((bool)converter.ConvertBack(Brushes.Green, null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromFalseValue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            ((bool)converter.ConvertBack(Brushes.Red, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromNullValue_DefaultOnNullValue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromNullValue_WithOnNullValueFalse()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnReverseNullValue = false
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromNullValue_WithOnNullValueTrue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnReverseNullValue = true
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromOtherValue_DefaultOnOtherValue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red
            };
            ((bool)converter.ConvertBack(Brushes.Gray, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromOtherValue_WithOnOtherValueFalse()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnReverseOtherValue = false
            };
            ((bool)converter.ConvertBack(Brushes.Gray, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBrushConverter")]
        [Category("ConvertBack")]
        public void BoolToBrushConverter_ConvertBackFromOtherValue_WithOnOtherValueTrue()
        {
            BoolToBrushConverter converter = new BoolToBrushConverter()
            {
                TrueValue = Brushes.Green,
                FalseValue = Brushes.Red,
                OnReverseOtherValue = true
            };
            ((bool)converter.ConvertBack(Brushes.Gray, null, null, null)).ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Tests BoolToBitmapImageConverter

        #region Tests ConvertMethod

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("Convert")]
        public void BoolToBitmapImageConverter_ConvertTrue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((BitmapImage)converter.Convert(true, null, null, null)).IsEqual(Resources._true.ToBitmapImage()).ShouldBeTrue();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("Convert")]
        public void BoolToBitmapImageConverter_ConvertFalse()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((BitmapImage)converter.Convert(false, null, null, null)).IsEqual(Resources._false.ToBitmapImage());
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("Convert")]
        public void BoolToBitmapImageConverter_ConvertNull_DefaultOnNullValue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((BitmapImage)converter.Convert(null, null, null, null)).IsEqual(Resources._false.ToBitmapImage()).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("Convert")]
        public void BoolToBitmapImageConverter_ConvertNull_WithOnNullValueFalse()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnReverseNullValue = false
            };
            ((BitmapImage)converter.Convert(null, null, null, null)).IsEqual(Resources._false.ToBitmapImage()).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("Convert")]
        public void BoolToBitmapImageConverter_ConvertNull_WithOnNullValueTrue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnNullValue = Resources._true.ToBitmapImage()
            };
            ((BitmapImage)converter.Convert(null, null, null, null)).IsEqual(Resources._true.ToBitmapImage()).ShouldBeTrue();
        }

        #endregion

        #region Test ConvertBack

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromTrueValue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((bool)converter.ConvertBack(Resources._true.ToBitmapImage(), null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromFalseValue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((bool)converter.ConvertBack(Resources._false.ToBitmapImage(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromNullValue_DefaultOnNullValue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromNullValue_WithOnNullValueFalse()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnReverseNullValue = false
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromNullValue_WithOnNullValueTrue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnReverseNullValue = true
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromOtherValue_DefaultOnOtherValue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage()
            };
            ((bool)converter.ConvertBack(Resources.other.ToBitmapImage(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromOtherValue_WithOnOtherValueFalse()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnReverseOtherValue = false
            };
            ((bool)converter.ConvertBack(Resources.other.ToBitmapImage(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToBitmapImageConverter")]
        [Category("ConvertBack")]
        public void BoolToBitmapImageConverter_ConvertBackFromOtherValue_WithOnOtherValueTrue()
        {
            BoolToBitmapImageConverter converter = new BoolToBitmapImageConverter()
            {
                TrueValue = Resources._true.ToBitmapImage(),
                FalseValue = Resources._false.ToBitmapImage(),
                OnReverseOtherValue = true
            };
            ((bool)converter.ConvertBack(Resources.other.ToBitmapImage(), null, null, null)).ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Tests BoolToObjectConverter

        #region Tests ConvertMethod

        [Test]
        [Category("ToObjectConverter")]
        [Category("Convert")]
        public void BoolToObjectConverter_ConvertTrue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            converter.Convert(true, null, null, null).ShouldBe(new ClassToTestBoolToObjectConverter1());
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("Convert")]
        public void BoolToObjectConverter_ConvertFalse()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            converter.Convert(false, null, null, null).ShouldBe(new ClassToTestBoolToObjectConverter2());
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("Convert")]
        public void BoolToObjectConverter_ConvertNull_DefaultOnNullValue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            converter.Convert(null, null, null, null).ShouldBeNull();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("Convert")]
        public void BoolToObjectConverter_ConvertNull_WithOnNullValueFalse()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnNullValue = new ClassToTestBoolToObjectConverter2(),
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<ClassToTestBoolToObjectConverter2>();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("Convert")]
        public void BoolToObjectConverter_ConvertNull_WithOnNullValueTrue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnNullValue = new ClassToTestBoolToObjectConverter1()
            };
            converter.Convert(null, null, null, null).ShouldBeOfType<ClassToTestBoolToObjectConverter1>();
        }

        #endregion

        #region Test ConvertBack

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromTrueValue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            ((bool)converter.ConvertBack(new ClassToTestBoolToObjectConverter1(), null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromFalseValue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            ((bool)converter.ConvertBack(new ClassToTestBoolToObjectConverter2(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromNullValue_DefaultOnNullValue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromNullValue_WithOnNullValueFalse()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnReverseNullValue = false
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromNullValue_WithOnNullValueTrue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnReverseNullValue = true
            };
            ((bool)converter.ConvertBack(null, null, null, null)).ShouldBeTrue();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromOtherValue_DefaultOnOtherValue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2()
            };
            ((bool)converter.ConvertBack(new ClassToTestBoolToObjectConverter3(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromOtherValue_WithOnOtherValueFalse()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnReverseOtherValue = false
            };
            ((bool)converter.ConvertBack(new ClassToTestBoolToObjectConverter3(), null, null, null)).ShouldBeFalse();
        }

        [Test]
        [Category("ToObjectConverter")]
        [Category("ConvertBack")]
        public void BoolToObjectConverter_ConvertBackFromOtherValue_WithOnOtherValueTrue()
        {
            BoolToObjectConverter converter = new BoolToObjectConverter()
            {
                TrueValue = new ClassToTestBoolToObjectConverter1(),
                FalseValue = new ClassToTestBoolToObjectConverter2(),
                OnReverseOtherValue = true
            };
            ((bool)converter.ConvertBack(new ClassToTestBoolToObjectConverter3(), null, null, null)).ShouldBeTrue();
        }

        #endregion

        #endregion
    }
}
