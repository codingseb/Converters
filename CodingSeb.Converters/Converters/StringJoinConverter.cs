using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This converter make a string.Join on a collection of object (Array, list...) into a string with the optional specified separator between each source objects. By default the Separator is considered as a a space character.
    /// </summary>
    public class StringJoinConverter : BaseConverter, IValueConverter
    {
        public StringJoinConverter()
        { }

        public StringJoinConverter(string separator)
        {
            Separator = separator;
        }

        /// <summary>
        /// This separator is added between each source object in the target string
        /// By Default : a space character
        /// </summary>
        [ConstructorArgument("separator")]
        public string Separator { get; set; } = " ";

        /// <summary>
        /// Allow to specify an expression that will be evaluated on each element of the enumerable before joining the result
        /// </summary>
        public string SelectExpression { get; set; }

        /// <summary>
        /// What to Show when it is null,
        /// By default string.Empty
        /// </summary>
        public string ValueForNull { get; set; } = string.Empty;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable enumerable)
            {
                if(!string.IsNullOrEmpty(SelectExpression))
                {
                    var evaluator = new ExpressionEvaluator.ExpressionEvaluator();
                    enumerable = enumerable.Cast<object>().Select(x =>
                    {
                        evaluator.Context = x;
                        return evaluator.Evaluate(SelectExpression);
                    });
                }

                return string.Join(Separator.EscapeForXaml(), enumerable.Cast<object>().Select(x => x ?? ValueForNull).ToArray());
            }
            else
            {
                object simpleValue = value;

                if(!string.IsNullOrEmpty(SelectExpression))
                {
                    var evaluator = new ExpressionEvaluator.ExpressionEvaluator()
                    {
                        Context = simpleValue,
                    };

                    return evaluator.Evaluate(SelectExpression)?.ToString() ?? ValueForNull;
                }

                return simpleValue?.ToString() ?? ValueForNull;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(new string[] { Separator.EscapeForXaml() }, StringSplitOptions.None);
        }
    }
}
