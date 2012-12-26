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
using System.Windows.Shapes;
using ProvinceSpy.ViewModels;
using ProvinceSpy.WpfGui.Controls;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for ProvinceWindow.xaml
    /// </summary>
    public partial class ProvinceWindow : Window
    {
        public ProvinceWindow()
        {
            InitializeComponent();
            
//            var province = new ProvinceUserControl();
            var provinceViewModel = new ProvinceViewModel { ProvinceName = "Burg", FarmsViewModel = new FarmsViewModel() };

            provinceUserControl.DataContext = provinceViewModel;
        }
    }
}
