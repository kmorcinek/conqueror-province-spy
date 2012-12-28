﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProvinceSpy.ViewModels;
using System.Linq;

namespace ProvinceSpy.WpfGui
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowsViewModel viewModel = new MainWindowsViewModel();
        private readonly List<ProvinceHistory> provinceHistories = new List<ProvinceHistory>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            SetUp();
            var button = sender as Button;

            if (button != null)
            {
                button.Visibility = Visibility.Hidden;
            }
        }

        private void SetUp()
        {
            viewModel.DatabaseObjects.Clear();
            var capital = cmbCapital.SelectedValue;
            if (capital != null)
            {
                var predictor = new Predictor();
                foreach (var neighbour in new NeighbourProvider().GetNeighbours(capital.ToString()))
                {
                    var provinceHistory = new ProvinceHistory(neighbour);
                    provinceHistories.Add(provinceHistory);
                    // TODO should be from model not from this loop
                    var firstPrediction = predictor.Predict(provinceHistory).First();
                    
                    var provinceViewModel = new ProvinceViewModel
                        {
                            ProvinceName = neighbour, 
                            FarmsViewModel = new FarmsViewModel {FarmsCount = 1}, 
                            SoldiersViewModel = new FarmsViewModel{FarmsCount = 1},
                            CultureViewModel = new CultureViewModel(),
                            BuildPrediction = new BuildPredictionViewModel
                                {
                                    Building = firstPrediction.Building, TurnsLeft = firstPrediction.TurnsLeft
                                },
                        };
                    provinceViewModel.ProvinceRemoved += provinceViewModel_OnProvinceRemoved;
            
                    viewModel.DatabaseObjects.Add(new MyTemporaryObject
                        {
                            ProvinceViewModel = provinceViewModel
                        });
                }
            }
        }

        void provinceViewModel_OnProvinceRemoved(ProvinceViewModel removedProvince)
        {
            for (int i = 0; i < viewModel.DatabaseObjects.Count; i++)
            {
                if (viewModel.DatabaseObjects[i].ProvinceViewModel == removedProvince)
                {
                    viewModel.DatabaseObjects.RemoveAt(i);
                }
            }
        }

        private void NextTurnClick(object sender, RoutedEventArgs e)
        {
            viewModel.Turn++;

            foreach (var provinceViewModel in this.viewModel.DatabaseObjects.Select(p => p.ProvinceViewModel))
            {
                var provinceHistory = provinceHistories.Single(p => p.ProvinceName == provinceViewModel.ProvinceName);

                provinceHistory.Add(
                    new ProvinceRevision(
                        provinceViewModel.FarmsViewModel.FarmsCount, 
                        provinceViewModel.SoldiersViewModel.FarmsCount, 
                        provinceViewModel.CultureViewModel.CultureLevel));

                var predictor = new Predictor();
                var buildPredictions = predictor.Predict(provinceHistory);

                var firstPrediction = buildPredictions.First();
                provinceViewModel.BuildPrediction.Building = firstPrediction.Building;
                provinceViewModel.BuildPrediction.TurnsLeft = firstPrediction.TurnsLeft;
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
//            cmbCapital.SelectedIndex = 0;
            SetUp();
        }
    }
}
