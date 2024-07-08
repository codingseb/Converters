using System;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    /// <summary>
    /// The base class for all converters of this lib
    /// To implement Markup extension
    /// </summary>
    public abstract class BaseConverter : MarkupExtension
    {
        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
