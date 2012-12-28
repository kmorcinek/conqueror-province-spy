using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProvinceSpy.ViewModels
{
    public class MainWindowsViewModel : ViewModelBase
    {
        public IEnumerable<string> Countries { get; private set; }

        private string selectedCapital;
        public string SelectedCapital
        {
            get { return selectedCapital; }
            set { SetField(ref this.selectedCapital, value, () => SelectedCapital); }
        }

        public ObservableCollection<MyTemporaryObject> DatabaseObjects { get; set; }

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

        public MainWindowsViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyTemporaryObject>();

            Countries = new NeighbourProvider().GetCapitals();
            SelectedCapital = Countries.FirstOrDefault();
        }
    }

    public class MyTemporaryObject
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }
    }
}