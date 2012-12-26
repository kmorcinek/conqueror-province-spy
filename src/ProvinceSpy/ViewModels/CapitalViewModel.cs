using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProvinceSpy.ViewModels
{
    public class CapitalViewModel : ViewModelBase
    {
        // TODO not a INPC
        public List<string> Countries { get; private set; }
        public ObservableCollection<MyTemporaryObject> DatabaseObjects { get; set; }

        public CapitalViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyTemporaryObject>();
        
            // TODO is it needed
            Countries = new List<string>();
            Countries.AddRange(new []
                {
                    "Grenada",
                    "Ulster",
                });
        }
    }

    public class MyTemporaryObject
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }
    }
}