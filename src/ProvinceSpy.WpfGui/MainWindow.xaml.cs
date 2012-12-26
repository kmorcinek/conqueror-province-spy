using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.WpfGui.ViewModels;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CapitalViewModel viewModel = new CapitalViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var capital = cmbCapital.SelectedValue;
            if (capital != null)
            {
                foreach (var neighbour in new NeighbourProvider().GetNeighbours(capital.ToString()))
                {
                    viewModel.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = neighbour } });
                }

                (sender as Button).Visibility = Visibility.Hidden;
            }
        }
    }
}
