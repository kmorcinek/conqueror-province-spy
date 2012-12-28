using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProvinceSpy.ViewModels
{
    public class CapitalViewModel : ViewModelBase
    {
        // TODO not a INPC
        public IEnumerable<string> Countries { get; private set; }
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

        public CapitalViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyTemporaryObject>();

            Countries = new NeighbourProvider().GetCapitals();
        }
    }

    public class MyTemporaryObject
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }
    }
}