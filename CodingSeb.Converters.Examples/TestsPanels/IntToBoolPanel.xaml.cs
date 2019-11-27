using System.Windows.Controls;
using System.Windows.Input;

namespace CodingSeb.Converters.Examples
{
    /// <summary>
    /// Logique d'interaction pour IntToBoolPanel.xaml
    /// </summary>
    public partial class IntToBoolPanel : UserControl
    {
        public IntToBoolPanel()
        {
            InitializeComponent();
        }

        private void txtNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Down)
                {
                    txtNumber.Text = (int.Parse(txtNumber.Text) - 1).ToString();
                    e.Handled = true;
                }
                if (e.Key == Key.Up)
                {
                    txtNumber.Text = (int.Parse(txtNumber.Text) + 1).ToString();
                    e.Handled = true;
                }
            }
            catch { }
        }
    }
}
