using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.ViewModels;
using System.Linq;

namespace ProvinceSpy.WpfGui
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowsViewModel viewModel = new MainWindowsViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
