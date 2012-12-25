using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProvinceSpy.WpfGui.Annotations;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class CapitalViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}