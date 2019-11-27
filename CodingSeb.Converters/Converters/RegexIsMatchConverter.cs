﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// This Converter Return a boolean reflecting the Regex.IsMatch of the defined pattern
    /// Only usable from source to target. (OneWay)
    /// </summary>
    [ContentProperty("Pattern")]
    public class RegexIsMatchConverter : BaseConverter, IValueConverter
    {
        public string InDesigner { get; set; }

        /// <summary>
        /// The Regex pattern to find
        /// </summary>
        public string Pattern { get; set; } = "";

        /// <summary>
        /// Options of the regex
        /// By Default : RegexOptions.None
        /// </summary>
        public RegexOptions Options { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) && InDesigner != null) return InDesigner;
            else
                return Regex.IsMatch(value.ToString(), Pattern.EscapeForXaml(), Options);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
