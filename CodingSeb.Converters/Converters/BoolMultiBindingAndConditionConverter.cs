using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiValueConverter Make a logic AND (&&) between multiple bool values
    /// </summary>
    public class BoolMultiBindingAndConditionConverter : BaseConverter, IMultiValueConverter
    {
        public bool? InDesigner { get; set; }

        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
                return InDesigner.Value;

            if (values.Any(v => v == Binding.DoNothing))
                return Binding.DoNothing;

            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return DependencyProperty.UnsetValue;

            return values.ToList().All(e => bool.TryParse(e.ToString(), out bool result) && result);
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
