using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// <para>
    /// Convert the int binding value to bool using the converter parameters to defines the rules of the conversion.
    /// Order of the rules tests
    /// <list type="bullet">
    ///     <item>If binding is FalseValue return false</item>
    ///     <item>If binding is TrueValue return true</item>
    ///     <item>If binding is smaller than SmallerThanFalseValue return false</item>
    ///     <item>If binding is smaller than SmallerThanTrueValue return true</item>
    ///     <item>If binding is bigger than BiggerThanFalseValue return false</item>
    ///     <item>If binding is bigger than BiggerThanTrueValue return true</item>
    ///     <item>Use the CustomRules to try to determine the value.</item>
    ///     <item>If nothing of the above is use return DefaultValue</item>
    /// </list>
    /// </para>
    /// <para>
    /// CustomRules use the following syntax "True=ValuesDefinition;False=ValuesDefinition" (CaseInsensitive)
    /// ValuesDefinition can be :
    /// <list type="bullet" >
    ///     <item>A simple integer like True=10 or False=-20</item>
    ///     <item>A Range [BiggerThan; SmallerThan] like True=[-5;5] true or True=[-5;] or False=[,5]</item>
    ///     <item>Discontinuous values and/or ranges {value1; value2; range1, value3, range2 ...} like True={-2; 3; 10; 50} or False={[-5;-2]; 0; 3; [10; 20]}</item>
    /// </list>
    /// </para>
    /// </summary>
    public class IntToBoolConverter : BaseConverter, IValueConverter
    {
        public int? InDesigner { get; set; }

        /// <summary>
        /// If matched return false
        /// </summary>
        public int? FalseValue { get; set; }

        /// <summary>
        /// If matched return true
        /// </summary>
        public int? TrueValue { get; set; }

        /// <summary>
        /// If is smaller than return false
        /// </summary>
        public int? SmallerThanFalseValue { get; set; }

        /// <summary>
        /// If is smaller than return true
        /// </summary>
        public int? SmallerThanTrueValue { get; set; }

        /// <summary>
        /// If is bigger than return false
        /// </summary>
        public int? BiggerThanFalseValue { get; set; }

        /// <summary>
        /// If is bigger than return true
        /// </summary>
        public int? BiggerThanTrueValue { get; set; }

        /// <summary>
        /// To define complex rules to dermine the boolean value
        /// CustomRules use the following syntax "True=ValuesDefinition;False=ValuesDefinition" (CaseInsensitive)
        /// ValuesDefinition can be :
        /// <list type="bullet" >
        ///     <item>A simple integer like True=10 or False=-20</item>
        ///     <item>A Range [BiggerThanOrEquals; SmallerThanOrEquals] like True=[-5;5] true or True=[-5;] or False=[,5]</item>
        ///     <item>Discontinuous values and/or ranges {value1; value2; range1, value3, range2 ...} like True={-2; 3; 10; 50} or False={[-5;-2]; 0; 3; [10; 20]}</item>
        /// </list>
        /// </summary>
        public string CustomRules { get; set; }

        private CustomRulesTester rulesTester;

        /// <summary>
        /// If no other rule match or is defined the DefaultValue is returned (default value of DefaultValue = false)
        /// </summary>
        public bool DefaultValue { get; set; }

        /// <summary>
        /// if true in case of an exception (example the binding value is not an int) the DefaultValue is returned, if false the exception is thrown. (default value is True)
        /// </summary>
        public bool UseDefaultValueOnException { get; set; } = true;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null)
                {
                    return InDesigner;
                }
                else if (FalseValue != null && (int)value == FalseValue)
                {
                    return false;
                }
                else if (TrueValue != null && (int)value == TrueValue)
                {
                    return true;
                }
                else if (SmallerThanFalseValue != null && (int)value < SmallerThanFalseValue)
                {
                    return false;
                }
                else if (SmallerThanTrueValue != null && (int)value < SmallerThanTrueValue)
                {
                    return true;
                }
                else if (BiggerThanFalseValue != null && (int)value > BiggerThanFalseValue)
                {
                    return false;
                }
                else if (BiggerThanTrueValue != null && (int)value > BiggerThanTrueValue)
                {
                    return true;
                }
                else if (CustomRules != null)
                {
                    if (rulesTester == null)
                    {
                        rulesTester = new CustomRulesTester(CustomRules);
                    }

                    return rulesTester.Convert((int)value) ?? DefaultValue;
                }
                else
                {
                    return DefaultValue;
                }
            }
            catch (CustomRuleSyntaxException)
            {
                throw;
            }
            catch when (UseDefaultValueOnException)
            {
                return DefaultValue;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueValue : FalseValue;
        }
    }

    public class CustomRuleSyntaxException : Exception
    {
        public CustomRuleSyntaxException(string message) : base(message)
        {
        }

        public CustomRuleSyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    internal class CustomRulesTester
    {
        private readonly Regex trueAndFalseSplitterRegex = new Regex(@"(?<bool>true|false)[=](?<definitions>(([^;\r\n]|[;](?!t|f)))*)", RegexOptions.IgnoreCase);
        private readonly Regex discontinuousRegex = new Regex(@"^[{](?<values>(\s*([-]?\d+|\[\s*[-]?\d*\s*[;]\s*[-]?\d*\s*\])\s*)([;](\s*([-]?\d+|\[\s*[-]?\d*\s*[;]\s*[-]?\d*\s*\])\s*))*)[}]$");
        private readonly Regex discontinuousValues = new Regex(@"(?<=(^|[;])\s*)(\[[^\]]+\]|[-]?\d+)(?=\s*[;]|$)");
        private readonly Regex rangesRegex = new Regex(@"^\[\s*(?<biggerThan>[-]?\d+)?\s*[;]\s*(?<smallerThan>[-]?\d+)?\s*\]$");

        private readonly List<ICustomRule> customRules = new List<ICustomRule>();

        public CustomRulesTester(string customRule)
        {
            trueAndFalseSplitterRegex.Matches(customRule).Cast<Match>().ToList()
                .ForEach(match =>
                {
                    bool bValue = match.Groups["bool"].Value.Equals("true", StringComparison.OrdinalIgnoreCase);

                    string definitions = match.Groups["definitions"].Value.Trim();

                    if (!(DefineDisontinuous(definitions, bValue) || DefineRange(definitions, bValue) || DefineSimple(definitions, bValue)))
                    {
                        throw new CustomRuleSyntaxException($"There is a problem in the syntax of CustomRules \"{customRule}\".");
                    }
                });
        }

        private bool DefineDisontinuous(string definitions, bool boolValue)
        {
            Match discontinuousMatch = discontinuousRegex.Match(definitions);

            if (discontinuousMatch.Success && discontinuousMatch.Groups["values"].Success)
            {
                MatchCollection matches = discontinuousValues.Matches(discontinuousMatch.Groups["values"].Value.Trim());

                for (int i = 0; i < matches.Count; i++)
                {
                    if (!(DefineRange(matches[i].Value.Trim(), boolValue) || DefineSimple(matches[i].Value.Trim(), boolValue)))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DefineRange(string definition, bool boolValue)
        {
            Match rangeMatch = rangesRegex.Match(definition);

            if (rangeMatch.Success)
            {
                Group biggerThanGroup = rangeMatch.Groups["biggerThan"];
                Group smallerThanGroup = rangeMatch.Groups["smallerThan"];

                if (biggerThanGroup.Success || smallerThanGroup.Success)
                {
                    int? biggerThan = null;
                    int? smallerThan = null;

                    if (biggerThanGroup.Success)
                    {
                        biggerThan = int.Parse(biggerThanGroup.Value);
                    }

                    if (smallerThanGroup.Success)
                    {
                        smallerThan = int.Parse(smallerThanGroup.Value);
                    }

                    customRules.Add(new RangeIntValueToBoolRule(biggerThan, smallerThan, boolValue));

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool DefineSimple(string definition, bool boolValue)
        {
            if (int.TryParse(definition, out int value))
            {
                customRules.Add(new SimpleIntValueToBoolRule(value, boolValue));

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? Convert(int intValue)
        {
            bool? result = null;

            for (int i = 0; i < customRules.Count; i++)
            {
                if (customRules[i].IsRuleOKFor(intValue))
                {
                    result = customRules[i].ResultIfOk;
                    break;
                }
            }

            return result;
        }
    }

    internal interface ICustomRule
    {
        bool IsRuleOKFor(int valueToTest);
        bool ResultIfOk { get; set; }
    }

    internal class SimpleIntValueToBoolRule : ICustomRule
    {
        public bool ResultIfOk { get; set; }

        public int SimpleValue { get; set; }

        public SimpleIntValueToBoolRule(int iValue, bool bValue)
        {
            ResultIfOk = bValue;
            SimpleValue = iValue;
        }

        public bool IsRuleOKFor(int valueToTest)
        {
            return valueToTest == SimpleValue;
        }
    }

    internal class RangeIntValueToBoolRule : ICustomRule
    {
        public RangeIntValueToBoolRule(int? biggerThan, int? smallerThan, bool bValue)
        {
            ResultIfOk = bValue;
            BiggerThan = biggerThan;
            SmallerThan = smallerThan;
        }

        public bool ResultIfOk { get; set; }

        public int? BiggerThan { get; set; }

        public int? SmallerThan { get; set; }

        public bool IsRuleOKFor(int valueToTest)
        {
            return (!BiggerThan.HasValue || valueToTest >= BiggerThan.Value) && (!SmallerThan.HasValue || valueToTest <= SmallerThan);
        }
    }
}
