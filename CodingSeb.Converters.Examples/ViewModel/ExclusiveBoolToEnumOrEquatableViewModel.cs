using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace CodingSeb.Converters.Examples
{
    public class ExclusiveBoolToEnumOrEquatableViewModel : INotifyPropertyChanged
    {
        private int intValue = 50;
        public int IntValue
        {
            get { return intValue; }
            set
            {
                intValue = value;
                NotifyPropertyChanged();
            }
        }

        private string stringValue = "Test";
        public string StringValue
        {
            get { return stringValue; }
            set
            {
                stringValue = value;
                NotifyPropertyChanged();
            }
        }

        private Visibility visibilityValue;
        public Visibility VisibilityValue
        {
            get { return visibilityValue; }
            set
            {
                visibilityValue = value;
                NotifyPropertyChanged();
            }
        }

        private Brush brushValue = Brushes.Yellow;
        public Brush BrushValue
        {
            get { return brushValue; }
            set
            {
                brushValue = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
