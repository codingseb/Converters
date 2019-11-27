using System.Windows.Controls;

namespace CodingSeb.Converters.Examples
{
    /// <summary>
    /// Logique d'interaction pour ExclusiveBoolToEnumOrEquatablePanel.xaml
    /// </summary>
    public partial class ExclusiveBoolToEnumOrEquatablePanel : UserControl
    {
        public ExclusiveBoolToEnumOrEquatablePanel()
        {
            InitializeComponent();
            DataContext = new ExclusiveBoolToEnumOrEquatableViewModel();
        }
    }
}
