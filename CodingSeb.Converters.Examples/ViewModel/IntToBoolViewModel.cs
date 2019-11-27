using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodingSeb.Converters.Examples
{
    public class IntToBoolViewModel : INotifyPropertyChanged
    {
        private int iValue;
        public int Value
        {
            get { return iValue; }
            set
            {
                iValue = value;
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
