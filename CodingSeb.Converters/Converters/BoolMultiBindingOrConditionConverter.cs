using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiValueConverter Make a logic OR (||) between multiple bool values
    /// </summary>
    public class BoolMultiBindingOrConditionConverter : BaseConverter, IMultiValueConverter
    {
        public bool? InDesigner { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
                return InDesigner;

            if (values.Any(v => v == Binding.DoNothing))
                return Binding.DoNothing;

            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return DependencyProperty.UnsetValue;

            return values.ToList().Any(e => bool.TryParse(e.ToString(), out bool result) && result);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
