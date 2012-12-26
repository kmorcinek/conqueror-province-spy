using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using ProvinceSpy.WpfGui.ViewModels;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for PanelWindow.xaml
    /// </summary>
    public partial class PanelWindow : Window
    {
        public PanelWindow()
        {
            InitializeComponent();
            var vm = new WindowViewModel();
            vm.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Burg" } });
            vm.DatabaseObjects.Add(new MyTempraryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Walachia" } });
            DataContext = vm;
        }
    }

    public class WindowViewModel
    {
        public ObservableCollection<MyTempraryObject> DatabaseObjects { get; set; }

        public WindowViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyTempraryObject>();
        }
    }


    public class MyTempraryObject
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }
    }
}
