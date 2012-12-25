using System.ComponentModel;
using System.Windows.Controls;
using ProvinceSpy.WpfGui.Annotations;
using ProvinceSpy.WpfGui.ViewModels;

namespace ProvinceSpy.WpfGui.Controls
{
    /// <summary>
    /// Interaction logic for FarmsUserControl.xaml
    /// </summary>
    public partial class FarmsUserControl : UserControl
    {
        public FarmsUserControl()
        {
            InitializeComponent();
            var vm = new FarmsViewModel();
            DataContext = vm;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = DataContext as FarmsViewModel;
            vm.FarmsCount++;
        }
    }
}
