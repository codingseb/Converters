using System;
using System.Windows.Markup;

namespace CodingSeb.Converters
{
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
