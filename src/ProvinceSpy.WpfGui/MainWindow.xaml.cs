using System.Windows;
using ProvinceSpy.WpfGui.Controls;
using ProvinceSpy.WpfGui.ViewModels;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CapitalViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CapitalViewModel();
            viewModel.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Walachia" } });
            DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Burg" } });

            return;

            var names = new[]
                {
                    "Poland",
                    "Holland",
                };

            foreach (var name in names)
            {
                var provinceViewModel = new ProvinceViewModel {ProvinceName = name};

                var province = new ProvinceUserControl {DataContext = provinceViewModel};
            }

            // TODO ICollectionView for province list


        }
    }
}
