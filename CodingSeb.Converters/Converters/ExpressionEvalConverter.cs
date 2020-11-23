using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Converter that use a string mathematical or pseudo C# expression to make the conversion.
    /// Use <c>binding</c> to inject the binding value in the expression (example <c>Abs(binding) + 1</c>)
    /// </summary>
    [ContentProperty(nameof(Expression))]
    public class ExpressionEvalConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// To specify a list of namespaces separated by the ; character to add as usings for the evaluator
        /// </summary>
        public string NamespacesToAdd { get; set; } = string.Empty;

        /// <summary>
        /// The expression to evaluate to make the conversion. Use <c>binding</c> to inject the binding value in the expression. By default just <c>binding</c>
        /// </summary>
        public string Expression { get; set; } = "binding";

        /// <summary>
        /// The expression to evaluate to make the back conversion. Use <c>binding</c> to inject the binding value in the expression. By default just <c>binding</c>
        /// </summary>
        public string ExpressionForConvertBack { get; set; } = "binding";

        /// <summary>
        /// If <c>true</c> evaluate a string binding as an expression, if false just inject the binding in the Expression, By default : <c>false</c>
        /// </summary>
        public bool EvaluateBindingAsAnExpression { get; set; }

        /// <summary>
        /// If <c>true</c> evaluate a string binding as an expression, if <c>false</c> just inject the binding in the ExpressionForConvertBack, By default : <c>false</c>
        /// </summary>
        public bool EvaluateBindingAsAnExpressionForConvertBack { get; set; }

        /// <summary>
        /// If <c>true</c> Evaluate function is callables in an expression. If <c>false</c> Evaluate is not callable.
        /// By default : false for security
        /// </summary>
        public bool OptionEvaluateFunctionActive { get; set; }

        /// <summary>
        /// if true all evaluation are case sensitives, if false evaluations are case insensitive.
        /// By default = true
        /// </summary>
        public bool OptionCaseSensitiveEvaluationActive { get; set; } = true;

        /// <summary>
        /// If <c>true</c> throw up all evaluate exceptions, if <c>false</c> just return the exception message as a string, By default <c>false</c>
        /// </summary>
        public bool ThrowExceptions { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, object> variables = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            try
            {
                var evaluator = new ExpressionEvaluator.ExpressionEvaluator()
                {
                    OptionCaseSensitiveEvaluationActive = OptionCaseSensitiveEvaluationActive
                };

                evaluator.Namespaces.ToList().NamespacesListForConverters();

                NamespacesToAdd.Split(';').ToList().ForEach(namespaceName =>
                {
                    if (!string.IsNullOrWhiteSpace(namespaceName))
                    {
                        evaluator.Namespaces.Add(namespaceName);
                    }
                });

                evaluator.OptionEvaluateFunctionActive = OptionEvaluateFunctionActive;

                if (EvaluateBindingAsAnExpression)
                {
                    variables["binding"] = evaluator.Evaluate(value.ToString().EscapeForXaml());
                }
                else
                {
                    variables["binding"] = value;
                }

                evaluator.Variables = variables;

                return evaluator.Evaluate((parameter is string pExpression ? pExpression : Expression).EscapeForXaml());
            }
            catch (Exception ex) when (!ThrowExceptions)
            {
                return ex.Message;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, object> variables = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            try
            {
                var evaluator = new ExpressionEvaluator.ExpressionEvaluator()
                {
                    OptionCaseSensitiveEvaluationActive = OptionCaseSensitiveEvaluationActive
                };

                evaluator.Namespaces.ToList().NamespacesListForConverters();

                evaluator.OptionEvaluateFunctionActive = OptionEvaluateFunctionActive;

                if (EvaluateBindingAsAnExpressionForConvertBack)
                {
                    variables["binding"] = evaluator.Evaluate(value.ToString().EscapeForXaml());
                }
                else
                {
                    variables["binding"] = value;
                }

                evaluator.Variables = variables;

                return evaluator.Evaluate(ExpressionForConvertBack.EscapeForXaml());
            }
            catch (Exception ex) when (!ThrowExceptions)
            {
                return ex.Message;
            }
        }
    }
}
