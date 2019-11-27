using System;
using System.Linq;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter return the nbr of element in a collection or an array
    /// </summary>
    public class CollectionCountOrArrayLengthConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Array)
            {
                return ((Array)value).Length;
            }
            else if (value is ICollection)
            {
                return ((ICollection)value).Count;
            }
            else if (value is IEnumerable)
            {
                return ((IEnumerable)value).Cast<dynamic>().ToList().Count;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
