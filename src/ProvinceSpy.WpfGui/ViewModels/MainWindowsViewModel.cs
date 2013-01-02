using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class MainWindowsViewModel : ViewModelBase
    {
        private readonly List<ProvinceHistory> provinceHistories = new List<ProvinceHistory>();

        public IEnumerable<string> Countries { get; private set; }

        private string selectedCapital;
        public string SelectedCapital
        {
            get { return selectedCapital; }
            set { SetField(ref this.selectedCapital, value, () => SelectedCapital); }
        }

        public ObservableCollection<ProvinceViewModel> DatabaseObjects { get; set; }

        private int turn = 1;
        public int Turn
        {
            get { return this.turn; }
            set
            {
                SetField(ref this.turn, value, () => this.Turn);
                OnPropertyChanged(() => Season);
            }
        }

        private static readonly Dictionary<int, string> SeasonsByTurn
            = new Dictionary<int, string> { { 0, "Winter" }, { 1, "Spring" }, { 2, "Summer" }, { 3, "Autumn" } };

        public string Season
        {
            get { return SeasonsByTurn[Turn % 4]; }
        }

        RelayCommand nextTurnCommand;
        public ICommand NextTurnCommand
        {
            get
            {
                if (nextTurnCommand == null)
                {
                    nextTurnCommand = new RelayCommand(param => this.OnNextTurn(),
                        param => true);
                }
                return nextTurnCommand;
            }
        }

        RelayCommand changeCapitalCommand;
        public ICommand ChangeCapitalCommand
        {
            get
            {
                if (changeCapitalCommand == null)
                {
                    changeCapitalCommand = new RelayCommand(param => this.OnChangeCapital(),
                        param => true);
                }
                return changeCapitalCommand;
            }
        }

        public MainWindowsViewModel()
        {
            DatabaseObjects = new ObservableCollection<ProvinceViewModel>();

            Countries = new NeighbourProvider().GetCapitals();
            SelectedCapital = Countries.FirstOrDefault();

            OnChangeCapital();
        }

        private void OnChangeCapital()
        {
            Turn = 1;

            DatabaseObjects.Clear();

            provinceHistories.Clear();

            if (SelectedCapital != null)
            {
                var predictor = new Predictor();
                foreach (var neighbour in new NeighbourProvider().GetNeighbours(SelectedCapital))
                {
                    var provinceHistory = new ProvinceHistory(neighbour);
                    provinceHistories.Add(provinceHistory);
                    // TODO should be from model not from this loop
                    var firstPrediction = predictor.Predict(provinceHistory).First();

                    var provinceViewModel = new ProvinceViewModel
                    {
                        ProvinceName = neighbour,
                        FarmsViewModel = new FarmsViewModel { FarmsCount = 1 },
                        SoldiersViewModel = new FarmsViewModel { FarmsCount = 1 },
                        CultureViewModel = new CultureViewModel(),
                        BuildPrediction = new BuildPredictionViewModel
                        {
                            Building = firstPrediction.Building,
                            TurnsLeft = firstPrediction.TurnsLeft
                        },
                    };
                    provinceViewModel.ProvinceRemoved += provinceViewModel_OnProvinceRemoved;

                    DatabaseObjects.Add(provinceViewModel);
                }
            }
        }

        private void provinceViewModel_OnProvinceRemoved(ProvinceViewModel removedProvince)
        {
            for (int i = 0; i < DatabaseObjects.Count; i++)
            {
                if (DatabaseObjects[i] == removedProvince)
                {
                    DatabaseObjects.RemoveAt(i);
                }
            }
        }

        private void OnNextTurn()
        {
            Turn++;

            foreach (var provinceViewModel in this.DatabaseObjects)
            {
                var provinceHistory = provinceHistories.Single(p => p.ProvinceName == provinceViewModel.ProvinceName);

                provinceHistory.Add(
                    new ProvinceRevision(
                        provinceViewModel.FarmsViewModel.FarmsCount,
                        0,
                        provinceViewModel.SoldiersViewModel.FarmsCount,
                        provinceViewModel.CultureViewModel.CultureLevel));

                var predictor = new Predictor();
                var buildPredictions = predictor.Predict(provinceHistory);

                var firstPrediction = buildPredictions.First();
                provinceViewModel.BuildPrediction.Building = firstPrediction.Building;
                provinceViewModel.BuildPrediction.TurnsLeft = firstPrediction.TurnsLeft;
            }
        }
    }
}