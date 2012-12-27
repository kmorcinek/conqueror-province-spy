using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.ViewModels;

namespace ProvinceSpy.WpfGui.Controls
{
    public partial class ProvinceUserControl : UserControl
    {
        public ProvinceUserControl()
        {
            InitializeComponent();
        }

        private void ProvinceUserControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var provinceViewModel = this.DataContext as ProvinceViewModel;
            if (provinceViewModel != null)
            {
                FarmsUserControl.DataContext = provinceViewModel.FarmsViewModel;
                SoldiersUserControl.DataContext = provinceViewModel.SoldiersViewModel;
                BuildPredictionUserControl.DataContext = provinceViewModel.BuildPrediction;
            }
        }
    }
}
