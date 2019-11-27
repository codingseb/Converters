using System.Windows.Controls;
using System.Windows.Data;

namespace CodingSeb.Converters.Examples
{
    /// <summary>
    /// Logique d'interaction pour ExpressionEvalPanel.xaml
    /// </summary>
    public partial class ExpressionEvalPanel : UserControl
    {
        public ExpressionEvalPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BindingOperations.GetBindingExpressionBase(ResultTextBox, TextBox.TextProperty).UpdateTarget();
        }
    }
}
