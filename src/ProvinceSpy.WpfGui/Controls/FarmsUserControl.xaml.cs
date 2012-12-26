using System.Windows.Controls;
using ProvinceSpy.ViewModels;

namespace ProvinceSpy.WpfGui.Controls
{
    public partial class FarmsUserControl : UserControl
    {
        public FarmsUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = DataContext as FarmsViewModel;

            if (vm != null)
            {
                vm.FarmsCount++;
            }
        }
    }
}
