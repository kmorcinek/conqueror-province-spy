using System.Collections.Generic;
using ProvinceSpy.WpfGui.Common;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class CapitalViewModel : ViewModelBase
    {
        // TODO not a INPC
        public List<string> Countries { get; private set; }

        public CapitalViewModel()
        {
            // TODO is it needed
            Countries = new List<string>();
            Countries.AddRange(new []
                {
                    "Grenada",
                    "Ulster",
                });
        }
    }
}