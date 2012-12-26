using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.WpfGui.ViewModels;
using System.Linq;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CapitalViewModel viewModel = new CapitalViewModel();
        private readonly List<ProvinceHistory> history = new List<ProvinceHistory>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var capital = cmbCapital.SelectedValue;
            if (capital != null)
            {
                foreach (var neighbour in new NeighbourProvider().GetNeighbours(capital.ToString()))
                {
                    history.Add(new ProvinceHistory(neighbour));
                    // TODO should be from model not from this loop
                    viewModel.DatabaseObjects.Add(new MyTemporaryObject { ProvinceViewModel = new ProvinceViewModel { ProvinceName = neighbour } });
                }

                (sender as Button).Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (var provinceViewModel in this.viewModel.DatabaseObjects.Select(p => p.ProvinceViewModel))
            {
                var provinceHistory = history.Single(p => p.ProvinceName == provinceViewModel.ProvinceName);
                
                provinceHistory.Add(new ProvinceRevision(provinceViewModel.FarmsViewModel.FarmsCount));
                
                var predictor = new Predictor();
                var buildPredictions = predictor.Predict(provinceHistory);
                
                provinceViewModel.BuildPrediction = buildPredictions.FirstOrDefault();
            }
        }
    }
}
