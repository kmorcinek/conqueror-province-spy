using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.ViewModels;
using System.Linq;

namespace ProvinceSpy.WpfGui
{
    public partial class MainWindow : Window
    {
        private readonly CapitalViewModel viewModel = new CapitalViewModel();
        private readonly List<ProvinceHistory> provinceHistories = new List<ProvinceHistory>();

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
                var predictor = new Predictor();
                foreach (var neighbour in new NeighbourProvider().GetNeighbours(capital.ToString()))
                {
                    var provinceHistory = new ProvinceHistory(neighbour);
                    provinceHistories.Add(provinceHistory);
                    // TODO should be from model not from this loop
                    viewModel.DatabaseObjects.Add(new MyTemporaryObject
                    {
                        ProvinceViewModel = new ProvinceViewModel
                            {
                                ProvinceName = neighbour,
                                FarmsViewModel = new FarmsViewModel { FarmsCount = 3 },
                                BuildPrediction = null,
                            }
                    });
                }
                var button = sender as Button;

                if (button != null)
                {
                    button.Visibility = Visibility.Hidden;
                }
            }
        }

        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            foreach (var provinceViewModel in this.viewModel.DatabaseObjects.Select(p => p.ProvinceViewModel))
            {
                var provinceHistory = provinceHistories.Single(p => p.ProvinceName == provinceViewModel.ProvinceName);

                provinceHistory.Add(new ProvinceRevision(provinceViewModel.FarmsViewModel.FarmsCount));

                var predictor = new Predictor();
                var buildPredictions = predictor.Predict(provinceHistory);

                provinceViewModel.BuildPrediction = buildPredictions.FirstOrDefault();
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Button_Click_1(this, RoutedEventArgs.Empty as RoutedEventArgs);
        }
    }
}
