using System;
using ProvinceSpy.WpfGui.ViewModels;

namespace ProvinceSpy.WpfGui
{
    public class EventBasedViewModel : ViewModelBase
    {
        public event Action ModelUpdated = delegate { };
        public void OnModelUpdated()
        {
            ModelUpdated();
        }

        public event Func<bool> WasUpdated = () => false;
        public bool OnWasUpdated()
        {
            return WasUpdated();
        }
    }
}