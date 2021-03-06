﻿using System.Collections.Generic;

namespace CodingSeb.Converters
{
    /// <summary>
    /// Contains a list of namespaces to add to and to remove from the sub ExpressionEvaluator of ExpressionEvalConverters
    /// </summary>
    internal static class NamespacesForExpressionEvalConverters
    {
        public static List<string> NamespaceToAdd { get; } = new List<string>()
        {
            "System.Windows",
            "System.Windows.Controls",
            "System.Windows.Media",
            "System.Windows.Shapes",
        };

        public static List<string> NamespaceToRemove { get; } = new List<string>()
        {
            "System.IO",
        };

        public static void NamespacesListForConverters(this List<string> list)
        {
            list.RemoveAll(ns => NamespaceToRemove.Contains(ns));
            list.AddRange(NamespaceToAdd);
        }
    }
}
