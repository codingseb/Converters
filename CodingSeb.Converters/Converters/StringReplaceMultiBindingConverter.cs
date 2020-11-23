using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter Make a string Replace based on multibinding.
    /// The First binding is the input string, the second binding is the oldString, the third binding is optional and is the newString (if not defined, considered as an empty string).
    /// </summary>
    public class StringReplaceMultiBindingConverter : BaseConverter, IMultiValueConverter
    {
        public string InDesigner { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
            {
                return InDesigner;
            }
            else if (values.Length < 2 || values[1].ToString().Equals(string.Empty))
            {
                return values[0];
            }
            else
            {
                return values[0].ToString().Replace(values[1].ToString(), values.Length >= 3 ? values[2].ToString() : string.Empty);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
