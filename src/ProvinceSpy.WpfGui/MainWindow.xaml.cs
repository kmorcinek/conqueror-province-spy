using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            DataContext = new CapitalViewModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
