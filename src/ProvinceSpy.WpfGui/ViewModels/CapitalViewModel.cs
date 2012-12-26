using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProvinceSpy.WpfGui.Common;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class CapitalViewModel : ViewModelBase
    {
        // TODO not a INPC
        public List<string> Countries { get; private set; }
        public ObservableCollection<MyTempraryObject> DatabaseObjects { get; set; }

        public CapitalViewModel()
        {
            DatabaseObjects = new ObservableCollection<MyTempraryObject>();
        
            // TODO is it needed
            Countries = new List<string>();
            Countries.AddRange(new []
                {
                    "Grenada",
                    "Ulster",
                });
        }
    }

    public class MyTempraryObject
    {
        public ProvinceViewModel ProvinceViewModel { get; set; }
    }
}