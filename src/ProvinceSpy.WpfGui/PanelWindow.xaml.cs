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
            vm.DatabaseObjects.Add(new MyDatabaseObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Burg" }, DbName = "a" });
            vm.DatabaseObjects.Add(new MyDatabaseObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = "Walachia" }, DbName = "b" });
            DataContext = vm;
        }
    }

    public class WindowViewModel
    {
        public ObservableCollection<MyDatabaseObject> DatabaseObjects { get; set; }

        public WindowViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyDatabaseObject>();
        }
    }


    public class MyDatabaseObject : INotifyPropertyChanged
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _dbName;

        public string DbName { get; set; }
//        public string DbName
//        {
//            get { return _dbName; }
//            set
//            {
//                _dbName = value;
//                if (PropertyChanged != null)
//                    PropertyChanged(this, new PropertyChangedEventArgs("DbName"));
//            }
//        }
    }
}
