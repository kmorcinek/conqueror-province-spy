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
        public MainWindow()
        {
            InitializeComponent();
            var vm = new CapitalViewModel();
            vm.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Burg" } });
            vm.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Walachia" } });
            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            return;
//            new ProvinceWindow().Show();

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

            // TOOD ICollectionView for province list


        }
    }
}
