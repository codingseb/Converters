using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This MultiValueConverter Make a System.IO.Path.Combine() with all sub paths given as bindings
    /// </summary>
    public class PathCombineMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// if <c>true</c> the converter return a Uri in place of a string
        /// if <c>false</c> the converter return a string
        /// By default : false
        /// </summary>
        public bool AsUri { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
                return InDesigner;

            if (values.Any(v => v == Binding.DoNothing))
                return Binding.DoNothing;
            
            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return DependencyProperty.UnsetValue;

            string result = Path.Combine(values.Select(v => v.ToString()).ToArray());

            return AsUri ? (object)new Uri(result) : result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
