using System.Windows.Media;

namespace CodingSeb.Converters
{
    public class NamedColor
    {
        public string Name { get; private set; }

        public Color Color { get; private set; }

        public NamedColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
