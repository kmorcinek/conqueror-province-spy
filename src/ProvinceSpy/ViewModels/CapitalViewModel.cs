using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProvinceSpy.ViewModels
{
    public class CapitalViewModel : ViewModelBase
    {
        // TODO not a INPC
        public IEnumerable<string> Countries { get; private set; }
        public ObservableCollection<MyTemporaryObject> DatabaseObjects { get; set; }

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