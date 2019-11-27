using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Cette classe est un converter générique de boolean en valeur de votre choix
    /// Pour un type de valeur spécifique héritez de cette classe
    /// si une valeur est null retourne TrueValue si OnNullValue est true retourne FalseValue si OnNullValue est false
    /// </summary>
    /// <typeparam name="T">Type des valeurs FalseValue et TrueValue</typeparam>
    public class BoolToValuesGenericConverter<T> : BaseConverter, IValueConverter
    {
        public T InDesigner { get; set; }

        /// <summary>
        /// The Value when it's DependencyProperty.UnsetValue
        /// </summary>
        public T OnUnsetValue { get; set; }

        /// <summary>
        /// The Value when value is null
        /// </summary>
        public T OnNullValue { get; set; }

        /// <summary>
        /// La valeur à laquelle convertir false
        /// </summary>
        public T FalseValue { get; set; }

        /// <summary>
        /// La valeur à laquelle convertir false 
        /// </summary>
        public T TrueValue { get; set; }

        /// <summary>
        /// Obtient la valeur boolean correspondant à la valeur null par défaut false
        /// </summary>
        [DefaultValue(false)]
        public virtual bool OnReverseNullValue { get; set; }

        /// <summary>
        /// Obtient la valeur boolean correspondant à une valeur qui ne serait ni FalseValue ni TrueValue ni null
        /// </summary>
        [DefaultValue(false)]
        public virtual bool OnReverseOtherValue { get; set; }

        #region IValueConverter Membres

        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = OnReverseNullValue;

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;
            else if (value == null) return OnNullValue;
            else if (value == DependencyProperty.UnsetValue) return OnUnsetValue;

            if (value != null)
                bValue = (bool)value;

            return bValue ? TrueValue : FalseValue;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = OnReverseNullValue;

            if (value != null)
            {
                if (value.Equals(TrueValue))
                    result = true;
                else if (value.Equals(FalseValue))
                    result = false;
                else
                    result = OnReverseOtherValue;
            }

            return result;
        }

        #endregion
    }

    public class BoolToStringConverter : BoolToValuesGenericConverter<String> { }
    public class BoolToBrushConverter : BoolToValuesGenericConverter<Brush> { }
    public class BoolToObjectConverter : BoolToValuesGenericConverter<Object> { }

    /// <summary>
    /// To Show 2 differents static resources BitmapImage in case corresponding to a true or false value
    /// </summary>
    public class BoolToBitmapImageConverter : BoolToValuesGenericConverter<BitmapImage>
    {
        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = OnReverseNullValue;

            if (value != null)
            {
                if (value is BitmapImage && ((BitmapImage)value).IsEqual(TrueValue))
                    result = true;
                else if (value is BitmapImage && ((BitmapImage)value).IsEqual(FalseValue))
                    result = false;
                else
                    result = OnReverseOtherValue;
            }

            return result;
        }
    }
}
