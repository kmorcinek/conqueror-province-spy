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
            var exampleBuilingsTakingTurns = new ExampleBuilingsTakingTurns();
            exampleBuilingsTakingTurns.AddThem();
            exampleBuilingsTakingTurns.SaveToFile();

            var window = new TurnsNeededWindow();
            window.Show();
        }
    }
}
