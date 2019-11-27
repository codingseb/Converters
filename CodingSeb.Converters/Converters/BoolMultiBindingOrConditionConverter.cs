using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    public class BoolMultiBindingOrConditionConverter : BaseConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToList().Any(e => bool.TryParse(e.ToString(), out bool result) && result);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
