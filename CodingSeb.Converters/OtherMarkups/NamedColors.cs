﻿using System;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Use this Markup to have the list of named Colors
    /// </summary>
    public class NamedColors : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .ToList().ConvertAll(propertyInfo => new NamedColor(propertyInfo.Name, (Color)propertyInfo.GetValue(null)));
        }
    }
}
