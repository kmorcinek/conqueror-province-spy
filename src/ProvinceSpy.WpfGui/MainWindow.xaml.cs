using System.Windows;

namespace ProvinceSpy.WpfGui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new TurnsNeededWindow();
            window.Show();
        }
    }
}
